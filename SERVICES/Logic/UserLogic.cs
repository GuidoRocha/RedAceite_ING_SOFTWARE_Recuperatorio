using SERVICES.DAL.Contratos;
using SERVICES.DAL.FactoryServices;
using SERVICES.Dominio;
using SERVICES.DTO;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICES.Logic
{
    public class UserLogic
    {
        private readonly IUsuarioDAL _usuarioRepository;
        
        /// <summary>
        /// Constructor que inicializa el repositorio de usuarios.
        /// </summary>
        public UserLogic()
        {
            _usuarioRepository = DALFactory.UsuarioRepository;
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        public bool ValidateUser(string username, string password)
        {
            // Obtener el usuario por su nombre de usuario
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                // Verificar si el usuario está deshabilitado
                if (usuario.Estado == "0")
                {
                    // Usuario está deshabilitado
                    return false;
                }

                // Verificar la contraseña
                string hashedPassword = CryptographyService.HashMd5(password);
                return usuario.Password == hashedPassword;
            }
            return false;
        }

        /// <summary>
        /// Crea un nuevo usuario con la contraseña encriptada.
        /// </summary>
        /// <param name="usuario">Objeto de usuario a crear.</param>
        /// <param name="plainPassword">Contraseña en texto plano.</param>
        public void CreateUser(Usuario usuario, string plainPassword)
        {
            // Validar datos del usuario
            ValidarUsuario(usuario);

            // Verificar si el nombre de usuario ya existe
            if (_usuarioRepository.ExisteUsuarioPorUsername(usuario.UserName))
            {
                throw new Exception($"El nombre de usuario '{usuario.UserName}' ya está en uso.");
            }

            // Verificar si el DNI ya existe (solo si se proporcionó)
            if (!string.IsNullOrWhiteSpace(usuario.DNI) && _usuarioRepository.ExisteUsuarioPorDNI(usuario.DNI))
            {
                throw new Exception($"Ya existe un usuario registrado con el DNI '{usuario.DNI}'.");
            }

            // Encriptar contraseña
            usuario.Password = CryptographyService.HashMd5(plainPassword);
            
            // Crear usuario
            _usuarioRepository.CreateUsuario(usuario);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="usuario">Usuario con los datos actualizados.</param>
        public void UpdateUsuario(Usuario usuario)
        {
            // Validar datos del usuario (sin validar Username/DNI ya que no se pueden modificar)
            ValidarDatosPersonales(usuario);

            // Verificar que el usuario existe
            var usuarioExistente = _usuarioRepository.GetUsuarioById(usuario.IdUsuario);
            if (usuarioExistente == null)
            {
                throw new Exception("El usuario no existe en el sistema.");
            }

            // Actualizar usuario
            _usuarioRepository.UpdateUsuario(usuario);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Usuario encontrado o null si no existe.</returns>
        public Usuario GetUsuarioById(Guid idUsuario)
        {
            return _usuarioRepository.GetUsuarioById(idUsuario);
        }

        /// <summary>
        /// Obtiene todos los usuarios activos del sistema.
        /// </summary>
        /// <returns>Lista de usuarios activos.</returns>
        public List<Usuario> GetUsuariosActivos()
        {
            return _usuarioRepository.GetUsuariosActivos();
        }

        /// <summary>
        /// Deshabilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a deshabilitar.</param>
        public void DisableUser(Guid idUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe en el sistema.");
            }

            _usuarioRepository.DisableUsuario(idUsuario);
            
            // Registrar en log
            LoggerService.WriteLog(
                $"Usuario deshabilitado: {usuario.UserName} (DNI: {usuario.DNI})",
                System.Diagnostics.TraceLevel.Warning
            );
        }

        /// <summary>
        /// Habilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a habilitar.</param>
        public void EnabledUsuario(Guid idUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe en el sistema.");
            }

            _usuarioRepository.EnabledUsuario(idUsuario);
            
            // Registrar en log
            LoggerService.WriteLog(
                $"Usuario habilitado: {usuario.UserName} (DNI: {usuario.DNI})",
                System.Diagnostics.TraceLevel.Info
            );
        }

        /// <summary>
        /// Actualiza los accesos de un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="accesos">Lista de accesos a asignar.</param>
        public void UpdateUserAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            _usuarioRepository.UpdateAccesos(idUsuario, accesos);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>Usuario encontrado o null si no existe.</returns>
        public Usuario GetUsuarioByUsername(string username)
        {
            return _usuarioRepository.GetUsuarioByUsername(username);
        }

        /// <summary>
        /// Obtiene una lista de usuarios junto con sus familias (roles).
        /// </summary>
        /// <returns>Lista de objetos <see cref="UsuarioFamiliaDTO"/>.</returns>
        public List<UsuarioFamiliaDto> GetUsuariosConFamilias()
        {
            return _usuarioRepository.GetUsuariosConFamilias();
        }

        /// <summary>
        /// Crea una nueva patente.
        /// </summary>
        /// <param name="patente">Objeto de patente a crear.</param>
        public void CreatePatente(Patente patente)
        {
            _usuarioRepository.CreatePatente(patente);
        }

        /// <summary>
        /// Genera un código OTP de 6 dígitos.
        /// </summary>
        /// <returns>Código OTP como string.</returns>
        public string GenerateOTP()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Genera un número de 6 dígitos
        }

        /// <summary>
        /// Inicia el proceso de recuperación de contraseña generando un OTP para el usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>Tupla con el código OTP generado y el teléfono del usuario.</returns>
        public (string otp, string telefono) StartPasswordRecovery(string username)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                string otp = GenerateOTP();
                DateTime expiry = DateTime.Now.AddMinutes(20);

                // Guardar OTP y fecha de expiración en la base de datos
                _usuarioRepository.SetOTP(usuario.IdUsuario, otp, expiry);

                return (otp, usuario.Telefono);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        /// <summary>
        /// Valida un código OTP ingresado por el usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="otp">Código OTP ingresado.</param>
        /// <returns>True si el OTP es válido; de lo contrario, false.</returns>
        public bool ValidateOTP(string username, string otp)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsernameWithOTP(username);
            if (usuario != null && usuario.OTP == otp && usuario.OTPExpiry > DateTime.Now)
            {
                return true; // OTP válido
            }
            return false; // OTP inválido o expirado
        }

        /// <summary>
        /// Cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="newPassword">Nueva contraseña en texto plano.</param>
        public bool ChangePassword(string username, string newPassword)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                string hashedPassword = CryptographyService.HashMd5(newPassword);
                _usuarioRepository.UpdatePassword(usuario.IdUsuario, hashedPassword);
                return true;
            }
            else
            {
                throw new Exception("Contraseña no Cambiada");
            }
        }

        // ===== GESTIÓN DE FAMILIAS =====

        /// <summary>
        /// Asigna una familia a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="idFamilia">ID de la familia.</param>
        public void AsignarFamiliaAUsuario(Guid idUsuario, Guid idFamilia)
        {
            _usuarioRepository.AsignarFamiliaAUsuario(idUsuario, idFamilia);
            
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            LoggerService.WriteLog(
                $"Familia asignada al usuario: {usuario.UserName}",
                System.Diagnostics.TraceLevel.Info
            );
        }

        /// <summary>
        /// Remueve una familia de un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="idFamilia">ID de la familia.</param>
        public void RemoverFamiliaDeUsuario(Guid idUsuario, Guid idFamilia)
        {
            _usuarioRepository.RemoverFamiliaDeUsuario(idUsuario, idFamilia);
            
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            LoggerService.WriteLog(
                $"Familia removida del usuario: {usuario.UserName}",
                System.Diagnostics.TraceLevel.Info
            );
        }

        /// <summary>
        /// Obtiene las familias asignadas a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Lista de familias.</returns>
        public List<Familia> GetFamiliasByUsuario(Guid idUsuario)
        {
            return _usuarioRepository.GetFamiliasByUsuarioId(idUsuario);
        }

        // ===== GESTIÓN DE PATENTES =====

        /// <summary>
        /// Asigna una patente a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="idPatente">ID de la patente.</param>
        public void AsignarPatenteAUsuario(Guid idUsuario, Guid idPatente)
        {
            _usuarioRepository.AsignarPatenteAUsuario(idUsuario, idPatente);
            
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            LoggerService.WriteLog(
                $"Patente asignada al usuario: {usuario.UserName}",
                System.Diagnostics.TraceLevel.Info
            );
        }

        /// <summary>
        /// Remueve una patente de un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="idPatente">ID de la patente.</param>
        public void RemoverPatenteDeUsuario(Guid idUsuario, Guid idPatente)
        {
            _usuarioRepository.RemoverPatenteDeUsuario(idUsuario, idPatente);
            
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            LoggerService.WriteLog(
                $"Patente removida del usuario: {usuario.UserName}",
                System.Diagnostics.TraceLevel.Info
            );
        }

        /// <summary>
        /// Obtiene las patentes asignadas directamente a un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Lista de patentes.</returns>
        public List<Patente> GetPatentesByUsuario(Guid idUsuario)
        {
            return _usuarioRepository.GetPatentesByUsuarioId(idUsuario);
        }

        // ===== VALIDACIONES =====

        /// <summary>
        /// Valida los datos completos de un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a validar.</param>
        private void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.UserName))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Telefono))
            {
                throw new ArgumentException("El teléfono es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                throw new ArgumentException("El apellido es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                throw new ArgumentException("El email es obligatorio.");
            }

            // Validar formato de email
            if (!ValidarFormatoEmail(usuario.Email))
            {
                throw new ArgumentException("El formato del email no es válido.");
            }

            // Validar formato de DNI si se proporcionó
            if (!string.IsNullOrWhiteSpace(usuario.DNI) && !ValidarFormatoDNI(usuario.DNI))
            {
                throw new ArgumentException("El formato del DNI no es válido.");
            }
        }

        /// <summary>
        /// Valida solo los datos personales (para modificación, sin Username/DNI).
        /// </summary>
        /// <param name="usuario">Usuario a validar.</param>
        private void ValidarDatosPersonales(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Telefono))
            {
                throw new ArgumentException("El teléfono es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                throw new ArgumentException("El apellido es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                throw new ArgumentException("El email es obligatorio.");
            }

            // Validar formato de email
            if (!ValidarFormatoEmail(usuario.Email))
            {
                throw new ArgumentException("El formato del email no es válido.");
            }
        }

        /// <summary>
        /// Valida el formato de un email.
        /// </summary>
        /// <param name="email">Email a validar.</param>
        /// <returns>True si el formato es válido.</returns>
        private bool ValidarFormatoEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida el formato de un DNI.
        /// </summary>
        /// <param name="dni">DNI a validar.</param>
        /// <returns>True si el formato es válido.</returns>
        private bool ValidarFormatoDNI(string dni)
        {
            // DNI debe tener entre 7 y 8 dígitos
            if (string.IsNullOrWhiteSpace(dni) || dni.Length < 7 || dni.Length > 8)
            {
                return false;
            }

            // Todos los caracteres deben ser dígitos
            return dni.All(char.IsDigit);
        }
    }
}
