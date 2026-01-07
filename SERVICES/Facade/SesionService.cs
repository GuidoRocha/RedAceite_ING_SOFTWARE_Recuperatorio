using SERVICES.Dominio;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio encargado de mantener la sesión del usuario logueado en el sistema.
    /// Proporciona acceso global al usuario actual y operaciones básicas como logout.
    /// </summary>
    public static class SesionService
    {
        private static Usuario _usuarioLogueado;

        /// <summary>
        /// Obtiene o establece el usuario actualmente logueado en la sesión.
        /// </summary>
        public static Usuario UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }

        /// <summary>
        /// Limpia la sesión actual (cierra sesión del usuario).
        /// </summary>
        public static void ClearSession()
        {
            _usuarioLogueado = null;
        }

        /// <summary>
        /// Obtiene una cadena con los nombres de los roles (familias) asignados al usuario actual.
        /// </summary>
        /// <returns>Cadena con los roles del usuario logueado.</returns>
        public static string ObtenerRolesUsuario()
        {
            return SesionLogic.ObtenerRolesUsuario(_usuarioLogueado);
        }
    }
}
