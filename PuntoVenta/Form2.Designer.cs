namespace PuntoVenta
{
    partial class Corte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label1 = new Label();
            txtFondoi = new TextBox();
            txtTarjeta = new TextBox();
            label3 = new Label();
            txtEfectivo = new TextBox();
            label4 = new Label();
            txtEntradas = new TextBox();
            label5 = new Label();
            txtSalidas = new TextBox();
            label6 = new Label();
            btn_realizar = new Button();
            btn_cancelar = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(197, 40);
            label2.TabIndex = 1;
            label2.Text = "Corte de caja";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 66);
            label1.Name = "label1";
            label1.Size = new Size(140, 30);
            label1.TabIndex = 2;
            label1.Text = "Fondo inicial";
            // 
            // txtFondoi
            // 
            txtFondoi.Location = new Point(12, 99);
            txtFondoi.Name = "txtFondoi";
            txtFondoi.Size = new Size(542, 23);
            txtFondoi.TabIndex = 3;
            // 
            // txtTarjeta
            // 
            txtTarjeta.Location = new Point(12, 247);
            txtTarjeta.Name = "txtTarjeta";
            txtTarjeta.Size = new Size(542, 23);
            txtTarjeta.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 214);
            label3.Name = "label3";
            label3.Size = new Size(138, 30);
            label3.TabIndex = 7;
            label3.Text = "Venta tarjeta";
            // 
            // txtEfectivo
            // 
            txtEfectivo.Location = new Point(12, 171);
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.Size = new Size(542, 23);
            txtEfectivo.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(153, 30);
            label4.TabIndex = 11;
            label4.Text = "Venta efectivo";
            // 
            // txtEntradas
            // 
            txtEntradas.Location = new Point(12, 325);
            txtEntradas.Name = "txtEntradas";
            txtEntradas.Size = new Size(542, 23);
            txtEntradas.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 292);
            label5.Name = "label5";
            label5.Size = new Size(141, 30);
            label5.TabIndex = 15;
            label5.Text = "Entradas caja";
            // 
            // txtSalidas
            // 
            txtSalidas.Location = new Point(12, 401);
            txtSalidas.Name = "txtSalidas";
            txtSalidas.Size = new Size(542, 23);
            txtSalidas.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 368);
            label6.Name = "label6";
            label6.Size = new Size(125, 30);
            label6.TabIndex = 19;
            label6.Text = "Salidas caja";
            // 
            // btn_realizar
            // 
            btn_realizar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_realizar.Location = new Point(12, 464);
            btn_realizar.Name = "btn_realizar";
            btn_realizar.Size = new Size(542, 66);
            btn_realizar.TabIndex = 21;
            btn_realizar.Text = "Realizar corte";
            btn_realizar.UseVisualStyleBackColor = true;
            btn_realizar.Click += btn_realizar_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelar.Location = new Point(12, 536);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(542, 66);
            btn_cancelar.TabIndex = 22;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // Corte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(568, 615);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_realizar);
            Controls.Add(txtSalidas);
            Controls.Add(label6);
            Controls.Add(txtEntradas);
            Controls.Add(label5);
            Controls.Add(txtEfectivo);
            Controls.Add(label4);
            Controls.Add(txtTarjeta);
            Controls.Add(label3);
            Controls.Add(txtFondoi);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Corte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Corte";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox txtFondoi;
        private TextBox txtTarjeta;
        private Label label3;
        private TextBox txtEfectivo;
        private Label label4;
        private TextBox txtEntradas;
        private Label label5;
        private TextBox txtSalidas;
        private Label label6;
        private Button btn_realizar;
        private Button btn_cancelar;
    }
}