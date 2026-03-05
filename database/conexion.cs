using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sistema_de_ventas.database
{
    internal class Conexion
    {
        SqlConnection conex = new SqlConnection();

        static string servidor = "DESKTOP-I9E14T9";
        static string bd = "prestamos_db";

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = servidor,
            InitialCatalog = bd,
            PersistSecurityInfo = true
        };

        public SqlConnection EstablecerConexion()
        {
            try
            {
                if (ProbarConexion()) // Se corrigió el error aquí
                {
                    conex.ConnectionString = builder.ToString();
                    conex.Open();
                    return conex;
                }
                else
                {
                    throw new Exception("No se logró conectar a la Base de Datos");
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al conectar a la Base de Datos", e);
            }
        }

        public void CerrarConexion()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

        private bool ProbarConexion() // Se movió la función a ser un método privado de la clase
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ToString()))
                {
                    connection.Open();

                    // Ejemplo de consulta simple para probar la conexión
                    string query = "SELECT 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != null && result.ToString() == "1";
                    }
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
