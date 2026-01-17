using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa el registro de un archivo PDF generado para un remito.
    /// Mantiene la referencia al archivo físico almacenado en el filesystem.
    /// </summary>
    public class RemitoPDF
    {
        /// <summary>
        /// Identificador único del registro PDF.
        /// </summary>
        public Guid IdRemitoPDF { get; set; }

        /// <summary>
        /// Identificador del remito asociado a este PDF.
        /// </summary>
        public Guid IdRemito { get; set; }

        /// <summary>
        /// Nombre del archivo PDF (sin ruta completa).
        /// Formato: {FechaYYYYMMDD}_{IdProveedor8chars}_{IdRemito8chars}.pdf
        /// Ejemplo: 20250117_a1b2c3d4_e5f6g7h8.pdf
        /// </summary>
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Fecha y hora en que se generó el PDF.
        /// </summary>
        public DateTime FechaGeneracion { get; set; }

        /// <summary>
        /// Tamaño del archivo PDF en bytes.
        /// </summary>
        public long TamañoBytes { get; set; }

        /// <summary>
        /// Hash MD5 del archivo para verificación de integridad.
        /// </summary>
        public string HashMD5 { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa valores predeterminados.
        /// </summary>
        public RemitoPDF()
        {
            IdRemitoPDF = Guid.NewGuid();
            FechaGeneracion = DateTime.Now;
        }

        /// <summary>
        /// Constructor con parámetros para inicializar el registro PDF.
        /// </summary>
        /// <param name="idRemito">ID del remito asociado.</param>
        /// <param name="nombreArchivo">Nombre del archivo PDF generado.</param>
        public RemitoPDF(Guid idRemito, string nombreArchivo)
        {
            IdRemitoPDF = Guid.NewGuid();
            IdRemito = idRemito;
            NombreArchivo = nombreArchivo;
            FechaGeneracion = DateTime.Now;
        }

        /// <summary>
        /// Representación en string del registro PDF.
        /// </summary>
        public override string ToString()
        {
            return $"PDF: {NombreArchivo} - Remito: {IdRemito} - {FechaGeneracion:dd/MM/yyyy HH:mm}";
        }
    }
}
