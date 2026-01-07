using SERVICES.DAL.Contratos;
using SERVICES.DAL.FactoryServices;
using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Logic
{
    /// <summary>
    /// Lógica de negocio para la gestión de proveedores.
    /// Coordina las operaciones entre la capa de presentación y la capa de acceso a datos.
    /// </summary>
    public class ProveedorLogic
    {
        private readonly IProveedorDAL _proveedorRepository;

        /// <summary>
        /// Constructor que inicializa el repositorio de proveedores usando el patrón Factory.
        /// </summary>
        public ProveedorLogic()
        {
            _proveedorRepository = DALFactory.ProveedorRepository;
        }

        /// <summary>
        /// Crea un nuevo proveedor en el sistema.
        /// Valida que el proveedor no exista previamente.
        /// </summary>
        /// <param name="proveedor">El proveedor a crear.</param>
        public void CrearProveedor(Proveedor proveedor)
        {
            // Validaciones de negocio
            ValidarProveedor(proveedor);

            // Verificar que el proveedor no exista previamente
            if (_proveedorRepository.ExisteProveedor(proveedor.CUIT, proveedor.DNI))
            {
                throw new Exception("Ya existe un proveedor registrado con el CUIT o DNI proporcionado.");
            }

            // Crear el proveedor en la base de datos
            _proveedorRepository.CreateProveedor(proveedor);
        }

        /// <summary>
        /// Actualiza los datos de un proveedor existente.
        /// Valida que el proveedor exista y que no se modifique el CUIT o DNI.
        /// </summary>
        /// <param name="proveedor">El proveedor con los datos actualizados.</param>
        public void ModificarProveedor(Proveedor proveedor)
        {
            // Validaciones de negocio
            ValidarProveedor(proveedor);

            // Verificar que el proveedor existe
            var proveedorExistente = _proveedorRepository.GetById(proveedor.IdProveedor);
            if (proveedorExistente == null)
            {
                throw new Exception("El proveedor no existe en el sistema.");
            }

            // Verificar que no se hayan modificado el CUIT o DNI
            if (proveedorExistente.CUIT != proveedor.CUIT || proveedorExistente.DNI != proveedor.DNI)
            {
                throw new Exception("No se puede modificar el CUIT o DNI del proveedor.");
            }

            // Actualizar el proveedor
            _proveedorRepository.UpdateProveedor(proveedor);
        }

        /// <summary>
        /// Deshabilita un proveedor en el sistema (cambio de estado a inactivo).
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor a deshabilitar.</param>
        public void DeshabilitarProveedor(Guid idProveedor)
        {
            // Verificar que el proveedor existe
            var proveedor = _proveedorRepository.GetById(idProveedor);
            if (proveedor == null)
            {
                throw new Exception("El proveedor no existe en el sistema.");
            }

            // Deshabilitar el proveedor
            _proveedorRepository.DisableProveedor(idProveedor);
        }

        /// <summary>
        /// Habilita un proveedor en el sistema (cambio de estado a activo).
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor a habilitar.</param>
        public void HabilitarProveedor(Guid idProveedor)
        {
            // Verificar que el proveedor existe
            var proveedor = _proveedorRepository.GetById(idProveedor);
            if (proveedor == null)
            {
                throw new Exception("El proveedor no existe en el sistema.");
            }

            // Habilitar el proveedor
            _proveedorRepository.EnableProveedor(idProveedor);
        }

        /// <summary>
        /// Obtiene todos los proveedores activos.
        /// </summary>
        /// <returns>Una lista de proveedores activos.</returns>
        public List<Proveedor> ObtenerProveedoresActivos()
        {
            return _proveedorRepository.GetProveedoresActivos();
        }

        /// <summary>
        /// Obtiene todos los proveedores (activos e inactivos).
        /// </summary>
        /// <returns>Una lista de todos los proveedores.</returns>
        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            return _proveedorRepository.GetAll();
        }

        /// <summary>
        /// Obtiene un proveedor por su ID.
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor.</param>
        /// <returns>El proveedor correspondiente, si existe.</returns>
        public Proveedor ObtenerProveedorPorId(Guid idProveedor)
        {
            return _proveedorRepository.GetById(idProveedor);
        }

        /// <summary>
        /// Filtra proveedores por criterios específicos.
        /// </summary>
        /// <param name="cuit">CUIT para filtrar (opcional).</param>
        /// <param name="razonSocial">Razón social para filtrar (opcional).</param>
        /// <param name="region">Región para filtrar (opcional).</param>
        /// <returns>Una lista de proveedores que coinciden con los criterios.</returns>
        public List<Proveedor> FiltrarProveedores(string cuit, string razonSocial, string region)
        {
            return _proveedorRepository.FiltrarProveedores(cuit, razonSocial, region);
        }

        /// <summary>
        /// Valida los datos de un proveedor.
        /// </summary>
        /// <param name="proveedor">El proveedor a validar.</param>
        private void ValidarProveedor(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
            {
                throw new ArgumentException("El nombre del proveedor es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(proveedor.CUIT))
            {
                throw new ArgumentException("El CUIT del proveedor es obligatorio.");
            }

            // Validar formato de CUIT (XX-XXXXXXXX-X)
            if (!ValidarFormatoCUIT(proveedor.CUIT))
            {
                throw new ArgumentException("El formato del CUIT no es válido. Debe tener 11 dígitos.");
            }

            if (!string.IsNullOrWhiteSpace(proveedor.Email) && !ValidarFormatoEmail(proveedor.Email))
            {
                throw new ArgumentException("El formato del correo electrónico no es válido.");
            }
        }

        /// <summary>
        /// Valida el formato de un CUIT.
        /// </summary>
        /// <param name="cuit">El CUIT a validar.</param>
        /// <returns>True si el formato es válido, false en caso contrario.</returns>
        private bool ValidarFormatoCUIT(string cuit)
        {
            // El CUIT ya viene limpio (sin guiones) desde el formulario
            // Debe tener 11 dígitos
            if (string.IsNullOrWhiteSpace(cuit) || cuit.Length != 11)
            {
                return false;
            }

            // Todos los caracteres deben ser dígitos
            return cuit.All(char.IsDigit);
        }

        /// <summary>
        /// Valida el formato de un email.
        /// </summary>
        /// <param name="email">El email a validar.</param>
        /// <returns>True si el formato es válido, false en caso contrario.</returns>
        private bool ValidarFormatoEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
