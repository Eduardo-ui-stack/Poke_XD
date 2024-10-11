using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex_No_copyrigt.Clases
{
    internal class CConexion
    {
        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";//127.0.0.1
        static string bd = "yucadex";
        static string usuario = "root";
        static string password = "123456";//03182130
        static string puerto = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        public string Cadena_conexuon()
        {
            return cadenaConexion;
        }
        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Se conecto a la bd");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la bd" + ex.ToString());
            }
            return conex;
        }

        public void cerrarConexion()
        {
            conex.Close();
        }
    }
}
