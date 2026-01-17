using System;

namespace SERVICES.DTO
{
    /// <summary>
    /// DTO (Data Transfer Object) que encapsula todos los datos necesarios 
    /// para generar un PDF de remito.
    /// </summary>
    public class DatosRemitoPdfDto
    {
        // Información del remito
        public Guid IdRemito { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // Información del transportista (Hugo Rocha - datos fijos)
        public string NombreTransportista { get; set; }
        public string TelefonoTransportista { get; set; }
        public string DomicilioTransportista { get; set; }
        
        // Información del generador (proveedor)
        public string NombreGenerador { get; set; }
        public string DomicilioPlanta { get; set; }
        
        // Información del residuo
        public string TipoResiduo { get; set; }
        public decimal Cantidad { get; set; }
        public string Estado { get; set; }
        
        // Información de envío (opcional)
        public bool RequiereEnvio { get; set; }
        public string Cuit { get; set; }
        public string NombreFantasia { get; set; }
        public string DireccionEnvio { get; set; }
        
        // Número de remito (generado)
        public string NumeroRemito { get; set; }

        /// <summary>
        /// Constructor por defecto con valores iniciales del transportista.
        /// </summary>
        public DatosRemitoPdfDto()
        {
            // Datos fijos del transportista
            NombreTransportista = "Hugo Rocha";
            TelefonoTransportista = "(011)114-4917473";
            DomicilioTransportista = "Mendoza 3149 San Andres Prov. de Bs.As.";
            RequiereEnvio = false;
        }

        /// <summary>
        /// Genera un número de remito único basado en la fecha y un correlativo.
        /// Formato: YYYYMMDD-XXXXX
        /// </summary>
        public void GenerarNumeroRemito()
        {
            string fecha = FechaCreacion.ToString("yyyyMMdd");
            string correlativo = IdRemito.ToString("N").Substring(0, 5).ToUpper();
            NumeroRemito = $"{fecha}-{correlativo}";
        }
    }
}
