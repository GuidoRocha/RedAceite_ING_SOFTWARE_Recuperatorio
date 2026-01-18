using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICES.DAL
{
    internal static class LanguageRepository
    {
        // Obtener las rutas desde el App.config
        private static string LanguagePath
        {
            get
            {
                string path = ConfigurationManager.AppSettings["LanguagePath"];
                
                // Si la ruta no es absoluta, combinarla con el directorio base de la aplicación
                if (!Path.IsPathRooted(path))
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                }
                
                return path;
            }
        }
        
        private static string UserLanguageConfigPath
        {
            get
            {
                string path = ConfigurationManager.AppSettings["UserLanguageConfigPath"];
                
                // Si la ruta no es absoluta, combinarla con el directorio base de la aplicación
                if (!Path.IsPathRooted(path))
                {
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                }
                
                // Asegurar que el directorio existe
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                return path;
            }
        }



        // Método para traducir una clave basada en el idioma actual
        public static string Translate(string key)
        {
            // Obtener el código de idioma actual (es-ES, en-US, etc.)
            string language = Thread.CurrentThread.CurrentUICulture.Name;

            // Construir el nombre completo del archivo basado en el idioma (language.es-ES, language.en-US)
            string fileName = Path.Combine(LanguagePath, $"language.{language}");

            // Verificar que el archivo de idioma existe
            if (!File.Exists(fileName))
            {
                // Si no existe, retornar la key original sin lanzar excepción
                return key;
            }

            // Leer el archivo y buscar la clave
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        
                        // Ignorar líneas vacías y comentarios
                        if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                        {
                            continue;
                        }

                        string[] columns = line.Split('=');
                        
                        if (columns.Length >= 2 && columns[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            // Retornar todo después del primer '=' para soportar valores con '='
                            return line.Substring(line.IndexOf('=') + 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Si hay error al leer el archivo, retornar la key original
                return key;
            }

            // Si no se encontró la traducción, retornar la key original
            return key;
        }

        public static void WriteKey(string key)
        {
            string language = Thread.CurrentThread.CurrentUICulture.Name;

        }

        public static List<string> GetLanguages()
        {
            return new List<string>();
        }



        // Método para guardar el idioma seleccionado en un archivo de configuración
        public static void SaveUserLanguage(string languageCode)
        {
            using (StreamWriter writer = new StreamWriter(UserLanguageConfigPath, false))  // Sobrescribe el archivo
            {
                writer.WriteLine(languageCode);  // Guarda el código del idioma
            }
        }

        // Método para cargar el idioma desde el archivo de configuración
        public static string LoadUserLanguage()
        {
            if (File.Exists(UserLanguageConfigPath))
            {
                using (StreamReader reader = new StreamReader(UserLanguageConfigPath))
                {
                    string languageCode = reader.ReadLine();
                    if (!string.IsNullOrEmpty(languageCode))
                    {
                        return languageCode;  // Retorna el idioma guardado
                    }
                }
            }

            // Si no existe el archivo o no tiene un valor retorna "es-ES" como idioma predeterminado
            return "es-ES";
        }




    }
}
