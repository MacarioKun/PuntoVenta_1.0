namespace PuntoVenta
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            btn_registro = new Button();
            btn_cobrar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(255, 255, 192);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btn_registro);
            panel1.Controls.Add(btn_cobrar);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 783);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Gold;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 529);
            button2.Name = "button2";
            button2.Size = new Size(228, 109);
            button2.TabIndex = 4;
            button2.Text = "Registros corte";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 387);
            button1.Name = "button1";
            button1.Size = new Size(228, 109);
            button1.TabIndex = 3;
            button1.Text = "Corte";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btn_registro
            // 
            btn_registro.BackColor = Color.Gold;
            btn_registro.Cursor = Cursors.Hand;
            btn_registro.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_registro.ForeColor = Color.White;
            btn_registro.Location = new Point(3, 246);
            btn_registro.Name = "btn_registro";
            btn_registro.Size = new Size(228, 109);
            btn_registro.TabIndex = 2;
            btn_registro.Text = "Registros";
            btn_registro.UseVisualStyleBackColor = false;
            btn_registro.Click += btn_registro_Click;
            // 
            // btn_cobrar
            // 
            btn_cobrar.BackColor = Color.Gold;
            btn_cobrar.Cursor = Cursors.Hand;
            btn_cobrar.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cobrar.ForeColor = Color.White;
            btn_cobrar.Location = new Point(3, 104);
            btn_cobrar.Name = "btn_cobrar";
            btn_cobrar.Size = new Size(228, 109);
            btn_cobrar.TabIndex = 1;
            btn_cobrar.Text = "Cobrar";
            btn_cobrar.UseVisualStyleBackColor = false;
            btn_cobrar.Click += btn_cobrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 783);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btn_cobrar;
        private Button btn_registro;
        private Button button1;
        private Button button2;
    }
}
