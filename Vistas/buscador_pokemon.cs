using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases; // Asegúrate de tener esta referencia

namespace Pokedex_No_copyrigt.Vistas
{
    public partial class buscador_pokemon : Form
    {
        
        private CConexion Clase=new CConexion();

        private string connectionString ;

        public buscador_pokemon()
        {
            InitializeComponent();
            connectionString = Clase.Cadena_conexuon();
            Buscador.MouseWheel += Buscador_MouseWheel;
        }

        private void Buscador_MouseWheel(object sender, MouseEventArgs e)
        {
            // Desplazamiento del DataGridView
            if (e.Delta > 0)
            {
                if (Buscador.FirstDisplayedScrollingRowIndex > 0)
                    Buscador.FirstDisplayedScrollingRowIndex--; // Desplazar hacia arriba
            }
            else if (e.Delta < 0)
            {
                if (Buscador.FirstDisplayedScrollingRowIndex < Buscador.RowCount - 1)
                    Buscador.FirstDisplayedScrollingRowIndex++; // Desplazar hacia abajo
            }
        }

        private void buscador_pokemon_Load(object sender, EventArgs e)
        {
            // Asegurar que el DataGridView ocupe todo el formulario
            Buscador.Dock = DockStyle.Fill;
        }
        public void cargarDatosPokemonesEnrtrenadores()
        {
           
            string query = $@"
        SELECT 
            LPAD(PC.Pokemon_id, 3, '0') AS pokemon_id,  -- Formatear el ID del Pokémon capturado
            P.Nombre AS nombre,
            P.Imagen AS imagen,
            PC.Estado
        FROM 
            Usuarios U
        INNER JOIN 
            Roles R ON U.Rol_id = R.id
        INNER JOIN 
            pokemon_captura PC ON U.id = PC.Usuario_id
        INNER JOIN 
            pokemon P ON PC.Pokemon_id = P.id  -- Asociar el Pokémon capturado con su información
        WHERE 
            R.Admin = 0  -- Solo entrenadores
            AND U.Apodo = '{Cache.UserCache.LoginName}';  -- Filtrar por el usuario logueado
    ";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    // Limpiar el DataGridView antes de cargar nuevos datos
                    Buscador.Rows.Clear();
                    Buscador.Columns.Clear(); // Asegurarse de que no haya columnas duplicadas

                    // Crear columnas en el DataGridView
                    DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        HeaderText = "ID",
                        ReadOnly = true, // La columna no se puede editar
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells // Ajustar tamaño al contenido
                    };
                    Buscador.Columns.Add(idColumn);

                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "Imagen",
                        HeaderText = "Imagen",
                        ReadOnly = true,
                        ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajustar imagen al tamaño de la celda
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Ajustar al tamaño de la imagen
                    };
                    Buscador.Columns.Add(imgColumn);

                    DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Nombre",
                        HeaderText = "Nombre",
                        ReadOnly = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Expandir para ocupar el espacio restante
                    };
                    Buscador.Columns.Add(nameColumn);

                    // Leer los datos del lector
                    while (reader.Read())
                    {
                        // Crear una nueva fila en cada iteración
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(Buscador);

                        // Asignar los valores
                        row.Cells[0].Value = reader["pokemon_id"].ToString(); // ID formateado
                        row.Cells[2].Value = reader["nombre"].ToString(); // Nombre del Pokémon

                        // Cargar la imagen desde la base de datos
                        byte[] imgBytes = reader["imagen"] as byte[]; // Obtener el BLOB de la imagen
                        if (imgBytes != null && imgBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                // Crear y redimensionar la imagen
                                Image img = Image.FromStream(ms);
                                Image imgResized = new Bitmap(img, new Size(32, 32)); // Redimensionar a 32x32
                                row.Cells[1].Value = imgResized; // Asignar la imagen redimensionada
                            }
                        }
                        else
                        {
                            row.Cells[1].Value = null; // Dejar la celda vacía si no hay imagen
                        }

                        // Agregar la fila al DataGridView
                        Buscador.Rows.Add(row);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        public void cargarDatosPokemones()
        {
            string query = @"
        SELECT 
            LPAD(pokemon.id, 3, '0') AS pokemon_id,  -- Formatear el ID
            pokemon.Nombre AS nombre,
            pokemon.Imagen AS imagen  -- Suponiendo que este es un campo BLOB
        FROM 
            pokemon;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    // Limpiar el DataGridView antes de cargar nuevos datos
                    Buscador.Rows.Clear();
                    Buscador.Columns.Clear(); // Asegurarse de que no haya columnas duplicadas

                    // Crear columnas en el DataGridView
                    DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        HeaderText = "ID",
                        ReadOnly = true, // La columna no se puede editar
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells // Ajustar tamaño al contenido
                    };
                    Buscador.Columns.Add(idColumn);
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "Imagen",
                        HeaderText = "Imagen",
                        ReadOnly = true,
                        ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajustar imagen al tamaño de la celda
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Ajustar al tamaño de la imagen
                    };
                    Buscador.Columns.Add(imgColumn);
                    DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Nombre",
                        HeaderText = "Nombre",
                        ReadOnly = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Expandir para ocupar el espacio restante
                    };
                    Buscador.Columns.Add(nameColumn);

                    

                    // Leer los datos del lector
                    while (reader.Read())
                    {
                        // Crear una nueva fila en cada iteración
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(Buscador);

                        // Asignar los valores
                        row.Cells[0].Value = reader["pokemon_id"].ToString(); // ID formateado
                        row.Cells[2].Value = reader["nombre"].ToString(); // Nombre del Pokémon

                        // Cargar la imagen desde la base de datos
                        byte[] imgBytes = reader["imagen"] as byte[]; // Obtener el BLOB de la imagen
                        if (imgBytes != null && imgBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                // Crear y redimensionar la imagen
                                Image img = Image.FromStream(ms);
                                Image imgResized = new Bitmap(img, new Size(32, 32)); // Redimensionar a 32x32
                                row.Cells[1].Value = imgResized; // Asignar la imagen redimensionada
                            }
                        }
                        else
                        {
                            row.Cells[1].Value = null; // Dejar la celda vacía si no hay imagen
                        }

                        // Agregar la fila al DataGridView
                        Buscador.Rows.Add(row);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }




        private void buscador_pokemon_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar si la tecla de flecha hacia abajo o hacia arriba se presiona
            if (e.KeyCode == Keys.Down)
            {
                if (Buscador.FirstDisplayedScrollingRowIndex < Buscador.RowCount - 1)
                    Buscador.FirstDisplayedScrollingRowIndex++;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (Buscador.FirstDisplayedScrollingRowIndex > 0)
                    Buscador.FirstDisplayedScrollingRowIndex--;
            }
        }
    }
}
