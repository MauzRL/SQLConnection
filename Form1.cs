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

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string conexion = "Data Source=LAPTOP-MAURI;Initial Catalog=Proyecto;Integrated Security=True";



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.USUARIOS' Puede moverla o quitarla según sea necesario.
            this.uSUARIOSTableAdapter.Fill(this.proyectoDataSet.USUARIOS);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = "insert into USUARIOS values ('" + txtName.Text + "','" + txtApellido.Text + "','" + txtGenero.Text + "'," + txtDNI.Text + ")";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text; // Indica el tipo de comando

                cn.Open();
                cmd.ExecuteNonQuery();  // Ejecuta COmando

                mostrar();

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = "update USUARIOS set NOMBRE = '" + txtName.Text + "' , APELLIDO = '" + txtApellido.Text + "', GENERO = '" + txtGenero.Text + "', DNI = '" + txtDNI.Text + "' where DNI = '" + txtDNIAct.Text + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                cmd.ExecuteNonQuery();

                mostrar();

            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = "delete from USUARIOS where DNI = '" + txtDNIAct.Text + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                cmd.ExecuteNonQuery();
                mostrar();

            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            mostrar();


        }

        private void mostrar()
        {
            DataTable tabla = new DataTable();  // Representa una tabla en la memoria virtual

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string query = "select * from USUARIOS";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);  // Representa comando y conexion para rellenar la tabla

                da.SelectCommand.CommandType = CommandType.Text;


                cn.Open();

                da.Fill(tabla); // Llena la tabla

                dgvMuestra.DataSource = tabla; // Muestra la tabla


            }
        }

        private void dgvMuestra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
