using DAL.Contratos;
using DOMAIN;
using SERVICES.Facade;
using SERVICES.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BLL.Remito
{
    /// <summary>
    /// Servicio de logica de negocio para la gestion de remitos.
    /// Coordina las operaciones de consulta, filtrado y descarga de PDFs de remitos.
    /// </summary>
    public class RemitoGestionService
    {
        private readonly IRemitoRepository _remitoRepository;
        private readonly IRemitoPdfRepository _remitoPdfRepository;
        private readonly string _rutaPdfRemitos;

        /// <summary>
        /// Constructor que inicializa los repositorios y configuracion.
        /// </summary>
        public RemitoGestionService()
        {
            _remitoRepository = ServiceFactory.RemitoRepository;
            _remitoPdfRepository = ServiceFactory.RemitoPdfRepository;
            _rutaPdfRemitos = ConfigHelper.ObtenerRutaPdfRemitos();
        }

        /// <summary>
        /// Constructor con inyeccion de dependencias (para testing).
        /// </summary>
        public RemitoGestionService(IRemitoRepository remitoRepository, IRemitoPdfRepository remitoPdfRepository)
        {
            _remitoRepository = remitoRepository;
            _remitoPdfRepository = remitoPdfRepository;
            _rutaPdfRemitos = ConfigHelper.ObtenerRutaPdfRemitos();
        }

        /// <summary>
        /// Obtiene todos los remitos con su informacion de PDF asociada.
        /// </summary>
        /// <returns>Lista de DTOs con informacion completa de remitos y PDFs.</returns>
        public List<RemitoGestionDto> ObtenerRemitosParaGestion()
        {
            try
            {
                var remitos = _remitoRepository.GetRemitosConPdf();

                // **VERIFICAR INTEGRIDAD DE CADA REMITO**
                VerificarIntegridadRemitos(remitos);

                LoggerService.WriteLog($"Se obtuvieron {remitos.Count} remitos para gestion.", TraceLevel.Info);
                return remitos;
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception("Error al obtener los remitos para gestion.", ex);
            }
        }

        /// <summary>
        /// Obtiene remitos filtrados con su informacion de PDF asociada.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango (opcional).</param>
        /// <param name="fechaFin">Fecha de fin del rango (opcional).</param>
        /// <param name="cuit">CUIT del generador para filtrar (opcional).</param>
        /// <param name="tipoResiduo">Tipo de residuo para filtrar (opcional).</param>
        /// <returns>Lista filtrada de DTOs.</returns>
        public List<RemitoGestionDto> ObtenerRemitosFiltrados(DateTime? fechaInicio, DateTime? fechaFin, string cuit, string tipoResiduo)
        {
            try
            {
                var remitos = _remitoRepository.GetRemitosFiltradosConPdf(fechaInicio, fechaFin, cuit, tipoResiduo);

                // **VERIFICAR INTEGRIDAD DE CADA REMITO**
                VerificarIntegridadRemitos(remitos);

                string filtrosAplicados = "";
                if (fechaInicio.HasValue) filtrosAplicados += $" FechaInicio:{fechaInicio.Value:dd/MM/yyyy}";
                if (fechaFin.HasValue) filtrosAplicados += $" FechaFin:{fechaFin.Value:dd/MM/yyyy}";
                if (!string.IsNullOrWhiteSpace(cuit)) filtrosAplicados += $" CUIT:{cuit}";
                if (!string.IsNullOrWhiteSpace(tipoResiduo)) filtrosAplicados += $" TipoResiduo:{tipoResiduo}";

                LoggerService.WriteLog($"Se obtuvieron {remitos.Count} remitos con filtros:{filtrosAplicados}", TraceLevel.Info);

                return remitos;
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception("Error al obtener los remitos filtrados.", ex);
            }
        }

        /// <summary>
        /// Obtiene un remito por su ID desde la base de datos.
        /// </summary>
        /// <param name="idRemito">ID del remito.</param>
        /// <returns>El remito correspondiente, o null si no existe.</returns>
        public DOMAIN.Remito ObtenerRemitoPorId(Guid idRemito)
        {
            return _remitoRepository.GetRemitoById(idRemito);
        }

        /// <summary>
        /// Descarga el PDF de un remito al directorio de descargas del usuario.
        /// Similar al comportamiento de Chrome al descargar archivos.
        /// </summary>
        /// <param name="idRemito">ID del remito cuyo PDF se desea descargar.</param>
        /// <returns>Ruta completa donde se guardo el archivo descargado.</returns>
        public string DescargarPdfRemito(Guid idRemito)
        {
            try
            {
                // Obtener informacion del PDF desde la base de datos
                var remitoPdf = _remitoPdfRepository.ObtenerPorIdRemito(idRemito);

                if (remitoPdf == null)
                {
                    throw new Exception($"No se encontro un PDF asociado al remito {idRemito}.");
                }

                // Construir ruta completa del archivo origen
                string rutaOrigenPdf = Path.Combine(_rutaPdfRemitos, remitoPdf.NombreArchivo);

                if (!File.Exists(rutaOrigenPdf))
                {
                    throw new FileNotFoundException($"El archivo PDF no existe en la ruta: {rutaOrigenPdf}");
                }

                // Obtener carpeta de descargas del usuario
                string carpetaDescargas = ObtenerCarpetaDescargas();

                // Construir ruta de destino en Descargas
                string rutaDestinoPdf = Path.Combine(carpetaDescargas, remitoPdf.NombreArchivo);

                // Si ya existe un archivo con el mismo nombre, agregar un numero secuencial
                rutaDestinoPdf = ObtenerRutaUnicaDescarga(rutaDestinoPdf);

                // Copiar el archivo a la carpeta de descargas
                File.Copy(rutaOrigenPdf, rutaDestinoPdf, false);

                LoggerService.WriteLog(
                    $"PDF descargado exitosamente. Remito: {idRemito}, Archivo: {remitoPdf.NombreArchivo}, Destino: {rutaDestinoPdf}",
                    TraceLevel.Info);

                return rutaDestinoPdf;
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al descargar el PDF del remito {idRemito}.", ex);
            }
        }

        /// <summary>
        /// Anula un remito (soft delete) y descuenta la cantidad del inventario.
        /// Usa UnitOfWork para coordinar ambos pasos: si falla el descuento
        /// de inventario, el remito vuelve a su estado original automaticamente.
        /// </summary>
        /// <param name="idRemito">ID del remito a anular.</param>
        public void AnularRemito(Guid idRemito)
        {
            // Verificar que el remito existe
            var remito = _remitoRepository.GetRemitoById(idRemito);
            if (remito == null)
            {
                throw new Exception($"No se encontro el remito con ID {idRemito}.");
            }

            // Verificar que no este ya anulado
            if (remito.EstadoRemito == "Anulado")
            {
                throw new Exception("El remito ya se encuentra anulado.");
            }

            // Guardar estado original para compensacion
            string estadoOriginal = remito.EstadoRemito;
            string dvOriginal = remito.DigitoVerificador;

            using (var uow = new UnitOfWork("AnularRemito"))
            {
                // PASO 1: Anular remito en BD + recalcular DV
                remito.EstadoRemito = "Anulado";
                remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);
                _remitoRepository.Update(remito);

                uow.RegistrarCompensacion("RevertirAnulacion", () =>
                {
                    remito.EstadoRemito = estadoOriginal;
                    remito.DigitoVerificador = dvOriginal;
                    _remitoRepository.Update(remito);
                });

                LoggerService.WriteLog(
                    $"Remito {idRemito} marcado como Anulado. DV recalculado.",
                    TraceLevel.Info);

                // PASO 2: Descontar del inventario
                var inventarioService = new InventarioService();
                inventarioService.RevertirEntradaDesdeRemito(
                    remito.TipoResiduo, remito.Estado, remito.Cantidad, remito.IdRemito);

                LoggerService.WriteLog(
                    $"Inventario descontado: {remito.Cantidad} de {remito.TipoResiduo} ({remito.Estado}).",
                    TraceLevel.Info);

                // Todo OK
                uow.Complete();
            }

            LoggerService.WriteLog(
                $"Remito anulado exitosamente. ID: {idRemito}, Generador: {remito.NombreGenerador}",
                TraceLevel.Info);
        }

        /// <summary>
        /// Modifica un remito existente y ajusta el inventario si cambio la cantidad o el estado fisico.
        /// Usa UnitOfWork para coordinar: si falla el ajuste de inventario, el remito vuelve a sus valores originales.
        /// </summary>
        /// <param name="remitoModificado">Remito con los nuevos valores.</param>
        /// <param name="cantidadAnterior">Cantidad original antes de la modificacion.</param>
        /// <param name="estadoAnterior">Estado fisico original antes de la modificacion.</param>
        public void ModificarRemito(DOMAIN.Remito remitoModificado, decimal cantidadAnterior, string estadoAnterior)
        {
            // Verificar que el remito existe en BD
            var remitoEnBD = _remitoRepository.GetRemitoById(remitoModificado.IdRemito);
            if (remitoEnBD == null)
            {
                throw new Exception($"No se encontro el remito con ID {remitoModificado.IdRemito}.");
            }

            if (remitoEnBD.EstadoRemito == "Anulado")
            {
                throw new Exception("No se puede modificar un remito anulado.");
            }

            // Guardar valores originales completos para compensacion
            string dvOriginal = remitoEnBD.DigitoVerificador;
            decimal cantOriginal = cantidadAnterior;
            string estOriginal = estadoAnterior;
            string domPlantaOriginal = remitoEnBD.DomicilioPlanta;
            string cuitOriginal = remitoEnBD.Cuit;
            string nfOriginal = remitoEnBD.NombreFantasia;
            string dirOriginal = remitoEnBD.Direccion;

            using (var uow = new UnitOfWork("ModificarRemito"))
            {
                // PASO 1: Recalcular DV y actualizar remito en BD
                remitoModificado.DigitoVerificador =
                    SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remitoModificado);
                _remitoRepository.Update(remitoModificado);

                uow.RegistrarCompensacion("RevertirModificacion", () =>
                {
                    remitoModificado.Cantidad = cantOriginal;
                    remitoModificado.Estado = estOriginal;
                    remitoModificado.DomicilioPlanta = domPlantaOriginal;
                    remitoModificado.Cuit = cuitOriginal;
                    remitoModificado.NombreFantasia = nfOriginal;
                    remitoModificado.Direccion = dirOriginal;
                    remitoModificado.DigitoVerificador = dvOriginal;
                    _remitoRepository.Update(remitoModificado);
                });

                LoggerService.WriteLog(
                    $"Remito {remitoModificado.IdRemito} actualizado en BD. DV recalculado.",
                    TraceLevel.Info);

                // PASO 2: Ajustar inventario si cambio cantidad o estado fisico
                var inventarioService = new InventarioService();
                bool estadoCambio = remitoModificado.Estado != estadoAnterior;
                decimal diferencia = remitoModificado.Cantidad - cantidadAnterior;

                if (estadoCambio)
                {
                    // Estado fisico cambio: revertir entrada vieja y registrar entrada nueva
                    inventarioService.RevertirEntradaDesdeRemito(
                        remitoModificado.TipoResiduo, estadoAnterior,
                        cantidadAnterior, remitoModificado.IdRemito);

                    inventarioService.RegistrarEntradaDesdeRemito(
                        remitoModificado.TipoResiduo, remitoModificado.Estado,
                        remitoModificado.Cantidad, remitoModificado.IdRemito,
                        "Reingreso por modificacion de remito");

                    uow.RegistrarCompensacion("RevertirAjusteInventarioEstado", () =>
                    {
                        inventarioService.RevertirEntradaDesdeRemito(
                            remitoModificado.TipoResiduo, remitoModificado.Estado,
                            remitoModificado.Cantidad, remitoModificado.IdRemito);
                        inventarioService.RegistrarEntradaDesdeRemito(
                            remitoModificado.TipoResiduo, estadoAnterior,
                            cantidadAnterior, remitoModificado.IdRemito,
                            "COMPENSACION: Reversion de modificacion de remito");
                    });

                    LoggerService.WriteLog(
                        $"Inventario ajustado por cambio de estado: {estadoAnterior} -> {remitoModificado.Estado}",
                        TraceLevel.Info);
                }
                else if (diferencia != 0)
                {
                    // Solo cambio la cantidad
                    if (diferencia > 0)
                    {
                        // Aumento: registrar entrada por la diferencia
                        inventarioService.RegistrarEntradaDesdeRemito(
                            remitoModificado.TipoResiduo, remitoModificado.Estado,
                            diferencia, remitoModificado.IdRemito,
                            "Ajuste por modificacion de remito (aumento)");

                        uow.RegistrarCompensacion("RevertirAumentoInventario", () =>
                        {
                            inventarioService.RevertirEntradaDesdeRemito(
                                remitoModificado.TipoResiduo, remitoModificado.Estado,
                                diferencia, remitoModificado.IdRemito);
                        });
                    }
                    else
                    {
                        // Disminucion: registrar salida por la diferencia absoluta
                        decimal cantidadReducida = Math.Abs(diferencia);
                        inventarioService.RegistrarSalida(
                            remitoModificado.TipoResiduo, remitoModificado.Estado,
                            cantidadReducida,
                            $"Ajuste por modificacion de remito {remitoModificado.IdRemito} (disminucion)");

                        uow.RegistrarCompensacion("RevertirDisminucionInventario", () =>
                        {
                            inventarioService.RegistrarEntradaDesdeRemito(
                                remitoModificado.TipoResiduo, remitoModificado.Estado,
                                cantidadReducida, remitoModificado.IdRemito,
                                "COMPENSACION: Reversion de disminucion");
                        });
                    }

                    LoggerService.WriteLog(
                        $"Inventario ajustado por cambio de cantidad: {cantidadAnterior} -> {remitoModificado.Cantidad} (diferencia: {diferencia})",
                        TraceLevel.Info);
                }

                uow.Complete();
            }

            LoggerService.WriteLog(
                $"Remito modificado exitosamente. ID: {remitoModificado.IdRemito}, Generador: {remitoModificado.NombreGenerador}",
                TraceLevel.Info);
        }

        #region Metodos auxiliares privados

        /// <summary>
        /// Verifica la integridad de una lista de remitos usando el Digito Verificador.
        /// Actualiza los campos IntegridadEstado e IntegridadValida de cada DTO.
        /// </summary>
        /// <param name="remitos">Lista de remitos a verificar.</param>
        private void VerificarIntegridadRemitos(List<RemitoGestionDto> remitos)
        {
            int contadorAlterados = 0;
            int contadorSinDV = 0;
            int contadorOK = 0;

            foreach (var dto in remitos)
            {
                try
                {
                    // Convertir DTO a entidad Remito para verificacion
                    var remito = new DOMAIN.Remito
                    {
                        IdRemito = dto.IdRemito,
                        NombreTransportista = dto.NombreTransportista,
                        DomicilioTransportista = dto.DomicilioTransportista,
                        NombreGenerador = dto.NombreGenerador,
                        DomicilioPlanta = dto.DomicilioPlanta,
                        TipoResiduo = dto.TipoResiduo,
                        Cantidad = dto.Cantidad,
                        Estado = dto.Estado,
                        Cuit = dto.Cuit,
                        NombreFantasia = dto.NombreFantasia,
                        Direccion = dto.Direccion,
                        EstadoRemito = dto.EstadoRemito,
                        DigitoVerificador = dto.DigitoVerificador,
                        FechaCreacion = dto.FechaCreacion
                    };

                    // Verificar si tiene DV
                    if (string.IsNullOrWhiteSpace(dto.DigitoVerificador))
                    {
                        dto.IntegridadEstado = "SIN_DV";
                        dto.IntegridadValida = false;
                        contadorSinDV++;
                    }
                    else
                    {
                        // Verificar integridad usando el servicio
                        bool esValido = SERVICES.Facade.RemitoDigitoVerificadorService.Verificar(remito);

                        if (esValido)
                        {
                            dto.IntegridadEstado = "OK";
                            dto.IntegridadValida = true;
                            contadorOK++;
                        }
                        else
                        {
                            dto.IntegridadEstado = "ALTERADO";
                            dto.IntegridadValida = false;
                            contadorAlterados++;

                            // Log de advertencia para remitos alterados
                            LoggerService.WriteLog(
                                $"ALERTA: Remito ALTERADO detectado. ID: {dto.IdRemito}, Generador: {dto.NombreGenerador}, CUIT: {dto.Cuit}",
                                TraceLevel.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Error al verificar, marcar como desconocido
                    dto.IntegridadEstado = "ERROR";
                    dto.IntegridadValida = false;

                    LoggerService.WriteLog(
                        $"Error al verificar integridad del remito {dto.IdRemito}: {ex.Message}",
                        TraceLevel.Warning);
                }
            }

            // Log resumen de verificacion
            if (contadorAlterados > 0 || contadorSinDV > 0)
            {
                LoggerService.WriteLog(
                    $"Verificacion de integridad completada. Total: {remitos.Count} | OK: {contadorOK} | ALTERADOS: {contadorAlterados} | SIN_DV: {contadorSinDV}",
                    TraceLevel.Warning);
            }
            else
            {
                LoggerService.WriteLog(
                    $"Verificacion de integridad completada. Total: {remitos.Count} | Todos OK",
                    TraceLevel.Info);
            }
        }

        /// <summary>
        /// Obtiene la ruta de la carpeta de descargas del usuario actual.
        /// </summary>
        /// <returns>Ruta completa de la carpeta de descargas.</returns>
        private string ObtenerCarpetaDescargas()
        {
            // Intentar obtener la carpeta de descargas estandar de Windows
            string carpetaDescargas = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            // Si no existe, intentar con el nombre en espanol
            if (!Directory.Exists(carpetaDescargas))
            {
                carpetaDescargas = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Descargas");
            }

            // Si ninguna existe, crear la carpeta Downloads
            if (!Directory.Exists(carpetaDescargas))
            {
                carpetaDescargas = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads");
                Directory.CreateDirectory(carpetaDescargas);
            }

            return carpetaDescargas;
        }

        /// <summary>
        /// Obtiene una ruta unica para el archivo, agregando un numero secuencial si ya existe.
        /// Ejemplo: archivo.pdf -> archivo (1).pdf -> archivo (2).pdf
        /// </summary>
        /// <param name="rutaBase">Ruta base del archivo.</param>
        /// <returns>Ruta unica que no existe en el sistema.</returns>
        private string ObtenerRutaUnicaDescarga(string rutaBase)
        {
            if (!File.Exists(rutaBase))
            {
                return rutaBase;
            }

            string directorio = Path.GetDirectoryName(rutaBase);
            string nombreSinExtension = Path.GetFileNameWithoutExtension(rutaBase);
            string extension = Path.GetExtension(rutaBase);

            int contador = 1;
            string nuevaRuta;

            do
            {
                string nuevoNombre = $"{nombreSinExtension} ({contador}){extension}";
                nuevaRuta = Path.Combine(directorio, nuevoNombre);
                contador++;
            } while (File.Exists(nuevaRuta));

            return nuevaRuta;
        }

        #endregion
    }
}
