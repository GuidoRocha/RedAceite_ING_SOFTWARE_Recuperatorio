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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

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

            // Verificar si el nombre de usuario ya existe
            var existingUser = _usuarioRepository.GetUsuarioByUsername(usuario.UserName);
            if (existingUser != null)
            {
                throw new Exception($"El nombre de usuario '{usuario.UserName}' ya está en uso.");


            }

            usuario.Password = CryptographyService.HashMd5(plainPassword);
            _usuarioRepository.CreateUsuario(usuario);
        }
        /// <summary>
        /// Deshabilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a deshabilitar.</param>
        public void DisableUser(Guid idUsuario)
        {
            _usuarioRepository.DisableUsuario(idUsuario);
        }
        /// <summary>
        /// Habilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a habilitar.</param>
        public void EnabledUsuario(Guid idUsuario)
        {
            _usuarioRepository.EnabledUsuario(idUsuario);
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
        /// Envía un código OTP por SMS utilizando Twilio.
        /// </summary>
        /// <param name="toPhoneNumber">Número de teléfono del destinatario.</param>
        /// <param name="otp">Código OTP a enviar.</param>
        public void SendOTP(string toPhoneNumber, string otp)
        {
            const string accountSid = ""; // completar este campo con lo pago de Twilio
            const string authToken = "";  // completar este campo con lo pago de Twilio
            TwilioClient.Init(accountSid, authToken);

            try
            {
                // Validar que solo se ingresen números y tengan longitud razonable (ej: 10 a 12 dígitos)
                if (!toPhoneNumber.All(char.IsDigit) || toPhoneNumber.Length < 10 || toPhoneNumber.Length > 12)
                    throw new Exception("El número de teléfono ingresado no es válido.");

                string formattedPhoneNumber = $"+54{toPhoneNumber}";  // Siempre Argentina

                var message = MessageResource.Create(
                    body: $"Tu código de verificación es: {otp}. Tenés 20 minutos para ingresarlo en la aplicación.",
                    from: new PhoneNumber("+12708184665"), // Tu número Twilio
                    to: new PhoneNumber(formattedPhoneNumber)
                );

                Console.WriteLine($"Mensaje enviado con SID: {message.Sid}");
            }
            catch (Exception ex)
            {

                LoggerService.WriteException(ex);
                throw;
            }
        }
        /// <summary>
        /// Inicia el proceso de recuperación de contraseña enviando un OTP al usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        public bool StartPasswordRecovery(string username)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                string otp = GenerateOTP();
                DateTime expiry = DateTime.Now.AddMinutes(20);

                // Guardar OTP y fecha de expiración en la base de datos
                _usuarioRepository.SetOTP(usuario.IdUsuario, otp, expiry);

                // Enviar OTP por SMS
                // Solo Habilitar Si tenes Twilio Pago     SendOTP(usuario.PhoneNumber, otp);
                return true;
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



        public bool SendOTP_VerifyAPI(string phoneNumber)
        {
            const string accountSid = "AC9190d8bc1c6c85e0bc7e26158d5c589d"; // tu SID
            const string authToken = "4bb96f12a316fbff8183c4a224b36954";     // tu token
            const string serviceSid = "VA0920a5d12f1582f784eb33384de4a220";     // tu Service SID

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var verification = VerificationResource.Create(
                    to: $"+1{phoneNumber}",    // número completo sin el +54 (lo agregamos acá)
                    channel: "sms",
                    pathServiceSid: serviceSid
                );

                return verification.Status == "pending";
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show("Error Twilio: " + ex.Message);  // <-- Agregá esto temporalmente
                return false;
            }
        }

        public bool VerifyOTP_VerifyAPI(string phoneNumber, string code)
        {
            const string accountSid = "AC9190d8bc1c6c85e0bc7e26158d5c589d"; // tu SID
            const string authToken = "4bb96f12a316fbff8183c4a224b36954";     // tu token
            const string serviceSid = "VA0920a5d12f1582f784eb33384de4a220";     // tu Service SID

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var verificationCheck = VerificationCheckResource.Create(
                    to: $"+1{phoneNumber}",
                    code: code,
                    pathServiceSid: serviceSid
                );

                return verificationCheck.Status == "approved";
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                return false;
            }
        }

    }
}
