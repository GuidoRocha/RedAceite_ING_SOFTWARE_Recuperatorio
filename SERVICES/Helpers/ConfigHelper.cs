using System.Configuration;

namespace SERVICES.Helpers
{
    /// <summary>
    /// Helper para acceder a la configuración de la aplicación.
    /// Proporciona métodos estáticos para obtener valores de App.config.
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// Obtiene un valor de configuración desde AppSettings.
        /// </summary>
        /// <param name="key">Clave de configuración.</param>
        /// <returns>El valor de configuración, o null si no existe.</returns>
        public static string ObtenerConfiguracion(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Obtiene la ruta configurada para los PDFs de remitos.
        /// </summary>
        public static string ObtenerRutaPdfRemitos()
        {
            return ConfigurationManager.AppSettings["RutaPDFRemitos"];
        }

        /// <summary>
        /// Obtiene la ruta configurada para el logo de remitos.
        /// </summary>
        public static string ObtenerRutaLogoRemito()
        {
            return ConfigurationManager.AppSettings["RutaLogoRemito"];
        }
    }
}
