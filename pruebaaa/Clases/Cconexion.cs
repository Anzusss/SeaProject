using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaaa.Clases
{
    internal class Cconexion
    {
        private MySqlConnection conex;

        private static readonly string servidor = "localhost";
        private static readonly string bd = "pruebaconn";
        private static readonly string user = "root";
        private static readonly string pssw = "";
        private static readonly string port = "3306";

        private static readonly string cadenaconexion = new MySqlConnectionStringBuilder
        {
            Server = servidor,
            Port = uint.Parse(port),
            UserID = user,
            Password = pssw,
            Database = bd,
            SslMode = MySqlSslMode.None
        }.ToString();

        public Cconexion()
        {
            conex = new MySqlConnection(cadenaconexion);
        }

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                if (conex.State == System.Data.ConnectionState.Closed)
                {
                    conex.Open();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error al conectar a la BD: {e.Message}");
                throw; // Lanza la excepción para que pueda ser manejada en niveles superiores
            }

            return conex;
        }

        public void CerrarConexion()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

        public void Dispose()
        {
            CerrarConexion();
            conex.Dispose();
        }
    }
}
