using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa el inventario consolidado de residuos almacenados.
    /// Mantiene el registro de cantidades disponibles por tipo y estado.
    /// </summary>
    public class Inventario
    {
        /// <summary>
        /// Identificador único del inventario.
        /// </summary>
        public Guid IdInventario { get; set; }

        /// <summary>
        /// Tipo de residuo (Aceite o Grasa).
        /// </summary>
        public string TipoResiduo { get; set; }

        /// <summary>
        /// Cantidad disponible actual en el inventario.
        /// </summary>
        public decimal CantidadDisponible { get; set; }

        /// <summary>
        /// Estado físico del residuo (Líquido o Sólido).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Fecha de creación del registro de inventario.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de última actualización del inventario.
        /// </summary>
        public DateTime FechaActualizacion { get; set; }

        /// <summary>
        /// Estado del inventario (Activo, Inactivo).
        /// </summary>
        public string EstadoInventario { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa valores predeterminados.
        /// </summary>
        public Inventario()
        {
            IdInventario = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
            FechaActualizacion = DateTime.Now;
            EstadoInventario = "Activo";
            CantidadDisponible = 0;
        }

        /// <summary>
        /// Constructor con parámetros para inicializar el inventario.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="estado">Estado físico (Líquido o Sólido).</param>
        /// <param name="cantidadInicial">Cantidad inicial (por defecto 0).</param>
        public Inventario(string tipoResiduo, string estado, decimal cantidadInicial = 0)
        {
            IdInventario = Guid.NewGuid();
            TipoResiduo = tipoResiduo;
            Estado = estado;
            CantidadDisponible = cantidadInicial;
            FechaCreacion = DateTime.Now;
            FechaActualizacion = DateTime.Now;
            EstadoInventario = "Activo";
        }

        /// <summary>
        /// Representación en string del inventario.
        /// </summary>
        public override string ToString()
        {
            return $"{TipoResiduo} ({Estado}): {CantidadDisponible} L/Kg";
        }
    }
}
