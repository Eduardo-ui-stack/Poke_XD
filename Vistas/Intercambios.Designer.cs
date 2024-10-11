namespace Pokedex_No_copyrigt.Vistas
{
    partial class Intercambios
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
            list_usuarios = new ComboBox();
            button1 = new Button();
            txt_pokemon = new TextBox();
            label2 = new Label();
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
            Buscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            Buscador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Buscador.BackgroundColor = Color.Black;
            Buscador.BorderStyle = BorderStyle.None;
            Buscador.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Buscador.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
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
            Buscador.Dock = DockStyle.Right;
            Buscador.EditMode = DataGridViewEditMode.EditProgrammatically;
            Buscador.EnableHeadersVisualStyles = false;
            Buscador.GridColor = Color.Black;
            Buscador.Location = new Point(386, 0);
            Buscador.MultiSelect = false;
            Buscador.Name = "Buscador";
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
            Buscador.Size = new Size(396, 553);
            Buscador.TabIndex = 8;
            Buscador.DoubleClick += Buscador_DoubleClick;
            // 
            // Id
            // 
            Id.HeaderText = "id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 6;
            // 
            // Column1
            // 
            Column1.HeaderText = "imagen";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            Column1.Width = 6;
            // 
            // Nombres
            // 
            Nombres.HeaderText = "Column2";
            Nombres.MinimumWidth = 6;
            Nombres.Name = "Nombres";
            Nombres.Width = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(list_usuarios);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txt_pokemon);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 553);
            panel1.TabIndex = 9;
            // 
            // list_usuarios
            // 
            list_usuarios.BackColor = Color.Black;
            list_usuarios.FlatStyle = FlatStyle.Popup;
            list_usuarios.ForeColor = Color.White;
            list_usuarios.FormattingEnabled = true;
            list_usuarios.Location = new Point(72, 252);
            list_usuarios.Name = "list_usuarios";
            list_usuarios.Size = new Size(167, 28);
            list_usuarios.TabIndex = 25;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.confirmar;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(46, 469);
            button1.Name = "button1";
            button1.Size = new Size(292, 34);
            button1.TabIndex = 24;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_pokemon
            // 
            txt_pokemon.BackColor = Color.Black;
            txt_pokemon.Font = new Font("Century Gothic", 12F);
            txt_pokemon.ForeColor = Color.White;
            txt_pokemon.Location = new Point(72, 147);
            txt_pokemon.Name = "txt_pokemon";
            txt_pokemon.ReadOnly = true;
            txt_pokemon.Size = new Size(167, 32);
            txt_pokemon.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(72, 208);
            label2.Name = "label2";
            label2.Size = new Size(236, 23);
            label2.TabIndex = 19;
            label2.Text = "Entrenador conectado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(72, 106);
            label1.Name = "label1";
            label1.Size = new Size(243, 23);
            label1.TabIndex = 17;
            label1.Text = "Pokemon para transferir";
            // 
            // Intercambios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(782, 553);
            Controls.Add(Buscador);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Intercambios";
            Text = "Intercambios";
            Load += Intercambios_Load;
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
        private Label label2;
        private Label label1;
        private TextBox txt_pokemon;
        private Button button1;
        private ComboBox list_usuarios;
    }
}