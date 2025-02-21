using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;

namespace pruebaaa.Clases
{
    internal class Clogin
    {
        Cregistromovimientos cregis = new Cregistromovimientos();
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void RegistrarUsuario(string nombreUsuario, string contraseña)
        {
            string hashedPassword = HashPassword(contraseña); // Hashea la contraseña

            string query = "INSERT INTO users (LoginName, Password) VALUES (@LoginName, @Password)";

            using (MySqlConnection conexion = new MySqlConnection("server =localhost;port=3306;user=root;password=;database=pruebaconn"))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@LoginName", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Registrar el movimiento de creación de usuario
            //cregis.RegistrarMovimiento(nombreUsuario, "Registro de nuevo usuario");
        }

        public List<string> ObtenerUsuarios()
        {
            List<string> usuarios = new List<string>();
            MySqlConnection conex = null;

            try
            {
                conex = new Cconexion().EstablecerConexion();
                string query = "SELECT CONCAT(LoginName, ' - ', FirstName, ' ', LastName) AS usuario FROM users ORDER BY LastName, FirstName";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(reader["usuario"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            return usuarios;
        }

        public Dictionary<string, string> ObtenerDatosUsuario(string LoginName)
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().EstablecerConexion();
                string query = "SELECT * FROM users WHERE LoginName = @LoginName";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                {
                    cmd.Parameters.AddWithValue("@LoginName", LoginName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datos["UserID"] = reader["UserID"].ToString();
                            datos["FirstName"] = reader["FirstName"].ToString();
                            datos["LastName"] = reader["LastName"].ToString();
                            datos["Position"] = reader["Position"].ToString();
                            datos["Email"] = reader["Email"].ToString();
                            datos["Telefono"] = reader["Telefono"].ToString();
                            datos["Cedula"] = reader["Cedula"].ToString();
                            datos["LoginName"] = reader["LoginName"].ToString();
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

        public bool EliminarCuenta(int id)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().EstablecerConexion();
                string queryEliminar = "DELETE FROM users WHERE UserID = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryEliminar, conex))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Cuenta eliminado exitosamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la cuenta a eliminar.");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al eliminar la cuenta: {ex.Message}");
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
        public bool ModificarRol(int id, string rol)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().EstablecerConexion();

                string queryActualizar = @"UPDATE users SET Position = @Position WHERE UserID = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryActualizar, conex))
                {
                    // Agregamos los parámetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Position", rol);

                    // Ejecutamos el comando
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Rol modificado exitosamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario para modificar. (ID del usuario incorrecto o inaccesible");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al modificar el rol del usuario: {ex.Message}");
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
