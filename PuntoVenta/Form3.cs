using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            string conexion = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CortesCaja", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarCortesPorFecha(fechaSeleccionada.Value);
        }

        private void FiltrarCortesPorFecha(DateTime fechaSeleccionada)
        {
            string conexion = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            // 1. Establecemos el rango del día (desde las 00:00:00 hasta el inicio del día siguiente)
            DateTime inicioDia = fechaSeleccionada.Date;
            DateTime finDia = inicioDia.AddDays(1);

            // 2. Consulta SQL filtrando por ese rango
            string query = "SELECT * FROM CortesCaja WHERE fecha >= @inicio AND fecha < @fin";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Pasamos los parámetros de forma segura
                        cmd.Parameters.AddWithValue("@inicio", inicioDia);
                        cmd.Parameters.AddWithValue("@fin", finDia);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Actualizamos el DataGridView con los datos filtrados
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar las ventas: " + ex.Message, "Error de Consulta");
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
