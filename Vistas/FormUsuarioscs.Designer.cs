namespace Pokedex_No_copyrigt.Vistas
{
    partial class FormUsuarioscs
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
            idUsuario = new TextBox();
            textBoxUsuario = new TextBox();
            textBoxCorreo = new TextBox();
            textBoxContraseña = new TextBox();
            comboBoxRoles = new ComboBox();
            btnInsertar = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tablaUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tablaUsuarios).BeginInit();
            SuspendLayout();
            // 
            // idUsuario
            // 
            idUsuario.Location = new Point(34, 29);
            idUsuario.Name = "idUsuario";
            idUsuario.Size = new Size(125, 27);
            idUsuario.TabIndex = 0;
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(34, 83);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(125, 27);
            textBoxUsuario.TabIndex = 1;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(34, 170);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(125, 27);
            textBoxCorreo.TabIndex = 2;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Location = new Point(34, 235);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.Size = new Size(125, 27);
            textBoxContraseña.TabIndex = 3;
            // 
            // comboBoxRoles
            // 
            comboBoxRoles.FormattingEnabled = true;
            comboBoxRoles.Location = new Point(253, 75);
            comboBoxRoles.Name = "comboBoxRoles";
            comboBoxRoles.Size = new Size(151, 28);
            comboBoxRoles.TabIndex = 4;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(55, 321);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(94, 29);
            btnInsertar.TabIndex = 5;
            btnInsertar.Text = "Agregar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(200, 321);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Actualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 60);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 7;
            label1.Text = "Nombre Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 135);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 8;
            label2.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 212);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 9;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(253, 32);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 10;
            label4.Text = "Roles";
            // 
            // tablaUsuarios
            // 
            tablaUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaUsuarios.Location = new Point(396, 126);
            tablaUsuarios.Name = "tablaUsuarios";
            tablaUsuarios.RowHeadersWidth = 51;
            tablaUsuarios.Size = new Size(300, 188);
            tablaUsuarios.TabIndex = 11;
            tablaUsuarios.DoubleClick += tablaUsuarios_DoubleClick;
            // 
            // FormUsuarioscs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tablaUsuarios);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnInsertar);
            Controls.Add(comboBoxRoles);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxCorreo);
            Controls.Add(textBoxUsuario);
            Controls.Add(idUsuario);
            Name = "FormUsuarioscs";
            Text = "FormUsuarioscs";
            ((System.ComponentModel.ISupportInitialize)tablaUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idUsuario;
        private TextBox textBoxUsuario;
        private TextBox textBoxCorreo;
        private TextBox textBoxContraseña;
        private ComboBox comboBoxRoles;
        private Button btnInsertar;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView tablaUsuarios;
    }
}