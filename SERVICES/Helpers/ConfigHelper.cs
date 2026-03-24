using System.Configuration;

namespace SERVICES.Helpers
{
    /// <summary>
    /// Helper para acceder a la configuraci�n de la aplicaci�n.
    /// Proporciona m�todos est�ticos para obtener valores de App.config.
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// Obtiene un valor de configuraci�n desde AppSettings.
        /// </summary>
        /// <param name="key">Clave de configuraci�n.</param>
        /// <returns>El valor de configuraci�n, o null si no existe.</returns>
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
        /// Obtiene la ruta configurada para el logo (unificado para remitos y manifiestos).
        /// </summary>
        public static string ObtenerRutaLogo()
        {
            return ConfigurationManager.AppSettings["RutaLogo"];
        }

        /// <summary>
        /// Obtiene la ruta configurada para el logo de remitos.
        /// </summary>
        public static string ObtenerRutaLogoRemito()
        {
            return ObtenerRutaLogo();
        }

        /// <summary>
        /// Obtiene la ruta configurada para los PDFs de manifiestos.
        /// </summary>
        public static string ObtenerRutaPdfManifiestos()
        {
            return ConfigurationManager.AppSettings["RutaPDFManifiestos"];
        }

        /// <summary>
        /// Obtiene la ruta configurada para el logo de manifiestos.
        /// </summary>
        public static string ObtenerRutaLogoManifiesto()
        {
            return ObtenerRutaLogo();
        }
    }
}
