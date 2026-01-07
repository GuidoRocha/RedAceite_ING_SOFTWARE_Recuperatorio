using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dominio
{
    /// <summary>
    /// Representa una patente (permiso individual) dentro del sistema de seguridad.
    /// Es un elemento hoja en el patrón Composite, por lo tanto no puede contener otros accesos.
    /// </summary>
    public class Patente : Acceso
    {
        /// <summary>
        /// Clave de datos asociada a la patente, utilizada para la verificación o control en UI.
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// No se permite agregar accesos a una patente, ya que es un nodo hoja.
        /// </summary>
        /// <param name="component">El acceso a agregar.</param>
        /// <exception cref="Exception">Siempre lanza una excepción al intentar agregar.</exception>
        public override void Add(Acceso component)
        {
            throw new Exception("No se puede agregar un elemento");
        }

        /// <summary>
        /// No se permite remover accesos de una patente, ya que es un nodo hoja.
        /// </summary>
        /// <param name="component">El acceso a remover.</param>
        /// <exception cref="Exception">Siempre lanza una excepción al intentar remover.</exception>
        public override void Remove(Acceso component)
        {
            throw new Exception("No se puede quitar un elemento");
        }

        /// <summary>
        /// Devuelve la cantidad de accesos hijos. En el caso de una patente, siempre es 0.
        /// </summary>
        /// <returns>0, ya que no contiene elementos hijos.</returns>
        public override int GetCount()
        {
            return 0;
        }
    }
}
