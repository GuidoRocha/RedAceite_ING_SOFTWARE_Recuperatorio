using System;

namespace DOMAIN
{
    /// <summary>
    /// DTO (Data Transfer Object) que representa la combinación de un Remito con su PDF asociado.
    /// Se utiliza para mostrar la información completa de remitos en la pantalla de gestión.
    /// </summary>
    public class RemitoGestionDto
    {
        // Campos del Remito
        public Guid IdRemito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NombreGenerador { get; set; }
        public string Cuit { get; set; }
        public string TipoResiduo { get; set; }
        public decimal Cantidad { get; set; }
        public string Estado { get; set; }
        public string EstadoRemito { get; set; }
        
        // Campos adicionales del Remito para filtros y detalles
        public string NombreFantasia { get; set; }
        public string Direccion { get; set; }
        public string DomicilioPlanta { get; set; }
        public string NombreTransportista { get; set; }
        public string DomicilioTransportista { get; set; }

        // Campos del RemitoPDF
        public Guid? IdRemitoPDF { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime? FechaGeneracionPdf { get; set; }
        public long? TamañoBytes { get; set; }
        public string HashMD5 { get; set; }

        /// <summary>
        /// Indica si el remito tiene un PDF generado asociado.
        /// </summary>
        public bool TienePdf => !string.IsNullOrWhiteSpace(NombreArchivo);

        /// <summary>
        /// Indica si el remito está anulado.
        /// </summary>
        public bool EstaAnulado => EstadoRemito == "Anulado";

        /// <summary>
        /// Formatea el tamaño del archivo en una cadena legible.
        /// </summary>
        public string TamañoFormateado
        {
            get
            {
                if (!TamañoBytes.HasValue || TamañoBytes.Value == 0)
                    return "-";

                double bytes = TamañoBytes.Value;

                if (bytes >= 1048576) // >= 1 MB
                    return $"{bytes / 1048576:N2} MB";
                else if (bytes >= 1024) // >= 1 KB
                    return $"{bytes / 1024:N2} KB";
                else
                    return $"{bytes} bytes";
            }
        }

        /// <summary>
        /// Representación en string del DTO.
        /// </summary>
        public override string ToString()
        {
            return $"Remito {IdRemito} - {NombreGenerador} - {FechaCreacion:dd/MM/yyyy} - PDF: {(TienePdf ? "Sí" : "No")}";
        }
    }
}
