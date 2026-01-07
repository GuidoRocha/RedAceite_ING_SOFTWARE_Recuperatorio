using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dominio
{
    /// <summary>
    /// Representa una familia de accesos compuesta por múltiples accesos (patentes u otras familias).
    /// Implementa el patrón Composite.
    /// </summary>
    public class Familia : Acceso
    {
        private List<Acceso> accesos = new List<Acceso>();

        /// <summary>
        /// Descripción de la familia de accesos.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Constructor que inicializa una nueva familia, opcionalmente con un acceso.
        /// </summary>
        /// <param name="acceso">Acceso inicial a agregar (puede ser null).</param>
        public Familia(Acceso acceso = null)
        {
            Id = Guid.NewGuid();
            if (acceso != null)
                accesos.Add(acceso);
        }

        /// <summary>
        /// Agrega un componente de acceso (Patente o Familia) a la familia actual.
        /// </summary>
        /// <param name="component">Componente de acceso a agregar.</param>
        public override void Add(Acceso component)
        {
            accesos.Add(component);
        }

        /// <summary>
        /// Elimina un componente de acceso de la familia.
        /// </summary>
        /// <param name="component">Componente de acceso a eliminar.</param>
        public override void Remove(Acceso component)
        {
            // Elimina el acceso coincidente por su Id
            accesos.RemoveAll(o => o.Id == component.Id);
        }

        /// <summary>
        /// Obtiene la cantidad de accesos hijos que contiene esta familia.
        /// </summary>
        /// <returns>Número de accesos hijos.</returns>
        public override int GetCount()
        {
            return Accesos.Count;
        }

        /// <summary>
        /// Lista de accesos que componen esta familia.
        /// </summary>
        public List<Acceso> Accesos
        {
            get { return accesos; }
        }
    }
}
