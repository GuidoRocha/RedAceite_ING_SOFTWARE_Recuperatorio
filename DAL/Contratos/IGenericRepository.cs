using System;
using System.Collections.Generic;

namespace DAL.Contratos
{
    /// <summary>
    /// Interfaz genérica que define las operaciones CRUD básicas para cualquier entidad.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad con la que trabaja el repositorio.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Agrega una nueva entidad.
        /// </summary>
        /// <param name="entity">La entidad a agregar.</param>
        void Add(T entity);

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        void Remove(Guid id);

        /// <summary>
        /// Obtiene una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad.</param>
        /// <returns>La entidad correspondiente.</returns>
        T GetById(Guid id);

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        /// <returns>Una lista de todas las entidades.</returns>
        List<T> GetAll();
    }
}
