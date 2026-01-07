using SERVICES.DAL.Contratos;
using SERVICES.DAL.Implementaciones.SQL.Helpers;
using SERVICES.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.DAL.Implementaciones.SQL
{
    /// <summary>
    /// Implementación del repositorio de proveedores para SQL Server.
    /// Gestiona las operaciones de acceso a datos para la entidad Proveedor.
    /// </summary>
    public class ProveedorRepository : IProveedorDAL
    {
        /// <summary>
        /// Crea un nuevo proveedor en la base de datos.
        /// </summary>
        public void CreateProveedor(Proveedor proveedor)
        {
            SqlHelper.ExecuteNonQueryWithConnection(
                @"INSERT INTO Proveedor (IdProveedor, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion) 
                  VALUES (@IdProveedor, @Nombre, @CUIT, @DNI, @Direccion, @Telefono, @Email, @RazonSocial, @Region, @Activo, @FechaCreacion)",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@IdProveedor", proveedor.IdProveedor),
                new SqlParameter("@Nombre", proveedor.Nombre),
                new SqlParameter("@CUIT", proveedor.CUIT),
                new SqlParameter("@DNI", proveedor.DNI ?? (object)DBNull.Value),
                new SqlParameter("@Direccion", proveedor.Direccion ?? (object)DBNull.Value),
                new SqlParameter("@Telefono", proveedor.Telefono ?? (object)DBNull.Value),
                new SqlParameter("@Email", proveedor.Email ?? (object)DBNull.Value),
                new SqlParameter("@RazonSocial", proveedor.RazonSocial ?? (object)DBNull.Value),
                new SqlParameter("@Region", proveedor.Region ?? (object)DBNull.Value),
                new SqlParameter("@Activo", proveedor.Activo),
                new SqlParameter("@FechaCreacion", proveedor.FechaCreacion)
            );
        }

        /// <summary>
        /// Obtiene un proveedor por su CUIT.
        /// </summary>
        public Proveedor GetProveedorByCUIT(string cuit)
        {
            Proveedor proveedor = null;

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                "SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor WHERE CUIT = @CUIT",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@CUIT", cuit)))
            {
                if (reader.Read())
                {
                    proveedor = MapProveedorFromReader(reader);
                }
            }

            return proveedor;
        }

        /// <summary>
        /// Obtiene un proveedor por su DNI.
        /// </summary>
        public Proveedor GetProveedorByDNI(string dni)
        {
            Proveedor proveedor = null;

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                "SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor WHERE DNI = @DNI",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@DNI", dni)))
            {
                if (reader.Read())
                {
                    proveedor = MapProveedorFromReader(reader);
                }
            }

            return proveedor;
        }

        /// <summary>
        /// Deshabilita un proveedor.
        /// </summary>
        public void DisableProveedor(Guid idProveedor)
        {
            SqlHelper.ExecuteNonQueryWithConnection(
                "UPDATE Proveedor SET Activo = 0, FechaModificacion = @FechaModificacion WHERE IdProveedor = @IdProveedor",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@IdProveedor", idProveedor),
                new SqlParameter("@FechaModificacion", DateTime.Now)
            );
        }

        /// <summary>
        /// Habilita un proveedor.
        /// </summary>
        public void EnableProveedor(Guid idProveedor)
        {
            SqlHelper.ExecuteNonQueryWithConnection(
                "UPDATE Proveedor SET Activo = 1, FechaModificacion = @FechaModificacion WHERE IdProveedor = @IdProveedor",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@IdProveedor", idProveedor),
                new SqlParameter("@FechaModificacion", DateTime.Now)
            );
        }

        /// <summary>
        /// Actualiza los datos de un proveedor.
        /// </summary>
        public void UpdateProveedor(Proveedor proveedor)
        {
            SqlHelper.ExecuteNonQueryWithConnection(
                @"UPDATE Proveedor 
                  SET Nombre = @Nombre, 
                      Direccion = @Direccion, 
                      Telefono = @Telefono, 
                      Email = @Email, 
                      RazonSocial = @RazonSocial, 
                      Region = @Region,
                      FechaModificacion = @FechaModificacion
                  WHERE IdProveedor = @IdProveedor",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@IdProveedor", proveedor.IdProveedor),
                new SqlParameter("@Nombre", proveedor.Nombre),
                new SqlParameter("@Direccion", proveedor.Direccion ?? (object)DBNull.Value),
                new SqlParameter("@Telefono", proveedor.Telefono ?? (object)DBNull.Value),
                new SqlParameter("@Email", proveedor.Email ?? (object)DBNull.Value),
                new SqlParameter("@RazonSocial", proveedor.RazonSocial ?? (object)DBNull.Value),
                new SqlParameter("@Region", proveedor.Region ?? (object)DBNull.Value),
                new SqlParameter("@FechaModificacion", DateTime.Now)
            );
        }

        /// <summary>
        /// Obtiene todos los proveedores activos.
        /// </summary>
        public List<Proveedor> GetProveedoresActivos()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                "SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor WHERE Activo = 1 ORDER BY IdSimple",
                CommandType.Text,
                SqlHelper.conStringProveedores))
            {
                while (reader.Read())
                {
                    proveedores.Add(MapProveedorFromReader(reader));
                }
            }

            return proveedores;
        }

        /// <summary>
        /// Filtra proveedores por criterios específicos.
        /// </summary>
        public List<Proveedor> FiltrarProveedores(string cuit, string razonSocial, string region)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            StringBuilder query = new StringBuilder("SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor WHERE Activo = 1");
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(cuit))
            {
                query.Append(" AND CUIT LIKE @CUIT");
                parameters.Add(new SqlParameter("@CUIT", "%" + cuit + "%"));
            }

            if (!string.IsNullOrWhiteSpace(razonSocial))
            {
                query.Append(" AND RazonSocial LIKE @RazonSocial");
                parameters.Add(new SqlParameter("@RazonSocial", "%" + razonSocial + "%"));
            }

            if (!string.IsNullOrWhiteSpace(region))
            {
                query.Append(" AND Region LIKE @Region");
                parameters.Add(new SqlParameter("@Region", "%" + region + "%"));
            }

            query.Append(" ORDER BY IdSimple");

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query.ToString(),
                CommandType.Text,
                SqlHelper.conStringProveedores,
                parameters.ToArray()))
            {
                while (reader.Read())
                {
                    proveedores.Add(MapProveedorFromReader(reader));
                }
            }

            return proveedores;
        }

        /// <summary>
        /// Verifica si un proveedor ya existe por su CUIT o DNI.
        /// </summary>
        public bool ExisteProveedor(string cuit, string dni)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            StringBuilder query = new StringBuilder("SELECT COUNT(*) FROM Proveedor WHERE ");
            
            if (!string.IsNullOrWhiteSpace(cuit) && !string.IsNullOrWhiteSpace(dni))
            {
                query.Append("CUIT = @CUIT OR DNI = @DNI");
                parameters.Add(new SqlParameter("@CUIT", cuit));
                parameters.Add(new SqlParameter("@DNI", dni));
            }
            else if (!string.IsNullOrWhiteSpace(cuit))
            {
                query.Append("CUIT = @CUIT");
                parameters.Add(new SqlParameter("@CUIT", cuit));
            }
            else if (!string.IsNullOrWhiteSpace(dni))
            {
                query.Append("DNI = @DNI");
                parameters.Add(new SqlParameter("@DNI", dni));
            }
            else
            {
                return false;
            }

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query.ToString(),
                CommandType.Text,
                SqlHelper.conStringProveedores,
                parameters.ToArray()))
            {
                if (reader.Read())
                {
                    return reader.GetInt32(0) > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene todos los proveedores (activos e inactivos).
        /// </summary>
        public List<Proveedor> GetAll()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                "SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor ORDER BY IdSimple",
                CommandType.Text,
                SqlHelper.conStringProveedores))
            {
                while (reader.Read())
                {
                    proveedores.Add(MapProveedorFromReader(reader));
                }
            }

            return proveedores;
        }

        /// <summary>
        /// Obtiene un proveedor por su ID.
        /// </summary>
        public Proveedor GetById(Guid id)
        {
            Proveedor proveedor = null;

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                "SELECT IdProveedor, IdSimple, Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo, FechaCreacion, FechaModificacion FROM Proveedor WHERE IdProveedor = @IdProveedor",
                CommandType.Text,
                SqlHelper.conStringProveedores,
                new SqlParameter("@IdProveedor", id)))
            {
                if (reader.Read())
                {
                    proveedor = MapProveedorFromReader(reader);
                }
            }

            return proveedor;
        }

        /// <summary>
        /// Mapea un SqlDataReader a un objeto Proveedor.
        /// </summary>
        private Proveedor MapProveedorFromReader(SqlDataReader reader)
        {
            return new Proveedor
            {
                IdProveedor = reader.GetGuid(0),
                IdSimple = reader.GetInt32(1),
                Nombre = reader.GetString(2),
                CUIT = reader.GetString(3),
                DNI = reader.IsDBNull(4) ? null : reader.GetString(4),
                Direccion = reader.IsDBNull(5) ? null : reader.GetString(5),
                Telefono = reader.IsDBNull(6) ? null : reader.GetString(6),
                Email = reader.IsDBNull(7) ? null : reader.GetString(7),
                RazonSocial = reader.IsDBNull(8) ? null : reader.GetString(8),
                Region = reader.IsDBNull(9) ? null : reader.GetString(9),
                Activo = reader.GetBoolean(10),
                FechaCreacion = reader.GetDateTime(11),
                FechaModificacion = reader.IsDBNull(12) ? (DateTime?)null : reader.GetDateTime(12)
            };
        }

        // Métodos del IGenericServiceDAL que no se utilizan en esta implementación
        public void Add(Proveedor obj)
        {
            CreateProveedor(obj);
        }

        public void Update(Proveedor obj)
        {
            UpdateProveedor(obj);
        }

        public void Remove(Guid id)
        {
            DisableProveedor(id);
        }
    }
}
