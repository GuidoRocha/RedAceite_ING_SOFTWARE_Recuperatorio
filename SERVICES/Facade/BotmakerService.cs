using SERVICES.Logic;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio fachada para la integración con Botmaker (envío de mensajes vía WhatsApp).
    /// </summary>
    public static class BotmakerService
    {
        private static readonly BotmakerLogic _botmakerLogic = new BotmakerLogic();

        /// <summary>
        /// Envía un código OTP al usuario vía WhatsApp a través de Botmaker.
        /// </summary>
        /// <param name="telefono">Número de teléfono del usuario.</param>
        /// <param name="codigoOTP">Código OTP de 6 dígitos.</param>
        /// <returns>True si el envío fue exitoso, false en caso contrario.</returns>
        public static bool EnviarOTPWhatsApp(string telefono, string codigoOTP)
        {
            return _botmakerLogic.EnviarOTPWhatsApp(telefono, codigoOTP);
        }
    }
}
