using DAL.Contratos;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using DomainRemito = DOMAIN.Remito;
using BLL.Remito;

namespace BLL
{
    /// <summary>
    /// Servicio de logica de negocio para la gestion de remitos.
    /// Coordina las operaciones entre la capa de presentacion y la capa de acceso a datos.
    /// </summary>
    public class RemitoService
    {
        private readonly IRemitoRepository _remitoRepository;
        private readonly RemitoPdfService _remitoPdfService;

        /// <summary>
        /// Constructor que inicializa el repositorio de remitos y el servicio de PDF.
        /// </summary>
        public RemitoService()
        {
            _remitoRepository = ServiceFactory.RemitoRepository;
            _remitoPdfService = new RemitoPdfService();
        }

        /// <summary>
        /// Constructor que permite inyectar una implementacion especifica del repositorio (para testing).
        /// </summary>
        /// <param name="remitoRepository">El repositorio de remitos.</param>
        public RemitoService(IRemitoRepository remitoRepository)
        {
            _remitoRepository = remitoRepository;
            _remitoPdfService = new RemitoPdfService();
        }

        /// <summary>
        /// Genera un nuevo remito en el sistema.
        /// </summary>
        /// <param name="nombreGenerador">Nombre del generador del residuo.</param>
        /// <param name="domicilioPlanta">Domicilio de la planta donde se genera el residuo.</param>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="cantidad">Cantidad del residuo recolectado.</param>
        /// <param name="estado">Estado fisico del residuo.</param>
        /// <param name="cuit">CUIT del generador del residuo.</param>
        /// <param name="nombreFantasia">Nombre de fantasia de la empresa generadora.</param>
        /// <param name="direccion">Direccion del establecimiento generador.</param>
        /// <returns>El ID del remito generado.</returns>
        public Guid GenerarRemito(
            string nombreGenerador,
            string domicilioPlanta,
            string tipoResiduo,
            decimal cantidad,
            string estado,
            string cuit,
            string nombreFantasia,
            string direccion)
        {
            // Crear el objeto remito con los datos proporcionados
            var remito = new DomainRemito
            {
                NombreGenerador = nombreGenerador,
                DomicilioPlanta = domicilioPlanta,
                TipoResiduo = tipoResiduo,
                Cantidad = cantidad,
                Estado = estado,
                Cuit = cuit,
                NombreFantasia = nombreFantasia,
                Direccion = direccion,
                // Los datos del transportista se establecen por defecto
                NombreTransportista = "Hugo Rocha",
                DomicilioTransportista = "Mendoza 3149 San Andres Prov. de Bs.As."
            };

            // Coordinar los pasos criticos con Unit of Work:
            // Si el inventario falla, el remito se compensa automaticamente.
            using (var uow = new UnitOfWork("GenerarRemito"))
            {
                // PASO 1: Validar y crear el remito en la base de datos
                CrearRemito(remito);
                uow.RegistrarCompensacion("EliminarRemito",
                    () => _remitoRepository.Remove(remito.IdRemito));

                // PASO 2: Registrar entrada automatica en inventario
                var inventarioService = new InventarioService();
                inventarioService.RegistrarEntradaDesdeRemito(
                    tipoResiduo,
                    estado,
                    cantidad,
                    remito.IdRemito,
                    $"Generador: {nombreGenerador}");
                uow.RegistrarCompensacion("RevertirInventario",
                    () => inventarioService.RevertirEntradaDesdeRemito(
                        tipoResiduo, estado, cantidad, remito.IdRemito));

                // Si llegamos aca, los pasos criticos fueron exitosos
                uow.Complete();
            }

            // PASO 3: Generar PDF del remito (fuera del UnitOfWork, no es critico)
            // Si falla, el remito y el inventario ya estan confirmados.
            try
            {
                _remitoPdfService.GenerarPdfRemito(remito.IdRemito);

                LoggerService.WriteLog(
                    $"PDF generado exitosamente para remito {remito.IdRemito}",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"ADVERTENCIA: Remito {remito.IdRemito} creado pero error al generar PDF. {ex.Message}",
                    System.Diagnostics.TraceLevel.Warning);
                LoggerService.WriteException(ex);
            }

            return remito.IdRemito;
        }

        /// <summary>
        /// Crea un nuevo remito en el sistema.
        /// Valida los datos antes de persistirlos en la base de datos.
        /// </summary>
        /// <param name="remito">El remito a crear.</param>
        public void CrearRemito(DomainRemito remito)
        {
            // Validaciones de negocio
            ValidarRemito(remito);

            // Establecer valores por defecto si no estan definidos
            if (string.IsNullOrWhiteSpace(remito.NombreTransportista))
            {
                remito.NombreTransportista = "Hugo Rocha";
            }

            if (string.IsNullOrWhiteSpace(remito.DomicilioTransportista))
            {
                remito.DomicilioTransportista = "Mendoza 3149 San Andres Prov. de Bs.As.";
            }

            // Asegurar que la fecha de creacion este establecida
            if (remito.FechaCreacion == DateTime.MinValue)
            {
                remito.FechaCreacion = DateTime.Now;
            }

            // Asegurar que el estado del remito este establecido
            if (string.IsNullOrWhiteSpace(remito.EstadoRemito))
            {
                remito.EstadoRemito = "Activo";
            }

            // **CALCULAR DIGITO VERIFICADOR**
            try
            {
                remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);

                LoggerService.WriteLog(
                    $"Digito Verificador calculado para remito {remito.IdRemito}: {remito.DigitoVerificador}",
                    System.Diagnostics.TraceLevel.Verbose);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"Error al calcular Digito Verificador para remito {remito.IdRemito}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Warning);
                LoggerService.WriteException(ex);
                // Continuar sin DV en caso de error
                remito.DigitoVerificador = null;
            }

            // Crear el remito en la base de datos
            _remitoRepository.CreateRemito(remito);
        }

        /// <summary>
        /// Obtiene un remito por su identificador unico.
        /// </summary>
        /// <param name="idRemito">El ID del remito.</param>
        /// <returns>El remito correspondiente, si existe.</returns>
        public DomainRemito ObtenerRemitoPorId(Guid idRemito)
        {
            return _remitoRepository.GetRemitoById(idRemito);
        }

        /// <summary>
        /// Obtiene todos los remitos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de todos los remitos.</returns>
        public List<DomainRemito> ObtenerTodosLosRemitos()
        {
            return _remitoRepository.GetAllRemitos();
        }

        /// <summary>
        /// Obtiene los remitos filtrados por CUIT del generador.
        /// </summary>
        /// <param name="cuit">El CUIT del generador.</param>
        /// <returns>Una lista de remitos asociados al CUIT especificado.</returns>
        public List<DomainRemito> ObtenerRemitosPorCuit(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
            {
                throw new ArgumentException("El CUIT no puede estar vacio.", nameof(cuit));
            }

            return _remitoRepository.GetRemitosByCuit(cuit);
        }

        /// <summary>
        /// Obtiene los remitos creados en un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una lista de remitos dentro del rango de fechas.</returns>
        public List<DomainRemito> ObtenerRemitosPorFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha de fin.");
            }

            return _remitoRepository.GetRemitosByFechaRango(fechaInicio, fechaFin);
        }

        /// <summary>
        /// Anula un remito existente.
        /// </summary>
        /// <param name="idRemito">El ID del remito a anular.</param>
        public void AnularRemito(Guid idRemito)
        {
            // Verificar que el remito existe
            var remito = _remitoRepository.GetRemitoById(idRemito);
            if (remito == null)
            {
                throw new Exception("El remito no existe.");
            }

            // Verificar que el remito no este ya anulado
            if (remito.EstadoRemito == "Anulado")
            {
                throw new Exception("El remito ya se encuentra anulado.");
            }

            // Cambiar estado a Anulado
            remito.EstadoRemito = "Anulado";

            // **RECALCULAR DIGITO VERIFICADOR**
            try
            {
                remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);

                LoggerService.WriteLog(
                    $"Digito Verificador recalculado al anular remito {remito.IdRemito}: {remito.DigitoVerificador}",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"Error al recalcular Digito Verificador al anular remito {remito.IdRemito}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Warning);
                LoggerService.WriteException(ex);
            }

            // Actualizar el remito con el nuevo estado y DV
            _remitoRepository.Update(remito);
        }

        /// <summary>
        /// Actualiza un remito existente.
        /// </summary>
        /// <param name="remito">El remito con los datos actualizados.</param>
        public void ActualizarRemito(DomainRemito remito)
        {
            // Validar el remito
            ValidarRemito(remito);

            // Verificar que el remito existe
            var remitoExistente = _remitoRepository.GetRemitoById(remito.IdRemito);
            if (remitoExistente == null)
            {
                throw new Exception("El remito no existe.");
            }

            // **RECALCULAR DIGITO VERIFICADOR**
            try
            {
                remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);

                LoggerService.WriteLog(
                    $"Digito Verificador recalculado al actualizar remito {remito.IdRemito}: {remito.DigitoVerificador}",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"Error al recalcular Digito Verificador al actualizar remito {remito.IdRemito}: {ex.Message}",
                    System.Diagnostics.TraceLevel.Warning);
                LoggerService.WriteException(ex);
            }

            _remitoRepository.Update(remito);
        }

        /// <summary>
        /// Valida los datos de un remito antes de persistirlo.
        /// </summary>
        /// <param name="remito">El remito a validar.</param>
        private void ValidarRemito(DomainRemito remito)
        {
            if (remito == null)
            {
                throw new ArgumentNullException(nameof(remito), "El remito no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(remito.NombreGenerador))
            {
                throw new ArgumentException("El nombre del generador es obligatorio.", nameof(remito.NombreGenerador));
            }

            if (string.IsNullOrWhiteSpace(remito.DomicilioPlanta))
            {
                throw new ArgumentException("El domicilio de la planta es obligatorio.", nameof(remito.DomicilioPlanta));
            }

            if (string.IsNullOrWhiteSpace(remito.TipoResiduo))
            {
                throw new ArgumentException("El tipo de residuo es obligatorio.", nameof(remito.TipoResiduo));
            }

            if (remito.Cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(remito.Cantidad));
            }

            if (string.IsNullOrWhiteSpace(remito.Estado))
            {
                throw new ArgumentException("El estado es obligatorio.", nameof(remito.Estado));
            }

            if (string.IsNullOrWhiteSpace(remito.Cuit))
            {
                throw new ArgumentException("El CUIT es obligatorio.", nameof(remito.Cuit));
            }

            if (string.IsNullOrWhiteSpace(remito.NombreFantasia))
            {
                throw new ArgumentException("El nombre de fantasia es obligatorio.", nameof(remito.NombreFantasia));
            }

            if (string.IsNullOrWhiteSpace(remito.Direccion))
            {
                throw new ArgumentException("La direccion es obligatoria.", nameof(remito.Direccion));
            }
        }

        /// <summary>
        /// Recalcula el Digito Verificador para todos los remitos que no lo tienen.
        /// Metodo de backfill para actualizar remitos creados antes de la implementacion del DV.
        /// </summary>
        /// <returns>Numero de remitos actualizados.</returns>
        public int RecalcularDVRemitosSinDV()
        {
            int contadorActualizados = 0;

            try
            {
                LoggerService.WriteLog(
                    "Iniciando proceso de backfill de Digitos Verificadores...",
                    System.Diagnostics.TraceLevel.Info);

                // Obtener todos los remitos
                var remitos = _remitoRepository.GetAllRemitos();

                foreach (var remito in remitos)
                {
                    // Solo procesar remitos sin DV
                    if (string.IsNullOrWhiteSpace(remito.DigitoVerificador))
                    {
                        try
                        {
                            // Calcular DV
                            remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);

                            // Actualizar en DB
                            _remitoRepository.Update(remito);

                            contadorActualizados++;

                            LoggerService.WriteLog(
                                $"DV calculado para remito {remito.IdRemito}: {remito.DigitoVerificador}",
                                System.Diagnostics.TraceLevel.Verbose);
                        }
                        catch (Exception ex)
                        {
                            LoggerService.WriteLog(
                                $"Error al calcular DV para remito {remito.IdRemito}: {ex.Message}",
                                System.Diagnostics.TraceLevel.Warning);
                            LoggerService.WriteException(ex);
                        }
                    }
                }

                LoggerService.WriteLog(
                    $"Proceso de backfill completado. {contadorActualizados} remitos actualizados de {remitos.Count} totales.",
                    System.Diagnostics.TraceLevel.Info);

                return contadorActualizados;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"Error en proceso de backfill de DV: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }
    }
}
