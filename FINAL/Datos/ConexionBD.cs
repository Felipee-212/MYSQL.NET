using MySql.Data.MySqlClient;
using System.Data;

namespace Obligatorio.Datos
{
    public class ConexionBD
    {
        private readonly string connectionString =
            "server=localhost;port=3306;database=obg_database;user=root;password=root1234;";

        public MySqlConnection AbrirConexion()
        {
            // Always create a fresh connection so each operation is isolated and we
            // avoid reusing a disposed instance after the first call.
            var conexion = new MySqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public void CerrarConexion(MySqlConnection? conexion = null)
        {
            if (conexion == null)
                return;

            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }

            conexion.Dispose();
        }
    }
}
