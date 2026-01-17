using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa un movimiento de inventario (entrada, salida o ajuste).
    /// Mantiene un registro de auditoría de todos los cambios en el inventario.
    /// </summary>
    public class MovimientoInventario
    {
        /// <summary>
        /// Identificador único del movimiento.
        /// </summary>
        public Guid IdMovimiento { get; set; }

        /// <summary>
        /// Identificador del inventario al que pertenece este movimiento.
        /// </summary>
        public Guid IdInventario { get; set; }

        /// <summary>
        /// Identificador del remito asociado (solo para entradas desde remitos).
        /// </summary>
        public Guid? IdRemito { get; set; }

        /// <summary>
        /// Tipo de movimiento (Entrada, Salida, Ajuste).
        /// </summary>
        public string TipoMovimiento { get; set; }

        /// <summary>
        /// Cantidad del movimiento (siempre positiva).
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Cantidad disponible antes del movimiento.
        /// </summary>
        public decimal CantidadAnterior { get; set; }

        /// <summary>
        /// Cantidad disponible después del movimiento.
        /// </summary>
        public decimal CantidadNueva { get; set; }

        /// <summary>
        /// Observaciones adicionales sobre el movimiento.
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Fecha y hora del movimiento.
        /// </summary>
        public DateTime FechaMovimiento { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó el movimiento.
        /// </summary>
        public Guid? UsuarioId { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public MovimientoInventario()
        {
            IdMovimiento = Guid.NewGuid();
            FechaMovimiento = DateTime.Now;
        }

        /// <summary>
        /// Constructor con parámetros principales.
        /// </summary>
        /// <param name="idInventario">ID del inventario afectado.</param>
        /// <param name="tipoMovimiento">Tipo de movimiento (Entrada, Salida, Ajuste).</param>
        /// <param name="cantidad">Cantidad del movimiento.</param>
        /// <param name="cantidadAnterior">Stock antes del movimiento.</param>
        /// <param name="observaciones">Observaciones opcionales.</param>
        public MovimientoInventario(Guid idInventario, string tipoMovimiento, 
            decimal cantidad, decimal cantidadAnterior, string observaciones = null)
        {
            IdMovimiento = Guid.NewGuid();
            IdInventario = idInventario;
            TipoMovimiento = tipoMovimiento;
            Cantidad = cantidad;
            CantidadAnterior = cantidadAnterior;
            
            // Calcular cantidad nueva según tipo de movimiento
            if (tipoMovimiento == "Entrada")
                CantidadNueva = cantidadAnterior + cantidad;
            else if (tipoMovimiento == "Salida")
                CantidadNueva = cantidadAnterior - cantidad;
            else // Ajuste
                CantidadNueva = cantidad;
            
            Observaciones = observaciones;
            FechaMovimiento = DateTime.Now;
        }

        /// <summary>
        /// Representación en string del movimiento.
        /// </summary>
        public override string ToString()
        {
            return $"{TipoMovimiento}: {Cantidad} L/Kg - {FechaMovimiento:dd/MM/yyyy HH:mm}";
        }
    }
}
