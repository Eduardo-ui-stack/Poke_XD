using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex_No_copyrigt.Vistas
{
    public partial class FormUsuarioscs : Form
    {
        public FormUsuarioscs()
        {
            InitializeComponent();
            InitializeComponent();
            comboBoxRoles.Items.Add("Admin");
            comboBoxRoles.Items.Add("Usuario");
            Clases.CLogin objetoUsuario = new Clases.CLogin();
            objetoUsuario.mostrarUsuarios(tablaUsuarios);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Clases.CConexion objetoConexion = new Clases.CConexion();
            objetoConexion.establecerConexion();

            Clases.CLogin objetoUsuario = new Clases.CLogin();
            objetoUsuario.CrearUsuarios(textBoxUsuario, textBoxCorreo, textBoxContraseña, comboBoxRoles);

            Clases.CLogin objetoUsuario1 = new Clases.CLogin();
            objetoUsuario1.mostrarUsuarios(tablaUsuarios);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clases.CLogin objetoUsuario = new Clases.CLogin();

            // Asumiendo que tienes un TextBox para el ID del usuario llamado idUsuario
            objetoUsuario.ActualizarUsuario(idUsuario, textBoxUsuario, textBoxCorreo, textBoxContraseña, comboBoxRoles);

            // Refrescar la lista de usuarios en el DataGridView
            objetoUsuario.mostrarUsuarios(tablaUsuarios);
        }

        private void tablaUsuarios_DoubleClick(object sender, EventArgs e)
        {
            Clases.CLogin objetoUsuarios = new Clases.CLogin();

            // Asegúrate de pasar el comboBoxRoles como parámetro
            objetoUsuarios.seleccionarUsuarios(tablaUsuarios, idUsuario, textBoxUsuario, textBoxCorreo, textBoxContraseña, comboBoxRoles);
        }
    }
}
