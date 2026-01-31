using SERVICES.Domain.Exceptions;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace SERVICES.DAL.Implementations
{
    /// <summary>
    /// Acceso a traducciones (archivos key=value por cultura).
    /// </summary>
    public sealed class LanguageRepository
    {
        public static string Translate(string key)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name;
            var basePath = ConfigurationManager.AppSettings["LanguagePath"];
            var fileName = (basePath ?? string.Empty) + culture;

            // Se lee desde el output del exe (config resuelve desde el proceso host: UI).
            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var trimmed = line.Trim();
                    if (trimmed.StartsWith("#"))
                        continue;

                    int idx = trimmed.IndexOf('=');
                    if (idx <= 0)
                        continue; // línea inválida

                    var fileKey = trimmed.Substring(0, idx).Trim();
                    var value = trimmed.Substring(idx + 1); // soporta '=' dentro del value

                    if (string.Equals(fileKey, key, System.StringComparison.OrdinalIgnoreCase))
                        return value;
                }
            }

            throw new WordNotFoundException(key);
        }
    }
}
