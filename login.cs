namespace sistema_de_ventas
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }



        public void GetRol()
        {
            database.conexion conex = new database.conexion();
            string query = "SELECT * FROM usuario WHERE Usuario = '" + Program.globalVariables.user + "'";
            SqlCommand command = new SqlCommand(query, conex.establecerConexion());
            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                MessageBox.Show("Bienvenido ", txtUsuario.Text);
                int idUsuario = reader.GetInt32(reader.GetOrdinal("id"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                string apellido = reader.GetString(reader.GetOrdinal("apellido"));
                string correo = reader.GetString(reader.GetOrdinal("correo"));
                string contraseña = reader.GetString(reader.GetOrdinal("contraseña"));
                int rol = reader.GetInt32(reader.GetOrdinal("rol"));
                DateTime fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fecha_registro"));
                string usuario = reader.GetString(reader.GetOrdinal("Usuario"));
                Program.globalVariables.rolUser = rol;


            }
            conex.cerrarConexion();


        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1Entrar_Click(object sender, EventArgs e)
        {

            database.conexion conex = new database.conexion();
            try
            {




                string consulta = "SELECT 1 FROM usuario WHERE Usuario = '" + txtUsuario.Text + "' AND contraseña = '" + txtContraseña.Text + "'";
                SqlCommand comando = new SqlCommand(consulta, conex.establecerConexion());
                SqlDataReader reader = comando.ExecuteReader();


                if (reader.HasRows)
                {

                    Program.globalVariables.user = txtUsuario.Text;

                    menu menu = new menu();
                    this.Hide();
                    menu.Show();

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
                conex.cerrarConexion();
                GetRol();

            }
            catch (Exception ex) { MessageBox.Show("Error al conectarse a la base de datos"); }


        }

        private void button2Salir_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtUsuario_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
