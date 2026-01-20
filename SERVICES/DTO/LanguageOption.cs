using SERVICES.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICES.DTO
{


        public sealed class LanguageOption
        {
            private static string Path = ConfigurationManager.AppSettings["LanguagePath"];
            public static string Translate(string key)
            {
                string language = Thread.CurrentThread.CurrentUICulture.Name;
                string fileName = Path + language;

                using (StreamReader str = new StreamReader(fileName))
                {
                    while (!str.EndOfStream)
                    {
                        string line = str.ReadLine();
                        string[] columns = line.Split('=');

                        if (columns[0].ToLower() == key.ToLower())
                        {
                            return columns[1];
                        }
                    }
                }
                //No encontré la clave...
                throw new Exception("No encontré la palabra...");

            }

            public static void WriteKey(string key)
            {
                string language = Thread.CurrentThread.CurrentUICulture.Name;
            }

            public static List<string> GetLanguages()
            {
                return new List<string>();
            }



        

    }
}
