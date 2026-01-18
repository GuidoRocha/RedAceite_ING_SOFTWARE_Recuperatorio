using DAL.Contratos;
using DAL.Helpers;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementaciones
{
    /// <summary>
    /// Implementación del repositorio de acceso a datos para la entidad Remito.
    /// Utiliza SQL Server como backend de almacenamiento.
    /// </summary>
    public class RemitoRepository : IRemitoRepository
    {
        /// <summary>
        /// Constructor por defecto del repositorio de remitos.
        /// </summary>
        public RemitoRepository()
        {
        }

        #region Métodos específicos de IRemitoRepository

        /// <summary>
        /// Crea un nuevo remito en la base de datos.
        /// </summary>
        /// <param name="remito">El remito a crear.</param>
        public void CreateRemito(Remito remito)
        {
            string query = @"INSERT INTO Remito 
                            (IdRemito, NombreTransportista, DomicilioTransportista, NombreGenerador, 
                             DomicilioPlanta, TipoResiduo, Cantidad, Estado, Cuit, NombreFantasia, 
                             Direccion, FechaCreacion, EstadoRemito, DigitoVerificador)
                            VALUES 
                            (@IdRemito, @NombreTransportista, @DomicilioTransportista, @NombreGenerador, 
                             @DomicilioPlanta, @TipoResiduo, @Cantidad, @Estado, @Cuit, @NombreFantasia, 
                             @Direccion, @FechaCreacion, @EstadoRemito, @DigitoVerificador)";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@IdRemito", remito.IdRemito),
                new SqlParameter("@NombreTransportista", remito.NombreTransportista),
                new SqlParameter("@DomicilioTransportista", remito.DomicilioTransportista),
                new SqlParameter("@NombreGenerador", remito.NombreGenerador),
                new SqlParameter("@DomicilioPlanta", remito.DomicilioPlanta),
                new SqlParameter("@TipoResiduo", remito.TipoResiduo),
                new SqlParameter("@Cantidad", remito.Cantidad),
                new SqlParameter("@Estado", remito.Estado),
                new SqlParameter("@Cuit", remito.Cuit),
                new SqlParameter("@NombreFantasia", remito.NombreFantasia),
                new SqlParameter("@Direccion", remito.Direccion),
                new SqlParameter("@FechaCreacion", remito.FechaCreacion),
                new SqlParameter("@EstadoRemito", remito.EstadoRemito),
                new SqlParameter("@DigitoVerificador", (object)remito.DigitoVerificador ?? DBNull.Value)
            );
        }

        /// <summary>
        /// Obtiene un remito por su identificador único.
        /// </summary>
        /// <param name="idRemito">El ID del remito.</param>
        /// <returns>El remito correspondiente, si existe.</returns>
        public Remito GetRemitoById(Guid idRemito)
        {
            Remito remito = null;

            string query = @"SELECT IdRemito, NombreTransportista, DomicilioTransportista, NombreGenerador, 
                                    DomicilioPlanta, TipoResiduo, Cantidad, Estado, Cuit, NombreFantasia, 
                                    Direccion, FechaCreacion, EstadoRemito, DigitoVerificador
                             FROM Remito 
                             WHERE IdRemito = @IdRemito";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@IdRemito", idRemito)))
            {
                if (reader.Read())
                {
                    remito = MapearRemito(reader);
                }
            }

            return remito;
        }

        /// <summary>
        /// Obtiene todos los remitos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de todos los remitos.</returns>
        public List<Remito> GetAllRemitos()
        {
            List<Remito> remitos = new List<Remito>();

            string query = @"SELECT IdRemito, NombreTransportista, DomicilioTransportista, NombreGenerador, 
                                    DomicilioPlanta, TipoResiduo, Cantidad, Estado, Cuit, NombreFantasia, 
                                    Direccion, FechaCreacion, EstadoRemito, DigitoVerificador
                             FROM Remito
                             ORDER BY FechaCreacion DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos))
            {
                while (reader.Read())
                {
                    remitos.Add(MapearRemito(reader));
                }
            }

            return remitos;
        }

        /// <summary>
        /// Obtiene los remitos filtrados por CUIT del generador.
        /// </summary>
        /// <param name="cuit">El CUIT del generador.</param>
        /// <returns>Una lista de remitos asociados al CUIT especificado.</returns>
        public List<Remito> GetRemitosByCuit(string cuit)
        {
            List<Remito> remitos = new List<Remito>();

            string query = @"SELECT IdRemito, NombreTransportista, DomicilioTransportista, NombreGenerador, 
                                    DomicilioPlanta, TipoResiduo, Cantidad, Estado, Cuit, NombreFantasia, 
                                    Direccion, FechaCreacion, EstadoRemito, DigitoVerificador
                             FROM Remito 
                             WHERE Cuit = @Cuit
                             ORDER BY FechaCreacion DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@Cuit", cuit)))
            {
                while (reader.Read())
                {
                    remitos.Add(MapearRemito(reader));
                }
            }

            return remitos;
        }

        /// <summary>
        /// Obtiene los remitos creados en un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una lista de remitos dentro del rango de fechas.</returns>
        public List<Remito> GetRemitosByFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Remito> remitos = new List<Remito>();

            string query = @"SELECT IdRemito, NombreTransportista, DomicilioTransportista, NombreGenerador, 
                                    DomicilioPlanta, TipoResiduo, Cantidad, Estado, Cuit, NombreFantasia, 
                                    Direccion, FechaCreacion, EstadoRemito, DigitoVerificador
                             FROM Remito 
                             WHERE FechaCreacion BETWEEN @FechaInicio AND @FechaFin
                             ORDER BY FechaCreacion DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin)))
            {
                while (reader.Read())
                {
                    remitos.Add(MapearRemito(reader));
                }
            }

            return remitos;
        }

        /// <summary>
        /// Anula un remito existente (soft delete).
        /// </summary>
        /// <param name="idRemito">El ID del remito a anular.</param>
        public void AnularRemito(Guid idRemito)
        {
            string query = "UPDATE Remito SET EstadoRemito = 'Anulado' WHERE IdRemito = @IdRemito";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@IdRemito", idRemito));
        }

        /// <summary>
        /// Obtiene todos los remitos con su información de PDF asociada (LEFT JOIN).
        /// Usado específicamente para la pantalla de gestión de remitos.
        /// </summary>
        public List<RemitoGestionDto> GetRemitosConPdf()
        {
            List<RemitoGestionDto> remitos = new List<RemitoGestionDto>();

            string query = @"SELECT 
                                R.IdRemito, R.FechaCreacion, R.NombreGenerador, R.Cuit, 
                                R.TipoResiduo, R.Cantidad, R.Estado, R.EstadoRemito,
                                R.NombreFantasia, R.Direccion, R.DomicilioPlanta,
                                R.NombreTransportista, R.DomicilioTransportista, R.DigitoVerificador,
                                P.IdRemitoPDF, P.NombreArchivo, P.FechaGeneracion, P.TamañoBytes, P.HashMD5
                             FROM Remito R
                             LEFT JOIN RemitoPDF P ON R.IdRemito = P.IdRemito
                             ORDER BY R.FechaCreacion DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos))
            {
                while (reader.Read())
                {
                    remitos.Add(MapearRemitoGestionDto(reader));
                }
            }

            return remitos;
        }

        /// <summary>
        /// Obtiene remitos filtrados con su información de PDF asociada.
        /// </summary>
        public List<RemitoGestionDto> GetRemitosFiltradosConPdf(DateTime? fechaInicio, DateTime? fechaFin, string cuit, string tipoResiduo)
        {
            List<RemitoGestionDto> remitos = new List<RemitoGestionDto>();
            List<SqlParameter> parametros = new List<SqlParameter>();

            string query = @"SELECT 
                                R.IdRemito, R.FechaCreacion, R.NombreGenerador, R.Cuit, 
                                R.TipoResiduo, R.Cantidad, R.Estado, R.EstadoRemito,
                                R.NombreFantasia, R.Direccion, R.DomicilioPlanta,
                                R.NombreTransportista, R.DomicilioTransportista, R.DigitoVerificador,
                                P.IdRemitoPDF, P.NombreArchivo, P.FechaGeneracion, P.TamañoBytes, P.HashMD5
                             FROM Remito R
                             LEFT JOIN RemitoPDF P ON R.IdRemito = P.IdRemito
                             WHERE 1=1";

            // Aplicar filtros dinámicamente
            if (fechaInicio.HasValue)
            {
                query += " AND R.FechaCreacion >= @FechaInicio";
                parametros.Add(new SqlParameter("@FechaInicio", fechaInicio.Value));
            }

            if (fechaFin.HasValue)
            {
                query += " AND R.FechaCreacion <= @FechaFin";
                parametros.Add(new SqlParameter("@FechaFin", fechaFin.Value));
            }

            if (!string.IsNullOrWhiteSpace(cuit))
            {
                query += " AND R.Cuit LIKE @Cuit";
                parametros.Add(new SqlParameter("@Cuit", $"%{cuit}%"));
            }

            if (!string.IsNullOrWhiteSpace(tipoResiduo))
            {
                query += " AND R.TipoResiduo = @TipoResiduo";
                parametros.Add(new SqlParameter("@TipoResiduo", tipoResiduo));
            }

            query += " ORDER BY R.FechaCreacion DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos, parametros.ToArray()))
            {
                while (reader.Read())
                {
                    remitos.Add(MapearRemitoGestionDto(reader));
                }
            }

            return remitos;
        }

        #endregion

        #region Métodos de IGenericRepository<Remito>

        /// <summary>
        /// Agrega un nuevo remito (implementación de IGenericRepository).
        /// </summary>
        /// <param name="entity">El remito a agregar.</param>
        public void Add(Remito entity)
        {
            CreateRemito(entity);
        }

        /// <summary>
        /// Actualiza un remito existente.
        /// </summary>
        /// <param name="entity">El remito con los datos actualizados.</param>
        public void Update(Remito entity)
        {
            string query = @"UPDATE Remito 
                            SET NombreTransportista = @NombreTransportista,
                                DomicilioTransportista = @DomicilioTransportista,
                                NombreGenerador = @NombreGenerador,
                                DomicilioPlanta = @DomicilioPlanta,
                                TipoResiduo = @TipoResiduo,
                                Cantidad = @Cantidad,
                                Estado = @Estado,
                                Cuit = @Cuit,
                                NombreFantasia = @NombreFantasia,
                                Direccion = @Direccion,
                                EstadoRemito = @EstadoRemito,
                                DigitoVerificador = @DigitoVerificador
                            WHERE IdRemito = @IdRemito";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@IdRemito", entity.IdRemito),
                new SqlParameter("@NombreTransportista", entity.NombreTransportista),
                new SqlParameter("@DomicilioTransportista", entity.DomicilioTransportista),
                new SqlParameter("@NombreGenerador", entity.NombreGenerador),
                new SqlParameter("@DomicilioPlanta", entity.DomicilioPlanta),
                new SqlParameter("@TipoResiduo", entity.TipoResiduo),
                new SqlParameter("@Cantidad", entity.Cantidad),
                new SqlParameter("@Estado", entity.Estado),
                new SqlParameter("@Cuit", entity.Cuit),
                new SqlParameter("@NombreFantasia", entity.NombreFantasia),
                new SqlParameter("@Direccion", entity.Direccion),
                new SqlParameter("@EstadoRemito", entity.EstadoRemito),
                new SqlParameter("@DigitoVerificador", (object)entity.DigitoVerificador ?? DBNull.Value)
            );
        }

        /// <summary>
        /// Elimina un remito por su ID (hard delete).
        /// </summary>
        /// <param name="id">El ID del remito a eliminar.</param>
        public void Remove(Guid id)
        {
            string query = "DELETE FROM Remito WHERE IdRemito = @IdRemito";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, SqlHelper.conStringRemitos,
                new SqlParameter("@IdRemito", id));
        }

        /// <summary>
        /// Obtiene un remito por su ID (implementación de IGenericRepository).
        /// </summary>
        /// <param name="id">El ID del remito.</param>
        /// <returns>El remito correspondiente.</returns>
        public Remito GetById(Guid id)
        {
            return GetRemitoById(id);
        }

        /// <summary>
        /// Obtiene todos los remitos (implementación de IGenericRepository).
        /// </summary>
        /// <returns>Una lista de todos los remitos.</returns>
        public List<Remito> GetAll()
        {
            return GetAllRemitos();
        }

        #endregion

        #region Métodos auxiliares

        /// <summary>
        /// Mapea un SqlDataReader a un objeto Remito.
        /// </summary>
        /// <param name="reader">El SqlDataReader con los datos del remito.</param>
        /// <returns>Un objeto Remito mapeado.</returns>
        private Remito MapearRemito(SqlDataReader reader)
        {
            return new Remito
            {
                IdRemito = reader.GetGuid(0),
                NombreTransportista = reader.GetString(1),
                DomicilioTransportista = reader.GetString(2),
                NombreGenerador = reader.GetString(3),
                DomicilioPlanta = reader.GetString(4),
                TipoResiduo = reader.GetString(5),
                Cantidad = reader.GetDecimal(6),
                Estado = reader.GetString(7),
                Cuit = reader.GetString(8),
                NombreFantasia = reader.GetString(9),
                Direccion = reader.GetString(10),
                FechaCreacion = reader.GetDateTime(11),
                EstadoRemito = reader.GetString(12),
                DigitoVerificador = reader.IsDBNull(13) ? null : reader.GetString(13)
            };
        }

        /// <summary>
        /// Mapea un SqlDataReader a un objeto RemitoGestionDto.
        /// Incluye datos del remito y su PDF asociado (LEFT JOIN).
        /// </summary>
        /// <param name="reader">El SqlDataReader con los datos combinados.</param>
        /// <returns>Un objeto RemitoGestionDto mapeado.</returns>
        private RemitoGestionDto MapearRemitoGestionDto(SqlDataReader reader)
        {
            return new RemitoGestionDto
            {
                // Campos del Remito
                IdRemito = reader.GetGuid(0),
                FechaCreacion = reader.GetDateTime(1),
                NombreGenerador = reader.GetString(2),
                Cuit = reader.GetString(3),
                TipoResiduo = reader.GetString(4),
                Cantidad = reader.GetDecimal(5),
                Estado = reader.GetString(6),
                EstadoRemito = reader.GetString(7),
                NombreFantasia = reader.GetString(8),
                Direccion = reader.GetString(9),
                DomicilioPlanta = reader.GetString(10),
                NombreTransportista = reader.GetString(11),
                DomicilioTransportista = reader.GetString(12),
                DigitoVerificador = reader.IsDBNull(13) ? null : reader.GetString(13),

                // Campos del RemitoPDF (pueden ser NULL por el LEFT JOIN)
                IdRemitoPDF = reader.IsDBNull(14) ? (Guid?)null : reader.GetGuid(14),
                NombreArchivo = reader.IsDBNull(15) ? null : reader.GetString(15),
                FechaGeneracionPdf = reader.IsDBNull(16) ? (DateTime?)null : reader.GetDateTime(16),
                TamañoBytes = reader.IsDBNull(17) ? (long?)null : reader.GetInt64(17),
                HashMD5 = reader.IsDBNull(18) ? null : reader.GetString(18)
            };
        }

        #endregion
    }
}
