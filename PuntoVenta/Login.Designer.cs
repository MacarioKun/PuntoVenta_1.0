namespace PuntoVenta
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(178, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 40);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 203);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 231);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(487, 23);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 257);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 285);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(487, 23);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(195, 49);
            label4.Name = "label4";
            label4.Size = new Size(128, 21);
            label4.TabIndex = 5;
            label4.Text = "Inicio de sesion";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 340);
            button1.Name = "button1";
            button1.Size = new Size(487, 66);
            button1.TabIndex = 6;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 411);
            button2.Name = "button2";
            button2.Size = new Size(487, 66);
            button2.TabIndex = 7;
            button2.Text = "Cerrar aplicacion";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 141);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 8;
            label5.Text = "Escojer rol";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 169);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(487, 23);
            comboBox1.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(511, 489);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Button button1;
        private Button button2;
        private Label label5;
        private ComboBox comboBox1;
    }
}