namespace Pokedex_No_copyrigt.Vistas
{
    partial class regitros_usu
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
            btn_confirmar = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            label1 = new Label();
            txt_usuario = new TextBox();
            list_rol = new ComboBox();
            Buscador = new DataGridView();
            panel1 = new Panel();
            btn_tipo = new Button();
            btn_habilidades = new Button();
            btn_usuarios = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)Buscador).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_confirmar
            // 
            btn_confirmar.FlatStyle = FlatStyle.Flat;
            btn_confirmar.Location = new Point(46, 340);
            btn_confirmar.Name = "btn_confirmar";
            btn_confirmar.Size = new Size(205, 37);
            btn_confirmar.TabIndex = 1;
            btn_confirmar.Text = "Confirmar";
            btn_confirmar.UseVisualStyleBackColor = true;
            btn_confirmar.Click += btn_confirmar_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 241);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 10;
            label1.Text = "Rol de Usuario";
            // 
            // txt_usuario
            // 
            txt_usuario.BackColor = Color.Black;
            txt_usuario.Font = new Font("Century Gothic", 12F);
            txt_usuario.ForeColor = Color.White;
            txt_usuario.Location = new Point(57, 185);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.ReadOnly = true;
            txt_usuario.Size = new Size(167, 32);
            txt_usuario.TabIndex = 24;
            // 
            // list_rol
            // 
            list_rol.BackColor = Color.Black;
            list_rol.FlatStyle = FlatStyle.Popup;
            list_rol.ForeColor = Color.White;
            list_rol.FormattingEnabled = true;
            list_rol.Items.AddRange(new object[] { "Administrador", "Entrenador" });
            list_rol.Location = new Point(57, 284);
            list_rol.Name = "list_rol";
            list_rol.Size = new Size(167, 31);
            list_rol.TabIndex = 26;
            // 
            // Buscador
            // 
            Buscador.AllowUserToAddRows = false;
            Buscador.AllowUserToDeleteRows = false;
            Buscador.AllowUserToResizeColumns = false;
            Buscador.AllowUserToResizeRows = false;
            Buscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Buscador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Buscador.BackgroundColor = Color.Black;
            Buscador.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Buscador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Buscador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Buscador.DefaultCellStyle = dataGridViewCellStyle2;
            Buscador.Dock = DockStyle.Fill;
            Buscador.EnableHeadersVisualStyles = false;
            Buscador.GridColor = Color.White;
            Buscador.Location = new Point(0, 0);
            Buscador.Margin = new Padding(3, 4, 3, 4);
            Buscador.MultiSelect = false;
            Buscador.Name = "Buscador";
            Buscador.ReadOnly = true;
            Buscador.RowHeadersVisible = false;
            Buscador.RowHeadersWidth = 51;
            Buscador.RowTemplate.Height = 24;
            Buscador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Buscador.ShowCellErrors = false;
            Buscador.ShowCellToolTips = false;
            Buscador.ShowEditingIcon = false;
            Buscador.ShowRowErrors = false;
            Buscador.Size = new Size(629, 600);
            Buscador.TabIndex = 27;
            Buscador.DoubleClick += Buscador_DoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(Buscador);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(393, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 600);
            panel1.TabIndex = 28;
            // 
            // btn_tipo
            // 
            btn_tipo.FlatStyle = FlatStyle.Flat;
            btn_tipo.Location = new Point(3, 3);
            btn_tipo.Name = "btn_tipo";
            btn_tipo.Size = new Size(98, 37);
            btn_tipo.TabIndex = 29;
            btn_tipo.Text = "Tipos";
            btn_tipo.UseVisualStyleBackColor = true;
            btn_tipo.Click += btn_tipo_Click;
            // 
            // btn_habilidades
            // 
            btn_habilidades.FlatStyle = FlatStyle.Flat;
            btn_habilidades.Location = new Point(3, 46);
            btn_habilidades.Name = "btn_habilidades";
            btn_habilidades.Size = new Size(154, 37);
            btn_habilidades.TabIndex = 30;
            btn_habilidades.Text = "Habilidades";
            btn_habilidades.UseVisualStyleBackColor = true;
            btn_habilidades.Click += button2_Click;
            // 
            // btn_usuarios
            // 
            btn_usuarios.FlatStyle = FlatStyle.Flat;
            btn_usuarios.Location = new Point(107, 3);
            btn_usuarios.Name = "btn_usuarios";
            btn_usuarios.Size = new Size(114, 37);
            btn_usuarios.TabIndex = 31;
            btn_usuarios.Text = "Usuarios";
            btn_usuarios.UseVisualStyleBackColor = true;
            btn_usuarios.Visible = false;
            btn_usuarios.Click += button3_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btn_tipo);
            flowLayoutPanel1.Controls.Add(btn_usuarios);
            flowLayoutPanel1.Controls.Add(btn_habilidades);
            flowLayoutPanel1.Location = new Point(12, 556);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(375, 44);
            flowLayoutPanel1.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 140);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 33;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 503);
            label3.Name = "label3";
            label3.Size = new Size(167, 23);
            label3.TabIndex = 34;
            label3.Text = "Agregar nuevos";
            // 
            // regitros_usu
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1022, 600);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(list_rol);
            Controls.Add(txt_usuario);
            Controls.Add(label1);
            Controls.Add(btn_confirmar);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "regitros_usu";
            Text = "regitros_usu";
            ((System.ComponentModel.ISupportInitialize)Buscador).EndInit();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_confirmar;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label label1;
        private TextBox txt_usuario;
        private ComboBox list_rol;
        private DataGridView Buscador;
        private Panel panel1;
        private Button btn_tipo;
        private Button btn_habilidades;
        private Button btn_usuarios;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label3;
    }
}