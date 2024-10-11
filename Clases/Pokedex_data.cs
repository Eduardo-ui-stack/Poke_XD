using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_No_copyrigt.Clases
{
    internal class Pokedex_data
    {
        public class Pokemon
        {
         
                public int Id { get; set; }
                public string Nombre { get; set; }
                public string Descripcion { get; set; }
                public decimal Altura { get; set; }
                public decimal Peso { get; set; }
                public byte[] Imagen { get; set; } // Aquí cambiamos a byte[]
                public List<string> Habilidades { get; set; }
                public List<string> GruposHuevo { get; set; }
            


            public Pokemon()
            {
                Habilidades = new List<string>();
                GruposHuevo = new List<string>();
            }

            // Función para cargar todos los pokemones de la base de datos
            public static List<Pokemon> CargarPokemonesPorUsuario(int usuarioId)
            {
                List<Pokemon> pokemones = new List<Pokemon>();
                using (var conexion = new MySqlConnection(CadenaConexion()))
                {
                    conexion.Open();
                    string query = "SELECT p.id, p.Nombre, p.Descripcion, p.Altura, p.Peso, p.Imagen, " +
                                   "GROUP_CONCAT(DISTINCT h.habilidad SEPARATOR ', ') AS Habilidades, " +
                                   "GROUP_CONCAT(DISTINCT g.grupo SEPARATOR ', ') AS GruposHuevo " +
                                   "FROM pokemon p " +
                                   "LEFT JOIN habilidades_pokemon hp ON p.id = hp.Pokemon_id " +
                                   "LEFT JOIN habilidades h ON hp.Habilidades_id = h.id " +
                                   "LEFT JOIN grupo_huevo_pokemon gh ON p.id = gh.Pokemon_id " +
                                   "LEFT JOIN grupo_huevo g ON gh.Grupo_huevo_id = g.id " +
                                   "INNER JOIN pokemon_captura pc ON p.id = pc.Pokemon_id " +
                                   "WHERE pc.Usuario_id = @UsuarioId " +  // Filtro por usuario
                                   "GROUP BY p.id";

                    using (var comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@UsuarioId", usuarioId);  // Parametrizamos el ID de usuario
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                Pokemon pokemon = new Pokemon
                                {
                                    Id = lector.GetInt32(lector.GetOrdinal("id")),
                                    Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                                    Descripcion = lector.GetString(lector.GetOrdinal("Descripcion")),
                                    Altura = lector.GetDecimal(lector.GetOrdinal("Altura")),
                                    Peso = lector.GetDecimal(lector.GetOrdinal("Peso")),
                                    Imagen = !lector.IsDBNull(lector.GetOrdinal("Imagen"))
                                        ? (byte[])lector["Imagen"]
                                        : null,
                                    Habilidades = !lector.IsDBNull(lector.GetOrdinal("Habilidades"))
                                        ? new List<string>(lector.GetString(lector.GetOrdinal("Habilidades")).Split(new[] { ", " }, StringSplitOptions.None))
                                        : new List<string>(),
                                    GruposHuevo = !lector.IsDBNull(lector.GetOrdinal("GruposHuevo"))
                                        ? new List<string>(lector.GetString(lector.GetOrdinal("GruposHuevo")).Split(new[] { ", " }, StringSplitOptions.None))
                                        : new List<string>()
                                };

                                pokemones.Add(pokemon);
                            }
                        }
                    }
                }
                return pokemones;
            }

            public static List<Pokemon> CargarPokemones()
            {
                List<Pokemon> pokemones = new List<Pokemon>();
                using (var conexion = new MySqlConnection(CadenaConexion()))
                {
                    conexion.Open();
                    string query = "SELECT p.id, p.Nombre, p.Descripcion, p.Altura, p.Peso, p.Imagen, " +
                                   "GROUP_CONCAT(DISTINCT h.habilidad SEPARATOR ', ') AS Habilidades, " +
                                   "GROUP_CONCAT(DISTINCT g.grupo SEPARATOR ', ') AS GruposHuevo " +
                                   "FROM pokemon p " +
                                   "LEFT JOIN habilidades_pokemon hp ON p.id = hp.Pokemon_id " +
                                   "LEFT JOIN habilidades h ON hp.Habilidades_id = h.id " +
                                   "LEFT JOIN grupo_huevo_pokemon gh ON p.id = gh.Pokemon_id " +
                                   "LEFT JOIN grupo_huevo g ON gh.Grupo_huevo_id = g.id " +
                                   "GROUP BY p.id";

                    using (var comando = new MySqlCommand(query, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                Pokemon pokemon = new Pokemon
                                {
                                    Id = lector.GetInt32(lector.GetOrdinal("id")),
                                    Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                                    Descripcion = lector.GetString(lector.GetOrdinal("Descripcion")),
                                    Altura = lector.GetDecimal(lector.GetOrdinal("Altura")),
                                    Peso = lector.GetDecimal(lector.GetOrdinal("Peso")),
                                    // Obtener la imagen como byte[] si no es nula
                                    Imagen = !lector.IsDBNull(lector.GetOrdinal("Imagen"))
                                        ? (byte[])lector["Imagen"]
                                        : null,
                                    // Obtener las habilidades como lista de strings si no es nula
                                    Habilidades = !lector.IsDBNull(lector.GetOrdinal("Habilidades"))
                                        ? new List<string>(lector.GetString(lector.GetOrdinal("Habilidades")).Split(new[] { ", " }, StringSplitOptions.None))
                                        : new List<string>(),
                                    // Obtener los grupos huevo como lista de strings si no es nula
                                    GruposHuevo = !lector.IsDBNull(lector.GetOrdinal("GruposHuevo"))
                                        ? new List<string>(lector.GetString(lector.GetOrdinal("GruposHuevo")).Split(new[] { ", " }, StringSplitOptions.None))
                                        : new List<string>()
                                };

                                pokemones.Add(pokemon);
                            }



                        }
                    }
                }
                return pokemones;
            }
            private static CConexion Cane = new CConexion();
            // Función para obtener la cadena de conexión
            private static string CadenaConexion()
            {
                string pene = Cane.Cadena_conexuon();
                return pene; // Usando la cadena de conexión proporcionada
            }
        }
    }
}
