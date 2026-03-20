using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa una linea de detalle dentro de un manifiesto.
    /// Cada detalle corresponde a un remito con su precio y subtotal calculado.
    /// </summary>
    public class ManifiestoDetalle
    {
        /// <summary>
        /// Identificador unico del detalle.
        /// </summary>
        public Guid IdDetalle { get; set; }

        /// <summary>
        /// Identificador del manifiesto al que pertenece.
        /// </summary>
        public Guid IdManifiesto { get; set; }

        /// <summary>
        /// Identificador del remito asociado.
        /// </summary>
        public Guid IdRemito { get; set; }

        /// <summary>
        /// Nombre del generador/proveedor del residuo.
        /// </summary>
        public string NombreGenerador { get; set; }

        /// <summary>
        /// Tipo de residuo (Aceite / Grasa).
        /// </summary>
        public string TipoResiduo { get; set; }

        /// <summary>
        /// Cantidad en litros o kilogramos segun el tipo.
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Precio unitario por litro/kilo vigente al momento de generar el manifiesto.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Subtotal calculado (Cantidad x PrecioUnitario).
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Numero de orden del detalle dentro del manifiesto.
        /// </summary>
        public int Orden { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ManifiestoDetalle()
        {
            IdDetalle = Guid.NewGuid();
        }

        /// <summary>
        /// Calcula el subtotal en base a cantidad y precio unitario.
        /// </summary>
        public void CalcularSubtotal()
        {
            Subtotal = Cantidad * PrecioUnitario;
        }

        /// <summary>
        /// Representacion en string del detalle.
        /// </summary>
        public override string ToString()
        {
            return $"{NombreGenerador} - {TipoResiduo}: {Cantidad} x ${PrecioUnitario:N2} = ${Subtotal:N2}";
        }
    }
}
