using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pruebaaa.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaaa.Clases
{
    internal class Cdatos
    {
        private Cconexion conexion;

        public Cdatos()
        {
            conexion = new Cconexion();
        }
        
        Cregistromovimientos regis = new Cregistromovimientos();

        public List<string> ObtenerEstudiantes()
        {
            List<string> estudiantes = new List<string>();
            MySqlConnection conex = null;

            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT CONCAT(cedula, ' - ', nombre, ' ', apellido) AS estudiante FROM estudiantes ORDER BY apellido, nombre";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estudiantes.Add(reader["estudiante"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estudiantes: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            return estudiantes;
        }
        public List<string> obtenerValoresSexo()
        {
            List<string> valores = new List<string>();
            try
            {
                using (MySqlConnection conexion = new Cconexion().establecerConexion())
                {
                    string query = "SHOW COLUMNS FROM estudiantes WHERE Field = 'sexo'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string enumString = reader["Type"].ToString();
                                enumString = enumString.Substring(5, enumString.Length - 6);
                                valores = enumString.Split(',')
                                                  .Select(v => v.Trim('\''))
                                                  .ToList();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al obtener valores de sexo: " + ex.Message);
            }
            return valores;
        }

        public bool AgregarEstudiante(int usuarioID, string cedula, string nombre, string apellido, string sexo, string telefono, string email)
        {
            MySqlConnection conex = null;
            try
            {
                // Crear una nueva conexión para esta operación
                conex = new Cconexion().establecerConexion();

                // Primero verificamos si el estudiante ya existe
                string queryVerificar = "SELECT COUNT(*) FROM estudiantes WHERE cedula = @cedula";
                using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conex))
                {
                    cmdVerificar.Parameters.AddWithValue("@cedula", cedula);
                    int count = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe un estudiante con esta cédula.");
                        return false;
                    }
                }

                // Query para insertar el estudiante
                string queryInsertar = @"INSERT INTO estudiantes 
                       (cedula, nombre, apellido, sexo, telefono, email) 
                       VALUES 
                       (@cedula, @nombre, @apellido, @sexo, @telefono, @email)";

                using (MySqlCommand cmdInsertar = new MySqlCommand(queryInsertar, conex))
                {
                    // Agregamos los parámetros
                    cmdInsertar.Parameters.AddWithValue("@cedula", cedula);
                    cmdInsertar.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsertar.Parameters.AddWithValue("@apellido", apellido);
                    cmdInsertar.Parameters.AddWithValue("@sexo", sexo);
                    cmdInsertar.Parameters.AddWithValue("@telefono", telefono);
                    cmdInsertar.Parameters.AddWithValue("@email", email); // Cambiado de @email a @correo

                    // Ejecutamos el comando
                    int filasAfectadas = cmdInsertar.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estudiante agregado exitosamente.");
                        regis.RegistrarMovimiento(usuarioID, $"Agregó estudiante: {nombre} {apellido} (Cédula: {cedula})");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el estudiante.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al agregar estudiante: {ex.Message}");
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

        public Dictionary<string, string> ObtenerDatosEstudiante(string cedula)
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT * FROM estudiantes WHERE cedula = @cedula";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datos["id"] = reader["id"].ToString();
                            datos["cedula"] = reader["cedula"].ToString();
                            datos["nombre"] = reader["nombre"].ToString();
                            datos["apellido"] = reader["apellido"].ToString();
                            datos["sexo"] = reader["sexo"].ToString();
                            datos["telefono"] = reader["telefono"].ToString();
                            datos["email"] = reader["email"].ToString();
                            datos["matricula"] = reader["matricula"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del estudiante: {ex.Message}");
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

        public bool ModificarEstudiante(int usuarioID, int id, string cedula, string nombre, string apellido, string sexo, string telefono, string email)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();

                string queryActualizar = @"UPDATE estudiantes 
                                 SET cedula = @cedula,
                                     nombre = @nombre, 
                                     apellido = @apellido, 
                                     sexo = @sexo, 
                                     telefono = @telefono, 
                                     email = @email 
                                 WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryActualizar, conex))
                {
                    // Agregamos los parámetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@sexo", sexo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);

                    // Ejecutamos el comando
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estudiante modificado exitosamente.");
                        regis.RegistrarMovimiento(usuarioID, $"Modifico Estudiante: {nombre} {apellido} (Cédula: {cedula})");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el estudiante para modificar.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al modificar estudiante: {ex.Message}");
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

        public bool EliminarEstudiante(int usuarioID, int id)
        {
            MySqlConnection conex = null;
            string nombre = string.Empty;
            string apellido = string.Empty;
            string cedula = string.Empty;

            try
            {
                conex = new Cconexion().establecerConexion();

                // Primero, obtenemos los datos del estudiante
                string queryObtenerDatos = "SELECT nombre, apellido, cedula FROM estudiantes WHERE id = @id";
                using (MySqlCommand cmdObtenerDatos = new MySqlCommand(queryObtenerDatos, conex))
                {
                    cmdObtenerDatos.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmdObtenerDatos.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombre = reader["nombre"].ToString();
                            apellido = reader["apellido"].ToString();
                            cedula = reader["cedula"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el estudiante para eliminar.");
                            return false;
                        }
                    }
                }

                // Ahora eliminamos al estudiante
                string queryEliminar = "DELETE FROM estudiantes WHERE id = @id";
                using (MySqlCommand cmdEliminar = new MySqlCommand(queryEliminar, conex))
                {
                    cmdEliminar.Parameters.AddWithValue("@id", id);
                    int filasAfectadas = cmdEliminar.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estudiante eliminado exitosamente.");

                        // Registrar el movimiento con los datos obtenidos
                        regis.RegistrarMovimiento(usuarioID, $"Eliminó estudiante: {nombre} {apellido} (Cédula: {cedula})");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el estudiante para eliminar.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al eliminar estudiante: {ex.Message}");
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