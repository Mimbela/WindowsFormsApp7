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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void cargarCombo(string codigo)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadenaNorthwind"].ConnectionString;
            string consulta = "select OrderID , Freight from Orders where CustomerID = '"+ codigo + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cadena);
             DataTable tabla = new DataTable();

            //rellenamos la combo box con las propiedades del valor delante, detras, fila vacia
            adaptador.Fill(tabla); //adaptador va a rellenar la tabla

            //relleno COMBO con sus diferentes opciones

            //creo objeto fila vacía
            DataRow fila = tabla.NewRow(); 
            fila["OrderId"] = 0; //  ó fila ["OrderId"]=equals(0);
            fila["Freight"] = 0;

            //añado a la tabla
            tabla.Rows.Add(fila);


            //creo el por delante y por detras
            cmbGastosViaje.DisplayMember = tabla.Columns["Freight"].ColumnName;  //valor a mostrar y a manejar, este es por delante, y le digo que columna debe coger
            cmbGastosViaje.ValueMember = tabla.Columns[0].ColumnName;   //este es el del valor por detrás

            //ordeno la tabla por el freight
            tabla.DefaultView.Sort = tabla.Columns["Freight"].ColumnName;

            //le decimos que tiene que cargar
            cmbGastosViaje.DataSource = tabla;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void cmbGastosViaje_SelectedIndexChanged(object sender, EventArgs e)//metodo para seleccionar del combo
        {
            txtCodigoPedido.Text = cmbGastosViaje.SelectedValue.ToString();//recupero el valor por detras y lo paso a la caja de texto , selectedvalue es el valor por detrás
            txtGastoViaje.Text = cmbGastosViaje.Text; //selectedtext es el valor por delante
        }
    }
}

//HACER EL 10.12
