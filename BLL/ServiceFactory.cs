using DAL.Contratos;
using DAL.Implementaciones;
using System;

namespace BLL
{
    /// <summary>
    /// Fábrica centralizada de repositorios de negocio. Implementa el patrón Factory + Singleton.
    /// Proporciona instancias únicas de los repositorios utilizados por los servicios de la capa BLL.
    ///
    /// Nota: Los repositorios cross-cutting (Usuario, Familia) se gestionan en DALFactory (SERVICES).
    /// Esta factory cubre exclusivamente los repositorios del dominio de negocio.
    /// </summary>
    public static class ServiceFactory
    {
        // Instancias singleton de los repositorios
        private static IRemitoRepository _remitoRepository;
        private static IInventarioRepository _inventarioRepository;
        private static IProveedorRepository _proveedorRepository;
        private static IRemitoPdfRepository _remitoPdfRepository;
        private static IManifiestoRepository _manifiestoRepository;

        private static readonly object _lock = new object();

        /// <summary>
        /// Obtiene la instancia singleton del repositorio de remitos.
        /// </summary>
        public static IRemitoRepository RemitoRepository
        {
            get
            {
                if (_remitoRepository == null)
                {
                    lock (_lock)
                    {
                        if (_remitoRepository == null)
                        {
                            _remitoRepository = new RemitoRepository();
                        }
                    }
                }
                return _remitoRepository;
            }
        }

        /// <summary>
        /// Obtiene la instancia singleton del repositorio de inventario.
        /// </summary>
        public static IInventarioRepository InventarioRepository
        {
            get
            {
                if (_inventarioRepository == null)
                {
                    lock (_lock)
                    {
                        if (_inventarioRepository == null)
                        {
                            _inventarioRepository = new InventarioRepository();
                        }
                    }
                }
                return _inventarioRepository;
            }
        }

        /// <summary>
        /// Obtiene la instancia singleton del repositorio de proveedores.
        /// </summary>
        public static IProveedorRepository ProveedorRepository
        {
            get
            {
                if (_proveedorRepository == null)
                {
                    lock (_lock)
                    {
                        if (_proveedorRepository == null)
                        {
                            _proveedorRepository = new ProveedorRepository();
                        }
                    }
                }
                return _proveedorRepository;
            }
        }

        /// <summary>
        /// Obtiene la instancia singleton del repositorio de PDFs de remitos.
        /// </summary>
        public static IRemitoPdfRepository RemitoPdfRepository
        {
            get
            {
                if (_remitoPdfRepository == null)
                {
                    lock (_lock)
                    {
                        if (_remitoPdfRepository == null)
                        {
                            _remitoPdfRepository = new RemitoPdfRepository();
                        }
                    }
                }
                return _remitoPdfRepository;
            }
        }

        /// <summary>
        /// Obtiene la instancia singleton del repositorio de manifiestos.
        /// </summary>
        public static IManifiestoRepository ManifiestoRepository
        {
            get
            {
                if (_manifiestoRepository == null)
                {
                    lock (_lock)
                    {
                        if (_manifiestoRepository == null)
                        {
                            _manifiestoRepository = new ManifiestoRepository();
                        }
                    }
                }
                return _manifiestoRepository;
            }
        }
    }
}
