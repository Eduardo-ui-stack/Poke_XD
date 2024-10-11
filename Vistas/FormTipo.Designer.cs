namespace Pokedex_No_copyrigt.Vistas
{
    partial class FormTipo
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            InsertarTipo = new Button();
            pictureBox1 = new PictureBox();
            TxtTipoName = new TextBox();
            TxtIdtipo = new TextBox();
            btnActualizar = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvTipo = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTipo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // InsertarTipo
            // 
            InsertarTipo.BackColor = Color.Black;
            InsertarTipo.Font = new Font("Century Gothic", 12F);
            InsertarTipo.ForeColor = Color.White;
            InsertarTipo.Location = new Point(349, 279);
            InsertarTipo.Name = "InsertarTipo";
            InsertarTipo.Size = new Size(94, 37);
            InsertarTipo.TabIndex = 3;
            InsertarTipo.Text = "Insertar";
            InsertarTipo.UseVisualStyleBackColor = false;
            InsertarTipo.Click += InsertarTipo_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.salir1;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TxtTipoName
            // 
            TxtTipoName.BackColor = Color.Black;
            TxtTipoName.Font = new Font("Century Gothic", 12F);
            TxtTipoName.ForeColor = Color.White;
            TxtTipoName.Location = new Point(12, 218);
            TxtTipoName.Name = "TxtTipoName";
            TxtTipoName.Size = new Size(174, 32);
            TxtTipoName.TabIndex = 1;
            // 
            // TxtIdtipo
            // 
            TxtIdtipo.BackColor = Color.Black;
            TxtIdtipo.Font = new Font("Century Gothic", 12F);
            TxtIdtipo.ForeColor = Color.White;
            TxtIdtipo.Location = new Point(12, 121);
            TxtIdtipo.Name = "TxtIdtipo";
            TxtIdtipo.Size = new Size(125, 32);
            TxtIdtipo.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Black;
            btnActualizar.Font = new Font("Century Gothic", 12F);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(487, 279);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(126, 37);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(56, 23);
            label1.TabIndex = 5;
            label1.Text = "Tipos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 170);
            label2.Name = "label2";
            label2.Size = new Size(174, 23);
            label2.TabIndex = 6;
            label2.Text = "Nombre de tipos";
            // 
            // dgvTipo
            // 
            dgvTipo.AllowUserToAddRows = false;
            dgvTipo.AllowUserToDeleteRows = false;
            dgvTipo.AllowUserToResizeColumns = false;
            dgvTipo.AllowUserToResizeRows = false;
            dgvTipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTipo.BackgroundColor = Color.Black;
            dgvTipo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 16F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTipo.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTipo.Dock = DockStyle.Bottom;
            dgvTipo.EnableHeadersVisualStyles = false;
            dgvTipo.GridColor = Color.White;
            dgvTipo.Location = new Point(0, 337);
            dgvTipo.Margin = new Padding(3, 4, 3, 4);
            dgvTipo.MultiSelect = false;
            dgvTipo.Name = "dgvTipo";
            dgvTipo.ReadOnly = true;
            dgvTipo.RowHeadersVisible = false;
            dgvTipo.RowHeadersWidth = 51;
            dgvTipo.RowTemplate.Height = 24;
            dgvTipo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipo.ShowCellErrors = false;
            dgvTipo.ShowCellToolTips = false;
            dgvTipo.ShowEditingIcon = false;
            dgvTipo.ShowRowErrors = false;
            dgvTipo.Size = new Size(635, 263);
            dgvTipo.TabIndex = 16;
            dgvTipo.DoubleClick += dgvTipo_DoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(dgvTipo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(TxtIdtipo);
            panel1.Controls.Add(TxtTipoName);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(InsertarTipo);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 600);
            panel1.TabIndex = 5;
            // 
            // FormTipo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 600);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTipo";
            Text = "FormTipocs";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTipo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button InsertarTipo;
        private PictureBox pictureBox1;
        private TextBox TxtTipoName;
        private TextBox TxtIdtipo;
        private Button btnActualizar;
        private Label label1;
        private Label label2;
        private DataGridView dgvTipo;
        private Panel panel1;
    }
}