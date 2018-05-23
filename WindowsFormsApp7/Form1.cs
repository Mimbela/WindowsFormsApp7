using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    
    public partial class Form1 : Form
    {
        string cadena = ConfigurationManager.ConnectionStrings["cadenaNorthwind"].ConnectionString;
        //creamos la cadena conexión
        //connectionstrings, recupera las conexiones
        //siempre que trabajamos con objetos, trabajamos con arrays
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Carga_Tabla();
        }

        private void Carga_Tabla()
        {
            //aquí escribimos el código.
            //ponemos la consulta del mana
            string consulta = "SELECT * FROM Customers WHERE Country = 'Germany'";
            //creamos el adaptador para trabajar con la tabla , le pasamos la query y la conexión
            SqlDataAdapter adaptador = new SqlDataAdapter( consulta , cadena);

            //al adaptador le paso la tabla
            DataTable tabla = new DataTable();

            //la tabla es rellenada por los datos
            adaptador.Fill(tabla);
            
            //datasource: dime la fuente de los datos
            dataGridView1.DataSource = tabla;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //voy a hacer que cuando el usuario clickea en cuakquiera de las celdas , la app recogerá el valor

            string codigo = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            //le estoy diciendo que me interesa la primera celda 
            //eñ valor de la celda actual

            //creo una variable para captar el segundo formulario y cargamos el combo del segundo formulario
            Form2 formulario2 = new Form2();
            formulario2.cargarCombo(codigo);

            formulario2.Show(); //para que cargue el formulario
        }
    }
}
