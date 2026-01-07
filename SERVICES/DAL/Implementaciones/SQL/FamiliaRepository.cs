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
    public class FamiliaRepository
    {
        public List<Familia> GetFamiliasByUsuarioId(Guid idUsuario)
        {
            List<Familia> familias = new List<Familia>();

            // 1. Obtener familias del usuario
            string queryFamilias = @"
                SELECT f.IdFamilia, f.Nombre
                FROM Usuario_Familia uf
                JOIN Familia f ON uf.IdFamilia = f.IdFamilia
                WHERE uf.IdUsuario = @IdUsuario";

            var tablaFamilias = SqlHelper.ExecuteDataTable(
                queryFamilias,
                CommandType.Text,
                new SqlParameter("@IdUsuario", idUsuario)
            );

            foreach (DataRow row in tablaFamilias.Rows)
            {
                var familia = new Familia
                {
                    Id = (Guid)row["IdFamilia"],
                    Nombre = row["Nombre"].ToString()
                };
                familias.Add(familia);
            }

            // 2. Por cada familia, cargar sus patentes
            string queryPatentes = @"
                SELECT p.IdPatente, p.Nombre, p.DataKey, p.TipoAcceso
                FROM Familia_Patente fp
                JOIN Patente p ON fp.IdPatente = p.IdPatente
                WHERE fp.IdFamilia = @IdFamilia";

            foreach (var familia in familias)
            {
                var tablaPatentes = SqlHelper.ExecuteDataTable(
                    queryPatentes,
                    CommandType.Text,
                    new SqlParameter("@IdFamilia", familia.Id)
                );

                foreach (DataRow row in tablaPatentes.Rows)
                {
                    var patente = new Patente
                    {
                        Id = (Guid)row["IdPatente"],
                        Nombre = row["Nombre"].ToString(),
                        DataKey = row["DataKey"].ToString(),
                    };
                    familia.Add(patente);
                }
            }

            return familias;
        }

        public List<Patente> GetPatentesByFamiliaId(Guid familiaId)
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT p.IdPatente, p.Nombre, p.DataKey, p.TipoAcceso FROM Patente p " +
                "INNER JOIN Familia_Patente fp ON p.IdPatente = fp.IdPatente " +
                "WHERE fp.IdFamilia = @IdFamilia",
                CommandType.Text,
                new SqlParameter("@IdFamilia", familiaId)))
            {
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1),
                        DataKey = reader.GetString(2),
                    });
                }
            }

            return patentes;
        }
        public void SaveFamilia(Familia familia)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO Familia (IdFamilia, Nombre) VALUES (@IdFamilia, @Nombre)",
                CommandType.Text,
                new SqlParameter("@IdFamilia", familia.Id),
                new SqlParameter("@Nombre", familia.Nombre)
            );

            foreach (var patente in familia.Accesos.OfType<Patente>())
            {
                SqlHelper.ExecuteNonQuery(
                    "INSERT INTO Familia_Patente (IdFamilia, IdPatente) VALUES (@IdFamilia, @IdPatente)",
                    CommandType.Text,
                    new SqlParameter("@IdFamilia", familia.Id),
                    new SqlParameter("@IdPatente", patente.Id)
                );
            }
        }

        public void UpdateFamilia(Familia familia)
        {
            // Actualizar el nombre de la familia
            SqlHelper.ExecuteNonQuery(
                "UPDATE Familia SET Nombre = @Nombre WHERE IdFamilia = @IdFamilia",
                CommandType.Text,
                new SqlParameter("@IdFamilia", familia.Id),
                new SqlParameter("@Nombre", familia.Nombre)
            );

            // Eliminar patentes actuales de la familia en Familia_Patente
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM Familia_Patente WHERE IdFamilia = @IdFamilia",
                CommandType.Text,
                new SqlParameter("@IdFamilia", familia.Id)
            );

            // Reinsertar las patentes actualizadas
            foreach (var patente in familia.Accesos.OfType<Patente>())
            {
                SqlHelper.ExecuteNonQuery(
                    "INSERT INTO Familia_Patente (IdFamilia, IdPatente) VALUES (@IdFamilia, @IdPatente)",
                    CommandType.Text,
                    new SqlParameter("@IdFamilia", familia.Id),
                    new SqlParameter("@IdPatente", patente.Id)
                );
            }
        }

        public void SaveUsuarioFamilia(Guid IdUsuario, Guid IdFamilia)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO Usuario_Familia (IdUsuario, IdFamilia) VALUES (@IdUsuario, @IdFamilia)",
                CommandType.Text,
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@IdFamilia", IdFamilia)
            );
        }

        public void UpdateUsuarioFamilia(Guid usuarioId, List<Familia> familias)
        {
            // Eliminar relaciones actuales
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM Usuario_Familia WHERE IdUsuario = @IdUsuario",
                CommandType.Text,
                new SqlParameter("@IdUsuario", usuarioId)
            );

            // Reinsertar relaciones actualizadas
            foreach (var familia in familias)
            {
                SaveUsuarioFamilia(usuarioId, familia.Id);
            }
        }
        public List<Familia> GetAll()
        {
            List<Familia> familias = new List<Familia>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT IdFamilia, Nombre FROM Familia",
                CommandType.Text))
            {
                while (reader.Read())
                {
                    familias.Add(new Familia
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }

            return familias;
        }
        public List<Patente> GetAllPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT IdPatente, Nombre, DataKey, TipoAcceso FROM Patente",
                CommandType.Text))
            {
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1),
                        DataKey = reader.GetString(2),
                    });
                }
            }

            return patentes;
        }
    }
}
