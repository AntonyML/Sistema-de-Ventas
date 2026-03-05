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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        public void llenar_tabla()
        {

            string consulta = "select * from clientes";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        public void limpiar()
        {
            txtID.Clear();
            txtSocial.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtCredito.Clear();
            txtObservacion.Clear();
            txtCondicion.Clear();

        }

       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // para ELIMINAR
            try
            {

                database.conexion con = new database.conexion();
                string consulta = " delete from clientes where ClienteNo = '" + txtID.Text + "'";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                MessageBox.Show("Registro eliminado");
                comando.ExecuteNonQuery();
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            txtFecha.CustomFormat = "yyyy-MM-dd";
            txtFecha.Format = DateTimePickerFormat.Custom;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;

            string consulta = "select * from clientes";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtCiudad.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtCredito.Text) && !string.IsNullOrEmpty(txtFecha.Text) && !string.IsNullOrEmpty(txtCondicion.Text)  && !string.IsNullOrEmpty(txtSocial.Text) && !string.IsNullOrEmpty(txtEstado.Text) && !string.IsNullOrEmpty(txtObservacion.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           


        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtTipoCliente_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtSocial_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtMod_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtAnulado_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // para Insertar
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "INSERT INTO clientes VALUES (@IDCliente, @Razon, @Nombre, @Cedula, @Direccion, @Ciudad, @Tel, @Email, @LimitCredit, @Observacion, @FechaEntrada, @CondicionCliente, @Estado)"; SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                comando.Parameters.AddWithValue("@IDCliente", txtID.Text);
                comando.Parameters.AddWithValue("@Razon", txtSocial.Text);
                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                comando.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                comando.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                comando.Parameters.AddWithValue("@Tel", txtTelefono.Text);
                comando.Parameters.AddWithValue("@Email", txtEmail.Text);
                comando.Parameters.AddWithValue("@LimitCredit", txtCredito.Text);
                comando.Parameters.AddWithValue("@Observacion", txtObservacion.Text);
                comando.Parameters.AddWithValue("@FechaEntrada", txtFecha.Text);
                comando.Parameters.AddWithValue("@CondicionCliente", txtCondicion.Text);
                comando.Parameters.AddWithValue("@Estado", txtEstado.Text);

                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // para MODIFICAR
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "update clientes set ClienteNo=" + txtID.Text + ",RazonSocial='" + txtSocial.Text + "',Nombre='" + txtNombre.Text + "',cedulaRNC='" + txtCedula.Text + "',Direccion='" + txtDireccion.Text + "',ciudad='" + txtCiudad.Text + "', tel1='" + txtTelefono.Text + "',email='" + txtEmail.Text + "',LimiteCredito='" + txtCredito.Text + "',Observacion='" + txtObservacion.Text + "',FechaEntrada='" + txtFecha.Text + "', CondicionCliente='" + txtCondicion.Text + "',estado= '" + txtEstado.Text + "'where ClienteNo=" + txtID.Text + "";

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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtCedula.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txtDireccion.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txtCiudad.Text = dataGridView1.SelectedCells[5].Value.ToString();
            txtTelefono.Text = dataGridView1.SelectedCells[6].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedCells[7].Value.ToString();
            txtCredito.Text = dataGridView1.SelectedCells[8].Value.ToString();
            txtFecha.Text = dataGridView1.SelectedCells[10].Value.ToString();
            txtCondicion.Text = dataGridView1.SelectedCells[11].Value.ToString();
            txtSocial.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtEstado.Text = dataGridView1.SelectedCells[12].Value.ToString();
            txtObservacion.Text = dataGridView1.SelectedCells[9].Value.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
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

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtCredito, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!validarTxt.validarEmail(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Correo no valido");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
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
    }
    }


