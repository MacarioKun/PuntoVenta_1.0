namespace PuntoVenta
{
    partial class Registros
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
            dataGridView1 = new DataGridView();
            btn_cerrar = new Button();
            btn_actualizar = new Button();
            btn_excel = new Button();
            fechaSeleccionada = new DateTimePicker();
            btn_filtrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1379, 665);
            dataGridView1.TabIndex = 0;
            // 
            // btn_cerrar
            // 
            btn_cerrar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cerrar.Location = new Point(12, 700);
            btn_cerrar.Name = "btn_cerrar";
            btn_cerrar.Size = new Size(167, 72);
            btn_cerrar.TabIndex = 1;
            btn_cerrar.Text = "Cerrar";
            btn_cerrar.UseVisualStyleBackColor = true;
            btn_cerrar.Click += btn_cerrar_Click;
            // 
            // btn_actualizar
            // 
            btn_actualizar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_actualizar.Location = new Point(198, 700);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(167, 72);
            btn_actualizar.TabIndex = 2;
            btn_actualizar.Text = "Actualizar";
            btn_actualizar.UseVisualStyleBackColor = true;
            btn_actualizar.Click += btn_actualizar_Click;
            // 
            // btn_excel
            // 
            btn_excel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_excel.Location = new Point(381, 700);
            btn_excel.Name = "btn_excel";
            btn_excel.Size = new Size(270, 72);
            btn_excel.TabIndex = 3;
            btn_excel.Text = "Generar Excel";
            btn_excel.UseVisualStyleBackColor = true;
            btn_excel.Click += btn_excel_Click;
            // 
            // fechaSeleccionada
            // 
            fechaSeleccionada.Location = new Point(681, 728);
            fechaSeleccionada.Name = "fechaSeleccionada";
            fechaSeleccionada.Size = new Size(242, 23);
            fechaSeleccionada.TabIndex = 4;
            // 
            // btn_filtrar
            // 
            btn_filtrar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_filtrar.Location = new Point(944, 700);
            btn_filtrar.Name = "btn_filtrar";
            btn_filtrar.Size = new Size(167, 72);
            btn_filtrar.TabIndex = 5;
            btn_filtrar.Text = "Filtrar";
            btn_filtrar.UseVisualStyleBackColor = true;
            btn_filtrar.Click += btn_filtrar_Click;
            // 
            // Registros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(1403, 793);
            Controls.Add(btn_filtrar);
            Controls.Add(fechaSeleccionada);
            Controls.Add(btn_excel);
            Controls.Add(btn_actualizar);
            Controls.Add(btn_cerrar);
            Controls.Add(dataGridView1);
            Name = "Registros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registros";
            Load += Registros_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_cerrar;
        private Button btn_actualizar;
        private Button btn_excel;
        private DateTimePicker fechaSeleccionada;
        private Button btn_filtrar;
    }
}