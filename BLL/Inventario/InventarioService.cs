using DAL.Contratos;
using DAL.Implementaciones;
using DOMAIN;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// Servicio de lógica de negocio para la gestión de inventario de residuos.
    /// Coordina las operaciones entre la capa de presentación y la capa de acceso a datos.
    /// Incluye validaciones de negocio y cálculo de métricas.
    /// </summary>
    public class InventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        /// <summary>
        /// Constructor que inicializa el repositorio de inventario.
        /// </summary>
        public InventarioService()
        {
            _inventarioRepository = new InventarioRepository();
        }

        /// <summary>
        /// Constructor que permite inyectar una implementación específica del repositorio (para testing).
        /// </summary>
        /// <param name="inventarioRepository">Repositorio de inventario.</param>
        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        /// <summary>
        /// Registra una entrada de residuos al inventario desde un remito.
        /// Crea el inventario automáticamente si no existe.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="estado">Estado físico (Líquido o Sólido).</param>
        /// <param name="cantidad">Cantidad a ingresar.</param>
        /// <param name="idRemito">ID del remito asociado.</param>
        /// <param name="observaciones">Observaciones adicionales.</param>
        public void RegistrarEntradaDesdeRemito(string tipoResiduo, string estado, 
            decimal cantidad, Guid idRemito, string observaciones = null)
        {
            try
            {
                // Validaciones de negocio
                ValidarDatosInventario(tipoResiduo, estado, cantidad);

                // Obtener o crear inventario
                var inventario = _inventarioRepository.GetInventarioByTipoYEstado(tipoResiduo, estado);
                
                if (inventario == null)
                {
                    // Crear nuevo inventario si no existe
                    inventario = new Inventario(tipoResiduo, estado, 0);
                    _inventarioRepository.Add(inventario);
                    
                    LoggerService.WriteLog(
                        $"Inventario creado automáticamente: {tipoResiduo} - {estado}",
                        System.Diagnostics.TraceLevel.Info);
                }

                // Registrar entrada
                string observacionCompleta = $"Entrada desde Remito {idRemito}. {observaciones ?? ""}".Trim();
                _inventarioRepository.RegistrarEntrada(
                    inventario.IdInventario, 
                    cantidad, 
                    idRemito, 
                    observacionCompleta);

                LoggerService.WriteLog(
                    $"Entrada registrada en inventario: {cantidad} L/Kg de {tipoResiduo} ({estado}). Remito: {idRemito}", 
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al registrar entrada en inventario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Registra una salida de residuos del inventario (consumo simulado).
        /// Valida que exista stock suficiente.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="estado">Estado físico (Líquido o Sólido).</param>
        /// <param name="cantidad">Cantidad a retirar.</param>
        /// <param name="observaciones">Observaciones adicionales.</param>
        public void RegistrarSalida(string tipoResiduo, string estado, decimal cantidad, 
            string observaciones = null)
        {
            try
            {
                // Validaciones de negocio
                ValidarDatosInventario(tipoResiduo, estado, cantidad);

                // Obtener inventario
                var inventario = _inventarioRepository.GetInventarioByTipoYEstado(tipoResiduo, estado);
                
                if (inventario == null)
                {
                    throw new Exception($"No existe inventario para {tipoResiduo} ({estado}).");
                }

                // Validar stock disponible
                if (inventario.CantidadDisponible < cantidad)
                {
                    throw new Exception(
                        $"Stock insuficiente. Disponible: {inventario.CantidadDisponible} L/Kg, " +
                        $"Solicitado: {cantidad} L/Kg");
                }

                // Registrar salida
                _inventarioRepository.RegistrarSalida(inventario.IdInventario, cantidad, observaciones);

                LoggerService.WriteLog(
                    $"Salida registrada en inventario: {cantidad} L/Kg de {tipoResiduo} ({estado}). " +
                    $"Observaciones: {observaciones ?? "N/A"}", 
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene el inventario actual consolidado.
        /// </summary>
        /// <returns>Lista de todos los inventarios activos.</returns>
        public List<Inventario> ObtenerInventarioCompleto()
        {
            try
            {
                return _inventarioRepository.GetAll();
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al obtener inventario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el inventario específico por tipo y estado.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="estado">Estado físico (Líquido o Sólido).</param>
        /// <returns>El inventario correspondiente o null si no existe.</returns>
        public Inventario ObtenerInventarioPorTipoYEstado(string tipoResiduo, string estado)
        {
            try
            {
                return _inventarioRepository.GetInventarioByTipoYEstado(tipoResiduo, estado);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al obtener inventario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el historial de movimientos de un inventario.
        /// </summary>
        /// <param name="idInventario">ID del inventario.</param>
        /// <returns>Lista de movimientos ordenados por fecha.</returns>
        public List<MovimientoInventario> ObtenerMovimientos(Guid idInventario)
        {
            try
            {
                return _inventarioRepository.GetMovimientosByInventario(idInventario);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al obtener movimientos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene movimientos en un rango de fechas para análisis y métricas.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial del rango.</param>
        /// <param name="fechaFin">Fecha final del rango.</param>
        /// <returns>Lista de movimientos en el período especificado.</returns>
        public List<MovimientoInventario> ObtenerMovimientosPorFecha(
            DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                {
                    throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha de fin.");
                }

                return _inventarioRepository.GetMovimientosByFechaRango(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al obtener movimientos por fecha: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Calcula métricas de inventario para el período especificado.
        /// Útil para dashboards y análisis estadístico.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial del análisis.</param>
        /// <param name="fechaFin">Fecha final del análisis.</param>
        /// <returns>Objeto con las métricas calculadas.</returns>
        public MetricasInventario CalcularMetricas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var movimientos = ObtenerMovimientosPorFecha(fechaInicio, fechaFin);
                var inventarios = ObtenerInventarioCompleto();

                decimal totalEntradas = 0;
                decimal totalSalidas = 0;
                int cantidadMovimientos = movimientos.Count;

                foreach (var mov in movimientos)
                {
                    if (mov.TipoMovimiento == "Entrada")
                        totalEntradas += mov.Cantidad;
                    else if (mov.TipoMovimiento == "Salida")
                        totalSalidas += mov.Cantidad;
                }

                decimal stockActualTotal = 0;
                foreach (var inv in inventarios)
                {
                    stockActualTotal += inv.CantidadDisponible;
                }

                int diasPeriodo = (fechaFin - fechaInicio).Days;
                if (diasPeriodo == 0) diasPeriodo = 1; // Evitar división por cero

                return new MetricasInventario
                {
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    TotalEntradas = totalEntradas,
                    TotalSalidas = totalSalidas,
                    StockActual = stockActualTotal,
                    CantidadMovimientos = cantidadMovimientos,
                    PromedioEntradaDiaria = totalEntradas / diasPeriodo,
                    PromedioSalidaDiaria = totalSalidas / diasPeriodo
                };
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al calcular métricas: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene estadísticas resumidas del inventario actual.
        /// </summary>
        /// <returns>Objeto con estadísticas del sistema.</returns>
        public EstadisticasInventario ObtenerEstadisticas()
        {
            try
            {
                var inventarios = ObtenerInventarioCompleto();
                
                decimal stockAceite = inventarios
                    .Where(i => i.TipoResiduo == "Aceite")
                    .Sum(i => i.CantidadDisponible);

                decimal stockGrasa = inventarios
                    .Where(i => i.TipoResiduo == "Grasa")
                    .Sum(i => i.CantidadDisponible);

                decimal stockTotal = stockAceite + stockGrasa;

                // Obtener movimientos del último mes
                DateTime fechaInicio = DateTime.Now.AddMonths(-1);
                DateTime fechaFin = DateTime.Now;
                var movimientosRecientes = ObtenerMovimientosPorFecha(fechaInicio, fechaFin);

                int entradasMes = movimientosRecientes.Count(m => m.TipoMovimiento == "Entrada");
                int salidasMes = movimientosRecientes.Count(m => m.TipoMovimiento == "Salida");

                return new EstadisticasInventario
                {
                    StockTotalAceite = stockAceite,
                    StockTotalGrasa = stockGrasa,
                    StockTotal = stockTotal,
                    EntradasUltimoMes = entradasMes,
                    SalidasUltimoMes = salidasMes,
                    FechaActualizacion = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw new Exception($"Error al obtener estadísticas: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Valida los datos básicos de inventario según reglas de negocio.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo a validar.</param>
        /// <param name="estado">Estado físico a validar.</param>
        /// <param name="cantidad">Cantidad a validar.</param>
        private void ValidarDatosInventario(string tipoResiduo, string estado, decimal cantidad)
        {
            if (string.IsNullOrWhiteSpace(tipoResiduo))
                throw new ArgumentException("El tipo de residuo es obligatorio.");

            if (tipoResiduo != "Aceite" && tipoResiduo != "Grasa")
                throw new ArgumentException("El tipo de residuo debe ser 'Aceite' o 'Grasa'.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado es obligatorio.");

            if (estado != "Líquido" && estado != "Sólido")
                throw new ArgumentException("El estado debe ser 'Líquido' o 'Sólido'.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
        }
    }

    /// <summary>
    /// Clase para encapsular métricas calculadas del inventario en un período.
    /// </summary>
    public class MetricasInventario
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal TotalEntradas { get; set; }
        public decimal TotalSalidas { get; set; }
        public decimal StockActual { get; set; }
        public int CantidadMovimientos { get; set; }
        public decimal PromedioEntradaDiaria { get; set; }
        public decimal PromedioSalidaDiaria { get; set; }
    }

    /// <summary>
    /// Clase para encapsular estadísticas resumidas del inventario.
    /// </summary>
    public class EstadisticasInventario
    {
        public decimal StockTotalAceite { get; set; }
        public decimal StockTotalGrasa { get; set; }
        public decimal StockTotal { get; set; }
        public int EntradasUltimoMes { get; set; }
        public int SalidasUltimoMes { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
