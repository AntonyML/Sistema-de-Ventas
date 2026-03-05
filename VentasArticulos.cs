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
    public partial class VentasArticulos : Form
    {
        public VentasArticulos()
        {
            InitializeComponent();
        }
        public void llenar_tabla()
        {
            database.conexion con = new database.conexion();
            string consulta = "Select * from articulo";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, con.establecerConexion());

            //Crear Tabla en memoria o Virtual

            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void VentasArticulos_Load(object sender, EventArgs e)
        {

            llenar_tabla();
        }  

        private DataGridViewRow filaSeleccionada = null;
        public event EventHandler<ArticuloSeleccionadoEventArgs> ArticuloSeleccionado;

        protected virtual void OnArticuloSeleccionado(ArticuloSeleccionadoEventArgs e)
        {
            ArticuloSeleccionado?.Invoke(this, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                filaSeleccionada = dataGridView1.SelectedRows[0];
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public DataGridViewRow ObtenerArticuloSeleccionado()
        {
            return filaSeleccionada;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int columna7 = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string columna0 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string columna2 = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string columna3 = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                string columna4 = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string columna5 = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();



                OnArticuloSeleccionado(new ArticuloSeleccionadoEventArgs(columna7, columna0, columna2, columna3, columna4, columna5));

                this.Close();
            }
        }
    }
}

        