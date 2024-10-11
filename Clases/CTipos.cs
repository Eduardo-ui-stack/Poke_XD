
using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace Yucadexleo.Clases
{
    internal class CTipos
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

                // Usar parámetros en lugar de concatenar el texto
                String query = "INSERT INTO tipos (tipo) VALUES (@tipo)";
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());

                // Asignar el valor al parámetro
                myComand.Parameters.AddWithValue("@tipo", TxtTipoName.Text);

                myComand.ExecuteNonQuery();
                MessageBox.Show("Se guardó correctamente.");

                objetoConexion.cerrarConexion();
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
                CConexion objetoConexion = new CConexion();

                // Usar parámetros en lugar de concatenar el texto
                String query = "UPDATE tipos SET tipo = @tipo WHERE id = @id";
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());

                // Asignar valores a los parámetros
                myComand.Parameters.AddWithValue("@tipo", TxtTipoName.Text);
                myComand.Parameters.AddWithValue("@id", TxtIdtipo.Text);

                myComand.ExecuteNonQuery();
                MessageBox.Show("Se actualizó correctamente.");

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.ToString());
            }
        }

    }
}

