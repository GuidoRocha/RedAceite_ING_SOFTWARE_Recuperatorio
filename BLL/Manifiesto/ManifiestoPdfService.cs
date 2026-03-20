using DAL.Contratos;
using DOMAIN;
using SERVICES.DTO;
using SERVICES.Facade;
using SERVICES.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace BLL.Manifiesto
{
    /// <summary>
    /// Servicio de logica de negocio para la generacion de PDFs de manifiestos.
    /// Coordina la generacion del archivo PDF con los datos del manifiesto y sus detalles.
    /// Sigue el mismo patron que RemitoPdfService.
    /// </summary>
    public class ManifiestoPdfService
    {
        private readonly IManifiestoRepository _manifiestoRepository;
        private readonly ManifiestoPdfGeneratorHelper _pdfGenerator;
        private readonly PdfService _pdfService;
        private readonly string _rutaPdfManifiestos;
        private readonly string _rutaLogoManifiesto;

        /// <summary>
        /// Constructor que inicializa repositorios, helpers y rutas.
        /// </summary>
        public ManifiestoPdfService()
        {
            _manifiestoRepository = ServiceFactory.ManifiestoRepository;
            _pdfGenerator = new ManifiestoPdfGeneratorHelper();
            _pdfService = new PdfService();

            _rutaPdfManifiestos = ConfigHelper.ObtenerRutaPdfManifiestos();
            _rutaLogoManifiesto = ConfigHelper.ObtenerRutaLogoManifiesto();

            ValidarConfiguracion();
        }

        /// <summary>
        /// Genera un archivo PDF para un manifiesto especifico.
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto para el cual generar el PDF.</param>
        /// <returns>Ruta completa del archivo PDF generado.</returns>
        public string GenerarPdfManifiesto(Guid idManifiesto)
        {
            LoggerService.WriteLog(
                $"[ManifiestoPdfService] Iniciando generacion de PDF para manifiesto {idManifiesto}",
                System.Diagnostics.TraceLevel.Info);

            try
            {
                // 1. Obtener el manifiesto
                var manifiesto = _manifiestoRepository.GetManifiestoById(idManifiesto);
                if (manifiesto == null)
                {
                    throw new Exception($"El manifiesto con ID {idManifiesto} no existe.");
                }

                // 2. Obtener los detalles
                var detalles = _manifiestoRepository.GetDetallesByManifiesto(idManifiesto);

                // 3. Mapear a DTO para PDF
                var datosPdf = MapearManifiestoADto(manifiesto, detalles);

                // 4. Generar nombre de archivo unico
                string nombreArchivo = GenerarNombreArchivo(manifiesto);
                string rutaCompleta = Path.Combine(_rutaPdfManifiestos, nombreArchivo);

                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] Archivo: {nombreArchivo}",
                    System.Diagnostics.TraceLevel.Info);

                // 5. Validar que la carpeta de destino existe
                ValidarYCrearCarpetaDestino();

                // 6. Generar el archivo PDF
                _pdfGenerator.CrearManifiestoPdf(datosPdf, rutaCompleta, _rutaLogoManifiesto);

                if (!File.Exists(rutaCompleta))
                {
                    throw new Exception("El archivo PDF no se genero correctamente.");
                }

                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] PDF generado exitosamente: {rutaCompleta}",
                    System.Diagnostics.TraceLevel.Info);

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] Error al generar PDF: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene la ruta completa del PDF de un manifiesto si existe.
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto.</param>
        /// <returns>Ruta del PDF o null si no existe.</returns>
        public string ObtenerRutaPdf(Guid idManifiesto)
        {
            var manifiesto = _manifiestoRepository.GetManifiestoById(idManifiesto);
            if (manifiesto == null) return null;

            string nombreArchivo = GenerarNombreArchivo(manifiesto);
            string rutaCompleta = Path.Combine(_rutaPdfManifiestos, nombreArchivo);

            return File.Exists(rutaCompleta) ? rutaCompleta : null;
        }

        /// <summary>
        /// Descarga el PDF de un manifiesto a la carpeta Descargas del usuario.
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto.</param>
        /// <returns>Ruta del archivo copiado.</returns>
        public string DescargarPdfManifiesto(Guid idManifiesto)
        {
            try
            {
                var manifiesto = _manifiestoRepository.GetManifiestoById(idManifiesto);
                if (manifiesto == null)
                {
                    throw new Exception("El manifiesto no existe.");
                }

                string nombreArchivo = GenerarNombreArchivo(manifiesto);
                string rutaOrigen = Path.Combine(_rutaPdfManifiestos, nombreArchivo);

                if (!File.Exists(rutaOrigen))
                {
                    // Intentar generar el PDF si no existe
                    rutaOrigen = GenerarPdfManifiesto(idManifiesto);
                }

                // Copiar a Descargas del usuario
                string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                carpetaDescargas = Path.Combine(carpetaDescargas, "Downloads");

                string nombreUnico = $"Manifiesto_{manifiesto.NumeroManifiesto}_{DateTime.Now:HHmmss}.pdf";
                string rutaDestino = Path.Combine(carpetaDescargas, nombreUnico);

                File.Copy(rutaOrigen, rutaDestino, true);

                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] PDF descargado a: {rutaDestino}",
                    System.Diagnostics.TraceLevel.Info);

                return rutaDestino;
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] Error al descargar PDF: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }

        #region Metodos Privados

        /// <summary>
        /// Mapea un Manifiesto y sus detalles a un DTO para generacion de PDF.
        /// </summary>
        private DatosManifiestoPdfDto MapearManifiestoADto(
            DOMAIN.Manifiesto manifiesto, List<ManifiestoDetalle> detalles)
        {
            var dto = new DatosManifiestoPdfDto
            {
                IdManifiesto = manifiesto.IdManifiesto,
                NumeroManifiesto = manifiesto.NumeroManifiesto,
                FechaManifiesto = manifiesto.FechaManifiesto,
                NombreTransportista = manifiesto.NombreTransportista,
                DomicilioTransportista = manifiesto.DomicilioTransportista,
                CantidadTotalRemitos = manifiesto.CantidadTotalRemitos,
                MontoTotal = manifiesto.MontoTotal
            };

            foreach (var detalle in detalles)
            {
                dto.Detalles.Add(new DetalleManifiestoPdfDto
                {
                    Orden = detalle.Orden,
                    NombreGenerador = detalle.NombreGenerador,
                    TipoResiduo = detalle.TipoResiduo,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario,
                    Subtotal = detalle.Subtotal
                });
            }

            return dto;
        }

        /// <summary>
        /// Genera un nombre de archivo unico para el PDF del manifiesto.
        /// Formato: MAN_{YYYYMMDD}_{IdCorto}.pdf
        /// </summary>
        private string GenerarNombreArchivo(DOMAIN.Manifiesto manifiesto)
        {
            string fecha = manifiesto.FechaManifiesto.ToString("yyyyMMdd");
            string idCorto = manifiesto.IdManifiesto.ToString("N").Substring(0, 8);

            return $"MAN_{fecha}_{idCorto}.pdf";
        }

        /// <summary>
        /// Valida que las rutas configuradas sean validas.
        /// </summary>
        private void ValidarConfiguracion()
        {
            if (string.IsNullOrWhiteSpace(_rutaPdfManifiestos))
            {
                throw new Exception(
                    "La configuracion 'RutaPDFManifiestos' no esta definida en App.config");
            }

            if (string.IsNullOrWhiteSpace(_rutaLogoManifiesto))
            {
                throw new Exception(
                    "La configuracion 'RutaLogoManifiesto' no esta definida en App.config");
            }

            if (!File.Exists(_rutaLogoManifiesto))
            {
                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] ADVERTENCIA: Logo no encontrado en: {_rutaLogoManifiesto}",
                    System.Diagnostics.TraceLevel.Warning);
            }
        }

        /// <summary>
        /// Valida que la carpeta de destino exista, y la crea si no existe.
        /// </summary>
        private void ValidarYCrearCarpetaDestino()
        {
            if (!Directory.Exists(_rutaPdfManifiestos))
            {
                LoggerService.WriteLog(
                    $"[ManifiestoPdfService] Creando carpeta: {_rutaPdfManifiestos}",
                    System.Diagnostics.TraceLevel.Info);

                Directory.CreateDirectory(_rutaPdfManifiestos);
            }
        }

        #endregion
    }
}
