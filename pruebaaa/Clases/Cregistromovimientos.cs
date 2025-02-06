using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaaa.Clases
{
    internal class Cregistromovimientos
    {
        public void RegistrarMovimiento(int usuarioID, string accion)
        {
            string query = "INSERT INTO registros (userid, accion) VALUES (@UsuarioID, @Accion)";

            using (MySqlConnection conexion = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=pruebaconn"))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    cmd.Parameters.AddWithValue("@Accion", accion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
