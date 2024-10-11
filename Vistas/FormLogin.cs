using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using static Pokedex_No_copyrigt.Clases.Cache;

namespace Pokedex_No_copyrigt.Vistas
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            
            //CTM cuadrito que sale al dar click derecho
            txtUsuario.ContextMenuStrip = new ContextMenuStrip(); 
            txtContraseña.ContextMenuStrip = new ContextMenuStrip();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Aquí redirecciona al registro
            FormRegistro registroform = new FormRegistro();
            this.Hide();
            registroform.Show();
        }


        // BOTON DE INICIO DE SESION
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = NormalizeUserInput(txtUsuario.Text);
            // no aceptar txt vacios
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear una instancia de la clase CLogin
            Clases.CLogin login = new Clases.CLogin();

            // Llamar al método IniciarSesion y verificar si la autenticación fue exitosa
            int resultado = login.IniciarSesion(txtUsuario, txtContraseña);

            // Si el resultado es verdadero, proceder a la página principal
            if (resultado == 1)
            {
                // Si el resultado es 1, el usuario es administrador
               
                Form1 inicioform = new Form1();
                this.Hide();
                inicioform.Show();
            }
            else if (resultado == 0)
            {

                
                Form1 inicioform = new Form1();  // cambiar aca
                this.Hide();
                inicioform.Show();
                inicioform.Entrenador();
            }
            
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

        // VALIDACION DE CAMPOS "USUARIO"
        private void txtUsuarioTextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 15)
            {
                txtUsuario.Text = txtUsuario.Text.Substring(0, 15);
                txtUsuario.SelectionStart = txtUsuario.Text.Length;
                txtUsuario.SelectionLength = 0;
            }
        }
        private string NormalizeUserInput(string input)
        {

            return Regex.Replace(input.Trim(), @"\s+", " ");
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            
            txtUsuario.Text = NormalizeUserInput(txtUsuario.Text);
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // evitar copiar y pegar
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtContraseña.Focus(); 
            }
        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //caracteres speciales
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // VALIDACION DE CAMPOS "CONTRASEÑA"
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length > 15)
            {
                txtContraseña.Text = txtContraseña.Text.Substring(0, 15);
                txtContraseña.SelectionStart = txtContraseña.Text.Length;
                txtContraseña.SelectionLength = 0;
            }
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // no espacios
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; 
            }
            //caracteres speciales
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // evitar copiar y pegar
                
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}