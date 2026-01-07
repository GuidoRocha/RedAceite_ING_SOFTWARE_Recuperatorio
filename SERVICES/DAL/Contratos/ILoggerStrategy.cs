using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Contratos
{
    public interface ILoggerStrategy
    {
        /// <summary>
        /// Escribe un log utilizando la estrategia de logging definida.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que contiene los detalles del registro.</param>
        /// <param name="ex">La excepción opcional asociada al log, si corresponde.</param>
        void WriteLog(Log log, Exception ex = null);
    }
}
