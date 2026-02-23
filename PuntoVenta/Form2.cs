using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Corte : Form
    {
        public Corte()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_realizar_Click(object sender, EventArgs e)
        {
           
            decimal.TryParse(txtFondoi.Text, out decimal fondo);
            decimal.TryParse(txtEfectivo.Text, out decimal vEfectivo);
            decimal.TryParse(txtTarjeta.Text, out decimal vTarjeta);
            decimal.TryParse(txtEntradas.Text, out decimal entradas);
            decimal.TryParse(txtSalidas.Text, out decimal salidas);

            GuardarCorteCaja(fondo, vEfectivo, vTarjeta, entradas, salidas);


        
        }

        public void GuardarCorteCaja(decimal fondo, decimal vEfectivo, decimal vTarjeta, decimal entradas, decimal salidas)
        {
            // Calculamos el total en C# SOLO para poder imprimirlo en el ticket
            decimal totalCalculadoParaTicket = (fondo + vEfectivo + entradas) - salidas;

            string conexionString = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            // Volvemos a tu query original: ¡sin TotalCalculado!
            string query = @"INSERT INTO CortesCaja 
                     (FondoInicial, VentasEfectivo, VentasTarjeta, EntradasEfectivo, SalidasEfectivo, fecha) 
                     VALUES 
                     (@Fondo, @VentasEf, @VentasTar, @Entradas, @Salidas, @fecha)";

            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Fondo", fondo);
                        cmd.Parameters.AddWithValue("@VentasEf", vEfectivo);
                        cmd.Parameters.AddWithValue("@VentasTar", vTarjeta);
                        cmd.Parameters.AddWithValue("@Entradas", entradas);
                        cmd.Parameters.AddWithValue("@Salidas", salidas);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Corte de caja guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mandamos a llamar el método de impresión pasando el total que calculamos arriba
                        ImprimirTicketCorte(fondo, vEfectivo, vTarjeta, entradas, salidas, totalCalculadoParaTicket);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el corte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirTicketCorte(decimal fondo, decimal vEfectivo, decimal vTarjeta, decimal entradas, decimal salidas, decimal totalCalculado)
        {
            PrintDocument ticket = new PrintDocument();

            
            ticket.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                Graphics g = e.Graphics;
                Font fuenteTitulo = new Font("Courier New", 12, FontStyle.Bold);
                Font fuenteNormal = new Font("Courier New", 10, FontStyle.Regular);
                Font fuenteTotal = new Font("Courier New", 11, FontStyle.Bold);

                int y = 10; // Posición Y inicial
                int margenIzquierdo = 10;

                // Diseño del Ticket
                g.DrawString("--- CORTE DE CAJA ---", fuenteTitulo, Brushes.Black, margenIzquierdo, y);
                y += 25;
                g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;
                g.DrawString("-----------------------", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;

                // Detalle de los montos
                g.DrawString($"Fondo Inicial:  ${fondo:0.00}", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;
                g.DrawString($"Ventas Efec:    ${vEfectivo:0.00}", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;
                g.DrawString($"Ventas Tarj:    ${vTarjeta:0.00}", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;
                g.DrawString($"Entradas Efec:  ${entradas:0.00}", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;
                g.DrawString($"Salidas Efec:  -${salidas:0.00}", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;

                g.DrawString("-----------------------", fuenteNormal, Brushes.Black, margenIzquierdo, y);
                y += 20;

                // Total
                g.DrawString($"TOTAL EN CAJA:  ${totalCalculado:0.00}", fuenteTotal, Brushes.Black, margenIzquierdo, y);
                y += 30;

                g.DrawString("*** FIN DEL CORTE ***", fuenteNormal, Brushes.Black, margenIzquierdo + 10, y);
            };

            try
            {
                ticket.Print(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el ticket: " + ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

            
}
 

