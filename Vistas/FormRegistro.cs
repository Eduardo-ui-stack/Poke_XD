using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;

namespace Pokedex_No_copyrigt.Vistas

{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();

            txtUsuario.ContextMenuStrip = new ContextMenuStrip();
            txtCorreo.ContextMenuStrip = new ContextMenuStrip();
            txtContraseña.ContextMenuStrip = new ContextMenuStrip();
        }

        //LINK PARA MANDAR AL LOGIN
        private void LoginLink_Click(object sender, EventArgs e)
        {
            // Aquí redirecciona al registro
            FormLogin loginform = new FormLogin();
            this.Hide();
            loginform.Show();
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


        //BOTON PARA REGISTRARSE
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string usuario = NormalizeUserInput(txtUsuario.Text);

            Clases.CConexion objetoConexion = new Clases.CConexion();
            objetoConexion.establecerConexion();

            Clases.CLogin objetoLogin = new Clases.CLogin();
            objetoLogin.InsertarUsuarios(txtUsuario, txtCorreo, txtContraseña);
        }


        // VALIDACION DE CAMPOS "USUARIO"
        private void txtUsuario_TextChanged(object sender, EventArgs e)
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
            //salta txt
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtCorreo.Focus(); 
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

        // VALIDACION DE CAMPOS "CORREO"
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string pattern = @"^[a-zA-Z0-9._]*@[a-zA-Z0-9]+\.(com)$";

            if (correo.Length > 25)
            {
                txtCorreo.Text = correo.Substring(0, 25);
                txtCorreo.SelectionStart = txtCorreo.Text.Length;
            }
            if (!Regex.IsMatch(txtCorreo.Text, pattern))
            {
                txtCorreo.BackColor = Color.LightPink; 
                                                       
            }
            else
            {
                txtCorreo.BackColor = Color.White; 
            }
        }
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '_' || e.KeyChar == '@' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true; 
            }
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
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
            //caracteres especiales
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
        }


    }
}
