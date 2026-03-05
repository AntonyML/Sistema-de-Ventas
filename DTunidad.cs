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
    public partial class DTunidad : Form
    {
        private Articulos form2Reference;
        public DTunidad(Articulos form2Ref)
        {
            InitializeComponent();
            form2Reference = form2Ref;
        }


        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        private void DTunidad_Load(object sender, EventArgs e)
        {
            string consulta = "select * from unidad";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                form2Reference.SetTextBox1Value(selectedValue); // Llena el primer TextBox en Form2
                this.Close();
            }
        }
    }
}
