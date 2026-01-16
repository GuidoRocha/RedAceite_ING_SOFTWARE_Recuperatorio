using SERVICES.DAL.Contratos;
using System;
using System.Configuration;
using SERVICES.DAL.Implementaciones.SQL;

namespace SERVICES.DAL.FactoryServices
{
    /// <summary>
    /// Fábrica de acceso a datos que implementa el patrón Factory y Singleton.
    /// Proporciona instancias únicas de repositorios SOLO para servicios cross-cutting (Usuarios, Familias).
    /// </summary>
    public class DALFactory
    {
        // Instancias singleton de los repositorios
        private static IUsuarioDAL _UsuarioRepository;

        private static readonly int backendType;
        private static readonly object _lock = new object();

        /// <summary>
        /// Constructor estático que inicializa el tipo de backend desde la configuración de la aplicación.
        /// </summary>
        static DALFactory()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        /// <summary>
        /// Obtiene una instancia del repositorio de usuario según el backend configurado.
        /// Implementa un patrón singleton y garantiza que solo se cree una instancia.
        /// </summary>
        public static IUsuarioDAL UsuarioRepository
        {
            get
            {
                if (_UsuarioRepository == null)
                {
                    lock (_lock)
                    {
                        if (_UsuarioRepository == null)
                        {
                            switch ((BackendType)backendType)
                            {
                                case BackendType.SqlServer:
                                    _UsuarioRepository = new UsuarioRepository();
                                    break;
                                default:
                                    throw new NotSupportedException("Backend no soportado.");
                            }
                        }
                    }
                }
                return _UsuarioRepository;
            }
        }

        /// <summary>
        /// Enumeración que define los tipos de backend compatibles para la fábrica.
        /// </summary>
        internal enum BackendType
        {
            /// <summary>
            /// Backend de base de datos SQL Server.
            /// </summary>
            SqlServer = 1
        }
    }
}