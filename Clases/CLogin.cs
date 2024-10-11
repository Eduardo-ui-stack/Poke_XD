using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pokedex_No_copyrigt.Clases.Cache;


namespace Pokedex_No_copyrigt.Clases
{
        internal class CLogin
        {


        public int IniciarSesion(TextBox textBoxUsuario, TextBox textBoxContraseña)
        {
            try
            {
                // Verificar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(textBoxUsuario.Text) || string.IsNullOrWhiteSpace(textBoxContraseña.Text))
                {
                    MessageBox.Show("El campo usuario y contraseña son obligatorios.");
                    return 2;
                }

                // Conexión a la base de datos
                CConexion objetoConexion = new CConexion();
                using (var conexion = objetoConexion.establecerConexion())
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open(); // Abrir la conexión si no está abierta
                    }

                    // Consulta SQL para buscar al usuario basado en el apodo y contraseña
                    string query = @"
                SELECT U.id, U.Apodo, R.Admin 
                FROM Usuarios U 
                INNER JOIN Datos_usuarios DU ON U.id = DU.Usuario_id 
                INNER JOIN Roles R ON U.Rol_id = R.id 
                WHERE DU.contraseña = @Contraseña AND U.Apodo = @Apodo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        // Parámetros para evitar inyecciones SQL
                        cmd.Parameters.AddWithValue("@Contraseña", textBoxContraseña.Text);
                        cmd.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);

                        // Ejecutar la consulta y leer los resultados
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Si se encuentra el usuario
                            if (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string apodo = reader["Apodo"].ToString();
                                bool esAdmin = Convert.ToBoolean(reader["Admin"]);

                                // Si es Administrador o Entrenador, proceder con el login
                                if (esAdmin)
                                {
                                    MessageBox.Show("Acceso concedido como Administrador.");
                                    UserCache.IdUser = id;
                                    UserCache.rol = esAdmin;
                                    UserCache.LoginName = apodo; // Almacena el apodo del usuario en UserCache
                                }
                                else
                                {
                                    MessageBox.Show("Acceso concedido como Entrenador.");
                                    UserCache.IdUser = id;
                                    UserCache.LoginName = apodo; // Almacena el apodo del usuario en UserCache
                                }

                                // Cerrar el reader antes de continuar con la actualización
                                reader.Close();

                                // Actualizar la columna 'Conectado' a 1 para el usuario que se ha logueado
                                string updateQuery = "UPDATE Usuarios SET Conectado = 1 WHERE id = @IdUsuario";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conexion))
                                {
                                    updateCmd.Parameters.AddWithValue("@IdUsuario", id);
                                    updateCmd.ExecuteNonQuery(); // Ejecuta la consulta de actualización
                                }

                                return esAdmin ? 1 : 0; // Retorna 1 si es Admin, 0 si es Entrenador
                            }
                            else
                            {
                                // Si no se encuentra el usuario, se muestra este mensaje
                                MessageBox.Show("Usuario o contraseña incorrectos.");
                                return 2;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                return 2;
            }
        }


        public void InsertarUsuarios(TextBox textBoxUsuario, TextBox textBoxCorreo, TextBox textBoxContraseña)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxUsuario.Text))
                {
                    MessageBox.Show("El campo usuario no puede estar vacío.");
                    return; // Salir del método si el campo está vacío
                }

                if (string.IsNullOrWhiteSpace(textBoxCorreo.Text) || string.IsNullOrWhiteSpace(textBoxContraseña.Text))
                {
                    MessageBox.Show("El campo correo o contraseña no puede estar vacío.");
                    return;
                }

                CConexion objetoConexion = new CConexion();

                using (var conexion = objetoConexion.establecerConexion())
                {
                    // Verificar si la conexión ya está abierta antes de intentar abrirla
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open(); // Solo abre la conexión si no está abierta
                    }

                    // Validar si el usuario o correo ya existen
                    String queryValidacion = "SELECT COUNT(*) FROM Usuarios u JOIN Datos_usuarios d ON u.id = d.Usuario_id WHERE u.Apodo = @Apodo OR d.correo = @Correo";
                    MySqlCommand cmdValidacion = new MySqlCommand(queryValidacion, conexion);
                    cmdValidacion.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                    cmdValidacion.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);

                    int count = Convert.ToInt32(cmdValidacion.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El usuario o el correo ya existen. Intenta con otros valores.");
                        return; // Salir si ya existe un usuario o correo igual
                    }

                    using (var transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Paso 1: Inserción en la tabla Roles (si no lo has hecho antes)
                            String queryRoles = "INSERT INTO Roles (Admin) VALUES (@Admin)";
                            MySqlCommand cmdRoles = new MySqlCommand(queryRoles, conexion, transaction);
                            cmdRoles.Parameters.AddWithValue("@Admin", 0);
                            cmdRoles.ExecuteNonQuery();

                            // Obtener el ID del rol recién insertado
                            long rolId = cmdRoles.LastInsertedId;

                            // Paso 2: Inserción en la tabla Usuarios
                            String queryUsuarios = "INSERT INTO Usuarios (Apodo, Rol_id) VALUES (@Apodo, @Rol_id)";
                            MySqlCommand cmdUsuarios = new MySqlCommand(queryUsuarios, conexion, transaction);
                            cmdUsuarios.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                            cmdUsuarios.Parameters.AddWithValue("@Rol_id", rolId);
                            cmdUsuarios.ExecuteNonQuery();

                            // Obtener el ID del usuario recién insertado
                            long usuarioId = cmdUsuarios.LastInsertedId;

                            // Paso 3: Inserción en la tabla Datos_usuarios
                            String queryDatosUsuarios = "INSERT INTO Datos_usuarios (correo, contraseña, Usuario_id) VALUES (@Correo, @Contraseña, @Usuario_id)";
                            MySqlCommand cmdDatosUsuarios = new MySqlCommand(queryDatosUsuarios, conexion, transaction);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Contraseña", textBoxContraseña.Text);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Usuario_id", usuarioId); // Usa el ID del usuario
                            cmdDatosUsuarios.ExecuteNonQuery();

                            // Confirmar la transacción
                            transaction.Commit();

                            MessageBox.Show("Se guardó correctamente.");
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción si algo sale mal
                            transaction.Rollback();
                            MessageBox.Show("Error al guardar los datos: " + ex.Message);
                        }
                    }
                }

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.Message);
            }
        }

        //a partir de aqui son metodos para el crud de los usuarios FormUsuarios
        public void CrearUsuarios(TextBox textBoxUsuario, TextBox textBoxCorreo, TextBox textBoxContraseña, ComboBox comboBoxRoles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxUsuario.Text))
                {
                    MessageBox.Show("El campo usuario no puede estar vacío.");
                    return; // Salir del método si el campo está vacío
                }

                if (string.IsNullOrWhiteSpace(textBoxCorreo.Text) || string.IsNullOrWhiteSpace(textBoxContraseña.Text))
                {
                    MessageBox.Show("El campo correo o contraseña no puede estar vacío.");
                    return;
                }

                if (comboBoxRoles.SelectedIndex == -1)
                {
                    MessageBox.Show("Debes seleccionar un rol.");
                    return;
                }

                // Asignar el valor basado en el SelectedIndex
                int rolId = comboBoxRoles.SelectedIndex + 1; // Asumiendo que Admin = 1, Usuario = 2

                CConexion objetoConexion = new CConexion();

                using (var conexion = objetoConexion.establecerConexion())
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Validar si el usuario o correo ya existen
                    String queryValidacion = "SELECT COUNT(*) FROM Usuarios u JOIN Datos_usuarios d ON u.id = d.Usuario_id WHERE u.Apodo = @Apodo OR d.correo = @Correo";
                    MySqlCommand cmdValidacion = new MySqlCommand(queryValidacion, conexion);
                    cmdValidacion.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                    cmdValidacion.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);

                    int count = Convert.ToInt32(cmdValidacion.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El usuario o el correo ya existen. Intenta con otros valores.");
                        return; // Salir si ya existe un usuario o correo igual
                    }

                    using (var transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la tabla Usuarios
                            String queryUsuarios = "INSERT INTO Usuarios (Apodo, Rol_id) VALUES (@Apodo, @Rol_id)";
                            MySqlCommand cmdUsuarios = new MySqlCommand(queryUsuarios, conexion, transaction);
                            cmdUsuarios.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                            cmdUsuarios.Parameters.AddWithValue("@Rol_id", rolId);
                            cmdUsuarios.ExecuteNonQuery();

                            long usuarioId = cmdUsuarios.LastInsertedId;

                            // Insertar en la tabla Datos_usuarios
                            String queryDatosUsuarios = "INSERT INTO Datos_usuarios (correo, contraseña, Usuario_id) VALUES (@Correo, @Contraseña, @Usuario_id)";
                            MySqlCommand cmdDatosUsuarios = new MySqlCommand(queryDatosUsuarios, conexion, transaction);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Contraseña", textBoxContraseña.Text);
                            cmdDatosUsuarios.Parameters.AddWithValue("@Usuario_id", usuarioId);
                            cmdDatosUsuarios.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Usuario creado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al guardar los datos: " + ex.Message);
                        }
                    }
                }

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.Message);
            }
        }
        public void mostrarUsuarios(DataGridView tablaUsuarios)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                // Definir la consulta SQL con JOIN para obtener los nombres de los roles
                String query = @"
                    SELECT u.id AS ID, u.Apodo AS Nombre, d.correo AS Correo, 
                           u.Rol_id AS Rol_id,
                           CASE r.Admin WHEN 1 THEN 'Admin' ELSE 'Usuario' END AS Rol
                    FROM Usuarios u
                    JOIN Datos_usuarios d ON u.id = d.Usuario_id
                    JOIN Roles r ON u.Rol_id = r.id";

                // Limpiar el DataGridView antes de cargar los datos
                tablaUsuarios.DataSource = null;

                // Crear un adaptador de datos
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());

                // Crear un DataTable para almacenar los datos de la consulta
                DataTable dt = new DataTable();

                // Llenar el DataTable con los datos de la base de datos
                adapter.Fill(dt);

                // Asignar el DataTable al DataGridView
                tablaUsuarios.DataSource = dt;

                // Cerrar la conexión a la base de datos
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre algún problema
                MessageBox.Show("No se conectó a la base de datos: " + ex.Message);
            }
        }

        public void seleccionarUsuarios(DataGridView tablaUsuarios, TextBox idUsuario, TextBox txtNombre, TextBox txtCorreo, TextBox txtContraseña, ComboBox comboBoxRol)
        {
            try
            {
                // Verificar que haya una fila seleccionada
                if (tablaUsuarios.CurrentRow != null)
                {
                    // Asignar los valores de las celdas a los respectivos TextBox
                    idUsuario.Text = tablaUsuarios.CurrentRow.Cells["ID"].Value.ToString();
                    txtNombre.Text = tablaUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtCorreo.Text = tablaUsuarios.CurrentRow.Cells["Correo"].Value.ToString();
                    txtContraseña.Text = ""; // Mantener la contraseña oculta

                    // Asignar el rol al ComboBox (Admin o Usuario)
                    int rolId = Convert.ToInt32(tablaUsuarios.CurrentRow.Cells["Rol_id"].Value);

                    // Establecer el SelectedIndex basado en Rol_id
                    switch (rolId)
                    {
                        case 1: // Admin
                            comboBoxRol.SelectedIndex = 0;
                            break;
                        case 2: // Usuario
                            comboBoxRol.SelectedIndex = 1;
                            break;
                        default: // Ninguno seleccionado
                            comboBoxRol.SelectedIndex = -1;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el usuario: " + ex.Message);
            }
        }

        public void ActualizarUsuario(TextBox idUsuario, TextBox textBoxUsuario, TextBox textBoxCorreo, TextBox textBoxContraseña, ComboBox comboBoxRoles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxUsuario.Text))
                {
                    MessageBox.Show("El campo usuario no puede estar vacío.");
                    return; // Salir del método si el campo está vacío
                }

                if (string.IsNullOrWhiteSpace(textBoxCorreo.Text))
                {
                    MessageBox.Show("El campo correo no puede estar vacío.");
                    return;
                }

                if (comboBoxRoles.SelectedIndex == -1)
                {
                    MessageBox.Show("Debes seleccionar un rol.");
                    return;
                }

                // Asignar el valor basado en el SelectedIndex
                int rolId = comboBoxRoles.SelectedIndex + 1; // Asumiendo que Admin = 1, Usuario = 2

                CConexion objetoConexion = new CConexion();

                using (var conexion = objetoConexion.establecerConexion())
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Validar si el Apodo o el Correo ya existen para otro usuario
                    string queryValidacion = "SELECT COUNT(*) FROM Usuarios u JOIN Datos_usuarios d ON u.id = d.Usuario_id WHERE (u.Apodo = @Apodo OR d.correo = @Correo) AND u.id != @Usuario_id";
                    MySqlCommand cmdValidacion = new MySqlCommand(queryValidacion, conexion);
                    cmdValidacion.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                    cmdValidacion.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);
                    cmdValidacion.Parameters.AddWithValue("@Usuario_id", idUsuario.Text); // Excluir al usuario actual

                    int count = Convert.ToInt32(cmdValidacion.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El apodo o el correo ya están en uso por otro usuario.");
                        return; // Salir si hay duplicados
                    }

                    using (var transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar el usuario
                            string queryActualizarUsuario = "UPDATE Usuarios SET Apodo = @Apodo, Rol_id = @Rol_id WHERE id = @Usuario_id";
                            MySqlCommand cmdActualizarUsuario = new MySqlCommand(queryActualizarUsuario, conexion, transaction);
                            cmdActualizarUsuario.Parameters.AddWithValue("@Apodo", textBoxUsuario.Text);
                            cmdActualizarUsuario.Parameters.AddWithValue("@Rol_id", rolId);
                            cmdActualizarUsuario.Parameters.AddWithValue("@Usuario_id", idUsuario.Text);
                            cmdActualizarUsuario.ExecuteNonQuery();

                            // Actualizar la contraseña solo si se proporciona
                            if (!string.IsNullOrWhiteSpace(textBoxContraseña.Text))
                            {
                                string queryActualizarDatosUsuario = "UPDATE Datos_usuarios SET correo = @Correo, contraseña = @Contraseña WHERE Usuario_id = @Usuario_id";
                                MySqlCommand cmdActualizarDatosUsuario = new MySqlCommand(queryActualizarDatosUsuario, conexion, transaction);
                                cmdActualizarDatosUsuario.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);
                                cmdActualizarDatosUsuario.Parameters.AddWithValue("@Contraseña", textBoxContraseña.Text);
                                cmdActualizarDatosUsuario.Parameters.AddWithValue("@Usuario_id", idUsuario.Text);
                                cmdActualizarDatosUsuario.ExecuteNonQuery();
                            }
                            else
                            {
                                // Actualizar solo el correo
                                string queryActualizarCorreo = "UPDATE Datos_usuarios SET correo = @Correo WHERE Usuario_id = @Usuario_id";
                                MySqlCommand cmdActualizarCorreo = new MySqlCommand(queryActualizarCorreo, conexion, transaction);
                                cmdActualizarCorreo.Parameters.AddWithValue("@Correo", textBoxCorreo.Text);
                                cmdActualizarCorreo.Parameters.AddWithValue("@Usuario_id", idUsuario.Text);
                                cmdActualizarCorreo.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaction.Commit();
                            MessageBox.Show("Usuario actualizado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción si hay un error
                            transaction.Rollback();
                            MessageBox.Show("Error al actualizar los datos: " + ex.Message);
                        }
                    }
                }

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.Message);
            }
        }

    }
}
