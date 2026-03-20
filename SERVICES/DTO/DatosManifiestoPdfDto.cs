using System;
using System.Collections.Generic;

namespace SERVICES.DTO
{
    /// <summary>
    /// DTO que encapsula los datos necesarios para generar el PDF de un manifiesto.
    /// </summary>
    public class DatosManifiestoPdfDto
    {
        // Datos del manifiesto
        public Guid IdManifiesto { get; set; }
        public string NumeroManifiesto { get; set; }
        public DateTime FechaManifiesto { get; set; }

        // Datos del transportista
        public string NombreTransportista { get; set; }
        public string DomicilioTransportista { get; set; }
        public string TelefonoTransportista { get; set; }

        // Totales
        public int CantidadTotalRemitos { get; set; }
        public decimal MontoTotal { get; set; }

        // Detalles (lineas del manifiesto)
        public List<DetalleManifiestoPdfDto> Detalles { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DatosManifiestoPdfDto()
        {
            NombreTransportista = "Hugo Rocha";
            DomicilioTransportista = "Mendoza 3149 San Andres Prov. de Bs.As.";
            TelefonoTransportista = "(011)114-4917473";
            Detalles = new List<DetalleManifiestoPdfDto>();
        }
    }

    /// <summary>
    /// DTO para cada linea de detalle dentro del PDF del manifiesto.
    /// </summary>
    public class DetalleManifiestoPdfDto
    {
        public int Orden { get; set; }
        public string NombreGenerador { get; set; }
        public string TipoResiduo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
