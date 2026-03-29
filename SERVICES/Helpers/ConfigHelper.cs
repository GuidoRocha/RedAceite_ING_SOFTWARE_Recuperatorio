using System;
using System.Configuration;
using System.IO;

namespace SERVICES.Helpers
{
    /// <summary>
    /// Helper para acceder a la configuraci�n de la aplicaci�n.
    /// Proporciona m�todos est�ticos para obtener valores de App.config.
    /// Las rutas configuradas se resuelven como relativas al directorio de ejecuci�n.
    /// </summary>
    public static class ConfigHelper
    {
        private static readonly string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Obtiene un valor de configuraci�n desde AppSettings.
        /// </summary>
        public static string ObtenerConfiguracion(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Resuelve una ruta de configuraci�n: si es relativa, la combina con el directorio base.
        /// </summary>
        private static string ResolverRuta(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
                return ruta;

            if (Path.IsPathRooted(ruta))
                return ruta;

            return Path.Combine(BaseDir, ruta);
        }

        /// <summary>
        /// Obtiene la ruta configurada para los PDFs de remitos.
        /// </summary>
        public static string ObtenerRutaPdfRemitos()
        {
            return ResolverRuta(ConfigurationManager.AppSettings["RutaPDFRemitos"]);
        }

        /// <summary>
        /// Obtiene la ruta configurada para el logo (unificado para remitos y manifiestos).
        /// </summary>
        public static string ObtenerRutaLogo()
        {
            return ResolverRuta(ConfigurationManager.AppSettings["RutaLogo"]);
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
            return ResolverRuta(ConfigurationManager.AppSettings["RutaPDFManifiestos"]);
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
