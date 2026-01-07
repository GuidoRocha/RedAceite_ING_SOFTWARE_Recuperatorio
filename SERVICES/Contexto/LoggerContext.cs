using SERVICES.DAL.Contratos;
using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Contexto
{
    public class LoggerContext
    {
        private ILoggerStrategy _loggerStrategy;


        /// <summary>
        /// Configura la estrategia de logging que se utilizará.
        /// </summary>
        /// <param name="strategy">La estrategia de logging que se establecerá.</param>
        // Permitir cambiar la estrategia 
        public void SetLoggerStrategy(ILoggerStrategy strategy)
        {
            _loggerStrategy = strategy;
        }

        /// <summary>
        /// Escribe un log utilizando la estrategia de logging configurada.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que contiene los detalles del log.</param>
        /// <param name="ex">La excepción opcional que puede incluirse en el log.</param>
        public void WriteLog(Log log, Exception ex = null)
        {
            _loggerStrategy.WriteLog(log, ex);
        }
    }
}
