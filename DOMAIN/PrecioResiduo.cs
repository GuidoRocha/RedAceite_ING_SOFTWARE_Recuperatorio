using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa el precio configurable por tipo de residuo.
    /// Solo puede haber un precio activo por cada tipo de residuo.
    /// </summary>
    public class PrecioResiduo
    {
        /// <summary>
        /// Identificador unico del registro de precio.
        /// </summary>
        public Guid IdPrecio { get; set; }

        /// <summary>
        /// Tipo de residuo al que aplica el precio (Aceite / Grasa).
        /// </summary>
        public string TipoResiduo { get; set; }

        /// <summary>
        /// Precio unitario por litro o kilogramo.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Fecha desde la cual este precio entra en vigencia.
        /// </summary>
        public DateTime FechaVigencia { get; set; }

        /// <summary>
        /// Indica si este precio esta activo. Solo uno por tipo de residuo.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public PrecioResiduo()
        {
            IdPrecio = Guid.NewGuid();
            FechaVigencia = DateTime.Now;
            Activo = true;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite / Grasa).</param>
        /// <param name="precioUnitario">Precio por litro o kilo.</param>
        public PrecioResiduo(string tipoResiduo, decimal precioUnitario) : this()
        {
            TipoResiduo = tipoResiduo;
            PrecioUnitario = precioUnitario;
        }

        /// <summary>
        /// Representacion en string del precio.
        /// </summary>
        public override string ToString()
        {
            return $"{TipoResiduo}: ${PrecioUnitario:N2}/unidad - Vigente desde {FechaVigencia:dd/MM/yyyy} - {(Activo ? "Activo" : "Inactivo")}";
        }
    }
}
