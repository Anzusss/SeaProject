using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaaa.Clases
{
    internal class Cmaterias
    {
        private Cconexion conexion;
        Cregistromovimientos regis = new Cregistromovimientos();

        public Cmaterias()
        {
            conexion = new Cconexion();
        }

        public class Categoria
        {
            public string id { get; set; }
            public string nombre { get; set; }
        }

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            MySqlConnection conex = null;

            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre FROM departamento ORDER BY nombre";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            id = reader["id"].ToString(),
                            nombre = reader["nombre"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las categorías: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            return categorias;
        }

        public List<string> ObtenerMaterias()
        {
            List<string> materias = new List<string>();
            MySqlConnection conex = null;

            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT CONCAT(nombre, ' - ', matricula) AS materia FROM materias ORDER BY nombre";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        materias.Add(reader["materia"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las materias: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            return materias;
        }

        public bool AgregarMateria(int usuarioID,string nombre, string descripcion, string categoria)
        {
            MySqlConnection conex = null;
            try
            {
                // Crear una nueva conexión para esta operación
                conex = new Cconexion().establecerConexion();

                // Primero verificamos si la materia ya existe con el mismo nombre y profesor
                string queryVerificar = "SELECT COUNT(*) FROM materias WHERE nombre = @nombre";
                using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conex))
                {
                    cmdVerificar.Parameters.AddWithValue("@nombre", nombre);
                    int count = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe una materia con este nombre para este profesor.");
                        return false;
                    }
                }

                // Query para insertar la materia
                string queryInsertar = @"INSERT INTO materias 
               (nombre, descripcion, id_categoria) 
               VALUES 
               (@nombre, @descripcion, @id_categoria)";

                using (MySqlCommand cmdInsertar = new MySqlCommand(queryInsertar, conex))
                {
                    // Agregamos los parámetros
                    cmdInsertar.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsertar.Parameters.AddWithValue("@descripcion", descripcion);
                    cmdInsertar.Parameters.AddWithValue("@id_categoria", categoria);

                    // Ejecutamos el comando
                    int filasAfectadas = cmdInsertar.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Materia agregada exitosamente.");
                        regis.RegistrarMovimiento(usuarioID, $"Agregó una materia: {nombre}*");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la materia.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al agregar la materia: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
                return false;
            }
            finally
            {
                // Asegurarnos de cerrar la conexión
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }

        public Dictionary<string, string> ObtenerDatosMateria(string nombre)
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT * FROM materias WHERE nombre = @nombre";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datos["id"] = reader["id"].ToString();
                            datos["id_categoria"] = reader["id_categoria"].ToString();
                            datos["nombre"] = reader["nombre"].ToString();
                            datos["descripcion"] = reader["descripcion"].ToString();
                            datos["matricula"] = reader["matricula"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la materia: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
            return datos;
        }

        public bool ModificarMateria(int usuarioID, int id, string nombre, string descripcion, string categoria)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();

                string queryActualizar = @"UPDATE materias SET nombre = @nombre, descripcion = @descripcion, id_categoria = @id_categoria WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryActualizar, conex))
                {
                    // Agregamos los parámetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", categoria);
                    // Ejecutamos el comando
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Materia modificada exitosamente.");
                        regis.RegistrarMovimiento(usuarioID, $"Modificó una matera: {nombre}");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la materia para modificar.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al modificar materia: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
                return false;
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }

        public bool EliminarMateria(int usuarioID, int id)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string queryEliminar = "DELETE FROM materias WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryEliminar, conex))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Materia eliminada exitosamente.");
                        regis.RegistrarMovimiento(usuarioID, $"Eliminó una materia");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la materia para eliminar.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al eliminar la materia: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
                return false;
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
    }
}
