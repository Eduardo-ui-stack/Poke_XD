using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;
using System.Data;
using static Pokedex_No_copyrigt.Clases.Pokedex_data;

namespace Pokedex_No_copyrigt.Vistas
{
    public partial class Pokedex : Form
    {
        private List<Pokemon> pokemones;
        private int contador = 0;
        public Pokedex()
        {
            InitializeComponent();
            
        }
        public void CargarPokemones()
        {
            pokemones = Pokemon.CargarPokemones();
            MostrarPokemon();
        }
        public void CargarPokemonesUsuario()
        {
            pokemones = Pokemon.CargarPokemonesPorUsuario(Cache.UserCache.IdUser);
            MostrarPokemon();
        }

        private void MostrarPokemon()
        {
            if (pokemones.Count > 0 && contador >= 0 && contador < pokemones.Count)
            {
                var pokemonActual = pokemones[contador];
                txt_id.Text = pokemonActual.Id.ToString();
                txt_nombre.Text = pokemonActual.Nombre;
                txt_decripcion.Text = pokemonActual.Descripcion;
                txt_altura.Text = pokemonActual.Altura.ToString();
                txt_peso.Text = pokemonActual.Peso.ToString();
                txt_habiilidades.Text = string.Join(", ", pokemonActual.Habilidades);
                txt_Ghuevo.Text = string.Join(", ", pokemonActual.GruposHuevo);

                // Cargar la imagen en el PictureBox
                if (pokemonActual.Imagen != null)
                {
                    using (var ms = new MemoryStream(pokemonActual.Imagen))
                    {
                        Cargar_imagenes.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Si no hay imagen, puedes dejar el PictureBox vacío o mostrar una imagen por defecto
                    Cargar_imagenes.Image = null; // O una imagen predeterminada si prefieres
                }
            }
        }



        private void MostrarPaginas()
        {
            Cargar_imagenes.Visible = true;
            btn_arriba.Visible = true;
            btn_abajo.Visible = true;
            btn_derecha.Visible = true;
            btn_izquierda.Visible = true;
        }
        private void btn_arriba_Click(object sender, EventArgs e)
        {
            if (contador > 0)
            {
                contador--;
                MostrarPokemon();
            }
        }

        private void btn_derecha_Click(object sender, EventArgs e)
        {
            Foto.Visible = true;
        }

        private void btn_abajo_Click(object sender, EventArgs e)
        {
            if (contador < pokemones.Count - 1)
            {
                contador++;
                MostrarPokemon();
            }
        }

        private void btn_izquierda_Click(object sender, EventArgs e)
        {
            Foto.Visible = false;
        }

        // Evento para detectar las teclas de dirección
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Shift && e.KeyCode == Keys.W)
            {
                btn_arriba.PerformClick();
            }
            else if (e.KeyCode == Keys.D)
            {
                btn_derecha.PerformClick();  // Simula un clic en el botón de la derecha
            }
            else if (e.KeyCode == Keys.S)
            {
                btn_abajo.PerformClick();  // Simula un clic en el botón de abajo
            }
            else if (e.KeyCode == Keys.A)
            {
                btn_izquierda.PerformClick();  // Simula un clic en el botón de la izquierda
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("¿quieres salir de esta sección?", "Cerrar seción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Application.Exit();
            }

        }

        private void Pokedex_Load(object sender, EventArgs e)
        {
            MostrarPaginas();

        }
        private CConexion Cane = new CConexion();
        




        //esta funcion sirve para la animacion de la mierda esa













        //Aki termina el codigo
    }
}
