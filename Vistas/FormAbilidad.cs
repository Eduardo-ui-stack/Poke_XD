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
    public partial class FormAbilidad : Form
    {
        public FormAbilidad()
        {
            InitializeComponent();
            Clases.CAbilidades objetoAbilidad = new Clases.CAbilidades();
            objetoAbilidad.mostrarAbilidades(dvgAbilidad);
        }
        private void dvgAbilidad_DoubleClick(object sender, EventArgs e)
        {
            Clases.CAbilidades objetoAbilidad = new Clases.CAbilidades();
            objetoAbilidad.seleccionarAbilidades(dvgAbilidad, idAbilidad, txtAbilidad);
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {


            Clases.CAbilidades objetoAbilidad = new Clases.CAbilidades();
            objetoAbilidad.InsertarAbilidades(txtAbilidad);

            objetoAbilidad.mostrarAbilidades(dvgAbilidad);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clases.CConexion objetoConexion = new Clases.CConexion();
            objetoConexion.establecerConexion();

            Clases.CAbilidades objetoAbilidad = new Clases.CAbilidades();
            objetoAbilidad.actualizaraAbilidades(idAbilidad, txtAbilidad);
            objetoAbilidad.mostrarAbilidades(dvgAbilidad);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
