using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaaa.Clases
{
    internal class Clog
    {
        public void mostrarLogs(DataGridView tablaAulas)
        {
            try
            {
                string query = "SELECT t.id, CONCAT(DATE_FORMAT(t.fecha, '%d/%m/%Y %H:%i:%s'), ' - ', t.accion, ' - Usuario: ', u.LoginName,' - ', u.FirstName,' ', u.LastName) AS registro_completo FROM registros t INNER JOIN users u ON t.userid = u.UserID;";
                Cconexion objConex = new Cconexion();
                tablaAulas.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConex.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                

                tablaAulas.DataSource = dt;
                tablaAulas.Columns[0].Visible = false;
                objConex.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron las aulas correctamente: " + ex.ToString());
            }
        }
    }
}
