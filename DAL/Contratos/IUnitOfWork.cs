using System;

namespace DAL.Contratos
{
    /// <summary>
    /// Interfaz que define el patrón Unit of Work.
    /// Coordina múltiples operaciones como una unidad atómica.
    /// Si todas las operaciones son exitosas, se confirma con Complete().
    /// Si ocurre un error, Dispose() ejecuta las compensaciones registradas en orden inverso.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Registra una acción compensatoria que se ejecutará si la unidad de trabajo falla.
        /// Las compensaciones se ejecutan en orden inverso al registro (LIFO).
        /// </summary>
        /// <param name="descripcion">Descripción del paso para logging.</param>
        /// <param name="compensacion">Acción que revierte la operación realizada.</param>
        void RegistrarCompensacion(string descripcion, Action compensacion);

        /// <summary>
        /// Marca la unidad de trabajo como completada exitosamente.
        /// Después de llamar a Complete(), Dispose() no ejecutará compensaciones.
        /// </summary>
        /// <returns>Cantidad de operaciones completadas.</returns>
        int Complete();
    }
}
