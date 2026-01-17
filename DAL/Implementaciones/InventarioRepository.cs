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
    /// Implementación del repositorio de inventario de residuos.
    /// Gestiona las operaciones CRUD y de movimientos con transacciones para garantizar consistencia.
    /// </summary>
    public class InventarioRepository : IInventarioRepository
    {
        /// <summary>
        /// Constructor por defecto del repositorio de inventario.
        /// </summary>
        public InventarioRepository()
        {
        }

        #region Métodos específicos de IInventarioRepository

        /// <summary>
        /// Obtiene el inventario por tipo de residuo y estado.
        /// </summary>
        public Inventario GetInventarioByTipoYEstado(string tipoResiduo, string estado)
        {
            Inventario inventario = null;

            string query = @"SELECT IdInventario, TipoResiduo, CantidadDisponible, Estado, 
                                    FechaCreacion, FechaActualizacion, EstadoInventario
                             FROM Inventario 
                             WHERE TipoResiduo = @TipoResiduo AND Estado = @Estado 
                             AND EstadoInventario = 'Activo'";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario,
                new SqlParameter("@TipoResiduo", tipoResiduo),
                new SqlParameter("@Estado", estado)))
            {
                if (reader.Read())
                {
                    inventario = MapearInventario(reader);
                }
            }

            return inventario;
        }

        /// <summary>
        /// Registra un movimiento de entrada en el inventario.
        /// Usa transacción para garantizar consistencia entre inventario y movimiento.
        /// </summary>
        public void RegistrarEntrada(Guid idInventario, decimal cantidad, 
            Guid? idRemito = null, string observaciones = null, Guid? usuarioId = null)
        {
            // Obtener inventario actual
            var inventario = GetById(idInventario);
            if (inventario == null)
                throw new Exception("Inventario no encontrado.");

            decimal cantidadAnterior = inventario.CantidadDisponible;
            decimal cantidadNueva = cantidadAnterior + cantidad;

            // Usar transacción para garantizar consistencia
            using (SqlConnection conn = new SqlConnection(SqlHelper.conStringInventario))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Actualizar cantidad en inventario
                        string updateQuery = @"UPDATE Inventario 
                                             SET CantidadDisponible = @CantidadNueva,
                                                 FechaActualizacion = @FechaActualizacion
                                             WHERE IdInventario = @IdInventario";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CantidadNueva", cantidadNueva);
                            cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IdInventario", idInventario);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Registrar movimiento
                        string insertQuery = @"INSERT INTO MovimientoInventario 
                                             (IdMovimiento, IdInventario, IdRemito, TipoMovimiento, 
                                              Cantidad, CantidadAnterior, CantidadNueva, Observaciones, 
                                              FechaMovimiento, UsuarioId)
                                             VALUES 
                                             (@IdMovimiento, @IdInventario, @IdRemito, @TipoMovimiento, 
                                              @Cantidad, @CantidadAnterior, @CantidadNueva, @Observaciones, 
                                              @FechaMovimiento, @UsuarioId)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdMovimiento", Guid.NewGuid());
                            cmd.Parameters.AddWithValue("@IdInventario", idInventario);
                            cmd.Parameters.AddWithValue("@IdRemito", (object)idRemito ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@TipoMovimiento", "Entrada");
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@CantidadAnterior", cantidadAnterior);
                            cmd.Parameters.AddWithValue("@CantidadNueva", cantidadNueva);
                            cmd.Parameters.AddWithValue("@Observaciones", 
                                (object)observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@FechaMovimiento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UsuarioId", 
                                (object)usuarioId ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Registra un movimiento de salida en el inventario.
        /// Valida que haya stock suficiente antes de procesar.
        /// </summary>
        public void RegistrarSalida(Guid idInventario, decimal cantidad, 
            string observaciones = null, Guid? usuarioId = null)
        {
            // Obtener inventario actual
            var inventario = GetById(idInventario);
            if (inventario == null)
                throw new Exception("Inventario no encontrado.");

            decimal cantidadAnterior = inventario.CantidadDisponible;

            // Validar stock suficiente
            if (cantidadAnterior < cantidad)
                throw new Exception($"Stock insuficiente. Disponible: {cantidadAnterior} L/Kg, Solicitado: {cantidad} L/Kg");

            decimal cantidadNueva = cantidadAnterior - cantidad;

            // Usar transacción
            using (SqlConnection conn = new SqlConnection(SqlHelper.conStringInventario))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Actualizar cantidad
                        string updateQuery = @"UPDATE Inventario 
                                             SET CantidadDisponible = @CantidadNueva,
                                                 FechaActualizacion = @FechaActualizacion
                                             WHERE IdInventario = @IdInventario";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@CantidadNueva", cantidadNueva);
                            cmd.Parameters.AddWithValue("@FechaActualizacion", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IdInventario", idInventario);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Registrar movimiento
                        string insertQuery = @"INSERT INTO MovimientoInventario 
                                             (IdMovimiento, IdInventario, TipoMovimiento, Cantidad, 
                                              CantidadAnterior, CantidadNueva, Observaciones, 
                                              FechaMovimiento, UsuarioId)
                                             VALUES 
                                             (@IdMovimiento, @IdInventario, @TipoMovimiento, @Cantidad, 
                                              @CantidadAnterior, @CantidadNueva, @Observaciones, 
                                              @FechaMovimiento, @UsuarioId)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdMovimiento", Guid.NewGuid());
                            cmd.Parameters.AddWithValue("@IdInventario", idInventario);
                            cmd.Parameters.AddWithValue("@TipoMovimiento", "Salida");
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmd.Parameters.AddWithValue("@CantidadAnterior", cantidadAnterior);
                            cmd.Parameters.AddWithValue("@CantidadNueva", cantidadNueva);
                            cmd.Parameters.AddWithValue("@Observaciones", 
                                (object)observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@FechaMovimiento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UsuarioId", 
                                (object)usuarioId ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene todos los movimientos de un inventario específico.
        /// </summary>
        public List<MovimientoInventario> GetMovimientosByInventario(Guid idInventario)
        {
            List<MovimientoInventario> movimientos = new List<MovimientoInventario>();

            string query = @"SELECT IdMovimiento, IdInventario, IdRemito, TipoMovimiento, 
                                    Cantidad, CantidadAnterior, CantidadNueva, Observaciones, 
                                    FechaMovimiento, UsuarioId
                             FROM MovimientoInventario 
                             WHERE IdInventario = @IdInventario
                             ORDER BY FechaMovimiento DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario,
                new SqlParameter("@IdInventario", idInventario)))
            {
                while (reader.Read())
                {
                    movimientos.Add(MapearMovimiento(reader));
                }
            }

            return movimientos;
        }

        /// <summary>
        /// Obtiene movimientos por rango de fechas.
        /// </summary>
        public List<MovimientoInventario> GetMovimientosByFechaRango(
            DateTime fechaInicio, DateTime fechaFin)
        {
            List<MovimientoInventario> movimientos = new List<MovimientoInventario>();

            string query = @"SELECT IdMovimiento, IdInventario, IdRemito, TipoMovimiento, 
                                    Cantidad, CantidadAnterior, CantidadNueva, Observaciones, 
                                    FechaMovimiento, UsuarioId
                             FROM MovimientoInventario 
                             WHERE FechaMovimiento BETWEEN @FechaInicio AND @FechaFin
                             ORDER BY FechaMovimiento DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario,
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin)))
            {
                while (reader.Read())
                {
                    movimientos.Add(MapearMovimiento(reader));
                }
            }

            return movimientos;
        }

        /// <summary>
        /// Obtiene movimientos asociados a un remito específico.
        /// </summary>
        public List<MovimientoInventario> GetMovimientosByRemito(Guid idRemito)
        {
            List<MovimientoInventario> movimientos = new List<MovimientoInventario>();

            string query = @"SELECT IdMovimiento, IdInventario, IdRemito, TipoMovimiento, 
                                    Cantidad, CantidadAnterior, CantidadNueva, Observaciones, 
                                    FechaMovimiento, UsuarioId
                             FROM MovimientoInventario 
                             WHERE IdRemito = @IdRemito
                             ORDER BY FechaMovimiento DESC";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario,
                new SqlParameter("@IdRemito", idRemito)))
            {
                while (reader.Read())
                {
                    movimientos.Add(MapearMovimiento(reader));
                }
            }

            return movimientos;
        }

        /// <summary>
        /// Obtiene todos los inventarios activos.
        /// </summary>
        public List<Inventario> GetInventariosActivos()
        {
            List<Inventario> inventarios = new List<Inventario>();

            string query = @"SELECT IdInventario, TipoResiduo, CantidadDisponible, Estado, 
                                    FechaCreacion, FechaActualizacion, EstadoInventario
                             FROM Inventario
                             WHERE EstadoInventario = 'Activo'
                             ORDER BY TipoResiduo, Estado";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario))
            {
                while (reader.Read())
                {
                    inventarios.Add(MapearInventario(reader));
                }
            }

            return inventarios;
        }

        #endregion

        #region Métodos de IGenericRepository<Inventario>

        /// <summary>
        /// Agrega un nuevo inventario.
        /// </summary>
        public void Add(Inventario entity)
        {
            string query = @"INSERT INTO Inventario 
                            (IdInventario, TipoResiduo, CantidadDisponible, Estado, 
                             FechaCreacion, FechaActualizacion, EstadoInventario)
                            VALUES 
                            (@IdInventario, @TipoResiduo, @CantidadDisponible, @Estado, 
                             @FechaCreacion, @FechaActualizacion, @EstadoInventario)";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, 
                SqlHelper.conStringInventario,
                new SqlParameter("@IdInventario", entity.IdInventario),
                new SqlParameter("@TipoResiduo", entity.TipoResiduo),
                new SqlParameter("@CantidadDisponible", entity.CantidadDisponible),
                new SqlParameter("@Estado", entity.Estado),
                new SqlParameter("@FechaCreacion", entity.FechaCreacion),
                new SqlParameter("@FechaActualizacion", entity.FechaActualizacion),
                new SqlParameter("@EstadoInventario", entity.EstadoInventario));
        }

        /// <summary>
        /// Actualiza un inventario existente.
        /// </summary>
        public void Update(Inventario entity)
        {
            string query = @"UPDATE Inventario 
                            SET TipoResiduo = @TipoResiduo,
                                CantidadDisponible = @CantidadDisponible,
                                Estado = @Estado,
                                FechaActualizacion = @FechaActualizacion,
                                EstadoInventario = @EstadoInventario
                            WHERE IdInventario = @IdInventario";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, 
                SqlHelper.conStringInventario,
                new SqlParameter("@IdInventario", entity.IdInventario),
                new SqlParameter("@TipoResiduo", entity.TipoResiduo),
                new SqlParameter("@CantidadDisponible", entity.CantidadDisponible),
                new SqlParameter("@Estado", entity.Estado),
                new SqlParameter("@FechaActualizacion", DateTime.Now),
                new SqlParameter("@EstadoInventario", entity.EstadoInventario));
        }

        /// <summary>
        /// Elimina un inventario (soft delete).
        /// </summary>
        public void Remove(Guid id)
        {
            string query = @"UPDATE Inventario 
                           SET EstadoInventario = 'Inactivo',
                               FechaActualizacion = @FechaActualizacion
                           WHERE IdInventario = @IdInventario";

            SqlHelper.ExecuteNonQueryWithConnection(query, CommandType.Text, 
                SqlHelper.conStringInventario,
                new SqlParameter("@FechaActualizacion", DateTime.Now),
                new SqlParameter("@IdInventario", id));
        }

        /// <summary>
        /// Obtiene un inventario por su ID.
        /// </summary>
        public Inventario GetById(Guid id)
        {
            Inventario inventario = null;

            string query = @"SELECT IdInventario, TipoResiduo, CantidadDisponible, Estado, 
                                    FechaCreacion, FechaActualizacion, EstadoInventario
                             FROM Inventario 
                             WHERE IdInventario = @IdInventario";

            using (SqlDataReader reader = SqlHelper.ExecuteReaderWithConnection(
                query, CommandType.Text, SqlHelper.conStringInventario,
                new SqlParameter("@IdInventario", id)))
            {
                if (reader.Read())
                {
                    inventario = MapearInventario(reader);
                }
            }

            return inventario;
        }

        /// <summary>
        /// Obtiene todos los inventarios.
        /// </summary>
        public List<Inventario> GetAll()
        {
            return GetInventariosActivos();
        }

        #endregion

        #region Métodos auxiliares de mapeo

        /// <summary>
        /// Mapea un SqlDataReader a un objeto Inventario.
        /// </summary>
        private Inventario MapearInventario(SqlDataReader reader)
        {
            return new Inventario
            {
                IdInventario = reader.GetGuid(0),
                TipoResiduo = reader.GetString(1),
                CantidadDisponible = reader.GetDecimal(2),
                Estado = reader.GetString(3),
                FechaCreacion = reader.GetDateTime(4),
                FechaActualizacion = reader.GetDateTime(5),
                EstadoInventario = reader.GetString(6)
            };
        }

        /// <summary>
        /// Mapea un SqlDataReader a un objeto MovimientoInventario.
        /// </summary>
        private MovimientoInventario MapearMovimiento(SqlDataReader reader)
        {
            return new MovimientoInventario
            {
                IdMovimiento = reader.GetGuid(0),
                IdInventario = reader.GetGuid(1),
                IdRemito = reader.IsDBNull(2) ? (Guid?)null : reader.GetGuid(2),
                TipoMovimiento = reader.GetString(3),
                Cantidad = reader.GetDecimal(4),
                CantidadAnterior = reader.GetDecimal(5),
                CantidadNueva = reader.GetDecimal(6),
                Observaciones = reader.IsDBNull(7) ? null : reader.GetString(7),
                FechaMovimiento = reader.GetDateTime(8),
                UsuarioId = reader.IsDBNull(9) ? (Guid?)null : reader.GetGuid(9)
            };
        }

        #endregion
    }
}
