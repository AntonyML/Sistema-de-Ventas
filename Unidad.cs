namespace sistema_de_ventas
{
    public partial class Unidad : Form
    {
        public Unidad()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        private void Unidad_Load(object sender, EventArgs e)
        {

            string consulta = "select * from unidad";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtUnidadNo.Text) && !string.IsNullOrEmpty(txtDescrip.Text) && !string.IsNullOrEmpty(txtCantidad.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();

            //para Insertar
            try
            {
                string consulta = "INSERT INTO unidad  VALUES ('" + txtUnidadNo.Text + "','" + txtDescrip.Text + "','" + txtCantidad.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                //llenar_tabla();
                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para ACTUALIZAR
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "update unidad set unidadNo=" + txtUnidadNo.Text + ",descripcion='" + txtDescrip.Text + "',Cantidad='" + txtCantidad.Text + "'where unidadNo=" + txtUnidadNo.Text + "";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }
                // llenar_tabla();
                // limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtUnidadNo_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtDescrip_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void txtUnidadNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtUnidadNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtCantidad, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }
    }
}
