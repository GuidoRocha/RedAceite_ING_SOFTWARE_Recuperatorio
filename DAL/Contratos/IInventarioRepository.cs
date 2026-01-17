using DOMAIN;
using System;
using System.Collections.Generic;

namespace DAL.Contratos
{
    /// <summary>
    /// Contrato para operaciones de acceso a datos del inventario de residuos.
    /// Define métodos específicos para gestión de stock y movimientos.
    /// </summary>
    public interface IInventarioRepository : IGenericRepository<Inventario>
    {
        /// <summary>
        /// Obtiene el inventario por tipo de residuo y estado.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="estado">Estado físico (Líquido o Sólido).</param>
        /// <returns>El inventario correspondiente o null si no existe.</returns>
        Inventario GetInventarioByTipoYEstado(string tipoResiduo, string estado);

        /// <summary>
        /// Registra un movimiento de entrada en el inventario.
        /// Actualiza automáticamente la cantidad disponible.
        /// </summary>
        /// <param name="idInventario">ID del inventario.</param>
        /// <param name="cantidad">Cantidad a ingresar.</param>
        /// <param name="idRemito">ID del remito asociado (opcional).</param>
        /// <param name="observaciones">Observaciones adicionales.</param>
        /// <param name="usuarioId">ID del usuario que realiza la operación.</param>
        void RegistrarEntrada(Guid idInventario, decimal cantidad, Guid? idRemito = null, 
            string observaciones = null, Guid? usuarioId = null);

        /// <summary>
        /// Registra un movimiento de salida en el inventario.
        /// Valida que exista stock suficiente antes de procesar.
        /// </summary>
        /// <param name="idInventario">ID del inventario.</param>
        /// <param name="cantidad">Cantidad a retirar.</param>
        /// <param name="observaciones">Observaciones adicionales.</param>
        /// <param name="usuarioId">ID del usuario que realiza la operación.</param>
        void RegistrarSalida(Guid idInventario, decimal cantidad, 
            string observaciones = null, Guid? usuarioId = null);

        /// <summary>
        /// Obtiene todos los movimientos de un inventario específico.
        /// </summary>
        /// <param name="idInventario">ID del inventario.</param>
        /// <returns>Lista de movimientos ordenados por fecha descendente.</returns>
        List<MovimientoInventario> GetMovimientosByInventario(Guid idInventario);

        /// <summary>
        /// Obtiene movimientos filtrados por rango de fechas.
        /// Útil para análisis de métricas y estadísticas.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial del rango.</param>
        /// <param name="fechaFin">Fecha final del rango.</param>
        /// <returns>Lista de movimientos en el rango especificado.</returns>
        List<MovimientoInventario> GetMovimientosByFechaRango(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Obtiene el historial de movimientos asociados a un remito específico.
        /// </summary>
        /// <param name="idRemito">ID del remito.</param>
        /// <returns>Lista de movimientos del remito.</returns>
        List<MovimientoInventario> GetMovimientosByRemito(Guid idRemito);

        /// <summary>
        /// Obtiene todos los inventarios activos del sistema.
        /// </summary>
        /// <returns>Lista de inventarios activos.</returns>
        List<Inventario> GetInventariosActivos();
    }
}
