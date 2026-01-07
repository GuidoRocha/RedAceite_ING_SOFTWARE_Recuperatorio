using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Contratos
{
    public interface IGenericServiceDAL<U>
    {
        /// <summary>
        /// Agrega una nueva entidad al sistema.
        /// </summary>
        /// <param name="obj">La entidad que se va a agregar.</param>
        void Add(U obj);

        /// <summary>
        /// Actualiza una entidad existente en el sistema.
        /// </summary>
        /// <param name="obj">La entidad con los datos actualizados.</param>
        void Update(U obj);

        /// <summary>
        /// Elimina una entidad del sistema según su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a eliminar.</param>
        void Remove(Guid id);


        /// <summary>
        /// Obtiene una entidad por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a obtener.</param>
        /// <returns>La entidad correspondiente al identificador proporcionado.</returns>
        U GetById(Guid id);

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        /// <returns>Una lista de todas las entidades.</returns>
        List<U> GetAll();
    }
}
