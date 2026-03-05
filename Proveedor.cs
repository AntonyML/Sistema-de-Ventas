using sistema_de_ventas.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_de_ventas
{
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");

        public void llenar_tabla()
        {

            string consulta = "select * from proveedor";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        public void limpiar()
        {
            txtProveedor.Clear();
            txtDescripcion.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
           


        }
        private void Proveedor_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;

            string consulta = "select * from proveedor";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtProveedor.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtCiudad.Text)  && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtContacto.Text) && !string.IsNullOrEmpty(txtEstado.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             txtProveedor.Text = dataGridView1.SelectedCells[0].Value.ToString();

             txtDescripcion.Text = dataGridView1.SelectedCells[1].Value.ToString();

             txtCedula.Text = dataGridView1.SelectedCells[2].Value.ToString();

             txtDireccion.Text = dataGridView1.SelectedCells[3].Value.ToString();

             txtCiudad.Text = dataGridView1.SelectedCells[4].Value.ToString();

            txtContacto.Text = dataGridView1.SelectedCells[5].Value.ToString();

            txtTelefono.Text = dataGridView1.SelectedCells[6].Value.ToString(); 

            txtEstado.Text = dataGridView1.SelectedCells[7].Value.ToString();

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
            conexion.Open();
            // para Insertar
            try
            {
                
                string consulta = "INSERT INTO proveedor  VALUES ('" + txtProveedor.Text + "', '" + txtDescripcion.Text + "', '" + txtCedula.Text + "', '" + txtDireccion.Text + "', '" + txtCiudad.Text + "','" +txtContacto.Text + "', '" + txtTelefono.Text + "', '" + txtEstado.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                limpiar();
                conexion.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            conexion.Open();
            // para MODIFICAR
            try
            {
                
                string consulta = "UPDATE proveedor SET ProveedorNo = @ProveedorNo, Descripcion = @Descripcion, cedulaRNC = @cedulaRNC, Direccion = @Direccion, Ciudad = @Ciudad, Contacto = @Contacto, Ctel = @Ctel, Estado = @Estado WHERE ProveedorNo = @ProveedorNo";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                comando.Parameters.AddWithValue("@ProveedorNo", txtProveedor.Text);
                comando.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                comando.Parameters.AddWithValue("@cedulaRNC", txtCedula.Text);
                comando.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                comando.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                comando.Parameters.AddWithValue("@Contacto", txtContacto.Text);
                comando.Parameters.AddWithValue("@Ctel", txtTelefono.Text);
                comando.Parameters.AddWithValue("@Estado", txtEstado.Text);
               

               
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }

                llenar_tabla();
                limpiar();
                conexion.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtAnulado_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtMod_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtProveedor, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtCedula, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtTelefono, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
             bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtContacto, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}


