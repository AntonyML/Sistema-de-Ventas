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
    public partial class Vendedor : Form
    {
        public Vendedor()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void Vendedor_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtVendedorNo.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();

            //para Insertar
            try
            {
                string consulta = "INSERT INTO vendedor  VALUES ('" + txtVendedorNo.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                //llenar_tabla();
                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //para ACTUALIZAR
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "update vendedor set vendedorNo=" + txtVendedorNo.Text + ",Nombre='" + txtNombre.Text + "',Apellido='" + txtApellido.Text + "'where vendedorNo=" + txtVendedorNo.Text + "";
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

        private void txtVendedorNo_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void txtVendedorNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtVendedorNo, "Solo numeros");
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
    }
}
