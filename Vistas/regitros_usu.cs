using MySql.Data.MySqlClient;
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

namespace Pokedex_No_copyrigt.Vistas
{
    public partial class regitros_usu : Form
    {
        private CConexion Cane = new CConexion();
        private FormTipo FomulaTipos;
        private FormAbilidad FormulaHabilidad;
        private FormUsuarioscs Formuusuarios;
        public regitros_usu()
        {
            InitializeComponent();
            FomulaTipos = new FormTipo();
            FormulaHabilidad = new FormAbilidad();
            Formuusuarios = new FormUsuarioscs();
            CargarUsuarios();
        }

        int selectedUserId = 0; // Variable para almacenar el ID del usuario seleccionado



        // Función para cargar los usuarios en el DataGridView
        public void CargarUsuarios()
        {
            string conexion = Cane.Cadena_conexuon();
            // Usamos un JOIN entre las tablas usuarios y roles
            string query = $@"SELECT 
    u.id, 
    u.Apodo, 
    CASE 
        WHEN u.Conectado = 1 THEN 'Sí'
        ELSE 'No'
    END AS Conectado,
    CASE 
        WHEN r.Admin = 1 THEN 'Administrador'
        ELSE 'Entrenador'
    END AS Rol
FROM usuarios u
INNER JOIN roles r ON u.Rol_id = r.id
WHERE NOT u.id = '{Cache.UserCache.IdUser}';
"; // Hacemos el join usando el Rol_id

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                DataTable dt = new DataTable();
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                Buscador.DataSource = dt; // Asignamos los resultados al DataGridView 'Buscador'
            }
        }


        // Evento DoubleClick para capturar el ID del usuario seleccionado
        private void Buscador_DoubleClick(object sender, EventArgs e)
        {
            if (Buscador.CurrentRow != null)
            {
                // Obtener el ID del usuario seleccionado
                selectedUserId = Convert.ToInt32(Buscador.CurrentRow.Cells["id"].Value);

                // Asignar el apodo al TextBox txt_usuario
                txt_usuario.Text = Buscador.CurrentRow.Cells["Apodo"].Value.ToString();

                // Mostrar mensaje de éxito
                MessageBox.Show("Datos cargados correctamente: " + txt_usuario.Text);
            }
        }


        // Evento Click del botón confirmar para actualizar el rol del usuario
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string comexion = Cane.Cadena_conexuon();
            if (selectedUserId > 0)
            {
                // Verificar si se seleccionó un rol en el ComboBox
                if (list_rol.SelectedItem != null)
                {
                    // Definir el nuevo rol basado en la selección del ComboBox
                    int nuevoRol = (list_rol.SelectedItem.ToString() == "Administrador") ? 1 : 0;

                    // Preguntar si el usuario está seguro de realizar el cambio
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Estás seguro de que deseas actualizar el rol del usuario seleccionado?",
                        "Confirmar Actualización",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmacion == DialogResult.Yes)
                    {
                        // Actualizar el rol del usuario en la base de datos
                        string query = "UPDATE roles SET Admin = @rol WHERE id = (SELECT Rol_id FROM usuarios WHERE id = @id);";

                        using (MySqlConnection conn = new MySqlConnection(comexion))
                        {
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@rol", nuevoRol);
                            cmd.Parameters.AddWithValue("@id", selectedUserId);
                            conn.Open();

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("El rol del usuario ha sido actualizado correctamente.");
                                CargarUsuarios(); // Refrescar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar el rol.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Actualización cancelada.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un rol para continuar.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario primero.");
            }
        }


        public void AbrirFormulario(Form form1, Form form2, Form form3)
        {


            // Configurar el formulario que deseas abrir
            form1.TopLevel = false;
            form1.FormBorderStyle = FormBorderStyle.None; // Eliminar el borde del formulario
            form1.Dock = DockStyle.Fill; // Hacer que el formulario llene todo el panel
            panel1.Controls.Add(form1);
            panel1.Tag = form1;
            form1.BringToFront();
            form1.Show(); // Asegurarse de que el formulario esté visible
            // Configurar los otros formularios como no visibles si es necesario
            form2.Visible = false;
            form3.Visible = false;
        }


        private void btn_tipo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(FomulaTipos, Formuusuarios, FormulaHabilidad);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Formuusuarios, FormulaHabilidad, FomulaTipos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(FormulaHabilidad,FomulaTipos, Formuusuarios);
        }

        //Aki termina el codigo
    }
}
