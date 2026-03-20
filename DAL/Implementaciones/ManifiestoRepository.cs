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
    /// Implementacion del repositorio de Manifiestos.
    /// Accede a la base de datos RedAceiteManifiesto.
    /// </summary>
    public class ManifiestoRepository : IManifiestoRepository
    {
        #region Manifiesto

        /// <summary>
        /// Crea un nuevo manifiesto en la base de datos.
        /// </summary>
        public void CrearManifiesto(Manifiesto manifiesto)
        {
            string sql = @"INSERT INTO Manifiesto
                (IdManifiesto, NumeroManifiesto, FechaManifiesto, NombreTransportista,
                 DomicilioTransportista, CantidadTotalRemitos, MontoTotal, Estado,
                 Observaciones, FechaCreacion, DigitoVerificador)
                VALUES
                (@IdManifiesto, @NumeroManifiesto, @FechaManifiesto, @NombreTransportista,
                 @DomicilioTransportista, @CantidadTotalRemitos, @MontoTotal, @Estado,
                 @Observaciones, @FechaCreacion, @DigitoVerificador)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", manifiesto.IdManifiesto),
                new SqlParameter("@NumeroManifiesto", (object)manifiesto.NumeroManifiesto ?? DBNull.Value),
                new SqlParameter("@FechaManifiesto", manifiesto.FechaManifiesto),
                new SqlParameter("@NombreTransportista", (object)manifiesto.NombreTransportista ?? DBNull.Value),
                new SqlParameter("@DomicilioTransportista", (object)manifiesto.DomicilioTransportista ?? DBNull.Value),
                new SqlParameter("@CantidadTotalRemitos", manifiesto.CantidadTotalRemitos),
                new SqlParameter("@MontoTotal", manifiesto.MontoTotal),
                new SqlParameter("@Estado", (object)manifiesto.Estado ?? DBNull.Value),
                new SqlParameter("@Observaciones", (object)manifiesto.Observaciones ?? DBNull.Value),
                new SqlParameter("@FechaCreacion", manifiesto.FechaCreacion),
                new SqlParameter("@DigitoVerificador", (object)manifiesto.DigitoVerificador ?? DBNull.Value)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters);
        }

        /// <summary>
        /// Obtiene un manifiesto por su ID.
        /// </summary>
        public Manifiesto GetManifiestoById(Guid idManifiesto)
        {
            string sql = "SELECT * FROM Manifiesto WHERE IdManifiesto = @IdManifiesto";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", idManifiesto)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters))
            {
                if (reader.Read())
                {
                    return MapearManifiesto(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene todos los manifiestos.
        /// </summary>
        public List<Manifiesto> GetAllManifiestos()
        {
            var manifiestos = new List<Manifiesto>();
            string sql = "SELECT * FROM Manifiesto ORDER BY FechaManifiesto DESC";

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos))
            {
                while (reader.Read())
                {
                    manifiestos.Add(MapearManifiesto(reader));
                }
            }

            return manifiestos;
        }

        /// <summary>
        /// Obtiene manifiestos por rango de fechas.
        /// </summary>
        public List<Manifiesto> GetManifiestosByFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            var manifiestos = new List<Manifiesto>();
            string sql = @"SELECT * FROM Manifiesto
                WHERE FechaManifiesto >= @FechaInicio AND FechaManifiesto <= @FechaFin
                ORDER BY FechaManifiesto DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", fechaInicio.Date),
                new SqlParameter("@FechaFin", fechaFin.Date)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters))
            {
                while (reader.Read())
                {
                    manifiestos.Add(MapearManifiesto(reader));
                }
            }

            return manifiestos;
        }

        /// <summary>
        /// Obtiene el manifiesto de una fecha especifica.
        /// </summary>
        public Manifiesto GetManifiestoByFecha(DateTime fecha)
        {
            string sql = "SELECT * FROM Manifiesto WHERE CAST(FechaManifiesto AS DATE) = @Fecha";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Fecha", fecha.Date)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters))
            {
                if (reader.Read())
                {
                    return MapearManifiesto(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Verifica si existe un manifiesto para una fecha.
        /// </summary>
        public bool ExisteManifiestoParaFecha(DateTime fecha)
        {
            string sql = "SELECT COUNT(*) FROM Manifiesto WHERE CAST(FechaManifiesto AS DATE) = @Fecha AND Estado != 'Anulado'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Fecha", fecha.Date)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters))
            {
                if (reader.Read())
                {
                    return reader.GetInt32(0) > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// Actualiza un manifiesto existente.
        /// </summary>
        public void UpdateManifiesto(Manifiesto manifiesto)
        {
            string sql = @"UPDATE Manifiesto SET
                NumeroManifiesto = @NumeroManifiesto,
                FechaManifiesto = @FechaManifiesto,
                NombreTransportista = @NombreTransportista,
                DomicilioTransportista = @DomicilioTransportista,
                CantidadTotalRemitos = @CantidadTotalRemitos,
                MontoTotal = @MontoTotal,
                Estado = @Estado,
                Observaciones = @Observaciones,
                DigitoVerificador = @DigitoVerificador
                WHERE IdManifiesto = @IdManifiesto";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", manifiesto.IdManifiesto),
                new SqlParameter("@NumeroManifiesto", (object)manifiesto.NumeroManifiesto ?? DBNull.Value),
                new SqlParameter("@FechaManifiesto", manifiesto.FechaManifiesto),
                new SqlParameter("@NombreTransportista", (object)manifiesto.NombreTransportista ?? DBNull.Value),
                new SqlParameter("@DomicilioTransportista", (object)manifiesto.DomicilioTransportista ?? DBNull.Value),
                new SqlParameter("@CantidadTotalRemitos", manifiesto.CantidadTotalRemitos),
                new SqlParameter("@MontoTotal", manifiesto.MontoTotal),
                new SqlParameter("@Estado", (object)manifiesto.Estado ?? DBNull.Value),
                new SqlParameter("@Observaciones", (object)manifiesto.Observaciones ?? DBNull.Value),
                new SqlParameter("@DigitoVerificador", (object)manifiesto.DigitoVerificador ?? DBNull.Value)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters);
        }

        /// <summary>
        /// Anula un manifiesto (soft delete).
        /// </summary>
        public void AnularManifiesto(Guid idManifiesto)
        {
            string sql = "UPDATE Manifiesto SET Estado = 'Anulado' WHERE IdManifiesto = @IdManifiesto";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", idManifiesto)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters);
        }

        /// <summary>
        /// Obtiene manifiestos para la pantalla de gestion.
        /// </summary>
        public List<ManifiestoGestionDto> GetManifiestosParaGestion()
        {
            var manifiestos = new List<ManifiestoGestionDto>();
            string sql = @"SELECT * FROM Manifiesto ORDER BY FechaManifiesto DESC";

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos))
            {
                while (reader.Read())
                {
                    manifiestos.Add(MapearManifiestoGestionDto(reader));
                }
            }

            return manifiestos;
        }

        /// <summary>
        /// Obtiene manifiestos filtrados para la pantalla de gestion.
        /// </summary>
        public List<ManifiestoGestionDto> GetManifiestosFiltradosParaGestion(
            DateTime? fechaInicio, DateTime? fechaFin, string estado)
        {
            var manifiestos = new List<ManifiestoGestionDto>();
            string sql = "SELECT * FROM Manifiesto WHERE 1=1";
            var parametersList = new List<SqlParameter>();

            if (fechaInicio.HasValue)
            {
                sql += " AND FechaManifiesto >= @FechaInicio";
                parametersList.Add(new SqlParameter("@FechaInicio", fechaInicio.Value.Date));
            }

            if (fechaFin.HasValue)
            {
                sql += " AND FechaManifiesto <= @FechaFin";
                parametersList.Add(new SqlParameter("@FechaFin", fechaFin.Value.Date));
            }

            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                sql += " AND Estado = @Estado";
                parametersList.Add(new SqlParameter("@Estado", estado));
            }

            sql += " ORDER BY FechaManifiesto DESC";

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parametersList.ToArray()))
            {
                while (reader.Read())
                {
                    manifiestos.Add(MapearManifiestoGestionDto(reader));
                }
            }

            return manifiestos;
        }

        #endregion

        #region ManifiestoDetalle

        /// <summary>
        /// Crea un detalle de manifiesto.
        /// </summary>
        public void CrearDetalle(ManifiestoDetalle detalle)
        {
            // Subtotal es columna COMPUTED PERSISTED en BD, no se incluye en el INSERT
            string sql = @"INSERT INTO ManifiestoDetalle
                (IdDetalle, IdManifiesto, IdRemito, NombreGenerador, TipoResiduo,
                 Cantidad, PrecioUnitario, Orden)
                VALUES
                (@IdDetalle, @IdManifiesto, @IdRemito, @NombreGenerador, @TipoResiduo,
                 @Cantidad, @PrecioUnitario, @Orden)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdDetalle", detalle.IdDetalle),
                new SqlParameter("@IdManifiesto", detalle.IdManifiesto),
                new SqlParameter("@IdRemito", detalle.IdRemito),
                new SqlParameter("@NombreGenerador", (object)detalle.NombreGenerador ?? DBNull.Value),
                new SqlParameter("@TipoResiduo", (object)detalle.TipoResiduo ?? DBNull.Value),
                new SqlParameter("@Cantidad", detalle.Cantidad),
                new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                new SqlParameter("@Orden", detalle.Orden)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters);
        }

        /// <summary>
        /// Obtiene los detalles de un manifiesto.
        /// </summary>
        public List<ManifiestoDetalle> GetDetallesByManifiesto(Guid idManifiesto)
        {
            var detalles = new List<ManifiestoDetalle>();
            string sql = "SELECT * FROM ManifiestoDetalle WHERE IdManifiesto = @IdManifiesto ORDER BY Orden";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", idManifiesto)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters))
            {
                while (reader.Read())
                {
                    detalles.Add(MapearDetalle(reader));
                }
            }

            return detalles;
        }

        /// <summary>
        /// Elimina todos los detalles de un manifiesto.
        /// </summary>
        public void EliminarDetallesByManifiesto(Guid idManifiesto)
        {
            string sql = "DELETE FROM ManifiestoDetalle WHERE IdManifiesto = @IdManifiesto";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdManifiesto", idManifiesto)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringManifiestos, parameters);
        }

        #endregion

        #region PrecioResiduo

        /// <summary>
        /// Crea un nuevo precio de residuo.
        /// </summary>
        public void CrearPrecio(PrecioResiduo precio)
        {
            string sql = @"INSERT INTO PrecioResiduo
                (IdPrecio, TipoResiduo, PrecioUnitario, FechaVigencia, Activo)
                VALUES
                (@IdPrecio, @TipoResiduo, @PrecioUnitario, @FechaVigencia, @Activo)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPrecio", precio.IdPrecio),
                new SqlParameter("@TipoResiduo", (object)precio.TipoResiduo ?? DBNull.Value),
                new SqlParameter("@PrecioUnitario", precio.PrecioUnitario),
                new SqlParameter("@FechaVigencia", precio.FechaVigencia),
                new SqlParameter("@Activo", precio.Activo)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios, parameters);
        }

        /// <summary>
        /// Obtiene el precio activo para un tipo de residuo.
        /// </summary>
        public PrecioResiduo GetPrecioActivoPorTipo(string tipoResiduo)
        {
            string sql = "SELECT * FROM PrecioResiduo WHERE TipoResiduo = @TipoResiduo AND Activo = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TipoResiduo", tipoResiduo)
            };

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios, parameters))
            {
                if (reader.Read())
                {
                    return MapearPrecio(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene todos los precios (historial completo).
        /// </summary>
        public List<PrecioResiduo> GetAllPrecios()
        {
            var precios = new List<PrecioResiduo>();
            string sql = "SELECT * FROM PrecioResiduo ORDER BY TipoResiduo, FechaVigencia DESC";

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios))
            {
                while (reader.Read())
                {
                    precios.Add(MapearPrecio(reader));
                }
            }

            return precios;
        }

        /// <summary>
        /// Obtiene solo los precios activos.
        /// </summary>
        public List<PrecioResiduo> GetPreciosActivos()
        {
            var precios = new List<PrecioResiduo>();
            string sql = "SELECT * FROM PrecioResiduo WHERE Activo = 1 ORDER BY TipoResiduo";

            using (var reader = SqlHelper.ExecuteReaderWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios))
            {
                while (reader.Read())
                {
                    precios.Add(MapearPrecio(reader));
                }
            }

            return precios;
        }

        /// <summary>
        /// Actualiza un precio existente.
        /// </summary>
        public void UpdatePrecio(PrecioResiduo precio)
        {
            string sql = @"UPDATE PrecioResiduo SET
                TipoResiduo = @TipoResiduo,
                PrecioUnitario = @PrecioUnitario,
                FechaVigencia = @FechaVigencia,
                Activo = @Activo
                WHERE IdPrecio = @IdPrecio";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPrecio", precio.IdPrecio),
                new SqlParameter("@TipoResiduo", (object)precio.TipoResiduo ?? DBNull.Value),
                new SqlParameter("@PrecioUnitario", precio.PrecioUnitario),
                new SqlParameter("@FechaVigencia", precio.FechaVigencia),
                new SqlParameter("@Activo", precio.Activo)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios, parameters);
        }

        /// <summary>
        /// Desactiva el precio activo de un tipo de residuo.
        /// </summary>
        public void DesactivarPrecioActual(string tipoResiduo)
        {
            string sql = "UPDATE PrecioResiduo SET Activo = 0 WHERE TipoResiduo = @TipoResiduo AND Activo = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TipoResiduo", tipoResiduo)
            };

            SqlHelper.ExecuteNonQueryWithConnection(sql, CommandType.Text,
                SqlHelper.conStringPrecios, parameters);
        }

        #endregion

        #region Mapeo privado

        /// <summary>
        /// Mapea un SqlDataReader a un objeto Manifiesto.
        /// </summary>
        private Manifiesto MapearManifiesto(SqlDataReader reader)
        {
            return new Manifiesto
            {
                IdManifiesto = reader.GetGuid(reader.GetOrdinal("IdManifiesto")),
                NumeroManifiesto = reader.IsDBNull(reader.GetOrdinal("NumeroManifiesto")) ? null : reader.GetString(reader.GetOrdinal("NumeroManifiesto")),
                FechaManifiesto = reader.GetDateTime(reader.GetOrdinal("FechaManifiesto")),
                NombreTransportista = reader.IsDBNull(reader.GetOrdinal("NombreTransportista")) ? null : reader.GetString(reader.GetOrdinal("NombreTransportista")),
                DomicilioTransportista = reader.IsDBNull(reader.GetOrdinal("DomicilioTransportista")) ? null : reader.GetString(reader.GetOrdinal("DomicilioTransportista")),
                CantidadTotalRemitos = reader.GetInt32(reader.GetOrdinal("CantidadTotalRemitos")),
                MontoTotal = reader.GetDecimal(reader.GetOrdinal("MontoTotal")),
                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado")),
                Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones")),
                FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion")),
                DigitoVerificador = reader.IsDBNull(reader.GetOrdinal("DigitoVerificador")) ? null : reader.GetString(reader.GetOrdinal("DigitoVerificador"))
            };
        }

        /// <summary>
        /// Mapea un SqlDataReader a un ManifiestoGestionDto.
        /// </summary>
        private ManifiestoGestionDto MapearManifiestoGestionDto(SqlDataReader reader)
        {
            return new ManifiestoGestionDto
            {
                IdManifiesto = reader.GetGuid(reader.GetOrdinal("IdManifiesto")),
                NumeroManifiesto = reader.IsDBNull(reader.GetOrdinal("NumeroManifiesto")) ? null : reader.GetString(reader.GetOrdinal("NumeroManifiesto")),
                FechaManifiesto = reader.GetDateTime(reader.GetOrdinal("FechaManifiesto")),
                NombreTransportista = reader.IsDBNull(reader.GetOrdinal("NombreTransportista")) ? null : reader.GetString(reader.GetOrdinal("NombreTransportista")),
                CantidadTotalRemitos = reader.GetInt32(reader.GetOrdinal("CantidadTotalRemitos")),
                MontoTotal = reader.GetDecimal(reader.GetOrdinal("MontoTotal")),
                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado")),
                Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones")),
                FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion")),
                DigitoVerificador = reader.IsDBNull(reader.GetOrdinal("DigitoVerificador")) ? null : reader.GetString(reader.GetOrdinal("DigitoVerificador"))
            };
        }

        /// <summary>
        /// Mapea un SqlDataReader a un ManifiestoDetalle.
        /// </summary>
        private ManifiestoDetalle MapearDetalle(SqlDataReader reader)
        {
            return new ManifiestoDetalle
            {
                IdDetalle = reader.GetGuid(reader.GetOrdinal("IdDetalle")),
                IdManifiesto = reader.GetGuid(reader.GetOrdinal("IdManifiesto")),
                IdRemito = reader.GetGuid(reader.GetOrdinal("IdRemito")),
                NombreGenerador = reader.IsDBNull(reader.GetOrdinal("NombreGenerador")) ? null : reader.GetString(reader.GetOrdinal("NombreGenerador")),
                TipoResiduo = reader.IsDBNull(reader.GetOrdinal("TipoResiduo")) ? null : reader.GetString(reader.GetOrdinal("TipoResiduo")),
                Cantidad = reader.GetDecimal(reader.GetOrdinal("Cantidad")),
                PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario")),
                Subtotal = reader.GetDecimal(reader.GetOrdinal("Subtotal")),
                Orden = reader.GetInt32(reader.GetOrdinal("Orden"))
            };
        }

        /// <summary>
        /// Mapea un SqlDataReader a un PrecioResiduo.
        /// </summary>
        private PrecioResiduo MapearPrecio(SqlDataReader reader)
        {
            return new PrecioResiduo
            {
                IdPrecio = reader.GetGuid(reader.GetOrdinal("IdPrecio")),
                TipoResiduo = reader.IsDBNull(reader.GetOrdinal("TipoResiduo")) ? null : reader.GetString(reader.GetOrdinal("TipoResiduo")),
                PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario")),
                FechaVigencia = reader.GetDateTime(reader.GetOrdinal("FechaVigencia")),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
            };
        }

        #endregion
    }
}
