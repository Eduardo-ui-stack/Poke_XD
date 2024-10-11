using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;
using Pokedex_No_copyrigt.Vistas;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.XPath;
using Timer = System.Windows.Forms.Timer;



namespace Pokedex_No_copyrigt
{
    public partial class Form1 : Form
    {

        Timer animacionTimer = new Timer();
        int paso = 10; // Controlaremos el incremento de la animación
        int maxAnchoForm = 800; // Tamaño objetivo del formulario



        private Pokedex pokeAbrieta;
        private buscador_pokemon busPoke;
        private Intercambios Pokeintercambios;
        private registrode_poke registros;
        private regitros_usu registros_usuarios;
        public Form1()
        {
            pokeAbrieta = new Pokedex();
            busPoke = new buscador_pokemon();
            Pokeintercambios = new Intercambios();
            registros = new registrode_poke();
            registros_usuarios = new regitros_usu();
            InitializeComponent();
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10; // Intervalo para la animación (más pequeño = más suave)
            animationTimer.Tick += AnimationTimer_Tick;

            // Configuración inicial del panel del menú
            panel_menu.Width = 1;
            panel_menu.Visible = false;
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isExpanding)
            {
                if (panel_menu.Width < targetWidth)
                {
                    panel_menu.Width += 10; // Incrementa el ancho para expandir
                    if (panel_menu.Width > targetWidth)
                    {
                        panel_menu.Width = targetWidth; // Asegura que no sobrepase el ancho objetivo
                        animationTimer.Stop();
                    }
                }
            }
            else
            {
                if (panel_menu.Width > targetWidth)
                {
                    panel_menu.Width -= 10; // Decrementa el ancho para contraer
                    if (panel_menu.Width < targetWidth)
                    {
                        panel_menu.Width = targetWidth; // Asegura que no sea menor que el ancho objetivo
                        panel_menu.Visible = false;
                        animationTimer.Stop();
                    }
                }
            }
        }

        private void btn_menu_exit_Click(object sender, EventArgs e)
        {
            isExpanding = false;
            targetWidth = 1; // Ancho objetivo
            animationTimer.Start();
            Menu_desplegado = false;
        }
        public void controla_bordes()
        {
            // Crear una nueva instancia de GraphicsPath
            GraphicsPath formPath = new GraphicsPath();

            // Definir el radio de las esquinas redondeadas
            int radius = 100; // Ajusta según tu preferencia

            // Agregar un rectángulo con esquinas redondeadas
            formPath.AddArc(0, 0, radius, radius, 180, 90); // Esquina superior izquierda
            formPath.AddArc(this.Width - radius - 1, 0, radius, radius, 270, 90); // Esquina superior derecha
            formPath.AddArc(this.Width - radius - 1, this.Height - radius - 1, radius, radius, 0, 90); // Esquina inferior derecha
            formPath.AddArc(0, this.Height - radius - 1, radius, radius, 90, 90); // Esquina inferior izquierda
            formPath.CloseAllFigures(); // Cerrar el camino de la forma

            // Asignar la nueva región con forma personalizada al formulario
            this.Region = new Region(formPath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            controla_bordes();
            // Cargar la imagen de la portada
            portada.Load("principal.gif");
            this.Width = 400;
            if (Cache.UserCache.rol)
            {
                pokeAbrieta.CargarPokemones();
            }
            else
            {
                pokeAbrieta.CargarPokemonesUsuario();
            }
        }
        public void Entrenador()
        {
            btn_registros.Visible = false;
            btn_crud_usuarios.Visible = false;
            panel_menu.Height = 220;
            flowLayoutPanel1.Height = flowLayoutPanel1.Height - 122;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Principal_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Abrir fromularios 
        public void AbrirFormulario(Form form1, Form form2, Form form3, Form form4,Form form5)
        {
            // Establecer el primer formulario como visible
            form1.Visible = true;
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            panel_formulario.Controls.Add(form1);
            panel_formulario.Tag = form1;
            form1.BringToFront();
            panel_menu.BringToFront();
            btn_menu.BringToFront();
            // Establecer los demás formularios como no visibles
            form2.Visible = false;
            form3.Visible = false;
            form4.Visible = false;
            form5.Visible = false;
        }



        private void AbrirLibro(object sender, EventArgs e)
        {
            animacionTimer.Interval = 30; // Cada 50ms actualiza la animación
            animacionTimer.Tick += new EventHandler(AnimarApertura);
            animacionTimer.Start();
            pokeAbrieta.Show();
            AbrirFormulario(pokeAbrieta, busPoke, Pokeintercambios, registros, registros_usuarios);
            btn_menu.Visible = true;

        }

        private void AnimarApertura(object sender, EventArgs e)
        {
            if (this.Width < maxAnchoForm) // Si la portada no ha salido completamente o el formulario no ha alcanzado el tamaño máximo
            {
                // Mueve la portada hacia la izquierda
                if (portada.Left > -portada.Width)
                {
                    portada.Left -= paso;
                }
                // Aumenta el ancho del formulario
                if (this.Width < maxAnchoForm)
                {
                    this.Width += paso;
                }
            }
            else
            {
                // Detenemos el timer cuando la portada ha salido completamente y el formulario ha alcanzado el tamaño deseado
                animacionTimer.Stop();
                portada.Visible = false;
                controla_bordes();// Ocultamos la portada una vez completada la animación
            }
        }

        private string keysPressed = "";
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("¿quieres salir de esta sección?", "Cerrar seción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CConexion objetoConexion = new CConexion();
                    var conexion = objetoConexion.establecerConexion();
                    string updateQuery = "UPDATE Usuarios SET Conectado = 0 WHERE id = @IdUsuario";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conexion))
                    {
                        updateCmd.Parameters.AddWithValue("@IdUsuario",Cache.UserCache.IdUser);
                        updateCmd.ExecuteNonQuery(); // Ejecuta la consulta de actualización
                    }
                    Application.Exit();
                }
                    
            }
            // Verifica si Shift y las teclas V, E, R, A están presionadas
            // Verifica si Shift está presionado
            if (e.Shift)
            {
                // Añade la tecla presionada a la secuencia
                keysPressed += e.KeyCode.ToString().ToUpper();

                // Si la secuencia es "VERA", muestra el mensaje
                if (keysPressed.Contains("V") && keysPressed.Contains("E") &&
                    keysPressed.Contains("R") && keysPressed.Contains("A"))
                {
                    MessageBox.Show("¡Sosa el más pollón!", "Mensaje especial");
                    keysPressed = ""; // Reinicia la secuencia
                }
            }
            else
            {
                // Si se suelta Shift o se presiona otra tecla, reinicia la secuencia
                keysPressed = "";
            }
        }


        private System.Windows.Forms.Timer animationTimer;
        private bool isExpanding; // Para controlar la dirección de la animación
        private int targetWidth;

        bool Menu_desplegado = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!Menu_desplegado)
            {
                panel_menu.Visible = true;
                isExpanding = true;
                targetWidth = 60; // Ancho objetivo
                animationTimer.Start();
                Menu_desplegado = true;

            }

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Region = null;
            this.Width = 400;
            panel_formulario.Width = 400;
            AbrirFormulario(busPoke, pokeAbrieta, Pokeintercambios, registros, registros_usuarios);
            if (Cache.UserCache.rol)
            {
                busPoke.cargarDatosPokemones();
            }
            else
            {
                busPoke.cargarDatosPokemonesEnrtrenadores();
            }

            controla_bordes();

        }

        private void btn_menu_DoubleClick(object sender, EventArgs e)
        {
            this.Region = null;

            this.Width = 800;
            panel_formulario.Width = 800;
            controla_bordes();
            if (Cache.UserCache.rol)
            {
                pokeAbrieta.CargarPokemones();
            }
            else
            {
                pokeAbrieta.CargarPokemonesUsuario();
            }
            AbrirLibro(sender, e);
        }

        private void btn_intercambio_Click(object sender, EventArgs e)
        {
            this.Region = null;
            this.Width = 800;
            panel_formulario.Width = 800;
            controla_bordes();
            AbrirFormulario(Pokeintercambios, busPoke, pokeAbrieta, registros, registros_usuarios);
            if (Cache.UserCache.rol)
            {
                Pokeintercambios.cargarDatosPokemones();
                Pokeintercambios.cargar_Entrenadores();
            }
            else
            {
                Pokeintercambios.cargarDatosPokemonesEnrtrenadores();
                Pokeintercambios.cargar_Entrenadores();
            }

        }

        private void btn_registros_Click(object sender, EventArgs e)
        {
            this.Region = null;
            this.Width = 1200;
            panel_formulario.Width = 1200;
            controla_bordes();
            AbrirFormulario(registros, Pokeintercambios, busPoke, pokeAbrieta, registros_usuarios);
            registros.Refresh();
        }

        private void btn_crud_usuarios_Click(object sender, EventArgs e)
        {
            this.Region = null;
            this.Width = 1022;
            panel_formulario.Width = 1022;
            controla_bordes();
            AbrirFormulario(registros_usuarios,registros, Pokeintercambios, busPoke, pokeAbrieta);
            registros_usuarios.CargarUsuarios();
        }










        // Aquí termina el código
    }
}









// MIT License
// Copyright (c) 2024 Jesús Eduardo Sosa Vera
//
// Este formulario es parte de un software licenciado bajo los términos de la licencia MIT.
// Puedes modificarlo y distribuirlo bajo los términos de la licencia.o 
