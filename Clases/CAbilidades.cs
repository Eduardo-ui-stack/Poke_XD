
using MySql.Data.MySqlClient;
using Pokedex_No_copyrigt.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace Pokedex_No_copyrigt.Clases
{
    internal class CAbilidades
    {
        public void mostrarAbilidades(DataGridView tablaAbilidades)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "select * from habilidades";
                tablaAbilidades.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaAbilidades.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
            }


        }

        public void InsertarAbilidades(TextBox txtAbilidad)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "INSERT INTO habilidades (habilidad) VALUES (@habilidad)";
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                myComand.Parameters.AddWithValue("@habilidad", txtAbilidad.Text);
                myComand.ExecuteNonQuery();
                MessageBox.Show("se guardo ni madres");

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
                Console.Error.WriteLine(ex.ToString());
            }
        }


        //permite seleccionar los datos de las filas 
        public void seleccionarAbilidades(DataGridView tablaAbilidades, TextBox idAbilidad, TextBox txtAbilidad)
        {
            try
            {
                idAbilidad.Text = tablaAbilidades.CurrentRow.Cells[0].Value.ToString();
                txtAbilidad.Text = tablaAbilidades.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
            }
        }

        public void actualizaraAbilidades(TextBox idAbilidad, TextBox txtAbilidad)
        {
            try
            {
                CConexion objetoConexion = new CConexion();


                String query = "UPDATE habilidades SET habilidad = @habilidad WHERE id = @id";
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());


                myComand.Parameters.AddWithValue("@habilidad", txtAbilidad.Text);
                myComand.Parameters.AddWithValue("@id", idAbilidad.Text);

                myComand.ExecuteNonQuery();
                MessageBox.Show("Se actualizó correctamente.");

                // Cerrar la conexión
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.ToString());
            }
        }

    }
}

