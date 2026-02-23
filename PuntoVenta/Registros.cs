using ClosedXML.Excel;
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
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }


        private void CargarDatos()
        {
            string conexion = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM venta", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel(dataGridView1);
        }

        public void ExportarExcel(DataGridView dgv)
        {
            try
            {
                // Convertimos el DataGridView a DataTable
                DataTable dt = DataGridViewToDataTable(dgv);

                // Elegir dónde guardar el archivo
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel (*.xlsx)|*.xlsx";
                save.FileName = "Ventas.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    // Crear el archivo
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Reporte");
                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show("Excel generado con éxito.", "Listo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private DataTable DataGridViewToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 1. Crear las columnas del DataTable y detectar si son números
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                Type tipoColumna = typeof(string);

                if (dgv.Rows.Count > 0 && dgv.Rows[0].Cells[col.Index].Value != null)
                {
                    string valorPrueba = dgv.Rows[0].Cells[col.Index].Value.ToString();
                    if (decimal.TryParse(valorPrueba, out _))
                    {
                        tipoColumna = typeof(decimal);
                    }
                }
                dt.Columns.Add(col.HeaderText, tipoColumna);
            }

            // 2. Pasar los datos fila por fila
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow dr = dt.NewRow();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    object cellValue = row.Cells[i].Value;
                    if (cellValue != null)
                    {
                        if (dt.Columns[i].DataType == typeof(decimal))
                        {
                            string valStr = cellValue.ToString().Replace("$", "").Trim();
                            if (decimal.TryParse(valStr, out decimal numeroFinal))
                                dr[i] = numeroFinal;
                            else
                                dr[i] = 0;
                        }
                        else
                        {
                            dr[i] = cellValue.ToString();
                        }
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            FiltrarVentasPorFecha(fechaSeleccionada.Value);
        }

        private void FiltrarVentasPorFecha(DateTime fechaSeleccionada)
        {
            string conexion = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            // 1. Establecemos el rango del día (desde las 00:00:00 hasta el inicio del día siguiente)
            DateTime inicioDia = fechaSeleccionada.Date;
            DateTime finDia = inicioDia.AddDays(1);

            // 2. Consulta SQL filtrando por ese rango
            string query = "SELECT * FROM venta WHERE fecha >= @inicio AND fecha < @fin";

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
    }
}
