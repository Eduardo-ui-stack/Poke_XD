namespace Pokedex_No_copyrigt.Vistas
{
    partial class FormRegistro
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
            panel1 = new Panel();
            txtCorreo = new TextBox();
            label6 = new Label();
            LoginLink = new Label();
            btnRegistrar = new Button();
            label4 = new Label();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCorreo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(LoginLink);
            panel1.Controls.Add(btnRegistrar);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 750);
            panel1.TabIndex = 0;
            panel1.MouseMove += Principal_MouseMove;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(63, 322);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(380, 34);
            txtCorreo.TabIndex = 18;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            txtCorreo.KeyDown += txtCorreo_KeyDown;
            txtCorreo.KeyPress += txtCorreo_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(58, 285);
            label6.Name = "label6";
            label6.Size = new Size(88, 27);
            label6.TabIndex = 17;
            label6.Text = "Correo";
            // 
            // LoginLink
            // 
            LoginLink.AutoSize = true;
            LoginLink.BackColor = Color.Transparent;
            LoginLink.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginLink.ForeColor = Color.Blue;
            LoginLink.Location = new Point(296, 636);
            LoginLink.Name = "LoginLink";
            LoginLink.Size = new Size(135, 24);
            LoginLink.TabIndex = 16;
            LoginLink.Text = "Iniciar sesión";
            LoginLink.Click += LoginLink_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Red;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(141, 536);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(208, 56);
            btnRegistrar.TabIndex = 15;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrarse_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 636);
            label4.Name = "label4";
            label4.Size = new Size(231, 24);
            label4.TabIndex = 14;
            label4.Text = "¿Ya tienes una cuenta?";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(63, 445);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(380, 34);
            txtContraseña.TabIndex = 13;
            txtContraseña.TextChanged += txtContraseña_TextChanged;
            txtContraseña.KeyDown += txtContraseña_KeyDown;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(63, 198);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(380, 34);
            txtUsuario.TabIndex = 12;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            txtUsuario.KeyPress += txtUsuario_KeyPress;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(58, 408);
            label3.Name = "label3";
            label3.Size = new Size(141, 27);
            label3.TabIndex = 11;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(58, 160);
            label2.Name = "label2";
            label2.Size = new Size(100, 27);
            label2.TabIndex = 10;
            label2.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(156, 69);
            label1.Name = "label1";
            label1.Size = new Size(178, 48);
            label1.TabIndex = 9;
            label1.Text = "Registro";
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 750);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistro";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LoginLink;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label6;
    }
}