using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using sistema_de_ventas.database;
using System.Windows.Media.TextFormatting;
using System.Diagnostics.Eventing.Reader;

namespace sistema_de_ventas
{
    public partial class usuario : Form
    {
        public usuario()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            txtUsuario.Clear();
           
        }
        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        public void llenar_tabla()
        {

            string consulta = "select * from usuario";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
       
        

        private void usuario_Load(object sender, EventArgs e)
        {
           

            txtFecha.CustomFormat = "yyyy-MM-dd";
            txtFecha.Format = DateTimePickerFormat.Custom;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;

            string consulta = "select * from usuario";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtRol.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtFecha.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled= vr;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            // para ELIMINAR
          /*  try { 

            database.conexion con = new database.conexion();
            string consulta = " delete from usuario where id=" + txtID.Text + "";
            SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
            MessageBox.Show("Registro eliminado");
                comando.ExecuteNonQuery();

                llenar_tabla();
                limpiar();
            con.cerrarConexion();
        } catch (Exception ex) { MessageBox.Show(ex.Message); }*/
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedCells[0].Value.ToString();

            txtNombre.Text = dataGridView1.SelectedCells[1].Value.ToString();

            txtApellido.Text = dataGridView1.SelectedCells[2].Value.ToString();

            txtCorreo.Text = dataGridView1.SelectedCells[3].Value.ToString();

            txtContraseña.Text = dataGridView1.SelectedCells[4].Value.ToString();

            txtRol.Text = dataGridView1.SelectedCells[5].Value.ToString();

            txtFecha.Text = dataGridView1.SelectedCells[6].Value.ToString();

            txtUsuario.Text = dataGridView1.SelectedCells[7].Value.ToString();

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();



            //para Insertar
            try
            {
                string consulta = "INSERT INTO usuario  VALUES ('" + txtID.Text + "','" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtCorreo.Text + "', '" + txtContraseña.Text + "', '" + txtRol.Text + "', '" + txtFecha.Text + "','" + txtUsuario.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();


            //para ACTUALIZAR
            try
            {
                string consulta = "update usuario set id=" + txtID.Text + ",nombre='" + txtNombre.Text + "',apellido='" + txtApellido.Text + "',correo='" + txtCorreo.Text + "',contraseña='" + txtContraseña.Text + "',rol='" + txtRol.Text + "',fecha_registro='" + txtFecha.Text + "',Usuario='" + txtUsuario.Text + "'where id=" + txtID.Text + "";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtID, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtRol_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtRol, "Solo numeros (0-ADMIN 1-USER)");
            }
            else
            {
                errorProvider.Clear();
            }

        }

        private void txtRol_Validating(object sender, CancelEventArgs e)
        {
           
            
        }

     

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (!validarTxt.validarEmail(txtCorreo.Text))
            {
                errorProvider.SetError(txtCorreo, "Correo no valido");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
