using SERVICES.Dominio;
using SERVICES.DTO;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio de fachada para operaciones relacionadas con usuarios,
    /// como autenticación, registro, acceso, recuperación de contraseña y asignación de permisos.
    /// </summary>
    public static class UserService
    {
        private static UserLogic _userLogic = new UserLogic();

        /// <summary>
        /// Verifica las credenciales del usuario para iniciar sesión.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>True si las credenciales son válidas, false en caso contrario.</returns>
        public static bool Login(string username, string password)
        {
            return _userLogic.ValidateUser(username, password);
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="telefono">Número de teléfono del usuario.</param>
        public static void Register(string username, string password, string telefono)
        {
            var usuario = new Usuario
            {
                UserName = username,
                PhoneNumber = telefono
            };
            _userLogic.CreateUser(usuario, password);
        }

        /// <summary>
        /// Crea una nueva patente (permiso) en el sistema.
        /// </summary>
        /// <param name="patente">Objeto <see cref="Patente"/> con los datos del permiso.</param>
        public static void CreatePatente(Patente patente)
        {
            _userLogic.CreatePatente(patente);
        }

        /// <summary>
        /// Desactiva un usuario del sistema (soft delete).
        /// </summary>
        /// <param name="idUsuario">ID del usuario a desactivar.</param>
        public static void DisableUser(Guid idUsuario)
        {
            _userLogic.DisableUser(idUsuario);
        }

        /// <summary>
        /// Habilita nuevamente un usuario previamente desactivado.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a habilitar.</param>
        public static void EnabledUsuario(Guid idUsuario)
        {
            _userLogic.EnabledUsuario(idUsuario);
        }

        /// <summary>
        /// Actualiza los accesos (familias y patentes) asignados a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="accesos">Lista de accesos a asignar.</param>
        public static void UpdateUserAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            _userLogic.UpdateUserAccesos(idUsuario, accesos);
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios registrados.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Usuario"/>.</returns>
        public static List<Usuario> GetAllUsuarios()
        {
            return _userLogic.GetAllUsuarios();
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario a buscar.</param>
        /// <returns>Objeto <see cref="Usuario"/> correspondiente, o null si no existe.</returns>
        public static Usuario GetUsuarioByUsername(string username)
        {
            return _userLogic.GetUsuarioByUsername(username);
        }

        /// <summary>
        /// Obtiene una lista de usuarios junto con sus familias asignadas.
        /// </summary>
        /// <returns>Lista de <see cref="UsuarioFamiliaDto"/>.</returns>
        public static List<UsuarioFamiliaDto> GetUsuariosConFamilias()
        {
            return _userLogic.GetUsuariosConFamilias();
        }

        /// <summary>
        /// Inicia el proceso de recuperación de contraseña para un usuario,
        /// enviando un código OTP por SMS.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        public static void StartPasswordRecovery(string username)
        {
            _userLogic.StartPasswordRecovery(username);
        }

        /// <summary>
        /// Valida el código OTP ingresado por el usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="otp">Código OTP recibido por el usuario.</param>
        /// <returns>True si el código es válido, false en caso contrario.</returns>
        public static bool ValidateOTP(string username, string otp)
        {
            return _userLogic.ValidateOTP(username, otp);
        }

        /// <summary>
        /// Cambia la contraseña del usuario luego de una recuperación exitosa.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="newPassword">Nueva contraseña.</param>
        public static void ChangePassword(string username, string newPassword)
        {
            _userLogic.ChangePassword(username, newPassword);
        }
    }
}
