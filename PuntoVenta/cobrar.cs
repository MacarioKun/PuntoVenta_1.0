using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PuntoVenta
{
    public partial class cobrar : Form
    {

        double total = 0;
        double efectivoRecibido = 0;
        double cambioDevuelto = 0;

        public cobrar()
        {
            InitializeComponent();
        }

        private void cobrar_Load(object sender, EventArgs e)
        {

        }

        private void agregarCarrito(string nombre, double precio)
        {
            //Rellenado de la lista
            listCarrito.Items.Add($"{nombre} - ${precio:F2}");
            total += precio;
            lbl_total.Text = $"Total: ${total:F2}";
        }

        private void btn_tacos_Click(object sender, EventArgs e)
        {
            agregarCarrito("Enchiladas suizas", 120);
        }

        private void btn_tacospastor_Click(object sender, EventArgs e)
        {
            agregarCarrito("Flautas", 110);
        }

        private void btn_tacoPirata_Click(object sender, EventArgs e)
        {
            agregarCarrito("Tostadas de pollo", 120);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listCarrito.Items.Clear();
            total = 0;

            lbl_total.Text = $"Total: ${total}";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private double ObtenerPrecio(string item)
        {
            // Divide por el signo de $
            string[] partes = item.Split('$');

            // partes[1] contiene el precio — ej: "35"
            decimal precio = decimal.Parse(partes[1]);

            return (double)precio;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (listCarrito.SelectedIndex != -1) // Hay un elemento seleccionado
            {

                // Preguntar al usuario si quiere eliminar
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este artículo del carrito?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;


                // 1. Obtener el texto del artículo
                string item = listCarrito.SelectedItem.ToString();

                // 2. Extraer el precio del string (último número)
                double precio = ObtenerPrecio(item);

                // 3. Restar del total
                total -= precio;
                lbl_total.Text = $"Total: ${total}";

                // 4. Remover del carrito
                listCarrito.Items.RemoveAt(listCarrito.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecciona un artículo para eliminar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            if (double.TryParse(txt_efectivo.Text, out double efectivo))
            {
                if (efectivo < total)
                {
                    MessageBox.Show("El efectivo es insuficiente para cubrir el total.");
                    return;
                }

                efectivoRecibido = efectivo;
                txt_efectivo.Clear();
            }
            else
            {
                MessageBox.Show("Por favor ingresa una cantidad de efectivo válida.");
                return;
            }

            cambioDevuelto = efectivoRecibido - total;

            string concepto = string.Join(", ", listCarrito.Items.Cast<string>());
            GuardarVenta(total, efectivoRecibido, cambioDevuelto, concepto);

            lbl_total.Text = $"Total: ${total:F2}";
            lbl_cambio.Text = $"Cambio: ${cambioDevuelto:F2}";
            MessageBox.Show("Venta registrada correctamente");

            ImprimirTicket();
        }

        private void ImprimirTicket()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(DibujarTicket);

            // pd.PrinterSettings.PrinterName = "NombreDeTuImpresoraTermica"; // Descomenta esto para usar una impresora específica

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar imprimir: " + ex.Message);
            }
        }

        private void btn_refresco_Click(object sender, EventArgs e)
        {
            agregarCarrito("Refresco", 20.50);

        }

        private void GuardarVenta(double costo, double efectivo, double cambio, string concepto)
        {
            string conexion = "Server=localhost\\SQLEXPRESS;Database=PuntoRestaurante;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();

                string query = "INSERT INTO venta (concepto, costo, efectivo, cambio, fecha) " +
                               "VALUES (@concepto, @costo, @efectivo, @cambio, @fecha)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@concepto", concepto);
                    cmd.Parameters.AddWithValue("@costo", costo);
                    cmd.Parameters.AddWithValue("@efectivo", efectivo);
                    cmd.Parameters.AddWithValue("@cambio", cambio);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {

            if (listCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío, no hay nada que imprimir.");
                return;
            }

            PrintDocument pd = new PrintDocument();


            pd.PrintPage += new PrintPageEventHandler(DibujarTicket);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar imprimir: " + ex.Message);
            }
        }

        private void DibujarTicket(object sender, PrintPageEventArgs e)
        {

            Font fuenteNormal = new Font("Courier New", 10);
            Font fuenteNegrita = new Font("Courier New", 10, FontStyle.Bold);
            int y = 10;
            int x = 10;
            int saltoLinea = 20;

            e.Graphics.DrawString("--- MI RESTAURANTE ---", fuenteNegrita, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString("---------------------------------", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;


            foreach (var item in listCarrito.Items)
            {
                e.Graphics.DrawString(item.ToString(), fuenteNormal, Brushes.Black, x, y);
                y += saltoLinea;
            }

            e.Graphics.DrawString("---------------------------------", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString($"TOTAL:      {total:F2}", fuenteNegrita, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString($"EFECTIVO:   {efectivoRecibido:F2}", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString($"CAMBIO:     {cambioDevuelto:F2}", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString("---------------------------------", fuenteNormal, Brushes.Black, x, y);
            y += saltoLinea;
            e.Graphics.DrawString("¡Gracias por su compra!", fuenteNormal, Brushes.Black, x, y);

        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            Corte formulario = new Corte();
            formulario.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            agregarCarrito("Nuggets de pollo", 110);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            agregarCarrito("Tender de pollo", 120);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarCarrito("Papas fritas", 60);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            agregarCarrito("Papas fritas / Queso", 70);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            agregarCarrito("Pay salado", 120);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            agregarCarrito("Sandwichon", 130);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            agregarCarrito("Ensalada cesar", 120);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            agregarCarrito("Club sandwich", 120);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            agregarCarrito("Ensalada de pollo", 120);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            agregarCarrito("Torta jamon", 100);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            agregarCarrito("Torta puerco", 120);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            agregarCarrito("Torta pollo", 120);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            agregarCarrito("H. Clasica", 100);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            agregarCarrito("H. Doble", 120);

        }

        private void button17_Click(object sender, EventArgs e)
        {
            agregarCarrito("H. Especial", 110);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            agregarCarrito("Cheesecake", 65);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            agregarCarrito("Ptortuga", 65);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            agregarCarrito("Mousse mango", 65);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            agregarCarrito("De queso", 65);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            agregarCarrito("Chocovainilla", 65);

        }

        private void button24_Click(object sender, EventArgs e)
        {
            agregarCarrito("De frutas", 65);

        }

        private void button23_Click(object sender, EventArgs e)
        {
            agregarCarrito("Volcan", 65);

        }

        private void button32_Click(object sender, EventArgs e)
        {
            agregarCarrito("Americano", 35);

        }

        private void button31_Click(object sender, EventArgs e)
        {
            agregarCarrito("Moka caliente", 65);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            agregarCarrito("Frapuchinno", 65);

        }

        private void button27_Click(object sender, EventArgs e)
        {
            agregarCarrito("Chocolate", 55);

        }

        private void button29_Click(object sender, EventArgs e)
        {
            agregarCarrito("Ice moka", 65);

        }

        private void button28_Click(object sender, EventArgs e)
        {
            agregarCarrito("Licuado", 65);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            agregarCarrito("Malteada", 65);

        }

        private void button37_Click(object sender, EventArgs e)
        {
            agregarCarrito("Refresco", 30);

        }

        private void button36_Click(object sender, EventArgs e)
        {
            agregarCarrito("Aguas naturales", 30);

        }

        private void button35_Click(object sender, EventArgs e)
        {
            agregarCarrito("Jarra limonada", 115);

        }

        private void button33_Click(object sender, EventArgs e)
        {
            agregarCarrito("Frape", 65);

        }

        private void button34_Click(object sender, EventArgs e)
        {
            agregarCarrito("Botella agua", 15);

        }
    }
}






