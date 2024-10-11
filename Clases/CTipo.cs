using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_No_copyrigt.Clases
{
    internal class CTipo
    {
        public void mostrarTipos(DataGridView tablaTipos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "select * from tipos";
                tablaTipos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaTipos.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
            }
        }

        public void InsertarTipos(TextBox TxtTipoName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtTipoName.Text))
                {
                    MessageBox.Show("El campo Tipo no puede estar vacío.");
                    return; // Salir del método si el campo está vacío
                }

                CConexion objetoConexion = new CConexion();

                using (var conexion = objetoConexion.establecerConexion())
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Validar si el tipo ya existe
                    string queryValidacion = "SELECT COUNT(*) FROM tipos WHERE tipo = @tipo";
                    MySqlCommand cmdValidacion = new MySqlCommand(queryValidacion, conexion);
                    cmdValidacion.Parameters.AddWithValue("@tipo", TxtTipoName.Text);

                    int count = Convert.ToInt32(cmdValidacion.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Este tipo ya está registrado.");
                        return; // Salir si ya existe
                    }

                    // Si no existe, insertar el nuevo tipo
                    String queryInsertar = "INSERT INTO tipos (tipo) VALUES (@tipo)";
                    MySqlCommand myComand = new MySqlCommand(queryInsertar, conexion);
                    myComand.Parameters.AddWithValue("@tipo", TxtTipoName.Text);
                    myComand.ExecuteNonQuery();

                    MessageBox.Show("Se guardó correctamente.");
                    objetoConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.ToString());
            }
        }




        //permite seleccionar los datos de las filas 
        public void seleccionarTipos(DataGridView tablaTipos, TextBox TxtIdtipo, TextBox TxtTipoName)
        {
            try
            {
                TxtIdtipo.Text = tablaTipos.CurrentRow.Cells[0].Value.ToString();
                TxtTipoName.Text = tablaTipos.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
            }
        }

        public void actualizarTipos(TextBox TxtIdtipo, TextBox TxtTipoName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtIdtipo.Text) || !int.TryParse(TxtIdtipo.Text, out _))
                {
                    MessageBox.Show("El campo ID de tipo no es válido.");
                    return; // Salir si el ID es inválido
                }

                if (string.IsNullOrWhiteSpace(TxtTipoName.Text))
                {
                    MessageBox.Show("El campo Tipo no puede estar vacío.");
                    return; // Salir si el campo está vacío
                }

                CConexion objetoConexion = new CConexion();

                using (var conexion = objetoConexion.establecerConexion())
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }

                    // Validar si el nombre del tipo ya existe para otro ID
                    string queryValidacion = "SELECT COUNT(*) FROM tipos WHERE tipo = @tipo AND id != @id";
                    MySqlCommand cmdValidacion = new MySqlCommand(queryValidacion, conexion);
                    cmdValidacion.Parameters.AddWithValue("@tipo", TxtTipoName.Text);
                    cmdValidacion.Parameters.AddWithValue("@id", TxtIdtipo.Text);

                    int count = Convert.ToInt32(cmdValidacion.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Este tipo ya está registrado bajo otro ID.");
                        return; // Salir si ya existe para otro ID
                    }

                    // Si no existe duplicado, actualizar el tipo
                    String queryActualizar = "UPDATE tipos SET tipo = @tipo WHERE id = @id";
                    MySqlCommand myComand = new MySqlCommand(queryActualizar, conexion);
                    myComand.Parameters.AddWithValue("@tipo", TxtTipoName.Text);
                    myComand.Parameters.AddWithValue("@id", TxtIdtipo.Text);
                    myComand.ExecuteNonQuery();

                    MessageBox.Show("Se actualizó correctamente.");
                    objetoConexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.ToString());
            }
        }

    }
}
