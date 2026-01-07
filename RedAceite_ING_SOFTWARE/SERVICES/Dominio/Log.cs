using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dominio
{
    /// <summary>
    /// Representa un registro de log del sistema.
    /// Contiene información sobre un evento, su nivel de severidad y la fecha de ocurrencia.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Mensaje descriptivo del evento registrado.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Nivel de traza del evento (Info, Warning, Error, etc.).
        /// </summary>
        public TraceLevel TraceLevel { get; set; }

        /// <summary>
        /// Fecha y hora en que ocurrió el evento.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Log"/>.
        /// </summary>
        /// <param name="message">Mensaje del evento.</param>
        /// <param name="traceLevel">Nivel de traza del evento (por defecto: Info).</param>
        /// <param name="date">Fecha del evento (si no se especifica, se toma la fecha actual).</param>
        public Log(string message, TraceLevel traceLevel = TraceLevel.Info, DateTime date = default)
        {
            Message = message;
            TraceLevel = traceLevel;
            Date = (date == default) ? DateTime.Now : date;
        }
    }
}
