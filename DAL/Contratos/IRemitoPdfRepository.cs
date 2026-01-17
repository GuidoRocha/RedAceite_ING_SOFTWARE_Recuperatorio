using DOMAIN;
using System;
using System.Collections.Generic;

namespace DAL.Contratos
{
    /// <summary>
    /// Contrato para operaciones de acceso a datos de PDFs de remitos.
    /// Define métodos específicos para gestión de archivos PDF asociados a remitos.
    /// </summary>
    public interface IRemitoPdfRepository : IGenericRepository<RemitoPDF>
    {
        /// <summary>
        /// Guarda el registro de un PDF generado en la base de datos.
        /// </summary>
        /// <param name="remitoPdf">El registro del PDF a guardar.</param>
        void GuardarRegistroPdf(RemitoPDF remitoPdf);

        /// <summary>
        /// Obtiene el registro PDF asociado a un remito específico.
        /// </summary>
        /// <param name="idRemito">ID del remito.</param>
        /// <returns>El registro PDF si existe, null en caso contrario.</returns>
        RemitoPDF ObtenerPorIdRemito(Guid idRemito);

        /// <summary>
        /// Obtiene el registro PDF por nombre de archivo.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo PDF.</param>
        /// <returns>El registro PDF si existe, null en caso contrario.</returns>
        RemitoPDF ObtenerPorNombreArchivo(string nombreArchivo);

        /// <summary>
        /// Verifica si ya existe un PDF generado para un remito específico.
        /// </summary>
        /// <param name="idRemito">ID del remito.</param>
        /// <returns>True si existe un PDF, false en caso contrario.</returns>
        bool ExistePdfParaRemito(Guid idRemito);

        /// <summary>
        /// Obtiene todos los PDFs generados en un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial del rango.</param>
        /// <param name="fechaFin">Fecha final del rango.</param>
        /// <returns>Lista de registros PDF en el rango especificado.</returns>
        List<RemitoPDF> ObtenerPorRangoFechas(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Actualiza el hash MD5 de un PDF existente.
        /// Útil si se regenera el archivo y necesita actualizar su hash.
        /// </summary>
        /// <param name="idRemitoPdf">ID del registro PDF.</param>
        /// <param name="nuevoHashMD5">Nuevo hash MD5 del archivo.</param>
        void ActualizarHashMD5(Guid idRemitoPdf, string nuevoHashMD5);
    }
}
