namespace Pokedex_No_copyrigt.Vistas
{
    partial class FormAbilidad
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            idAbilidad = new TextBox();
            txtAbilidad = new TextBox();
            btnInsertar = new Button();
            button2 = new Button();
            dvgAbilidad = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dvgAbilidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // idAbilidad
            // 
            idAbilidad.BackColor = Color.Black;
            idAbilidad.Font = new Font("Century Gothic", 12F);
            idAbilidad.ForeColor = Color.White;
            idAbilidad.Location = new Point(12, 118);
            idAbilidad.Name = "idAbilidad";
            idAbilidad.Size = new Size(125, 32);
            idAbilidad.TabIndex = 1;
            // 
            // txtAbilidad
            // 
            txtAbilidad.BackColor = Color.Black;
            txtAbilidad.Font = new Font("Century Gothic", 12F);
            txtAbilidad.ForeColor = Color.White;
            txtAbilidad.Location = new Point(12, 212);
            txtAbilidad.Name = "txtAbilidad";
            txtAbilidad.Size = new Size(125, 32);
            txtAbilidad.TabIndex = 2;
            // 
            // btnInsertar
            // 
            btnInsertar.BackColor = Color.Black;
            btnInsertar.Font = new Font("Century Gothic", 12F);
            btnInsertar.ForeColor = Color.White;
            btnInsertar.Location = new Point(326, 290);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(94, 37);
            btnInsertar.TabIndex = 3;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = false;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Century Gothic", 12F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(477, 290);
            button2.Name = "button2";
            button2.Size = new Size(128, 37);
            button2.TabIndex = 4;
            button2.Text = "Actualizar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dvgAbilidad
            // 
            dvgAbilidad.AllowUserToAddRows = false;
            dvgAbilidad.AllowUserToDeleteRows = false;
            dvgAbilidad.AllowUserToResizeColumns = false;
            dvgAbilidad.AllowUserToResizeRows = false;
            dvgAbilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgAbilidad.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dvgAbilidad.BackgroundColor = Color.Black;
            dvgAbilidad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 16F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dvgAbilidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dvgAbilidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dvgAbilidad.DefaultCellStyle = dataGridViewCellStyle4;
            dvgAbilidad.Dock = DockStyle.Bottom;
            dvgAbilidad.EnableHeadersVisualStyles = false;
            dvgAbilidad.GridColor = Color.White;
            dvgAbilidad.Location = new Point(0, 353);
            dvgAbilidad.Margin = new Padding(3, 4, 3, 4);
            dvgAbilidad.MultiSelect = false;
            dvgAbilidad.Name = "dvgAbilidad";
            dvgAbilidad.ReadOnly = true;
            dvgAbilidad.RowHeadersVisible = false;
            dvgAbilidad.RowHeadersWidth = 51;
            dvgAbilidad.RowTemplate.Height = 24;
            dvgAbilidad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgAbilidad.ShowCellErrors = false;
            dvgAbilidad.ShowCellToolTips = false;
            dvgAbilidad.ShowEditingIcon = false;
            dvgAbilidad.ShowRowErrors = false;
            dvgAbilidad.Size = new Size(617, 200);
            dvgAbilidad.TabIndex = 17;
            dvgAbilidad.DoubleClick += dvgAbilidad_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 170);
            label2.Name = "label2";
            label2.Size = new Size(202, 23);
            label2.TabIndex = 19;
            label2.Text = "Nombre de habilidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 75);
            label3.Name = "label3";
            label3.Size = new Size(34, 23);
            label3.TabIndex = 20;
            label3.Text = "ID";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.salir1;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FormAbilidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(617, 553);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(btnInsertar);
            Controls.Add(txtAbilidad);
            Controls.Add(idAbilidad);
            Controls.Add(dvgAbilidad);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAbilidad";
            Text = "FormAbilidad";
            ((System.ComponentModel.ISupportInitialize)dvgAbilidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox idAbilidad;
        private TextBox txtAbilidad;
        private Button btnInsertar;
        private Button button2;
        private DataGridView dvgAbilidad;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
    }
}