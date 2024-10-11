namespace Pokedex_No_copyrigt.Vistas
{
    partial class buscador_pokemon
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Buscador = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Nombres = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Buscador).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Buscador
            // 
            Buscador.AllowUserToAddRows = false;
            Buscador.AllowUserToDeleteRows = false;
            Buscador.AllowUserToResizeColumns = false;
            Buscador.AllowUserToResizeRows = false;
            Buscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Buscador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Buscador.BackgroundColor = Color.Black;
            Buscador.BorderStyle = BorderStyle.None;
            Buscador.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Buscador.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            Buscador.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Buscador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Buscador.ColumnHeadersHeight = 29;
            Buscador.ColumnHeadersVisible = false;
            Buscador.Columns.AddRange(new DataGridViewColumn[] { Id, Column1, Nombres });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Brown;
            dataGridViewCellStyle2.SelectionForeColor = Color.Brown;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Buscador.DefaultCellStyle = dataGridViewCellStyle2;
            Buscador.Dock = DockStyle.Fill;
            Buscador.EnableHeadersVisualStyles = false;
            Buscador.GridColor = Color.Black;
            Buscador.Location = new Point(0, 84);
            Buscador.MultiSelect = false;
            Buscador.Name = "Buscador";
            Buscador.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Buscador.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Buscador.RowHeadersVisible = false;
            Buscador.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            Buscador.RowsDefaultCellStyle = dataGridViewCellStyle4;
            Buscador.ScrollBars = ScrollBars.None;
            Buscador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Buscador.ShowCellErrors = false;
            Buscador.ShowCellToolTips = false;
            Buscador.ShowEditingIcon = false;
            Buscador.ShowRowErrors = false;
            Buscador.Size = new Size(382, 469);
            Buscador.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 6;
            // 
            // Column1
            // 
            Column1.HeaderText = "imagen";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            Column1.Width = 6;
            // 
            // Nombres
            // 
            Nombres.HeaderText = "Column2";
            Nombres.MinimumWidth = 6;
            Nombres.Name = "Nombres";
            Nombres.ReadOnly = true;
            Nombres.Width = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 84);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(191, 25);
            label1.Name = "label1";
            label1.Size = new Size(143, 37);
            label1.TabIndex = 0;
            label1.Text = "Pokedex";
            // 
            // buscador_pokemon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 553);
            Controls.Add(Buscador);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "buscador_pokemon";
            Text = "buscador_pokemon";
            Load += buscador_pokemon_Load;
            KeyDown += buscador_pokemon_KeyDown;
            ((System.ComponentModel.ISupportInitialize)Buscador).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Buscador;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewImageColumn Column1;
        private DataGridViewTextBoxColumn Nombres;
        private Panel panel1;
        private Label label1;
    }
}