using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic
{
    public static class SesionLogic
    {
        /// <summary>
        /// Obtiene los roles (familias) asociados al usuario logueado.
        /// </summary>
        /// <param name="usuario">Instancia de <see cref="Usuario"/> que representa al usuario logueado.</param>
        /// <returns>Cadena con los nombres de las familias (roles) del usuario o un mensaje indicando que no tiene rol asignado.</returns>
        public static string ObtenerRolesUsuario(Usuario usuario)
        {
            // Verificar que el usuario no sea nulo
            if (usuario == null)
            {
                return "Usuario no logueado";
            }

            // Obtener las familias (roles) del usuario
            List<Familia> familiasDelUsuario = usuario.GetFamilias();

            // Retornar una cadena con los nombres de las familias o "Sin rol asignado" si no tiene roles
            return familiasDelUsuario.Any()
                ? string.Join(", ", familiasDelUsuario.Select(f => f.Nombre))
                : "Sin rol asignado";
        }
    }
}
