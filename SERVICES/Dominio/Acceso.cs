using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dominio
{
    /// <summary>
    /// Clase base abstracta que representa un componente de acceso dentro del sistema de permisos.
    /// Puede ser una patente (hoja) o una familia de accesos (composite).
    /// </summary>
    public abstract class Acceso
    {
        /// <summary>
        /// Identificador único del acceso.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del acceso (puede representar una patente o familia).
        /// </summary>
        public string Nombre { get; set; }


        /// <summary>
        /// Método abstracto para agregar un subcomponente de acceso.
        /// Solo tiene implementación en clases composite (como Familia).
        /// </summary>
        /// <param name="component">Componente de acceso a agregar.</param>
        public abstract void Add(Acceso component);

        /// <summary>
        /// Método abstracto para remover un subcomponente de acceso.
        /// Solo tiene implementación en clases composite (como Familia).
        /// </summary>
        /// <param name="component">El componente de acceso a eliminar.</param>
        public abstract void Remove(Acceso component);

        /// <summary>
        /// Devuelve la cantidad de subcomponentes que contiene este acceso.
        /// Las hojas (como Patente) devuelven 0.
        /// </summary>
        /// <returns>Número de accesos hijos.</returns>
        public abstract int GetCount();
    }
}
