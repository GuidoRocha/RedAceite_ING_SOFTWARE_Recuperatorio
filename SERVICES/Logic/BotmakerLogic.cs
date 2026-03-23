using Newtonsoft.Json;
using SERVICES.Facade;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace SERVICES.Logic
{
    /// <summary>
    /// Lógica de integración con la API de Botmaker para envío de mensajes vía WhatsApp.
    /// </summary>
    public class BotmakerLogic
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Envía un código OTP al usuario vía WhatsApp a través de la API de Botmaker.
        /// </summary>
        /// <param name="telefono">Número de teléfono del usuario.</param>
        /// <param name="codigoOTP">Código OTP de 6 dígitos.</param>
        /// <returns>True si el envío fue exitoso, false en caso contrario.</returns>
        public bool EnviarOTPWhatsApp(string telefono, string codigoOTP)
        {
            string telefonoNormalizado = NormalizarTelefono(telefono);

            string apiUrl = ConfigurationManager.AppSettings["BotmakerApiUrl"];
            string accessToken = ConfigurationManager.AppSettings["BotmakerAccessToken"];
            string channelId = ConfigurationManager.AppSettings["BotmakerChannelId"];
            string intentName = ConfigurationManager.AppSettings["BotmakerIntentName"];

            var body = new
            {
                chat = new
                {
                    channelId = channelId,
                    contactId = telefonoNormalizado
                },
                intentIdOrName = intentName,
                variables = new
                {
                    codigo = codigoOTP,
                    numVar = "12345"
                }
            };

            string jsonBody = JsonConvert.SerializeObject(body);

            LoggerService.WriteLog(
                $"Botmaker API - Enviando OTP al teléfono: {telefonoNormalizado}",
                TraceLevel.Info);

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("access-token", accessToken);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = _httpClient.SendAsync(request).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    LoggerService.WriteLog(
                        $"Botmaker API - OTP enviado exitosamente al teléfono: {telefonoNormalizado}. Status: {(int)response.StatusCode}. Response: {responseBody}",
                        TraceLevel.Info);
                    return true;
                }
                else
                {
                    LoggerService.WriteLog(
                        $"Botmaker API - Error al enviar OTP al teléfono: {telefonoNormalizado}. Status: {(int)response.StatusCode}. Response: {responseBody}",
                        TraceLevel.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog(
                    $"Botmaker API - Excepción al enviar OTP al teléfono: {telefonoNormalizado}. Error: {ex.Message}",
                    TraceLevel.Error);
                LoggerService.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// Normaliza el número de teléfono al formato requerido por Botmaker (ej: 541150409728).
        /// Quita +, espacios, guiones y asegura el prefijo 54.
        /// </summary>
        /// <param name="telefono">Número de teléfono en cualquier formato.</param>
        /// <returns>Número normalizado con prefijo 54, sin caracteres especiales.</returns>
        public string NormalizarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return telefono;

            // Quitar +, espacios, guiones, paréntesis
            string limpio = telefono
                .Replace("+", "")
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");

            // Si no empieza con 54, agregar el prefijo
            if (!limpio.StartsWith("54"))
            {
                limpio = "54" + limpio;
            }

            return limpio;
        }
    }
}
