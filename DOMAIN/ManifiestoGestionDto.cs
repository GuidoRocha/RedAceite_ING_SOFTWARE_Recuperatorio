using System;

namespace DOMAIN
{
    /// <summary>
    /// DTO para mostrar manifiestos en la pantalla de gestion.
    /// Combina datos del manifiesto con informacion de integridad.
    /// </summary>
    public class ManifiestoGestionDto
    {
        // Campos del Manifiesto
        public Guid IdManifiesto { get; set; }
        public string NumeroManifiesto { get; set; }
        public DateTime FechaManifiesto { get; set; }
        public string NombreTransportista { get; set; }
        public int CantidadTotalRemitos { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Campos de integridad
        public string DigitoVerificador { get; set; }
        public string IntegridadEstado { get; set; }
        public bool IntegridadValida { get; set; }

        /// <summary>
        /// Indica si el manifiesto esta anulado.
        /// </summary>
        public bool EstaAnulado => Estado == "Anulado";

        /// <summary>
        /// Formatea el monto total para mostrar en el grid.
        /// </summary>
        public string MontoTotalFormateado => $"${MontoTotal:N2}";

        /// <summary>
        /// Representacion en string del DTO.
        /// </summary>
        public override string ToString()
        {
            return $"Manifiesto {NumeroManifiesto} - {FechaManifiesto:dd/MM/yyyy} - Total: ${MontoTotal:N2}";
        }
    }
}
