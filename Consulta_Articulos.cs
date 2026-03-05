using sistema_de_ventas.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_de_ventas
{
    public partial class Consulta_Articulos : Form
    {
        public event Action<string, string, string, string> RowSelected; //Nuevo now

        private DataGridViewRow filaSeleccionada = null;

        public Consulta_Articulos()
        {
            InitializeComponent();
            
        }

       
        public event EventHandler<ArticuloSeleccionadoEventArgs> ArticuloSeleccionado;

        protected virtual void OnArticuloSeleccionado(ArticuloSeleccionadoEventArgs e)
        {
            ArticuloSeleccionado?.Invoke(this, e);
        }

        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        private void Consulta_Articulos_Load(object sender, EventArgs e)
        {

            string consulta = "select * from articulo";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
               dataGridView1.ClearSelection();

   ;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();

            conexion.Open();
            string consulta = "SELECT * FROM articulo WHERE ArticuloNo = '" + txtFiltro.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;


            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            conexion.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            string consulta = "select * from articulo";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtén el valor de la columna 7
                int columna7 = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                // Obtén los valores de las columnas 0, 2 y 3
                string columna0 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string columna2 = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string columna3 = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                // Notifica al formulario "Ajuste" sobre la selección
                OnArticuloSeleccionado(new ArticuloSeleccionadoEventArgs(columna7, columna0, columna2, columna3));

                // Cierra el formulario "Articulo"
                this.Close();
            }


        

        }
     

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                filaSeleccionada = dataGridView1.SelectedRows[0];
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           
        }
        

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public DataGridViewRow ObtenerArticuloSeleccionado()
        {
            return filaSeleccionada;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
