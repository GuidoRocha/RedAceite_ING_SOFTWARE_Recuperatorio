using DAL.Contratos;
using DAL.Implementaciones;
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
    /// Servicio de lógica de negocio para la gestión de remitos.
    /// Coordina las operaciones de consulta, filtrado y descarga de PDFs de remitos.
    /// </summary>
    public class RemitoGestionService
    {
        private readonly IRemitoRepository _remitoRepository;
        private readonly IRemitoPdfRepository _remitoPdfRepository;
        private readonly string _rutaPdfRemitos;

        /// <summary>
        /// Constructor que inicializa los repositorios y configuración.
        /// </summary>
        public RemitoGestionService()
        {
            _remitoRepository = new RemitoRepository();
            _remitoPdfRepository = new RemitoPdfRepository();
            _rutaPdfRemitos = ConfigHelper.ObtenerRutaPdfRemitos();
        }

        /// <summary>
        /// Constructor con inyección de dependencias (para testing).
        /// </summary>
        public RemitoGestionService(IRemitoRepository remitoRepository, IRemitoPdfRepository remitoPdfRepository)
        {
            _remitoRepository = remitoRepository;
            _remitoPdfRepository = remitoPdfRepository;
            _rutaPdfRemitos = ConfigHelper.ObtenerRutaPdfRemitos();
        }

        /// <summary>
        /// Obtiene todos los remitos con su información de PDF asociada.
        /// </summary>
        /// <returns>Lista de DTOs con información completa de remitos y PDFs.</returns>
        public List<RemitoGestionDto> ObtenerRemitosParaGestion()
        {
            try
            {
                var remitos = _remitoRepository.GetRemitosConPdf();
                
                // **VERIFICAR INTEGRIDAD DE CADA REMITO**
                VerificarIntegridadRemitos(remitos);
                
                LoggerService.WriteLog($"Se obtuvieron {remitos.Count} remitos para gestión.", TraceLevel.Info);
                return remitos;
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception("Error al obtener los remitos para gestión.", ex);
            }
        }

        /// <summary>
        /// Obtiene remitos filtrados con su información de PDF asociada.
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
        /// Descarga el PDF de un remito al directorio de descargas del usuario.
        /// Similar al comportamiento de Chrome al descargar archivos.
        /// </summary>
        /// <param name="idRemito">ID del remito cuyo PDF se desea descargar.</param>
        /// <returns>Ruta completa donde se guardó el archivo descargado.</returns>
        public string DescargarPdfRemito(Guid idRemito)
        {
            try
            {
                // Obtener información del PDF desde la base de datos
                var remitoPdf = _remitoPdfRepository.ObtenerPorIdRemito(idRemito);
                
                if (remitoPdf == null)
                {
                    throw new Exception($"No se encontró un PDF asociado al remito {idRemito}.");
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

                // Si ya existe un archivo con el mismo nombre, agregar un número secuencial
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
        /// Anula un remito (soft delete).
        /// </summary>
        /// <param name="idRemito">ID del remito a anular.</param>
        public void AnularRemito(Guid idRemito)
        {
            try
            {
                // Verificar que el remito existe
                var remito = _remitoRepository.GetRemitoById(idRemito);
                if (remito == null)
                {
                    throw new Exception($"No se encontró el remito con ID {idRemito}.");
                }

                // Verificar que no esté ya anulado
                if (remito.EstadoRemito == "Anulado")
                {
                    throw new Exception("El remito ya se encuentra anulado.");
                }

                // Cambiar estado a Anulado
                remito.EstadoRemito = "Anulado";

                // **RECALCULAR DÍGITO VERIFICADOR**
                try
                {
                    remito.DigitoVerificador = SERVICES.Facade.RemitoDigitoVerificadorService.Calcular(remito);
                    
                    LoggerService.WriteLog(
                        $"Dígito Verificador recalculado al anular remito {remito.IdRemito}: {remito.DigitoVerificador}",
                        TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    LoggerService.WriteLog(
                        $"Error al recalcular Dígito Verificador al anular remito {remito.IdRemito}: {ex.Message}",
                        TraceLevel.Warning);
                    LoggerService.WriteException(ex);
                }

                // Actualizar el remito con el nuevo estado y DV
                _remitoRepository.Update(remito);

                LoggerService.WriteLog(
                    $"Remito anulado exitosamente. ID: {idRemito}, Generador: {remito.NombreGenerador}",
                    TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al anular el remito {idRemito}.", ex);
            }
        }

        #region Métodos auxiliares privados

        /// <summary>
        /// Verifica la integridad de una lista de remitos usando el Dígito Verificador.
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
                    // Convertir DTO a entidad Remito para verificación
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
                                $"?? ALERTA: Remito ALTERADO detectado. ID: {dto.IdRemito}, Generador: {dto.NombreGenerador}, CUIT: {dto.Cuit}",
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

            // Log resumen de verificación
            if (contadorAlterados > 0 || contadorSinDV > 0)
            {
                LoggerService.WriteLog(
                    $"Verificación de integridad completada. Total: {remitos.Count} | OK: {contadorOK} | ALTERADOS: {contadorAlterados} | SIN_DV: {contadorSinDV}",
                    TraceLevel.Warning);
            }
            else
            {
                LoggerService.WriteLog(
                    $"Verificación de integridad completada. Total: {remitos.Count} | Todos OK",
                    TraceLevel.Info);
            }
        }

        /// <summary>
        /// Obtiene la ruta de la carpeta de descargas del usuario actual.
        /// </summary>
        /// <returns>Ruta completa de la carpeta de descargas.</returns>
        private string ObtenerCarpetaDescargas()
        {
            // Intentar obtener la carpeta de descargas estándar de Windows
            string carpetaDescargas = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            // Si no existe, intentar con el nombre en español
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
        /// Obtiene una ruta única para el archivo, agregando un número secuencial si ya existe.
        /// Ejemplo: archivo.pdf -> archivo (1).pdf -> archivo (2).pdf
        /// </summary>
        /// <param name="rutaBase">Ruta base del archivo.</param>
        /// <returns>Ruta única que no existe en el sistema.</returns>
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
