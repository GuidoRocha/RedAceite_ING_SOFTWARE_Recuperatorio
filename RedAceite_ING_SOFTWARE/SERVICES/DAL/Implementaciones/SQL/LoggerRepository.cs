using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Implementaciones.SQL
{
    internal static class LoggerRepository
    {
        // Obtener las rutas de los archivos de log desde App.config
        private static string PathLogError => ConfigurationManager.AppSettings["PathLogError"];
        private static string PathLogInfo => ConfigurationManager.AppSettings["PathLogInfo"];
        // Obtener la cadena de conexión desde el App.config
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["LogDatabase"].ConnectionString;


        public static void WriteLog(Log log, Exception ex = null)
        {
            switch (log.TraceLevel)
            {

                case TraceLevel.Error:
                    string formatMessage = FormatMessage(log);
                    formatMessage += ex.StackTrace;

                    WriteToFile(PathLogError, formatMessage);
                    break;

                case TraceLevel.Warning:
                case TraceLevel.Verbose:
                case TraceLevel.Info:
                    //Aplicando particularidades para cada severidad
                    WriteToFile(PathLogInfo, FormatMessage(log));
                    break;
            }
        }

        private static string FormatMessage(Log log)
        {
            return $"{log.Date.ToString("dd/MM/yyyy HH:mm:ss")} [{log.TraceLevel}] : {log.Message}";
        }

        private static void WriteToFile(string path, string message)
        {
            //Definir política de depuración de logs (Corte)
            path = DateTime.Now.ToString("dd-MM-yyyy") + path;

            using (StreamWriter str = new StreamWriter(path, true))
            {
                str.WriteLine(message);
            }
        }

        public static void WriteLogToDatabase(Log log, Exception ex = null)
        {
            string query = @"INSERT INTO Log (Date, TraceLevel, Message, StackTrace) VALUES (@Date, @TraceLevel, @Message, @StackTrace)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", log.Date);
                    cmd.Parameters.AddWithValue("@TraceLevel", log.TraceLevel.ToString());
                    cmd.Parameters.AddWithValue("@Message", log.Message);
                    cmd.Parameters.AddWithValue("@StackTrace", ex?.StackTrace ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void WriteLogToFile(Log log, Exception ex = null)
        {
            // Selecciona la ruta dependiendo del nivel de log (Error o Info)
            string path = log.TraceLevel == TraceLevel.Error ? PathLogError : PathLogInfo;

            try
            {
                // Obtener el directorio del archivo
                string directoryPath = Path.GetDirectoryName(path);

                // Crear el directorio si no existe
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Obtener solo el nombre del archivo (error.log o info.log)
                string fileName = Path.GetFileName(path);

                // Agregar la fecha al nombre del archivo 
                string filePath = Path.Combine(directoryPath, $"{DateTime.Now:yyyy-MM-dd}_{fileName}");

                // Escribir en el archivo correspondiente
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(FormatLogMessage(log, ex));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al escribir en el archivo de log: {e.Message}");
                throw;
            }
        }

        private static string FormatLogMessage(Log log, Exception ex)
        {
            // Formatear el mensaje del log
            return $"{log.Date:yyyy-MM-dd HH:mm:ss} [{log.TraceLevel}] {log.Message} {ex?.StackTrace}";
        }


        public static void WriteLogPath(Log log, Exception ex = null)
        {
            // Podemos decidir si escribir el log en la base de datos, archivo o ambos
            WriteLogToDatabase(log, ex);
            WriteLogToFile(log, ex);
        }
    }
}
