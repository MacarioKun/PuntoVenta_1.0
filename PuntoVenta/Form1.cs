namespace PuntoVenta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_cobrar_Click(object sender, EventArgs e)
        {
            cobrar formulario = new cobrar();
            formulario.MdiParent = this;
            formulario.Show();

        }

        private void btn_registro_Click(object sender, EventArgs e)
        {
            Registros formulario = new Registros();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Corte formulario = new Corte();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formulario = new Form3();
            formulario.MdiParent = this; 
            formulario.Show();
        }
    }
}
