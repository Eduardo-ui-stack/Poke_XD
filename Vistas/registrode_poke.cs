using Pokedex_No_copyrigt.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // Asegúrate de tener esta línea para usar la clase Image
using System.IO;

namespace Pokedex_No_copyrigt
{
    
    public partial class registrode_poke : Form
    {
        private bool datosCargados = false;

        public registrode_poke()
        {
            InitializeComponent();
            
            CargarDatosComboBoxes(); // Cargar datos en ComboBoxes
            Clases.CPokemon objetoPokemon = new Clases.CPokemon();
            objetoPokemon.mostrarPokemones(tablaPokemones);
            LimpiarControles();
        }
        public void Refresh()
        {
            Clases.CPokemon objetoPokemon = new Clases.CPokemon();
            objetoPokemon.mostrarPokemones(tablaPokemones);
            LimpiarControles();
        }
        private void CargarDatosComboBoxes()
        {
            if (!datosCargados)
            {
                Clases.CPokemon objetoPokemon = new Clases.CPokemon();
                objetoPokemon.mostrarTipos(comboBoxTipo1, comboBoxTipo2);
                objetoPokemon.mostrarHabilidades(comboBoxHabilidad1, comboBoxHabilidad2, comboBoxHabilidad3);
                objetoPokemon.mostrarGrupoHuevo(comboBoxGrupohuevo);
                datosCargados = true;
            }
        }

        private void LimpiarControles()
        {
            // Limpiar TextBoxes
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
            }

            // Limpiar PictureBox
            pictureBox1.Image = null;
        }

        private void btnInsertar_Click_Click(object sender, EventArgs e)
        {
            // Validar que los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtAltura.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.");
                return; // Salir del método si hay campos vacíos
            }

            // Verificar que los ComboBox tengan un valor seleccionado
            if (comboBoxTipo1.SelectedIndex == -1 ||
                comboBoxHabilidad1.SelectedIndex == -1 ||
                comboBoxGrupohuevo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona al menos un tipo, una habilidad y un grupo de huevo.");
                return; // Salir del método si hay ComboBoxes sin selección
            }

            // Verificar que se haya cargado una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen antes de insertar el Pokémon.");
                return; // Salir del método si no hay imagen
            }

            // Validar que altura y peso sean números válidos y mayores que cero
            if (!float.TryParse(txtAltura.Text, out float altura) || altura <= 0)
            {
                MessageBox.Show("Por favor, ingresa una altura válida mayor que cero.");
                return;
            }

            if (!float.TryParse(txtPeso.Text, out float peso) || peso <= 0)
            {
                MessageBox.Show("Por favor, ingresa un peso válido mayor que cero.");
                return;
            }

            // Validar formato del nombre (opcional)
            if (!IsValidNombre(txtNombre.Text))
            {
                MessageBox.Show("El nombre contiene caracteres no válidos. Por favor, usa solo letras.");
                return; // Salir del método si el nombre no es válido
            }

            // Preparar los datos para la inserción
            string nombre = txtNombre.Text;

            // Llamar al método de inserción
            CPokemon cPokemon = new CPokemon();
            cPokemon.insertarPokemon(nombre, altura, peso, txtDescripcion.Text,
                comboBoxTipo1, comboBoxTipo2, comboBoxHabilidad1, comboBoxHabilidad2,
                comboBoxHabilidad3, comboBoxGrupohuevo, pictureBox1.Image);

            LimpiarControles();

            // Mostrar los Pokémon nuevamente después de la inserción
            Clases.CPokemon objetoPokemon = new Clases.CPokemon();
            objetoPokemon.mostrarPokemones(tablaPokemones);
        }

        // Método para validar el formato del nombre (opcional)
        private bool IsValidNombre(string nombre)
        {
            // Verifica que el nombre contenga solo letras y espacios
            return nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }


        private void cargarImagenButon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void tablaPokemones_DoubleClick(object sender, EventArgs e)
        {
            if (tablaPokemones.CurrentRow != null)
            {
                // Obtener el ID del Pokémon desde la fila seleccionada
                int pokemonId = Convert.ToInt32(tablaPokemones.CurrentRow.Cells["pokemon_id"].Value);

                // Crear una instancia de la clase CPokemon
                CPokemon cPokemon = new CPokemon();

                // Llamar al método CargarDatosPokemonYCombos pasando todos los parámetros requeridos
                cPokemon.CargarDatosPokemonYCombos(pokemonId, idtextBox, txtNombre, txtAltura, txtPeso, txtDescripcion,
                    comboBoxTipo1, comboBoxTipo2, comboBoxHabilidad1, comboBoxHabilidad2,
                    comboBoxHabilidad3, comboBoxGrupohuevo, pictureBox1);


                // Mostrar mensaje de éxito
                MessageBox.Show("Los Datos han sido cargados correctamente.");
            }
        }

        private void actualizarbutton_Click(object sender, EventArgs e)
        {
            // Validar que el ID no esté vacío y sea un número válido
            if (string.IsNullOrWhiteSpace(idtextBox.Text) || !int.TryParse(idtextBox.Text, out int pokemonId))
            {
                MessageBox.Show("Por favor, ingresa un ID válido del Pokémon que deseas actualizar.");
                return;
            }

            // Verificar que los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtAltura.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.");
                return; // Salir del método si hay campos vacíos
            }

            // Verificar que los ComboBox tengan un valor seleccionado
            if (comboBoxTipo1.SelectedIndex == -1 ||
                comboBoxHabilidad1.SelectedIndex == -1 ||
                comboBoxGrupohuevo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona al menos un tipo, una habilidad y un grupo de huevo.");
                return; // Salir del método si hay ComboBoxes sin selección
            }

            // Verificar que se haya cargado una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen antes de actualizar el Pokémon.");
                return; // Salir del método si no hay imagen
            }

            // Validar que altura y peso sean números válidos
            if (!float.TryParse(txtAltura.Text, out float altura) || altura <= 0)
            {
                MessageBox.Show("Por favor, ingresa una altura válida mayor que cero.");
                return;
            }

            if (!float.TryParse(txtPeso.Text, out float peso) || peso <= 0)
            {
                MessageBox.Show("Por favor, ingresa un peso válido mayor que cero.");
                return;
            }

            // Crear una instancia de CPokemon para la actualización
            CPokemon cPokemon = new CPokemon();

            // Llama al método actualizarPokemon pasando el ID del Pokémon
            cPokemon.actualizarPokemon(pokemonId, txtNombre.Text,
                              altura,
                              peso,
                              txtDescripcion.Text,
                              comboBoxTipo1,
                              comboBoxTipo2,
                              comboBoxHabilidad1,
                              comboBoxHabilidad2,
                              comboBoxHabilidad3,
                              comboBoxGrupohuevo,
                              pictureBox1.Image);

            // Limpiar controles y mostrar los Pokémon nuevamente
            LimpiarControles();
            Clases.CPokemon objetoPokemon = new Clases.CPokemon();
            objetoPokemon.mostrarPokemones(tablaPokemones);
        }

    }
}
