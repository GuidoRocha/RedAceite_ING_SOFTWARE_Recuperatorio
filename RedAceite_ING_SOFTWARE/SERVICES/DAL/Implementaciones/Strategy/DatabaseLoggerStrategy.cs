using SERVICES.DAL.Contratos;
using SERVICES.DAL.Implementaciones.SQL;
using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Implementaciones.Strategy
{
    public class DatabaseLoggerStrategy : ILoggerStrategy
    {
        public void WriteLog(Log log, Exception ex = null)
        {
            LoggerRepository.WriteLogToDatabase(log, ex);
        }
    }
}
