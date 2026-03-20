using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa un manifiesto diario que agrupa los remitos generados en un dia.
    /// Incluye el resumen de cantidades y montos a pagar por proveedor.
    /// </summary>
    public class Manifiesto
    {
        /// <summary>
        /// Identificador unico del manifiesto.
        /// </summary>
        public Guid IdManifiesto { get; set; }

        /// <summary>
        /// Numero de manifiesto con formato MAN-YYYYMMDD-NNN.
        /// </summary>
        public string NumeroManifiesto { get; set; }

        /// <summary>
        /// Fecha del dia que cubre este manifiesto.
        /// </summary>
        public DateTime FechaManifiesto { get; set; }

        /// <summary>
        /// Nombre del transportista responsable.
        /// </summary>
        public string NombreTransportista { get; set; }

        /// <summary>
        /// Domicilio del transportista.
        /// </summary>
        public string DomicilioTransportista { get; set; }

        /// <summary>
        /// Cantidad total de remitos incluidos en el manifiesto.
        /// </summary>
        public int CantidadTotalRemitos { get; set; }

        /// <summary>
        /// Monto total a pagar (suma de todos los subtotales de detalle).
        /// </summary>
        public decimal MontoTotal { get; set; }

        /// <summary>
        /// Estado del manifiesto (Generado / Anulado).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Observaciones opcionales del manifiesto.
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Fecha y hora de creacion del registro.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Digito Verificador (hash MD5) para integridad de datos.
        /// </summary>
        public string DigitoVerificador { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa valores predeterminados.
        /// </summary>
        public Manifiesto()
        {
            IdManifiesto = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
            Estado = "Generado";
            CantidadTotalRemitos = 0;
            MontoTotal = 0;
        }

        /// <summary>
        /// Constructor con fecha de manifiesto.
        /// </summary>
        /// <param name="fechaManifiesto">Fecha del dia que cubre el manifiesto.</param>
        public Manifiesto(DateTime fechaManifiesto) : this()
        {
            FechaManifiesto = fechaManifiesto;
        }

        /// <summary>
        /// Indica si el manifiesto esta anulado.
        /// </summary>
        public bool EstaAnulado => Estado == "Anulado";

        /// <summary>
        /// Representacion en string del manifiesto.
        /// </summary>
        public override string ToString()
        {
            return $"Manifiesto {NumeroManifiesto} - {FechaManifiesto:dd/MM/yyyy} - Remitos: {CantidadTotalRemitos} - Total: ${MontoTotal:N2}";
        }
    }
}
