using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helpers
{
    /// <summary>
    /// Clase auxiliar para ejecutar comandos SQL de manera simplificada.
    /// Maneja las conexiones a diferentes bases de datos según el contexto.
    /// </summary>
    internal static class SqlHelper
    {
        // Cadena de conexión para la base de datos de remitos
        public readonly static string conStringRemitos;

        // Cadena de conexión para la base de datos de proveedores
        public readonly static string conStringProveedores;

        /// <summary>
        /// Constructor estático que inicializa las cadenas de conexión desde el archivo de configuración.
        /// </summary>
        static SqlHelper()
        {
            conStringRemitos = ConfigurationManager.ConnectionStrings["Remitos_conexiones"].ConnectionString;
            conStringProveedores = ConfigurationManager.ConnectionStrings["Proveedores_conexiones"].ConnectionString;
        }

        /// <summary>
        /// Ejecuta un comando SQL que no devuelve resultados usando una cadena de conexión específica.
        /// </summary>
        /// <param name="commandText">El texto del comando SQL o nombre del stored procedure.</param>
        /// <param name="commandType">El tipo de comando (Text o StoredProcedure).</param>
        /// <param name="connectionString">La cadena de conexión a utilizar.</param>
        /// <param name="parameters">Los parámetros del comando.</param>
        /// <returns>El número de filas afectadas.</returns>
        public static Int32 ExecuteNonQueryWithConnection(String commandText,
            CommandType commandType, string connectionString, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Verifica si algún parámetro tiene valor null y lo reemplaza por DBNull.Value.
        /// </summary>
        /// <param name="parameters">Los parámetros a verificar.</param>
        private static void CheckNullables(SqlParameter[] parameters)
        {
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Ejecuta un comando SQL y devuelve un SqlDataReader usando una cadena de conexión específica.
        /// </summary>
        /// <param name="commandText">El texto del comando SQL o nombre del stored procedure.</param>
        /// <param name="commandType">El tipo de comando (Text o StoredProcedure).</param>
        /// <param name="connectionString">La cadena de conexión a utilizar.</param>
        /// <param name="parameters">Los parámetros del comando.</param>
        /// <returns>Un SqlDataReader con los resultados de la consulta.</returns>
        public static SqlDataReader ExecuteReaderWithConnection(String commandText,
            CommandType commandType, string connectionString, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}