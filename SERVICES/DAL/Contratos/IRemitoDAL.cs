using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Contratos
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Remito.
    /// Hereda de IGenericServiceDAL para operaciones CRUD básicas.
    /// </summary>
    public interface IRemitoDAL : IGenericServiceDAL<Remito>
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
    }
}
