using SERVICES.Dominio;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    public static class FamiliaService
    {
        private static readonly FamiliaLogic _familiaLogic = new FamiliaLogic();

        /// <summary>
        /// Crea una nueva familia con las patentes especificadas.
        /// </summary>
        /// <param name="nombreFamilia">Nombre de la familia.</param>
        /// <param name="patentes">Lista de patentes a incluir en la familia.</param>
        public static void CrearFamiliaConPatentes(string nombreFamilia, List<Patente> patentes)
        {
            var familia = new Familia { Nombre = nombreFamilia };
            foreach (var patente in patentes)
            {
                familia.Add(patente);
            }

            _familiaLogic.CrearFamiliaConPatentes(familia);
        }

        /// <summary>
        /// Asigna una familia de permisos a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <param name="familia">Familia a asignar.</param>
        public static void AsignarFamiliaAUsuario(Guid usuarioId, Familia familia)
        {
            _familiaLogic.AsignarFamiliaAUsuario(usuarioId, familia);
        }

        /// <summary>
        /// Actualiza la información y patentes asociadas a una familia existente.
        /// </summary>
        /// <param name="familia">Familia con datos actualizados.</param>
        public static void ActualizarFamilia(Familia familia)
        {
            _familiaLogic.ActualizarFamilia(familia);
        }

        /// <summary>
        /// Reemplaza las familias asignadas a un usuario con una nueva lista.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <param name="familias">Lista de nuevas familias a asignar.</param>
        public static void ActualizarFamiliasDeUsuario(Guid usuarioId, List<Familia> familias)
        {
            _familiaLogic.ActualizarFamiliasDeUsuario(usuarioId, familias);
        }

        /// <summary>
        /// Obtiene todas las familias registradas en el sistema.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Familia"/>.</returns>
        public static List<Familia> GetAllFamilias()
        {
            return _familiaLogic.GetAllFamilias();
        }

        /// <summary>
        /// Obtiene todas las patentes disponibles para ser asignadas.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Patente"/>.</returns>
        public static List<Patente> GetAllPatentes()
        {
            return _familiaLogic.GetAllPatentes();
        }
    }
}
