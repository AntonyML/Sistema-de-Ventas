using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace sistema_de_ventas.database
{
    public class conexion
    {
        private SqlConnection conex = new SqlConnection();

        // Valores por defecto (se pueden sobrescribir desde project.json)
        static string servidor = "DESKTOP-I9E14T9";
        static string bd = "prestamos_db";

        SqlConnectionStringBuilder builder;

        public conexion()
        {
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "project.json");
                if (File.Exists(configPath))
                {
                    string content = File.ReadAllText(configPath);
                    // Buscamos la clave DefaultConnection de forma simple
                    string marker = "\"DefaultConnection\"";
                    int idx = content.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        int colon = content.IndexOf(':', idx);
                        if (colon > 0)
                        {
                            int firstQuote = content.IndexOf('"', colon + 1);
                            int secondQuote = content.IndexOf('"', firstQuote + 1);
                            if (firstQuote >= 0 && secondQuote > firstQuote)
                            {
                                string conn = content.Substring(firstQuote + 1, secondQuote - firstQuote - 1);
                                if (!string.IsNullOrWhiteSpace(conn))
                                {
                                    builder = new SqlConnectionStringBuilder(conn);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignorar y usar valores por defecto
            }

            // Si no hay configuración válida, usar los valores por defecto
            builder = new SqlConnectionStringBuilder
            {
                DataSource = servidor,
                InitialCatalog = bd,
                IntegratedSecurity = true,
                PersistSecurityInfo = true
            };
        }

        public static void SaveConnectionString(string connectionString)
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "project.json");
                string content = "{\n  \"ConnectionStrings\": {\n    \"DefaultConnection\": \"" + connectionString.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"\n  }\n}\n";
                File.WriteAllText(configPath, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar la configuración: {ex.Message}");
            }
        }

        public SqlConnection establecerConexion()
        {
            try
            {
                if (probarConexion())
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

        public void cerrarConexion()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

        private bool probarConexion()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ToString()))
                {
                    connection.Open();

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
