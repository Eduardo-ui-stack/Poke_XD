namespace Pokedex_No_copyrigt.Vistas
{
    partial class Pokedex
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
            paginaDerecha = new PictureBox();
            Cargar_imagenes = new PictureBox();
            btn_arriba = new Button();
            btn_derecha = new Button();
            btn_abajo = new Button();
            btn_izquierda = new Button();
            paginaIzquierda = new PictureBox();
            txt_nombre = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_peso = new Label();
            txt_habiilidades = new Label();
            txt_Ghuevo = new Label();
            txt_altura = new Label();
            txt_decripcion = new TextBox();
            txt_id = new Label();
            label7 = new Label();
            Foto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)paginaDerecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cargar_imagenes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)paginaIzquierda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Foto).BeginInit();
            SuspendLayout();
            // 
            // paginaDerecha
            // 
            paginaDerecha.Dock = DockStyle.Right;
            paginaDerecha.Location = new Point(400, 0);
            paginaDerecha.Name = "paginaDerecha";
            paginaDerecha.Size = new Size(400, 600);
            paginaDerecha.SizeMode = PictureBoxSizeMode.StretchImage;
            paginaDerecha.TabIndex = 9;
            paginaDerecha.TabStop = false;
            // 
            // Cargar_imagenes
            // 
            Cargar_imagenes.BackColor = Color.FromArgb(238, 238, 238);
            Cargar_imagenes.Image = Properties.Resources.charmander;
            Cargar_imagenes.Location = new Point(125, 217);
            Cargar_imagenes.Name = "Cargar_imagenes";
            Cargar_imagenes.Size = new Size(144, 122);
            Cargar_imagenes.SizeMode = PictureBoxSizeMode.StretchImage;
            Cargar_imagenes.TabIndex = 12;
            Cargar_imagenes.TabStop = false;
            // 
            // btn_arriba
            // 
            btn_arriba.BackColor = Color.Gainsboro;
            btn_arriba.Cursor = Cursors.Hand;
            btn_arriba.FlatStyle = FlatStyle.Flat;
            btn_arriba.ForeColor = Color.Transparent;
            btn_arriba.Location = new Point(75, 453);
            btn_arriba.Name = "btn_arriba";
            btn_arriba.Size = new Size(37, 37);
            btn_arriba.TabIndex = 11;
            btn_arriba.UseVisualStyleBackColor = false;
            btn_arriba.Visible = false;
            btn_arriba.Click += btn_arriba_Click;
            // 
            // btn_derecha
            // 
            btn_derecha.BackColor = Color.Gainsboro;
            btn_derecha.Cursor = Cursors.Hand;
            btn_derecha.FlatStyle = FlatStyle.Flat;
            btn_derecha.ForeColor = Color.Transparent;
            btn_derecha.Location = new Point(115, 487);
            btn_derecha.Name = "btn_derecha";
            btn_derecha.Size = new Size(32, 39);
            btn_derecha.TabIndex = 13;
            btn_derecha.UseVisualStyleBackColor = false;
            btn_derecha.Visible = false;
            btn_derecha.Click += btn_derecha_Click;
            // 
            // btn_abajo
            // 
            btn_abajo.BackColor = Color.Gainsboro;
            btn_abajo.Cursor = Cursors.Hand;
            btn_abajo.FlatStyle = FlatStyle.Flat;
            btn_abajo.ForeColor = Color.Transparent;
            btn_abajo.Location = new Point(75, 526);
            btn_abajo.Name = "btn_abajo";
            btn_abajo.Size = new Size(37, 31);
            btn_abajo.TabIndex = 14;
            btn_abajo.UseVisualStyleBackColor = false;
            btn_abajo.Visible = false;
            btn_abajo.Click += btn_abajo_Click;
            // 
            // btn_izquierda
            // 
            btn_izquierda.BackColor = Color.Gainsboro;
            btn_izquierda.Cursor = Cursors.Hand;
            btn_izquierda.FlatStyle = FlatStyle.Flat;
            btn_izquierda.ForeColor = Color.Transparent;
            btn_izquierda.Location = new Point(41, 487);
            btn_izquierda.Name = "btn_izquierda";
            btn_izquierda.Size = new Size(32, 39);
            btn_izquierda.TabIndex = 15;
            btn_izquierda.UseVisualStyleBackColor = false;
            btn_izquierda.Visible = false;
            btn_izquierda.Click += btn_izquierda_Click;
            // 
            // paginaIzquierda
            // 
            paginaIzquierda.Image = Properties.Resources.menu;
            paginaIzquierda.InitialImage = Properties.Resources.menu;
            paginaIzquierda.Location = new Point(0, 0);
            paginaIzquierda.Name = "paginaIzquierda";
            paginaIzquierda.Size = new Size(400, 600);
            paginaIzquierda.SizeMode = PictureBoxSizeMode.StretchImage;
            paginaIzquierda.TabIndex = 10;
            paginaIzquierda.TabStop = false;
            // 
            // txt_nombre
            // 
            txt_nombre.AutoSize = true;
            txt_nombre.BackColor = Color.FromArgb(238, 238, 238);
            txt_nombre.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_nombre.Location = new Point(85, 348);
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(0, 34);
            txt_nombre.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(427, 53);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 17;
            label1.Text = "Altura";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(430, 407);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 18;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(427, 321);
            label3.Name = "label3";
            label3.Size = new Size(143, 23);
            label3.TabIndex = 19;
            label3.Text = "Grupo Huevo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(427, 229);
            label4.Name = "label4";
            label4.Size = new Size(126, 23);
            label4.TabIndex = 20;
            label4.Text = "Habilidades";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Black;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(427, 138);
            label5.Name = "label5";
            label5.Size = new Size(56, 23);
            label5.TabIndex = 21;
            label5.Text = "Peso";
            // 
            // txt_peso
            // 
            txt_peso.AutoSize = true;
            txt_peso.BackColor = Color.Black;
            txt_peso.BorderStyle = BorderStyle.FixedSingle;
            txt_peso.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_peso.ForeColor = Color.White;
            txt_peso.Location = new Point(427, 172);
            txt_peso.Name = "txt_peso";
            txt_peso.Size = new Size(2, 25);
            txt_peso.TabIndex = 26;
            // 
            // txt_habiilidades
            // 
            txt_habiilidades.AutoSize = true;
            txt_habiilidades.BackColor = Color.Black;
            txt_habiilidades.BorderStyle = BorderStyle.FixedSingle;
            txt_habiilidades.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_habiilidades.ForeColor = Color.White;
            txt_habiilidades.Location = new Point(427, 263);
            txt_habiilidades.Name = "txt_habiilidades";
            txt_habiilidades.Size = new Size(2, 25);
            txt_habiilidades.TabIndex = 25;
            // 
            // txt_Ghuevo
            // 
            txt_Ghuevo.AutoSize = true;
            txt_Ghuevo.BackColor = Color.Black;
            txt_Ghuevo.BorderStyle = BorderStyle.FixedSingle;
            txt_Ghuevo.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Ghuevo.ForeColor = Color.White;
            txt_Ghuevo.Location = new Point(427, 355);
            txt_Ghuevo.Name = "txt_Ghuevo";
            txt_Ghuevo.Size = new Size(2, 25);
            txt_Ghuevo.TabIndex = 24;
            // 
            // txt_altura
            // 
            txt_altura.AutoSize = true;
            txt_altura.BackColor = Color.Black;
            txt_altura.BorderStyle = BorderStyle.FixedSingle;
            txt_altura.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_altura.ForeColor = Color.White;
            txt_altura.Location = new Point(427, 87);
            txt_altura.Name = "txt_altura";
            txt_altura.Size = new Size(2, 25);
            txt_altura.TabIndex = 22;
            // 
            // txt_decripcion
            // 
            txt_decripcion.BackColor = Color.Black;
            txt_decripcion.BorderStyle = BorderStyle.FixedSingle;
            txt_decripcion.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_decripcion.ForeColor = Color.White;
            txt_decripcion.Location = new Point(430, 444);
            txt_decripcion.Multiline = true;
            txt_decripcion.Name = "txt_decripcion";
            txt_decripcion.Size = new Size(341, 131);
            txt_decripcion.TabIndex = 27;
            // 
            // txt_id
            // 
            txt_id.AutoSize = true;
            txt_id.BackColor = Color.Black;
            txt_id.BorderStyle = BorderStyle.FixedSingle;
            txt_id.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_id.ForeColor = Color.White;
            txt_id.Location = new Point(687, 53);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(2, 25);
            txt_id.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Black;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(650, 27);
            label7.Name = "label7";
            label7.Size = new Size(138, 23);
            label7.TabIndex = 28;
            label7.Text = "No pokemon";
            // 
            // Foto
            // 
            Foto.BackColor = Color.DimGray;
            Foto.Image = Properties.Resources._2;
            Foto.Location = new Point(400, 0);
            Foto.Name = "Foto";
            Foto.Size = new Size(400, 600);
            Foto.SizeMode = PictureBoxSizeMode.StretchImage;
            Foto.TabIndex = 30;
            Foto.TabStop = false;
            Foto.Visible = false;
            // 
            // Pokedex
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 600);
            Controls.Add(Foto);
            Controls.Add(txt_id);
            Controls.Add(label7);
            Controls.Add(txt_decripcion);
            Controls.Add(txt_peso);
            Controls.Add(txt_habiilidades);
            Controls.Add(txt_Ghuevo);
            Controls.Add(txt_altura);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_nombre);
            Controls.Add(paginaDerecha);
            Controls.Add(Cargar_imagenes);
            Controls.Add(btn_arriba);
            Controls.Add(btn_derecha);
            Controls.Add(btn_abajo);
            Controls.Add(btn_izquierda);
            Controls.Add(paginaIzquierda);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Pokedex";
            Text = "Pokedex";
            Load += Pokedex_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)paginaDerecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cargar_imagenes).EndInit();
            ((System.ComponentModel.ISupportInitialize)paginaIzquierda).EndInit();
            ((System.ComponentModel.ISupportInitialize)Foto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox paginaDerecha;
        private PictureBox Cargar_imagenes;
        private Button btn_arriba;
        private Button btn_derecha;
        private Button btn_abajo;
        private Button btn_izquierda;
        private PictureBox paginaIzquierda;
        private Label txt_nombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label txt_peso;
        private Label txt_habiilidades;
        private Label txt_Ghuevo;
        private Label txt_altura;
        private TextBox txt_decripcion;
        private Label txt_id;
        private Label label7;
        private PictureBox Foto;
    }
}