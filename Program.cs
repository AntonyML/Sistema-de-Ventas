using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace sistema_de_ventas
{
    internal static class Program
    {
        public static common.Variables_Globals globalVariables = new common.Variables_Globals();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EnsureConnectionConfigured();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private static bool TestConnectionString(string conn)
        {
            try
            {
                using (var c = new SqlConnection(conn))
                {
                    c.Open();
                    using (var cmd = new SqlCommand("SELECT 1", c))
                    {
                        var r = cmd.ExecuteScalar();
                        return r != null && r.ToString() == "1";
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private static void EnsureConnectionConfigured()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "project.json");
            string conn = null;

            if (File.Exists(configPath))
            {
                try
                {
                    string content = File.ReadAllText(configPath);
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
                                conn = content.Substring(firstQuote + 1, secondQuote - firstQuote - 1);
                            }
                        }
                    }
                }
                catch { conn = null; }
            }

            bool ok = false;
            if (!string.IsNullOrEmpty(conn)) ok = TestConnectionString(conn);

            if (!ok)
            {
                // Abrir consola para permitir configurar la conexión
                AllocConsole();
                Console.WriteLine("No hay una cadena de conexión válida configurada.");
                Console.Write("Servidor (ej: .\\SQLEXPRESS) [ENTER para usar '.']: ");
                string server = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(server)) server = ".";
                Console.Write("Base de datos (ej: prestamos_db) [ENTER para usar 'master']: ");
                string db = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(db)) db = "master";

                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    InitialCatalog = db,
                    IntegratedSecurity = true
                };

                conn = builder.ToString();

                // Guardar en project.json
                try
                {
                    string content = "{\n  \"ConnectionStrings\": {\n    \"DefaultConnection\": \"" + conn.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"\n  }\n}\n";
                    File.WriteAllText(configPath, content);
                    Console.WriteLine("Cadena de conexión guardada en project.json");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No se pudo guardar project.json: {ex.Message}");
                }

                Console.WriteLine("Probando conexión...");
                ok = TestConnectionString(conn);
                Console.WriteLine(ok ? "Conexión OK." : "No se pudo conectar con los parámetros proporcionados.");
                Console.WriteLine("Presiona ENTER para continuar...");
                Console.ReadLine();
                FreeConsole();
            }
        }
    }
}
