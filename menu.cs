using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_de_ventas
{
    public partial class menu : Form
    {
        

        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void registrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void facturadorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void registarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
           
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registrarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void registrarToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturadorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void unidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                usuario usuario = new usuario();
                usuario.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            

        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_Articulos consulta_Articulos = new Consulta_Articulos();
            consulta_Articulos.Visible = true;
        }

        private void registrarToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
          

            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Articulos articulos = new Articulos();
                articulos.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }
        }

        private void registrarToolStripMenuItem3_Click_2(object sender, EventArgs e)
        {

            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Clientes clientes = new Clientes();
                clientes.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

           
        }

        private void registrarToolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Facturador facturador = new Facturador();
                facturador.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            
        }

        private void registarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Unidad unidad = new Unidad();
                unidad.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            
        }

        private void registrarToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Proveedor provee = new Proveedor();
                provee.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }
            

        }

        private void registrarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Vendedor vendedor = new Vendedor();
                vendedor.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            
        }

        private void registrarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Linea linea = new Linea();
                linea.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            
        }

        private void registrarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Marca marca = new Marca();
                marca.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.globalVariables.rolUser == 0)
            {
                this.Hide();
                Consulta_usuario consulta_usuario = new Consulta_usuario();
                consulta_usuario.Visible = true;

            }
            else
            {
                MessageBox.Show($"Debe ser administrador para tener acceso a los mantenimientos");
            }
           
      
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_proveedor consulta_proveedor = new Consulta_proveedor();
            consulta_proveedor.Visible = true;
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_clientes consulta_clientes = new Consulta_clientes();
            consulta_clientes.Visible = true;
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_Facturador consulta_facturador = new Consulta_Facturador();
            consulta_facturador.Visible = true;
        }

        private void consultarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_unidad consulta_unidad = new Consulta_unidad();
            consulta_unidad.Visible = true;
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_vendedor consulta_vendedor = new Consulta_vendedor();
            consulta_vendedor.Visible = true;
        }

        private void consultarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_linea consulta_linea = new Consulta_linea();
            consulta_linea.Visible = true;
        }

        private void consultarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consulta_marca consulta_marca = new Consulta_marca ();
            consulta_marca.Visible = true;

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            
                   this.Close();

                login login = new login();
                login.Visible = true;

               login login1 = new login();

        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            this.Close();
            Ajuste ajuste = new Ajuste();
            ajuste.Visible = true;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Close();
            Mov_Ventas ventas = new Mov_Ventas();
            ventas.Visible = true;
        }

        private void btnConsult_M_Click(object sender, EventArgs e)
        {
            this.Close();
            Consulta_Ajuste_M ajuste_M = new Consulta_Ajuste_M();
            ajuste_M.Visible = true;

        }

        private void btnConsult_D_Click(object sender, EventArgs e)
        {
            this.Close();
            Consulta_Ajuste_D ajuste_D = new Consulta_Ajuste_D();
            ajuste_D.Visible = true;
        }
    }
}
