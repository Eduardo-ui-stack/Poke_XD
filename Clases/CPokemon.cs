using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // Asegúrate de tener esta línea para usar la clase Image
using System.IO;

namespace Pokedex_No_copyrigt.Clases
{
    internal class CPokemon
    {
        public void mostrarPokemones(DataGridView tablaPokemones)
        {
            try
            {
                // Establecer la conexión a la base de datos
                CConexion objetoConexion = new CConexion();

                // Consulta SQL
                string query = @"
                SELECT 
                    pokemon.id AS pokemon_id,
                    pokemon.Nombre AS nombre,
                    pokemon.Altura AS altura,
                    pokemon.Peso AS peso,
                    pokemon.Imagen AS imagen,
                    pokemon.Descripcion AS descripcion,
                    GROUP_CONCAT(DISTINCT tipos.Tipo) AS tipos,
                    GROUP_CONCAT(DISTINCT habilidades.Habilidad) AS habilidades,
                    grupo_huevo.Grupo AS grupo_huevo
                FROM 
                    pokemon
                INNER JOIN 
                    tipos_pokemon ON pokemon.id = tipos_pokemon.Pokemon_id
                INNER JOIN 
                    tipos ON tipos_pokemon.Tipos_id = tipos.id
                LEFT JOIN 
                    habilidades_pokemon ON pokemon.id = habilidades_pokemon.Pokemon_id
                LEFT JOIN 
                    habilidades ON habilidades_pokemon.Habilidades_id = habilidades.id
                LEFT JOIN 
                    grupo_huevo_pokemon ON pokemon.id = grupo_huevo_pokemon.Pokemon_id
                LEFT JOIN 
                    grupo_huevo ON grupo_huevo_pokemon.Grupo_huevo_id = grupo_huevo.id
                GROUP BY 
                    pokemon.id;
                ";

                // Configurar el DataGridView
                tablaPokemones.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                tablaPokemones.DataSource = dt;

                if (dt.Columns.Contains("imagen"))
                {

                    if (tablaPokemones.Columns.Contains("imagen"))
                    {
                        tablaPokemones.Columns.Remove("imagen");
                    }


                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "Imagen",
                        HeaderText = "Imagen",
                        ImageLayout = DataGridViewImageCellLayout.Zoom // Ajustar imagen al tamaño de la celda
                    };

                    tablaPokemones.Columns.Add(imgColumn); // Agregar la nueva columna al DataGridView

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["imagen"] != DBNull.Value)
                        {
                            byte[] imgBytes = (byte[])row["imagen"];
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                Image img = Image.FromStream(ms);
                                int index = dt.Rows.IndexOf(row);
                                tablaPokemones.Rows[index].Cells["Imagen"].Value = img;
                            }
                        }
                        else
                        {
                            // Asignar null si no hay imagen
                            int index = dt.Rows.IndexOf(row);
                            tablaPokemones.Rows[index].Cells["Imagen"].Value = null;
                        }
                    }
                }

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                // Si algo sale mal, lo registramos en la consola
                Console.WriteLine("¡Vaya! No se conectó a la BD. " + ex.ToString());
            }
        }





        public void mostrarTipos(ComboBox comboBoxTipo1, ComboBox comboBoxTipo2)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                // Consulta para obtener los tipos desde la tabla 'tipos'
                String query = "SELECT id, Tipo FROM tipos";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Limpiar los ComboBox antes de llenarlos
                comboBoxTipo1.DataSource = null;
                comboBoxTipo2.DataSource = null;

                // Asignar los datos a los ComboBox
                comboBoxTipo1.DataSource = dt.Copy(); // Hacemos una copia para evitar conflictos de referencia
                comboBoxTipo2.DataSource = dt;

                // Mostrar el nombre del tipo en los ComboBox
                comboBoxTipo1.DisplayMember = "Tipo"; // Usa el nombre correcto de la columna
                comboBoxTipo2.DisplayMember = "Tipo"; // Usa el nombre correcto de la columna

                // Usar el id como valor que se guarda internamente
                comboBoxTipo1.ValueMember = "id";
                comboBoxTipo2.ValueMember = "id";

                // Cerrar conexión
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los tipos: " + ex.ToString());
            }
        }

        public void mostrarHabilidades(ComboBox comboBoxHabilidad1, ComboBox comboBoxHabilidad2, ComboBox comboBoxHabilidad3)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                // Consulta para obtener las habilidades desde la tabla 'Habilidades'
                string query = "SELECT id, Habilidad FROM Habilidades";

                // Crear el adaptador de datos
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Limpiar los ComboBox antes de llenarlos
                comboBoxHabilidad1.DataSource = null;
                comboBoxHabilidad2.DataSource = null;
                comboBoxHabilidad3.DataSource = null; // Limpiar también el tercer ComboBox

                // Asignar los datos a los ComboBox
                comboBoxHabilidad1.DataSource = dt.Copy(); // Hacemos una copia para evitar conflictos de referencia
                comboBoxHabilidad2.DataSource = dt.Copy(); // Hacemos una copia para evitar conflictos de referencia
                comboBoxHabilidad3.DataSource = dt; // El tercero puede usar la tabla original

                // Mostrar el nombre de la habilidad en los ComboBox
                comboBoxHabilidad1.DisplayMember = "Habilidad"; // Usa el nombre correcto de la columna
                comboBoxHabilidad2.DisplayMember = "Habilidad"; // Usa el nombre correcto de la columna
                comboBoxHabilidad3.DisplayMember = "Habilidad"; // Usa el nombre correcto de la columna

                // Usar el id como valor que se guarda internamente
                comboBoxHabilidad1.ValueMember = "id";
                comboBoxHabilidad2.ValueMember = "id";
                comboBoxHabilidad3.ValueMember = "id"; // Agregar el ValueMember para el tercer ComboBox

                // Cerrar conexión
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las habilidades: " + ex.ToString());
            }
        }

        public void mostrarGrupoHuevo(ComboBox comboBoxGrupohuevo)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                // Consulta para obtener los grupos de huevo desde la tabla 'grupo_huevo'
                string query = "SELECT id, Grupo FROM grupo_huevo";

                // Crear el adaptador de datos
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Limpiar el ComboBox antes de llenarlo
                comboBoxGrupohuevo.DataSource = null;

                // Asignar los datos al ComboBox
                comboBoxGrupohuevo.DataSource = dt;

                // Mostrar el nombre del grupo de huevo en el ComboBox
                comboBoxGrupohuevo.DisplayMember = "Grupo"; // Usa el nombre correcto de la columna

                // Usar el id como valor que se guarda internamente
                comboBoxGrupohuevo.ValueMember = "id";

                // Cerrar conexión
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los grupos de huevo: " + ex.ToString());
            }
        }

        public void insertarPokemon(string nombre, float altura, float peso, string descripcion, ComboBox comboBoxTipo1, ComboBox comboBoxTipo2, ComboBox comboBoxHabilidad1, ComboBox comboBoxHabilidad2, ComboBox comboBoxHabilidad3, ComboBox comboBoxGrupoHuevo, Image imagen)
        {
            try
            {
                // Convertir la imagen a un arreglo de bytes
                byte[] imagenBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bitmap = new Bitmap(imagen, new Size(32, 32))) // Redimensionar a 32x32
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    imagenBytes = ms.ToArray();
                }

                // Validar el tamaño de la imagen
                if (imagenBytes.Length > 65535)
                {
                    MessageBox.Show("La imagen es demasiado grande. Por favor, selecciona una imagen más pequeña.");
                    return;
                }

                // Establecer la conexión a la base de datos
                CConexion objetoConexion = new CConexion();
                using (MySqlConnection conexion = objetoConexion.establecerConexion())
                {
                    // Validar si el Pokémon ya existe por nombre
                    string validarQuery = "SELECT COUNT(*) FROM pokemon WHERE Nombre = @nombre;";
                    using (MySqlCommand validarCmd = new MySqlCommand(validarQuery, conexion))
                    {
                        validarCmd.Parameters.AddWithValue("@nombre", nombre);
                        int count = Convert.ToInt32(validarCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("El Pokémon con este nombre ya existe.");
                            return; // Si ya existe, detener el proceso
                        }
                    }

                    // Si el Pokémon no existe, proceder a insertarlo
                    string query = @"
            INSERT INTO pokemon (Nombre, Altura, Peso, Descripcion, Imagen) 
            VALUES (@nombre, @altura, @peso, @descripcion, @imagen);
            SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        // Asignar los parámetros
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@altura", altura);
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@imagen", imagenBytes);

                        // Ejecutar el comando y obtener el ID del nuevo Pokémon
                        int nuevoPokemonId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Insertar tipos asociados
                        int tipo1Id = (int)comboBoxTipo1.SelectedValue;
                        int tipo2Id = (int)comboBoxTipo2.SelectedValue;

                        string tipoQuery = "INSERT INTO tipos_pokemon (Pokemon_id, Tipos_id) VALUES (@pokemonId, @tipoId);";
                        using (MySqlCommand tipoCmd = new MySqlCommand(tipoQuery, conexion))
                        {
                            // Insertar tipo 1
                            tipoCmd.Parameters.AddWithValue("@pokemonId", nuevoPokemonId);
                            tipoCmd.Parameters.AddWithValue("@tipoId", tipo1Id);
                            tipoCmd.ExecuteNonQuery();

                            // Insertar tipo 2 si existe
                            if (tipo2Id != 0)
                            {
                                tipoCmd.Parameters["@tipoId"].Value = tipo2Id;
                                tipoCmd.ExecuteNonQuery();
                            }
                        }

                        // Insertar habilidades asociadas
                        string habilidadQuery = "INSERT INTO habilidades_pokemon (Pokemon_id, Habilidades_id) VALUES (@pokemonId, @habilidadId);";
                        foreach (var habilidad in new[] { comboBoxHabilidad1, comboBoxHabilidad2, comboBoxHabilidad3 })
                        {
                            using (MySqlCommand habilidadCmd = new MySqlCommand(habilidadQuery, conexion))
                            {
                                int habilidadId = (int)habilidad.SelectedValue;
                                habilidadCmd.Parameters.AddWithValue("@pokemonId", nuevoPokemonId);
                                habilidadCmd.Parameters.AddWithValue("@habilidadId", habilidadId);
                                habilidadCmd.ExecuteNonQuery();
                            }
                        }

                        // Insertar grupo de huevo
                        string grupoHuevoQuery = "INSERT INTO grupo_huevo_pokemon (Pokemon_id, Grupo_huevo_id) VALUES (@pokemonId, @grupoHuevoId);";
                        using (MySqlCommand grupoHuevoCmd = new MySqlCommand(grupoHuevoQuery, conexion))
                        {
                            int grupoHuevoId = (int)comboBoxGrupoHuevo.SelectedValue;
                            grupoHuevoCmd.Parameters.AddWithValue("@pokemonId", nuevoPokemonId);
                            grupoHuevoCmd.Parameters.AddWithValue("@grupoHuevoId", grupoHuevoId);
                            grupoHuevoCmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Pokémon insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Pokémon: " + ex.Message);
            }
        }



        public void CargarDatosPokemonYCombos(int pokemonId, TextBox idtextBox, TextBox txtNombre, TextBox txtAltura, TextBox txtPeso, TextBox txtDescripcion, ComboBox comboBoxTipo1, ComboBox comboBoxTipo2, ComboBox comboBoxHabilidad1, ComboBox comboBoxHabilidad2, ComboBox comboBoxHabilidad3, ComboBox comboBoxGrupoHuevo, PictureBox pictureBox)
        {
            CConexion objetoConexion = new CConexion();

            using (MySqlConnection conexion = objetoConexion.establecerConexion())
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                try
                {
                    // Consulta para obtener los datos del Pokémon
                    string queryPokemon = @"
                        SELECT 
                            p.id AS pokemon_id,
                            p.Nombre AS nombre,
                            p.Altura AS altura,
                            p.Peso AS peso,
                            p.Imagen AS imagen,
                            p.Descripcion AS descripcion,
                            GROUP_CONCAT(DISTINCT t.Tipo) AS tipos,
                            GROUP_CONCAT(DISTINCT h.Habilidad) AS habilidades,
                            gh.Grupo AS grupo_huevo
                        FROM 
                            pokemon p
                        LEFT JOIN 
                            tipos_pokemon tp ON p.id = tp.Pokemon_id
                        LEFT JOIN 
                            tipos t ON tp.Tipos_id = t.id
                        LEFT JOIN 
                            habilidades_pokemon hp ON p.id = hp.Pokemon_id
                        LEFT JOIN 
                            habilidades h ON hp.Habilidades_id = h.id
                        LEFT JOIN 
                            grupo_huevo_pokemon ghp ON p.id = ghp.Pokemon_id
                        LEFT JOIN 
                            grupo_huevo gh ON ghp.Grupo_huevo_id = gh.id
                        WHERE 
                            p.id = @pokemonId
                        GROUP BY 
                            p.id;";

                    using (MySqlCommand cmdPokemon = new MySqlCommand(queryPokemon, conexion))
                    {
                        cmdPokemon.Parameters.AddWithValue("@pokemonId", pokemonId);
                        using (MySqlDataReader reader = cmdPokemon.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar valores a los TextBox
                                idtextBox.Text = reader["pokemon_id"].ToString();
                                txtNombre.Text = reader["nombre"].ToString();
                                txtAltura.Text = reader["altura"].ToString();
                                txtPeso.Text = reader["peso"].ToString();
                                txtDescripcion.Text = reader["descripcion"].ToString();

                                // Cargar imagen si existe
                                if (reader["imagen"] != DBNull.Value)
                                {
                                    byte[] imgBytes = (byte[])reader["imagen"];
                                    using (MemoryStream ms = new MemoryStream(imgBytes))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pictureBox.Image = null;
                                }

                                // Cargar tipos en los ComboBox
                                string[] tipos = reader["tipos"].ToString().Split(',');
                                comboBoxTipo1.SelectedIndex = -1;
                                comboBoxTipo2.SelectedIndex = -1;
                                if (tipos.Length > 0)
                                {
                                    comboBoxTipo1.Text = tipos[0];
                                }
                                if (tipos.Length > 1)
                                {
                                    comboBoxTipo2.Text = tipos[1];
                                }

                                // Cargar habilidades en los ComboBox
                                string[] habilidades = reader["habilidades"].ToString().Split(',');
                                comboBoxHabilidad1.SelectedIndex = -1;
                                comboBoxHabilidad2.SelectedIndex = -1;
                                comboBoxHabilidad3.SelectedIndex = -1;
                                if (habilidades.Length > 0)
                                {
                                    comboBoxHabilidad1.Text = habilidades[0];
                                }
                                if (habilidades.Length > 1)
                                {
                                    comboBoxHabilidad2.Text = habilidades[1];
                                }
                                if (habilidades.Length > 2)
                                {
                                    comboBoxHabilidad3.Text = habilidades[2];
                                }

                                // Cargar grupo huevo
                                comboBoxGrupoHuevo.Text = reader["grupo_huevo"].ToString();
                            }
                        }
                    }

                    // Consulta para cargar los tipos en ComboBox
                    string queryTipos = "SELECT id, Tipo FROM tipos";
                    using (MySqlCommand cmdTipos = new MySqlCommand(queryTipos, conexion))
                    {
                        MySqlDataAdapter adapterTipos = new MySqlDataAdapter(cmdTipos);
                        DataTable dtTipos = new DataTable();
                        adapterTipos.Fill(dtTipos);

                        comboBoxTipo1.DataSource = dtTipos.Copy();
                        comboBoxTipo1.DisplayMember = "Tipo";
                        comboBoxTipo1.ValueMember = "id";

                        comboBoxTipo2.DataSource = dtTipos.Copy();
                        comboBoxTipo2.DisplayMember = "Tipo";
                        comboBoxTipo2.ValueMember = "id";
                    }

                    // Consulta para cargar las habilidades en ComboBox
                    string queryHabilidades = "SELECT id, Habilidad FROM habilidades";
                    using (MySqlCommand cmdHabilidades = new MySqlCommand(queryHabilidades, conexion))
                    {
                        MySqlDataAdapter adapterHabilidades = new MySqlDataAdapter(cmdHabilidades);
                        DataTable dtHabilidades = new DataTable();
                        adapterHabilidades.Fill(dtHabilidades);

                        comboBoxHabilidad1.DataSource = dtHabilidades.Copy();
                        comboBoxHabilidad1.DisplayMember = "Habilidad";
                        comboBoxHabilidad1.ValueMember = "id";

                        comboBoxHabilidad2.DataSource = dtHabilidades.Copy();
                        comboBoxHabilidad2.DisplayMember = "Habilidad";
                        comboBoxHabilidad2.ValueMember = "id";

                        comboBoxHabilidad3.DataSource = dtHabilidades.Copy();
                        comboBoxHabilidad3.DisplayMember = "Habilidad";
                        comboBoxHabilidad3.ValueMember = "id";
                    }

                    // Consulta para cargar el grupo huevo en ComboBox
                    string queryGrupoHuevo = "SELECT id, Grupo FROM grupo_huevo";
                    using (MySqlCommand cmdGrupoHuevo = new MySqlCommand(queryGrupoHuevo, conexion))
                    {
                        MySqlDataAdapter adapterGrupoHuevo = new MySqlDataAdapter(cmdGrupoHuevo);
                        DataTable dtGrupoHuevo = new DataTable();
                        adapterGrupoHuevo.Fill(dtGrupoHuevo);

                        comboBoxGrupoHuevo.DataSource = dtGrupoHuevo.Copy();
                        comboBoxGrupoHuevo.DisplayMember = "Grupo";
                        comboBoxGrupoHuevo.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos del Pokémon y ComboBox: " + ex.Message);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }

        public void actualizarPokemon(int pokemonId, string nombre, float altura, float peso, string descripcion,
                               ComboBox comboBoxTipo1, ComboBox comboBoxTipo2,
                               ComboBox comboBoxHabilidad1, ComboBox comboBoxHabilidad2, ComboBox comboBoxHabilidad3,
                               ComboBox comboBoxGrupoHuevo, Image imagen)
        {
            try
            {
                // Validar si el nombre ya existe en otro Pokémon
                CConexion objetoConexion = new CConexion();
                using (MySqlConnection conexion = objetoConexion.establecerConexion())
                {
                    string checkQuery = "SELECT COUNT(*) FROM pokemon WHERE Nombre = @nombre AND Id != @pokemonId";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conexion))
                    {
                        checkCmd.Parameters.AddWithValue("@nombre", nombre);
                        checkCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Ya existe un Pokémon con este nombre.");
                            return; // Salir de la función si ya existe
                        }
                    }
                }

                // Convertir la imagen a un arreglo de bytes
                byte[] imagenBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    // Redimensionar la imagen a 32x32 píxeles
                    using (Bitmap bitmap = new Bitmap(imagen, new Size(32, 32))) // Cambia el tamaño a 32x32
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    imagenBytes = ms.ToArray(); // Convertir a byte[]
                }

                // Validar el tamaño de la imagen
                if (imagenBytes.Length > 65535) // Verificar si el tamaño excede 65KB
                {
                    MessageBox.Show("La imagen es demasiado grande. Por favor, selecciona una imagen más pequeña.");
                    return;
                }

                // Establecer la conexión a la base de datos
                CConexion objetoConexion2 = new CConexion();
                using (MySqlConnection conexion = objetoConexion2.establecerConexion())
                {
                    // Consulta SQL para actualizar un Pokémon existente
                    string query = @"
            UPDATE pokemon 
            SET Nombre = @nombre, Altura = @altura, Peso = @peso, Descripcion = @descripcion, Imagen = @imagen 
            WHERE Id = @pokemonId;"; // Asume que 'Id' es la columna de identificador

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        // Asignar los parámetros
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@altura", altura);
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@imagen", imagenBytes); // Usar el arreglo de bytes para la imagen
                        cmd.Parameters.AddWithValue("@pokemonId", pokemonId); // ID del Pokémon a actualizar

                        // Ejecutar el comando
                        cmd.ExecuteNonQuery();
                    }

                    // Actualizar tipos asociados
                    // Primero, eliminamos los tipos existentes para este Pokémon
                    string deleteTiposQuery = "DELETE FROM tipos_pokemon WHERE Pokemon_id = @pokemonId;";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteTiposQuery, conexion))
                    {
                        deleteCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        deleteCmd.ExecuteNonQuery(); // Ejecutar la eliminación de tipos
                    }

                    // Insertar los nuevos tipos
                    int tipo1Id = (int)comboBoxTipo1.SelectedValue;
                    int tipo2Id = (int)comboBoxTipo2.SelectedValue;

                    // Insertar los nuevos tipos en la tabla tipos_pokemon
                    string tipoQuery = "INSERT INTO tipos_pokemon (Pokemon_id, Tipos_id) VALUES (@pokemonId, @tipoId);";
                    using (MySqlCommand tipoCmd = new MySqlCommand(tipoQuery, conexion))
                    {
                        // Insertar tipo 1
                        tipoCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        tipoCmd.Parameters.AddWithValue("@tipoId", tipo1Id);
                        tipoCmd.ExecuteNonQuery(); // Ejecutar la inserción de tipo 1

                        // Insertar tipo 2 si existe
                        if (tipo2Id != 0) // Verificar si hay un segundo tipo
                        {
                            tipoCmd.Parameters["@tipoId"].Value = tipo2Id;
                            tipoCmd.ExecuteNonQuery(); // Ejecutar la inserción de tipo 2
                        }
                    }

                    // Actualizar habilidades asociadas
                    // Primero, eliminamos las habilidades existentes para este Pokémon
                    string deleteHabilidadesQuery = "DELETE FROM habilidades_pokemon WHERE Pokemon_id = @pokemonId;";
                    using (MySqlCommand deleteHabilidadCmd = new MySqlCommand(deleteHabilidadesQuery, conexion))
                    {
                        deleteHabilidadCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        deleteHabilidadCmd.ExecuteNonQuery(); // Ejecutar la eliminación de habilidades
                    }

                    // Insertar las nuevas habilidades
                    string habilidadQuery = "INSERT INTO habilidades_pokemon (Pokemon_id, Habilidades_id) VALUES (@pokemonId, @habilidadId);";
                    foreach (var habilidad in new[] { comboBoxHabilidad1, comboBoxHabilidad2, comboBoxHabilidad3 })
                    {
                        using (MySqlCommand habilidadCmd = new MySqlCommand(habilidadQuery, conexion))
                        {
                            int habilidadId = (int)habilidad.SelectedValue;
                            habilidadCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                            habilidadCmd.Parameters.AddWithValue("@habilidadId", habilidadId);
                            habilidadCmd.ExecuteNonQuery(); // Ejecutar la inserción de habilidad
                        }
                    }

                    // Actualizar el grupo de huevo
                    // Primero, eliminamos el grupo de huevo existente para este Pokémon
                    string deleteGrupoHuevoQuery = "DELETE FROM grupo_huevo_pokemon WHERE Pokemon_id = @pokemonId;";
                    using (MySqlCommand deleteGrupoHuevoCmd = new MySqlCommand(deleteGrupoHuevoQuery, conexion))
                    {
                        deleteGrupoHuevoCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        deleteGrupoHuevoCmd.ExecuteNonQuery(); // Ejecutar la eliminación del grupo de huevo
                    }

                    // Insertar el nuevo grupo de huevo
                    string grupoHuevoQuery = "INSERT INTO grupo_huevo_pokemon (Pokemon_id, Grupo_huevo_id) VALUES (@pokemonId, @grupoHuevoId);";
                    using (MySqlCommand grupoHuevoCmd = new MySqlCommand(grupoHuevoQuery, conexion))
                    {
                        int grupoHuevoId = (int)comboBoxGrupoHuevo.SelectedValue; // Obtener el ID del grupo de huevo
                        grupoHuevoCmd.Parameters.AddWithValue("@pokemonId", pokemonId);
                        grupoHuevoCmd.Parameters.AddWithValue("@grupoHuevoId", grupoHuevoId);
                        grupoHuevoCmd.ExecuteNonQuery(); // Ejecutar la inserción de grupo de huevo
                    }
                }
                MessageBox.Show("Pokémon actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar Pokémon: " + ex.Message);
            }
        }

    }
}

