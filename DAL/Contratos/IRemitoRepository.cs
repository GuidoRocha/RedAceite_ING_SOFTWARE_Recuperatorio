using DOMAIN;
using System;
using System.Collections.Generic;

namespace DAL.Contratos
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Remito.
    /// Hereda de IGenericRepository para operaciones CRUD básicas.
    /// </summary>
    public interface IRemitoRepository : IGenericRepository<Remito>
    {
        /// <summary>
        /// Crea un nuevo remito en la base de datos.
        /// </summary>
        /// <param name="remito">El remito a crear.</param>
        void CreateRemito(Remito remito);

        /// <summary>
        /// Obtiene un remito por su identificador único.
        /// </summary>
        /// <param name="idRemito">El ID del remito.</param>
        /// <returns>El remito correspondiente, si existe.</returns>
        Remito GetRemitoById(Guid idRemito);

        /// <summary>
        /// Obtiene todos los remitos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de todos los remitos.</returns>
        List<Remito> GetAllRemitos();

        /// <summary>
        /// Obtiene los remitos filtrados por CUIT del generador.
        /// </summary>
        /// <param name="cuit">El CUIT del generador.</param>
        /// <returns>Una lista de remitos asociados al CUIT especificado.</returns>
        List<Remito> GetRemitosByCuit(string cuit);

        /// <summary>
        /// Obtiene los remitos creados en un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una lista de remitos dentro del rango de fechas.</returns>
        List<Remito> GetRemitosByFechaRango(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Anula un remito existente (soft delete).
        /// </summary>
        /// <param name="idRemito">El ID del remito a anular.</param>
        void AnularRemito(Guid idRemito);

        /// <summary>
        /// Obtiene todos los remitos con su información de PDF asociada (LEFT JOIN).
        /// Usado específicamente para la pantalla de gestión de remitos.
        /// </summary>
        /// <returns>Lista de DTOs con información completa de remitos y PDFs.</returns>
        List<RemitoGestionDto> GetRemitosConPdf();

        /// <summary>
        /// Obtiene remitos filtrados con su información de PDF asociada.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango (opcional, null para omitir).</param>
        /// <param name="fechaFin">Fecha de fin del rango (opcional, null para omitir).</param>
        /// <param name="cuit">CUIT del generador para filtrar (opcional, null o vacío para omitir).</param>
        /// <param name="tipoResiduo">Tipo de residuo para filtrar (opcional, null o vacío para omitir).</param>
        /// <returns>Lista filtrada de DTOs con información completa.</returns>
        List<RemitoGestionDto> GetRemitosFiltradosConPdf(DateTime? fechaInicio, DateTime? fechaFin, string cuit, string tipoResiduo);
    }
}
