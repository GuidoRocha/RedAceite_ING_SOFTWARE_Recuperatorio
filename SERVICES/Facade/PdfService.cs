using SERVICES.DTO;
using SERVICES.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio fachada para generaci�n de archivos PDF.
    /// Expone m�todos simplificados a la capa BLL ocultando la complejidad de iText7.
    /// </summary>
    public class PdfService
    {
        private readonly PdfGeneratorHelper _pdfGenerator;

        /// <summary>
        /// Constructor que inicializa el helper de generaci�n de PDF.
        /// </summary>
        public PdfService()
        {
            _pdfGenerator = new PdfGeneratorHelper();
        }

        /// <summary>
        /// Genera un archivo PDF de remito y lo guarda en la ruta especificada.
        /// </summary>
        /// <param name="datos">Datos del remito a incluir en el PDF.</param>
        /// <param name="rutaDestino">Ruta completa donde se guardar� el archivo PDF.</param>
        /// <param name="rutaLogo">Ruta completa del archivo de logo.</param>
        /// <returns>True si se gener� exitosamente, false en caso contrario.</returns>
        public bool GenerarPdfRemito(DatosRemitoPdfDto datos, string rutaDestino, string rutaLogo)
        {
            try
            {
                // Validar datos de entrada
                ValidarDatos(datos, rutaDestino, rutaLogo);

                // Generar n�mero de remito si no existe
                if (string.IsNullOrWhiteSpace(datos.NumeroRemito))
                {
                    datos.GenerarNumeroRemito();
                }

                // Crear carpeta de destino si no existe
                string carpetaDestino = Path.GetDirectoryName(rutaDestino);
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // Generar el PDF
                _pdfGenerator.CrearRemitoPdf(datos, rutaDestino, rutaLogo);

                // Verificar que el archivo se cre� correctamente
                if (!File.Exists(rutaDestino))
                {
                    throw new Exception("El archivo PDF no se gener� correctamente.");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF de remito: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Calcula el hash MD5 de un archivo para verificaci�n de integridad.
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa del archivo.</param>
        /// <returns>Hash MD5 en formato hexadecimal.</returns>
        public string CalcularHashMD5(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException("El archivo no existe.", rutaArchivo);
                }

                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(rutaArchivo))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular hash MD5: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el tama�o de un archivo en bytes.
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa del archivo.</param>
        /// <returns>Tama�o del archivo en bytes.</returns>
        public long ObtenerTama�oArchivo(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException("El archivo no existe.", rutaArchivo);
                }

                FileInfo fileInfo = new FileInfo(rutaArchivo);
                return fileInfo.Length;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener tama�o del archivo: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si un archivo PDF existe en la ruta especificada.
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa del archivo.</param>
        /// <returns>True si existe, false en caso contrario.</returns>
        public bool ExisteArchivo(string rutaArchivo)
        {
            return File.Exists(rutaArchivo);
        }

        /// <summary>
        /// Elimina un archivo PDF del sistema de archivos.
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa del archivo a eliminar.</param>
        public void EliminarArchivo(string rutaArchivo)
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar archivo: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Valida los datos necesarios para generar el PDF.
        /// </summary>
        private void ValidarDatos(DatosRemitoPdfDto datos, string rutaDestino, string rutaLogo)
        {
            if (datos == null)
            {
                throw new ArgumentNullException(nameof(datos), "Los datos del remito no pueden ser nulos.");
            }

            if (string.IsNullOrWhiteSpace(rutaDestino))
            {
                throw new ArgumentException("La ruta de destino no puede estar vac�a.", nameof(rutaDestino));
            }

            if (string.IsNullOrWhiteSpace(rutaLogo) || !File.Exists(rutaLogo))
            {
                LoggerService.WriteLog(
                    $"[PdfService] Logo no encontrado en: {rutaLogo ?? "(vac�o)"}. El PDF se generar� sin logo.",
                    TraceLevel.Warning);
            }

            // Validar datos obligatorios del remito
            if (string.IsNullOrWhiteSpace(datos.NombreGenerador))
            {
                throw new ArgumentException("El nombre del generador es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(datos.TipoResiduo))
            {
                throw new ArgumentException("El tipo de residuo es obligatorio.");
            }

            if (datos.Cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            }

            // Validar datos de env�o si se requiere
            if (datos.RequiereEnvio)
            {
                if (string.IsNullOrWhiteSpace(datos.Cuit))
                {
                    throw new ArgumentException("El CUIT es obligatorio cuando se requiere env�o.");
                }

                if (string.IsNullOrWhiteSpace(datos.NombreFantasia))
                {
                    throw new ArgumentException("El nombre de fantas�a es obligatorio cuando se requiere env�o.");
                }

                if (string.IsNullOrWhiteSpace(datos.DireccionEnvio))
                {
                    throw new ArgumentException("La direcci�n es obligatoria cuando se requiere env�o.");
                }
            }
        }
    }
}
