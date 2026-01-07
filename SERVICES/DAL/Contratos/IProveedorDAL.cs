using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Contratos
{
    /// <summary>
    /// Interfaz de acceso a datos para la entidad Proveedor.
    /// Define las operaciones CRUD y consultas específicas para proveedores.
    /// </summary>
    public interface IProveedorDAL : IGenericServiceDAL<Proveedor>
    {
        /// <summary>
        /// Crea un nuevo proveedor en la base de datos.
        /// </summary>
        /// <param name="proveedor">El proveedor a crear.</param>
        void CreateProveedor(Proveedor proveedor);

        /// <summary>
        /// Obtiene un proveedor por su CUIT.
        /// </summary>
        /// <param name="cuit">El CUIT del proveedor.</param>
        /// <returns>El proveedor correspondiente, si existe.</returns>
        Proveedor GetProveedorByCUIT(string cuit);

        /// <summary>
        /// Obtiene un proveedor por su DNI.
        /// </summary>
        /// <param name="dni">El DNI del proveedor.</param>
        /// <returns>El proveedor correspondiente, si existe.</returns>
        Proveedor GetProveedorByDNI(string dni);

        /// <summary>
        /// Deshabilita un proveedor por su ID (cambio de estado a inactivo).
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor.</param>
        void DisableProveedor(Guid idProveedor);

        /// <summary>
        /// Habilita un proveedor por su ID (cambio de estado a activo).
        /// </summary>
        /// <param name="idProveedor">El ID del proveedor.</param>
        void EnableProveedor(Guid idProveedor);

        /// <summary>
        /// Actualiza los datos de un proveedor existente.
        /// </summary>
        /// <param name="proveedor">El proveedor con los datos actualizados.</param>
        void UpdateProveedor(Proveedor proveedor);

        /// <summary>
        /// Obtiene todos los proveedores activos.
        /// </summary>
        /// <returns>Una lista de proveedores activos.</returns>
        List<Proveedor> GetProveedoresActivos();

        /// <summary>
        /// Filtra proveedores por criterios específicos.
        /// </summary>
        /// <param name="cuit">CUIT para filtrar (opcional).</param>
        /// <param name="razonSocial">Razón social para filtrar (opcional).</param>
        /// <param name="region">Región para filtrar (opcional).</param>
        /// <returns>Una lista de proveedores que coinciden con los criterios.</returns>
        List<Proveedor> FiltrarProveedores(string cuit, string razonSocial, string region);

        /// <summary>
        /// Verifica si un proveedor ya existe por su CUIT o DNI.
        /// </summary>
        /// <param name="cuit">El CUIT del proveedor.</param>
        /// <param name="dni">El DNI del proveedor.</param>
        /// <returns>True si el proveedor ya existe, false en caso contrario.</returns>
        bool ExisteProveedor(string cuit, string dni);
    }
}
