namespace Pokedex_No_copyrigt
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
            portada = new PictureBox();
            panel_formulario = new Panel();
            panel_menu = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_buscar = new Button();
            btn_intercambio = new Button();
            btn_registros = new Button();
            btn_crud_usuarios = new Button();
            btn_menu_exit = new Button();
            btn_menu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)portada).BeginInit();
            panel_formulario.SuspendLayout();
            panel_menu.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_menu).BeginInit();
            SuspendLayout();
            // 
            // portada
            // 
            portada.InitialImage = null;
            portada.Location = new Point(0, 0);
            portada.Name = "portada";
            portada.Size = new Size(400, 600);
            portada.TabIndex = 0;
            portada.TabStop = false;
            portada.Click += AbrirLibro;
            portada.MouseMove += Principal_MouseMove;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Black;
            panel_formulario.Controls.Add(panel_menu);
            panel_formulario.Controls.Add(btn_menu);
            panel_formulario.Controls.Add(portada);
            panel_formulario.Location = new Point(0, 0);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(800, 600);
            panel_formulario.TabIndex = 1;
            // 
            // panel_menu
            // 
            panel_menu.BackColor = Color.Black;
            panel_menu.Controls.Add(flowLayoutPanel1);
            panel_menu.Controls.Add(btn_menu_exit);
            panel_menu.Location = new Point(0, 91);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(59, 359);
            panel_menu.TabIndex = 19;
            panel_menu.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btn_buscar);
            flowLayoutPanel1.Controls.Add(btn_intercambio);
            flowLayoutPanel1.Controls.Add(btn_registros);
            flowLayoutPanel1.Controls.Add(btn_crud_usuarios);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 87);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(59, 272);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_buscar
            // 
            btn_buscar.BackColor = Color.Transparent;
            btn_buscar.FlatAppearance.BorderSize = 0;
            btn_buscar.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_buscar.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_buscar.FlatStyle = FlatStyle.Flat;
            btn_buscar.Image = Properties.Resources.registro1;
            btn_buscar.Location = new Point(3, 3);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(51, 62);
            btn_buscar.TabIndex = 1;
            btn_buscar.UseVisualStyleBackColor = false;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // btn_intercambio
            // 
            btn_intercambio.BackColor = Color.Transparent;
            btn_intercambio.FlatAppearance.BorderSize = 0;
            btn_intercambio.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_intercambio.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_intercambio.FlatStyle = FlatStyle.Flat;
            btn_intercambio.Image = Properties.Resources.trade1;
            btn_intercambio.Location = new Point(3, 71);
            btn_intercambio.Name = "btn_intercambio";
            btn_intercambio.Size = new Size(51, 62);
            btn_intercambio.TabIndex = 2;
            btn_intercambio.UseVisualStyleBackColor = false;
            btn_intercambio.Click += btn_intercambio_Click;
            // 
            // btn_registros
            // 
            btn_registros.BackColor = Color.Transparent;
            btn_registros.FlatAppearance.BorderSize = 0;
            btn_registros.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_registros.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_registros.FlatStyle = FlatStyle.Flat;
            btn_registros.Image = Properties.Resources.añadir1;
            btn_registros.Location = new Point(3, 139);
            btn_registros.Name = "btn_registros";
            btn_registros.Size = new Size(51, 62);
            btn_registros.TabIndex = 3;
            btn_registros.UseVisualStyleBackColor = false;
            btn_registros.Click += btn_registros_Click;
            // 
            // btn_crud_usuarios
            // 
            btn_crud_usuarios.BackColor = Color.Transparent;
            btn_crud_usuarios.FlatAppearance.BorderSize = 0;
            btn_crud_usuarios.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_crud_usuarios.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_crud_usuarios.FlatStyle = FlatStyle.Flat;
            btn_crud_usuarios.Image = Properties.Resources.trainer;
            btn_crud_usuarios.Location = new Point(3, 207);
            btn_crud_usuarios.Name = "btn_crud_usuarios";
            btn_crud_usuarios.Size = new Size(51, 62);
            btn_crud_usuarios.TabIndex = 4;
            btn_crud_usuarios.UseVisualStyleBackColor = false;
            btn_crud_usuarios.Click += btn_crud_usuarios_Click;
            // 
            // btn_menu_exit
            // 
            btn_menu_exit.BackColor = Color.Transparent;
            btn_menu_exit.Dock = DockStyle.Top;
            btn_menu_exit.FlatAppearance.BorderSize = 0;
            btn_menu_exit.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_menu_exit.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_menu_exit.FlatStyle = FlatStyle.Flat;
            btn_menu_exit.Image = Properties.Resources.salir1;
            btn_menu_exit.Location = new Point(0, 0);
            btn_menu_exit.Name = "btn_menu_exit";
            btn_menu_exit.Size = new Size(59, 62);
            btn_menu_exit.TabIndex = 0;
            btn_menu_exit.UseVisualStyleBackColor = false;
            btn_menu_exit.Click += btn_menu_exit_Click;
            // 
            // btn_menu
            // 
            btn_menu.BackColor = Color.Transparent;
            btn_menu.Image = Properties.Resources.menu;
            btn_menu.Location = new Point(0, 0);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(91, 83);
            btn_menu.TabIndex = 18;
            btn_menu.TabStop = false;
            btn_menu.Visible = false;
            btn_menu.Click += btn_menu_DoubleClick;
            btn_menu.MouseHover += pictureBox1_Click;
            btn_menu.MouseMove += Principal_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 600);
            Controls.Add(panel_formulario);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "z";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            MouseMove += Principal_MouseMove;
            ((System.ComponentModel.ISupportInitialize)portada).EndInit();
            panel_formulario.ResumeLayout(false);
            panel_menu.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_menu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox portada;
        private Panel panel_formulario;
        private Panel panel_menu;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn_buscar;
        private Button btn_intercambio;
        private Button btn_registros;
        private Button btn_crud_usuarios;
        private Button btn_menu_exit;
        private PictureBox btn_menu;
    }
}
