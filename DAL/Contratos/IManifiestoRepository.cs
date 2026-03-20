using DOMAIN;
using System;
using System.Collections.Generic;

namespace DAL.Contratos
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para Manifiestos.
    /// Cubre operaciones CRUD de Manifiesto, ManifiestoDetalle y PrecioResiduo.
    /// </summary>
    public interface IManifiestoRepository
    {
        // ===== MANIFIESTO =====

        /// <summary>
        /// Crea un nuevo manifiesto en la base de datos.
        /// </summary>
        /// <param name="manifiesto">El manifiesto a crear.</param>
        void CrearManifiesto(Manifiesto manifiesto);

        /// <summary>
        /// Obtiene un manifiesto por su identificador unico.
        /// </summary>
        /// <param name="idManifiesto">El ID del manifiesto.</param>
        /// <returns>El manifiesto correspondiente, o null si no existe.</returns>
        Manifiesto GetManifiestoById(Guid idManifiesto);

        /// <summary>
        /// Obtiene todos los manifiestos registrados.
        /// </summary>
        /// <returns>Lista de todos los manifiestos.</returns>
        List<Manifiesto> GetAllManifiestos();

        /// <summary>
        /// Obtiene manifiestos filtrados por rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Lista de manifiestos dentro del rango.</returns>
        List<Manifiesto> GetManifiestosByFechaRango(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Obtiene el manifiesto generado para una fecha especifica.
        /// </summary>
        /// <param name="fecha">Fecha del manifiesto.</param>
        /// <returns>El manifiesto del dia, o null si no existe.</returns>
        Manifiesto GetManifiestoByFecha(DateTime fecha);

        /// <summary>
        /// Verifica si ya existe un manifiesto para una fecha dada.
        /// </summary>
        /// <param name="fecha">Fecha a verificar.</param>
        /// <returns>True si existe, false en caso contrario.</returns>
        bool ExisteManifiestoParaFecha(DateTime fecha);

        /// <summary>
        /// Actualiza un manifiesto existente.
        /// </summary>
        /// <param name="manifiesto">El manifiesto con datos actualizados.</param>
        void UpdateManifiesto(Manifiesto manifiesto);

        /// <summary>
        /// Anula un manifiesto (soft delete).
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto a anular.</param>
        void AnularManifiesto(Guid idManifiesto);

        /// <summary>
        /// Obtiene manifiestos para la pantalla de gestion con datos de integridad.
        /// </summary>
        /// <returns>Lista de DTOs de gestion.</returns>
        List<ManifiestoGestionDto> GetManifiestosParaGestion();

        /// <summary>
        /// Obtiene manifiestos filtrados para la pantalla de gestion.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicio (opcional).</param>
        /// <param name="fechaFin">Fecha fin (opcional).</param>
        /// <param name="estado">Estado para filtrar (opcional).</param>
        /// <returns>Lista filtrada de DTOs de gestion.</returns>
        List<ManifiestoGestionDto> GetManifiestosFiltradosParaGestion(DateTime? fechaInicio, DateTime? fechaFin, string estado);

        // ===== MANIFIESTO DETALLE =====

        /// <summary>
        /// Crea un detalle de manifiesto en la base de datos.
        /// </summary>
        /// <param name="detalle">El detalle a crear.</param>
        void CrearDetalle(ManifiestoDetalle detalle);

        /// <summary>
        /// Obtiene todos los detalles de un manifiesto.
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto.</param>
        /// <returns>Lista de detalles del manifiesto.</returns>
        List<ManifiestoDetalle> GetDetallesByManifiesto(Guid idManifiesto);

        /// <summary>
        /// Elimina todos los detalles de un manifiesto (para regeneracion).
        /// </summary>
        /// <param name="idManifiesto">ID del manifiesto.</param>
        void EliminarDetallesByManifiesto(Guid idManifiesto);

        // ===== PRECIO RESIDUO =====

        /// <summary>
        /// Crea un nuevo registro de precio de residuo.
        /// </summary>
        /// <param name="precio">El precio a crear.</param>
        void CrearPrecio(PrecioResiduo precio);

        /// <summary>
        /// Obtiene el precio activo vigente para un tipo de residuo.
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite / Grasa).</param>
        /// <returns>El precio activo, o null si no hay configurado.</returns>
        PrecioResiduo GetPrecioActivoPorTipo(string tipoResiduo);

        /// <summary>
        /// Obtiene todos los precios (activos e inactivos) para historial.
        /// </summary>
        /// <returns>Lista de todos los precios.</returns>
        List<PrecioResiduo> GetAllPrecios();

        /// <summary>
        /// Obtiene todos los precios activos.
        /// </summary>
        /// <returns>Lista de precios activos.</returns>
        List<PrecioResiduo> GetPreciosActivos();

        /// <summary>
        /// Actualiza un precio existente.
        /// </summary>
        /// <param name="precio">El precio con datos actualizados.</param>
        void UpdatePrecio(PrecioResiduo precio);

        /// <summary>
        /// Desactiva el precio activo actual de un tipo de residuo
        /// (para poder activar uno nuevo).
        /// </summary>
        /// <param name="tipoResiduo">Tipo de residuo.</param>
        void DesactivarPrecioActual(string tipoResiduo);
    }
}
