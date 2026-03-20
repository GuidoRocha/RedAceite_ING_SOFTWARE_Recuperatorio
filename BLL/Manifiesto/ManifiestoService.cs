using DAL.Contratos;
using DOMAIN;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Manifiesto
{
    /// <summary>
    /// Servicio de logica de negocio para la gestion de manifiestos diarios.
    /// Coordina la generacion automatica, consultas y anulacion de manifiestos.
    /// </summary>
    public class ManifiestoService
    {
        private readonly IManifiestoRepository _manifiestoRepository;
        private readonly IRemitoRepository _remitoRepository;

        // Datos fijos del transportista
        private const string TRANSPORTISTA_NOMBRE = "Hugo Rocha";
        private const string TRANSPORTISTA_DOMICILIO = "Mendoza 3149 San Andres Prov. de Bs.As.";

        /// <summary>
        /// Constructor que inicializa los repositorios desde ServiceFactory.
        /// </summary>
        public ManifiestoService()
        {
            _manifiestoRepository = ServiceFactory.ManifiestoRepository;
            _remitoRepository = ServiceFactory.RemitoRepository;
        }

        #region Generacion de Manifiesto

        /// <summary>
        /// Genera el manifiesto diario para una fecha dada.
        /// Agrupa todos los remitos activos del dia, calcula precios y subtotales.
        /// Usa UnitOfWork para garantizar atomicidad.
        /// </summary>
        /// <param name="fecha">Fecha para la cual generar el manifiesto.</param>
        /// <returns>El manifiesto generado.</returns>
        public DOMAIN.Manifiesto GenerarManifiestoDiario(DateTime fecha)
        {
            LoggerService.WriteLog(
                $"[ManifiestoService] Iniciando generacion de manifiesto para {fecha:dd/MM/yyyy}",
                System.Diagnostics.TraceLevel.Info);

            try
            {
                // 1. Obtener los remitos activos del dia
                DateTime inicioDelDia = fecha.Date;
                DateTime finDelDia = fecha.Date.AddDays(1).AddSeconds(-1);

                var remitosDelDia = _remitoRepository.GetRemitosByFechaRango(inicioDelDia, finDelDia);

                // Filtrar solo los activos (no anulados)
                remitosDelDia = remitosDelDia.Where(r => r.EstadoRemito != "Anulado").ToList();

                if (remitosDelDia.Count == 0)
                {
                    LoggerService.WriteLog(
                        $"[ManifiestoService] No hay remitos activos para {fecha:dd/MM/yyyy}. No se genera manifiesto.",
                        System.Diagnostics.TraceLevel.Info);
                    throw new Exception($"No hay remitos activos para la fecha {fecha:dd/MM/yyyy}. No se puede generar el manifiesto.");
                }

                LoggerService.WriteLog(
                    $"[ManifiestoService] Se encontraron {remitosDelDia.Count} remitos activos para {fecha:dd/MM/yyyy}",
                    System.Diagnostics.TraceLevel.Info);

                // 2. Obtener precios vigentes
                var precioAceite = _manifiestoRepository.GetPrecioActivoPorTipo("Aceite");
                var precioGrasa = _manifiestoRepository.GetPrecioActivoPorTipo("Grasa");

                if (precioAceite == null)
                {
                    throw new Exception("No hay precio activo configurado para Aceite. Configure los precios antes de generar el manifiesto.");
                }
                if (precioGrasa == null)
                {
                    throw new Exception("No hay precio activo configurado para Grasa. Configure los precios antes de generar el manifiesto.");
                }

                LoggerService.WriteLog(
                    $"[ManifiestoService] Precios vigentes - Aceite: ${precioAceite.PrecioUnitario:N2} | Grasa: ${precioGrasa.PrecioUnitario:N2}",
                    System.Diagnostics.TraceLevel.Info);

                // 3. Generar numero de manifiesto
                string numeroManifiesto = GenerarNumeroManifiesto(fecha);

                // 4. Crear el manifiesto con UnitOfWork
                var manifiesto = new DOMAIN.Manifiesto(fecha)
                {
                    NumeroManifiesto = numeroManifiesto,
                    NombreTransportista = TRANSPORTISTA_NOMBRE,
                    DomicilioTransportista = TRANSPORTISTA_DOMICILIO,
                    CantidadTotalRemitos = remitosDelDia.Count
                };

                using (var uow = new UnitOfWork("GenerarManifiestoDiario"))
                {
                    // PASO 1: Crear manifiesto en BD
                    // Primero con monto 0, luego actualizar con el total
                    _manifiestoRepository.CrearManifiesto(manifiesto);
                    uow.RegistrarCompensacion("EliminarManifiesto",
                        () =>
                        {
                            _manifiestoRepository.EliminarDetallesByManifiesto(manifiesto.IdManifiesto);
                            _manifiestoRepository.AnularManifiesto(manifiesto.IdManifiesto);
                        });

                    // PASO 2: Crear detalles para cada remito
                    decimal montoTotal = 0;
                    int orden = 1;

                    foreach (var remito in remitosDelDia)
                    {
                        decimal precioUnitario = remito.TipoResiduo == "Aceite"
                            ? precioAceite.PrecioUnitario
                            : precioGrasa.PrecioUnitario;

                        var detalle = new ManifiestoDetalle
                        {
                            IdManifiesto = manifiesto.IdManifiesto,
                            IdRemito = remito.IdRemito,
                            NombreGenerador = remito.NombreGenerador,
                            TipoResiduo = remito.TipoResiduo,
                            Cantidad = remito.Cantidad,
                            PrecioUnitario = precioUnitario,
                            Orden = orden
                        };

                        // Calcular subtotal en el objeto (para log/referencia)
                        detalle.CalcularSubtotal();
                        montoTotal += detalle.Subtotal;

                        _manifiestoRepository.CrearDetalle(detalle);

                        LoggerService.WriteLog(
                            $"[ManifiestoService] Detalle #{orden}: {remito.NombreGenerador} - {remito.TipoResiduo} x{remito.Cantidad} @ ${precioUnitario:N2} = ${detalle.Subtotal:N2}",
                            System.Diagnostics.TraceLevel.Verbose);

                        orden++;
                    }

                    // PASO 3: Actualizar el monto total y calcular DV
                    manifiesto.MontoTotal = montoTotal;

                    try
                    {
                        manifiesto.DigitoVerificador = ManifiestoDigitoVerificadorService.Calcular(manifiesto);
                        LoggerService.WriteLog(
                            $"[ManifiestoService] DV calculado: {manifiesto.DigitoVerificador}",
                            System.Diagnostics.TraceLevel.Verbose);
                    }
                    catch (Exception ex)
                    {
                        LoggerService.WriteLog(
                            $"[ManifiestoService] Error al calcular DV: {ex.Message}",
                            System.Diagnostics.TraceLevel.Warning);
                        manifiesto.DigitoVerificador = null;
                    }

                    _manifiestoRepository.UpdateManifiesto(manifiesto);

                    // Todo OK
                    uow.Complete();
                }

                LoggerService.WriteLog(
                    $"[ManifiestoService] Manifiesto {numeroManifiesto} generado exitosamente. " +
                    $"Remitos: {remitosDelDia.Count} | Monto total: ${manifiesto.MontoTotal:N2}",
                    System.Diagnostics.TraceLevel.Info);

                return manifiesto;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoService] Error al generar manifiesto para {fecha:dd/MM/yyyy}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        #endregion

        #region Consultas

        /// <summary>
        /// Obtiene todos los manifiestos para la pantalla de gestion, con verificacion de integridad.
        /// </summary>
        /// <returns>Lista de DTOs para el grid.</returns>
        public List<ManifiestoGestionDto> ObtenerManifiestosParaGestion()
        {
            try
            {
                var manifiestos = _manifiestoRepository.GetManifiestosParaGestion();
                VerificarIntegridadManifiestos(manifiestos);
                return manifiestos;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoService] Error al obtener manifiestos para gestion: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene manifiestos filtrados para la pantalla de gestion.
        /// </summary>
        public List<ManifiestoGestionDto> ObtenerManifiestosFiltrados(
            DateTime? fechaInicio, DateTime? fechaFin, string estado)
        {
            try
            {
                var manifiestos = _manifiestoRepository.GetManifiestosFiltradosParaGestion(
                    fechaInicio, fechaFin, estado);
                VerificarIntegridadManifiestos(manifiestos);
                return manifiestos;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoService] Error al obtener manifiestos filtrados: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un manifiesto por su ID.
        /// </summary>
        public DOMAIN.Manifiesto ObtenerManifiestoPorId(Guid idManifiesto)
        {
            return _manifiestoRepository.GetManifiestoById(idManifiesto);
        }

        /// <summary>
        /// Obtiene los detalles (lineas) de un manifiesto.
        /// </summary>
        public List<ManifiestoDetalle> ObtenerDetallesManifiesto(Guid idManifiesto)
        {
            return _manifiestoRepository.GetDetallesByManifiesto(idManifiesto);
        }

        /// <summary>
        /// Verifica si ya existe un manifiesto para una fecha dada.
        /// </summary>
        public bool ExisteManifiestoParaFecha(DateTime fecha)
        {
            return _manifiestoRepository.ExisteManifiestoParaFecha(fecha);
        }

        #endregion

        #region Precios

        /// <summary>
        /// Obtiene todos los precios activos configurados.
        /// </summary>
        public List<PrecioResiduo> ObtenerPreciosActivos()
        {
            return _manifiestoRepository.GetPreciosActivos();
        }

        /// <summary>
        /// Obtiene todos los precios (historial completo).
        /// </summary>
        public List<PrecioResiduo> ObtenerTodosLosPrecios()
        {
            return _manifiestoRepository.GetAllPrecios();
        }

        /// <summary>
        /// Obtiene el precio activo para un tipo de residuo.
        /// </summary>
        public PrecioResiduo ObtenerPrecioActivoPorTipo(string tipoResiduo)
        {
            return _manifiestoRepository.GetPrecioActivoPorTipo(tipoResiduo);
        }

        /// <summary>
        /// Actualiza el precio de un tipo de residuo.
        /// Desactiva el precio anterior y crea uno nuevo con la fecha de vigencia actual.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite / Grasa).</param>
        /// <param name="nuevoPrecio">Nuevo precio unitario.</param>
        public void ActualizarPrecio(string tipoResiduo, decimal nuevoPrecio)
        {
            if (nuevoPrecio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }

            if (string.IsNullOrWhiteSpace(tipoResiduo))
            {
                throw new ArgumentException("El tipo de residuo es obligatorio.");
            }

            try
            {
                // Desactivar el precio actual
                _manifiestoRepository.DesactivarPrecioActual(tipoResiduo);

                // Crear nuevo precio activo
                var precio = new PrecioResiduo(tipoResiduo, nuevoPrecio);
                _manifiestoRepository.CrearPrecio(precio);

                LoggerService.WriteLog(
                    $"[ManifiestoService] Precio actualizado para {tipoResiduo}: ${nuevoPrecio:N2}",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoService] Error al actualizar precio de {tipoResiduo}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        #endregion

        #region Anulacion

        /// <summary>
        /// Anula un manifiesto existente (soft delete).
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto a anular.</param>
        public void AnularManifiesto(Guid idManifiesto)
        {
            try
            {
                var manifiesto = _manifiestoRepository.GetManifiestoById(idManifiesto);

                if (manifiesto == null)
                {
                    throw new Exception("El manifiesto no existe.");
                }

                if (manifiesto.EstaAnulado)
                {
                    throw new Exception("El manifiesto ya se encuentra anulado.");
                }

                manifiesto.Estado = "Anulado";

                // Recalcular DV con el nuevo estado
                try
                {
                    manifiesto.DigitoVerificador = ManifiestoDigitoVerificadorService.Calcular(manifiesto);
                }
                catch (Exception ex)
                {
                    LoggerService.WriteLog(
                        $"[ManifiestoService] Error al recalcular DV al anular: {ex.Message}",
                        System.Diagnostics.TraceLevel.Warning);
                }

                _manifiestoRepository.UpdateManifiesto(manifiesto);

                LoggerService.WriteLog(
                    $"[ManifiestoService] Manifiesto {manifiesto.NumeroManifiesto} anulado exitosamente.",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoService] Error al anular manifiesto {idManifiesto}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        #endregion

        #region Notificacion (placeholder para WhatsApp/Email futuro)

        // TODO: Implementar envio de manifiesto por WhatsApp/Email
        // Interfaz sugerida: IManifiestoNotificador con metodo EnviarManifiesto(Manifiesto, List<ManifiestoDetalle>)
        // Implementaciones futuras: WhatsAppNotificador, EmailNotificador

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Genera el numero de manifiesto con formato MAN-YYYYMMDD-NNN.
        /// Si ya existe uno para esa fecha, incrementa el contador.
        /// </summary>
        private string GenerarNumeroManifiesto(DateTime fecha)
        {
            string fechaStr = fecha.ToString("yyyyMMdd");

            // Buscar manifiestos existentes para esa fecha (incluyendo anulados)
            var existentes = _manifiestoRepository.GetManifiestosByFechaRango(fecha.Date, fecha.Date);

            int secuencia = existentes.Count + 1;

            return $"MAN-{fechaStr}-{secuencia:D3}";
        }

        /// <summary>
        /// Verifica la integridad de una lista de manifiestos comparando sus DV.
        /// </summary>
        private void VerificarIntegridadManifiestos(List<ManifiestoGestionDto> manifiestos)
        {
            foreach (var dto in manifiestos)
            {
                if (string.IsNullOrWhiteSpace(dto.DigitoVerificador))
                {
                    dto.IntegridadEstado = "SIN_DV";
                    dto.IntegridadValida = false;
                    continue;
                }

                try
                {
                    // Reconstruir un Manifiesto temporal para verificar
                    var manifiestoTemp = new DOMAIN.Manifiesto
                    {
                        IdManifiesto = dto.IdManifiesto,
                        NumeroManifiesto = dto.NumeroManifiesto,
                        FechaManifiesto = dto.FechaManifiesto,
                        NombreTransportista = dto.NombreTransportista,
                        DomicilioTransportista = TRANSPORTISTA_DOMICILIO,
                        CantidadTotalRemitos = dto.CantidadTotalRemitos,
                        MontoTotal = dto.MontoTotal,
                        Estado = dto.Estado,
                        DigitoVerificador = dto.DigitoVerificador
                    };

                    bool integro = ManifiestoDigitoVerificadorService.Verificar(manifiestoTemp);

                    dto.IntegridadEstado = integro ? "OK" : "ALTERADO";
                    dto.IntegridadValida = integro;
                }
                catch (Exception ex)
                {
                    LoggerService.WriteLog(
                        $"[ManifiestoService] Error al verificar integridad de manifiesto {dto.IdManifiesto}: {ex.Message}",
                        System.Diagnostics.TraceLevel.Warning);
                    dto.IntegridadEstado = "ERROR";
                    dto.IntegridadValida = false;
                }
            }
        }

        #endregion
    }
}
