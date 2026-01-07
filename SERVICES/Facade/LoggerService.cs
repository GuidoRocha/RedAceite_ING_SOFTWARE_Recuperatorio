using SERVICES.Dominio;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio de logging encargado de registrar mensajes, eventos e
    /// información de errores del sistema mediante la lógica de <see cref="LoggerLogic"/>.
    /// </summary>
    public static class LoggerService
    {
        /// <summary>
        /// Escribe un log personalizado con posibilidad de incluir una excepción.
        /// </summary>
        /// <param name="log">Instancia de <see cref="Log"/> que contiene mensaje y nivel de traza.</param>
        /// <param name="ex">Excepción opcional asociada al evento.</param>
        public static void WriteLog(Log log, Exception ex = null)
        {
            LoggerLogic.WriteLog(log, ex);
        }

        /// <summary>
        /// Escribe un mensaje en el log con el nivel de traza especificado (por defecto: Info).
        /// </summary>
        /// <param name="message">Mensaje a registrar.</param>
        /// <param name="level">Nivel de traza (Info, Warning, Error, etc.).</param>
        public static void WriteLog(string message, TraceLevel level = TraceLevel.Info)
        {
            LoggerLogic.WriteLog(new Log(message, level));
        }

        /// <summary>
        /// Registra una excepción como error en el log.
        /// </summary>
        /// <param name="ex">Excepción a registrar.</param>
        public static void WriteException(Exception ex)
        {
            LoggerLogic.WriteLog(new Log(ex.Message, TraceLevel.Error), ex);
        }
    }
}
