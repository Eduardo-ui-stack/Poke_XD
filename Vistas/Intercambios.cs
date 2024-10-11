using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Pokedex_No_copyrigt.Vistas
{
    public partial class Intercambios : Form
    {
        private CConexion Clase = new CConexion();

        private string connectionString;
        public Intercambios()
        {
            InitializeComponent();
            connectionString = Clase.Cadena_conexuon();
            Buscador.MouseWheel += Buscador_MouseWheel;
        }
        private MySqlConnection connection;
        public void cargar_Entrenadores()
        {
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 3. Consulta para obtener los usuarios conectados y con rol Admin = 0
                string query = $@"
                SELECT u.id, u.Apodo 
                FROM yucadex.usuarios u
                JOIN yucadex.roles r ON u.Rol_id = r.id
                WHERE u.Conectado = 1 AND r.Admin = 0 AND not u.id='{Cache.UserCache.IdUser}';
            ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                // 4. Limpiar el ComboBox antes de llenarlo
                list_usuarios.Items.Clear();

                // 5. Itera sobre los resultados y añade los apodos al ComboBox
                while (reader.Read())
                {
                    // Asocia el 'id' del usuario como valor y el 'Apodo' como texto visible
                    list_usuarios.Items.Add(new ComboBoxItem(reader["Apodo"].ToString(), reader["id"].ToString()));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //Esta funcion me almacena el id de esa wea de los usuarios 
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;  // Lo que se muestra en el ComboBox
            }
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
        //Esta funcion sirve para poder cargar los usuarioa siempre y cuando sean entrenadores
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

        private void Intercambios_Load(object sender, EventArgs e)
        {
        }
        private int pokemonId = 0;
        private void Buscador_DoubleClick(object sender, EventArgs e)
        {


            if (Buscador.CurrentRow != null)
            {
                // Obtener el ID del Pokémon desde la fila seleccionada
                pokemonId = Convert.ToInt32(Buscador.CurrentRow.Cells["ID"].Value);
                string Nombre_poke = Buscador.CurrentRow.Cells["Nombre"].Value.ToString();
                // Mostrar mensaje de éxito
                txt_pokemon.Text = Nombre_poke;
                MessageBox.Show("Los datos han sido cargados correctamente.");
            }

        }
        public void capturarPokemon(int pokemonId)
        {
            // Consulta para verificar si el Pokémon ya fue capturado por el usuario
            string checkQuery = @"
    SELECT COUNT(*) FROM pokemon_captura 
    WHERE Usuario_id = (SELECT id FROM usuarios WHERE apodo = @loginName)
    AND Pokemon_id = @pokemonId;";

            // Consulta para insertar el Pokémon capturado
            string insertQuery = @"
    INSERT INTO pokemon_captura (Usuario_id, Pokemon_id)
    VALUES (
        (SELECT id FROM usuarios WHERE apodo = @loginName), 
        @pokemonId);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Primero, validar si el Pokémon ya está capturado
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@loginName", list_usuarios.SelectedItem.ToString());
                        checkCommand.Parameters.AddWithValue("@pokemonId", pokemonId);

                        // Ejecutar la consulta de validación
                        int pokemonCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        // Si el Pokémon ya está capturado, mostramos un mensaje
                        if (pokemonCount > 0)
                        {
                            MessageBox.Show("Este Pokémon ya ha sido capturado por el usuario.");
                            return;  // Salir de la función, no se inserta duplicado
                        }
                    }

                    // Si el Pokémon no está capturado, procedemos a insertarlo
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        // Pasar los parámetros
                        insertCommand.Parameters.AddWithValue("@loginName", list_usuarios.SelectedItem.ToString());
                        insertCommand.Parameters.AddWithValue("@pokemonId", pokemonId);

                        // Ejecutar el comando de inserción
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("El Pokémon ha sido capturado y agregado a la base de datos.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo capturar el Pokémon.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar Pokémon: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            capturarPokemon(pokemonId);
        }
        //Este es el fin del codigo
    }
}
