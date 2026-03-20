using DAL.Contratos;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLL
{
    /// <summary>
    /// Implementación del patrón Unit of Work con compensaciones automáticas.
    /// Coordina operaciones multi-paso entre diferentes bases de datos.
    ///
    /// Uso:
    /// using (var uow = new UnitOfWork("NombreOperacion"))
    /// {
    ///     // Ejecutar paso 1
    ///     uow.RegistrarCompensacion("Paso1", () => { /* deshacer paso 1 */ });
    ///
    ///     // Ejecutar paso 2
    ///     uow.RegistrarCompensacion("Paso2", () => { /* deshacer paso 2 */ });
    ///
    ///     uow.Complete(); // Todo OK, no se compensará
    /// }
    /// // Si hubo excepción antes de Complete(), Dispose() compensa automáticamente
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly List<CompensacionRegistrada> _compensaciones;
        private readonly string _nombreOperacion;
        private bool _completado;
        private bool _disposed;

        /// <summary>
        /// Inicializa una nueva unidad de trabajo.
        /// </summary>
        /// <param name="nombreOperacion">Nombre descriptivo para logging (ej: "GenerarRemito").</param>
        public UnitOfWork(string nombreOperacion = "UnitOfWork")
        {
            _compensaciones = new List<CompensacionRegistrada>();
            _nombreOperacion = nombreOperacion;
            _completado = false;
            _disposed = false;

            LoggerService.WriteLog(
                $"[UnitOfWork:{_nombreOperacion}] Unidad de trabajo iniciada.",
                TraceLevel.Info);
        }

        /// <summary>
        /// Registra una acción compensatoria que se ejecutará si la unidad de trabajo falla.
        /// Las compensaciones se ejecutan en orden inverso al registro (LIFO).
        /// </summary>
        /// <param name="descripcion">Descripción del paso para logging.</param>
        /// <param name="compensacion">Acción que revierte la operación realizada.</param>
        public void RegistrarCompensacion(string descripcion, Action compensacion)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            if (compensacion == null)
                throw new ArgumentNullException(nameof(compensacion));

            _compensaciones.Add(new CompensacionRegistrada
            {
                Descripcion = descripcion,
                Accion = compensacion
            });

            LoggerService.WriteLog(
                $"[UnitOfWork:{_nombreOperacion}] Compensacion registrada: {descripcion} (total: {_compensaciones.Count})",
                TraceLevel.Verbose);
        }

        /// <summary>
        /// Marca la unidad de trabajo como completada exitosamente.
        /// Después de llamar a Complete(), Dispose() no ejecutará compensaciones.
        /// </summary>
        /// <returns>Cantidad de operaciones completadas.</returns>
        public int Complete()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(UnitOfWork));

            _completado = true;
            int totalPasos = _compensaciones.Count;

            LoggerService.WriteLog(
                $"[UnitOfWork:{_nombreOperacion}] Completada exitosamente ({totalPasos} pasos).",
                TraceLevel.Info);

            return totalPasos;
        }

        /// <summary>
        /// Libera los recursos. Si no se llamó a Complete(), ejecuta todas las compensaciones
        /// en orden inverso para revertir las operaciones realizadas.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            if (!_completado && _compensaciones.Count > 0)
            {
                LoggerService.WriteLog(
                    $"[UnitOfWork:{_nombreOperacion}] NO se completo. Ejecutando {_compensaciones.Count} compensacion(es)...",
                    TraceLevel.Warning);

                EjecutarCompensaciones();
            }
        }

        /// <summary>
        /// Ejecuta las compensaciones registradas en orden inverso (LIFO).
        /// Si una compensación falla, se loguea el error y se continúa con las demás.
        /// </summary>
        private void EjecutarCompensaciones()
        {
            int exitosas = 0;
            int fallidas = 0;

            for (int i = _compensaciones.Count - 1; i >= 0; i--)
            {
                var compensacion = _compensaciones[i];
                try
                {
                    LoggerService.WriteLog(
                        $"[UnitOfWork:{_nombreOperacion}] Compensando [{i + 1}/{_compensaciones.Count}]: {compensacion.Descripcion}",
                        TraceLevel.Warning);

                    compensacion.Accion();
                    exitosas++;

                    LoggerService.WriteLog(
                        $"[UnitOfWork:{_nombreOperacion}] Compensacion exitosa: {compensacion.Descripcion}",
                        TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    fallidas++;

                    LoggerService.WriteLog(
                        $"[UnitOfWork:{_nombreOperacion}] ERROR CRITICO en compensacion '{compensacion.Descripcion}': {ex.Message}",
                        TraceLevel.Error);
                    LoggerService.WriteException(ex);
                }
            }

            LoggerService.WriteLog(
                $"[UnitOfWork:{_nombreOperacion}] Compensaciones finalizadas. Exitosas: {exitosas}, Fallidas: {fallidas}",
                fallidas > 0 ? TraceLevel.Error : TraceLevel.Warning);
        }

        /// <summary>
        /// Estructura interna para almacenar una compensación con su descripción.
        /// </summary>
        private class CompensacionRegistrada
        {
            public string Descripcion { get; set; }
            public Action Accion { get; set; }
        }
    }
}
