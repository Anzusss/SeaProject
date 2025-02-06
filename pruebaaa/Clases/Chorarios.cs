using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pruebaaa.Clases.Cmaterias;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaaa.Clases
{
    internal class Chorarios
    {
        Cregistromovimientos regis = new Cregistromovimientos();
        private Cconexion conexion;
        public Chorarios()
        {
            conexion = new Cconexion();
        }
        public class Materia
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }
        public class Profesor
        {
            public int id { get; set; } // Cambiar a int si el ID es numerico
            public string nombre { get; set; }
            public string apellido { get; set; }

            // Propiedad calculada para obtener el nombre completo
            public string NombreCompleto
            {
                get { return $"{nombre} {apellido}"; }
            }

            // Opcional: Sobrescribir ToString para mostrar NombreCompleto en el ComboBox
            public override string ToString()
            {
                return NombreCompleto;
            }
        }
        public class Aulas
        {
            public int id { get; set; } // Cambiado a int si el ID es numérico
            public string nombre { get; set; }
            public string capacidad { get; set; }

            // Propiedad calculada para obtener el nombre y capacidad
            public string NombreCompleto
            {
                get { return $"{nombre} - {capacidad}"; }
            }

            // Sobrescribir ToString para mostrar NombreCompleto
            public override string ToString()
            {
                return NombreCompleto;
            }
        }
        public class Grupos
        {
            public int id { get; set; } // Cambiado a int si el ID es numérico
            public string nombre { get; set; }
            public string descripcion { get; set; } // Opcional, si deseas incluir una descripción

            // Propiedad calculada para obtener el nombre completo (si es necesario)
            public string NombreCompleto
            {
                get { return $"{nombre}"; } // Puedes personalizar esto si deseas mostrar más información
            }

            public override string ToString()
            {
                return NombreCompleto; // Esto permite que el ComboBox muestre el nombre del grupo
            }
        }
        public class Dias
        {
            public int id { get; set; } // Cambiado a int si el ID es numérico
            public string nombre { get; set; }
            public string descripcion { get; set; } // Opcional, si deseas incluir una descripción

            // Propiedad calculada para obtener el nombre completo (si es necesario)
            public string NombreCompleto
            {
                get { return $"{nombre}"; } // Puedes personalizar esto si deseas mostrar más información
            }

            public override string ToString()
            {
                return NombreCompleto; // Esto permite que el ComboBox muestre el nombre del grupo
            }
        }
        public void LlenarComboBoxHoras(ComboBox comboBox)
        {
            for (int i = 6; i < 18; i++)
            {
                for (int j = 0; j < 60; j += 30) // Cada 30 minutos
                {
                    string hora = $"{i:D2}:{j:D2}"; // Formato HH:MM
                    comboBox.Items.Add(hora);
                }
            }
        }
        public void LlenarComboBoxesMaterias(ComboBox cmbVisible, ComboBox cmbHidden)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre FROM materias ORDER BY id";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbVisible.Items.Clear(); // Limpiar items anteriores
                    cmbHidden.Items.Clear(); // Limpiar items en el ComboBox oculto

                    while (reader.Read())
                    {
                        // Crear una nueva instancia de Materia
                        Materia materia = new Materia
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString()
                        };

                        // Agregar al ComboBox visible
                        cmbVisible.Items.Add(materia);

                        // Agregar la ID al ComboBox oculto
                        cmbHidden.Items.Add(materia.ID);
                    }
                }

                // Establecer DisplayMember y ValueMember para el ComboBox visible
                cmbVisible.DisplayMember = "Nombre"; // Mostrar nombre en el ComboBox visible
                cmbVisible.ValueMember = "ID"; // Guardar ID internamente en el ComboBox oculto

                // Ocultar el ComboBox de IDs
                cmbHidden.Visible = false;
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
        }
        public void LlenarComboBoxesProfesores(ComboBox cmbVisible, ComboBox cmbHidden)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre, apellido FROM profesores ORDER BY id";

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbVisible.Items.Clear(); // Limpiar items anteriores
                    cmbHidden.Items.Clear(); // Limpiar items en el ComboBox oculto

                    while (reader.Read())
                    {
                        // Crear una nueva instancia de Profesor
                        Profesor profesor = new Profesor
                        {
                            id = Convert.ToInt32(reader["id"]), // Asegúrate de que sea int
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString()
                        };

                        // Agregar al ComboBox visible
                        cmbVisible.Items.Add(profesor);

                        // Agregar la ID al ComboBox oculto
                        cmbHidden.Items.Add(profesor.id);
                    }
                }

                // Establecer DisplayMember y ValueMember para el ComboBox visible
                cmbVisible.DisplayMember = "NombreCompleto"; // Mostrar nombre completo en el ComboBox visible
                cmbVisible.ValueMember = "id"; // Guardar ID internamente en el ComboBox oculto

                // Ocultar el ComboBox de IDs (si es necesario)
                cmbHidden.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los profesores: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        public void LlenarComboBoxesAulas(ComboBox cmbVisible, ComboBox cmbHidden)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre, capacidad FROM aulas where disponible = 'Si' ORDER BY id"; // Filtrar por disponibilidad

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbVisible.Items.Clear(); // Limpiar items anteriores
                    cmbHidden.Items.Clear(); // Limpiar items en el ComboBox oculto

                    while (reader.Read())
                    {
                        // Crear una nueva instancia de Aulas
                        Aulas aula = new Aulas
                        {
                            id = Convert.ToInt32(reader["id"]), // Cambiado a int
                            nombre = reader["nombre"].ToString(),
                            capacidad = reader["capacidad"].ToString()
                            // No se incluye 'disponible' ya que no está en la consulta
                        };

                        // Agregar al ComboBox visible
                        cmbVisible.Items.Add(aula);

                        // Agregar la ID al ComboBox oculto
                        cmbHidden.Items.Add(aula.id);
                    }
                }

                // Verificar si se encontraron aulas disponibles
                if (cmbVisible.Items.Count == 0)
                {
                    MessageBox.Show("No hay aulas disponibles.");
                }

                // Establecer DisplayMember y ValueMember para el ComboBox visible
                cmbVisible.DisplayMember = "NombreCompleto"; // Mostrar nombre y capacidad en el ComboBox visible
                cmbVisible.ValueMember = "id"; // Guardar ID internamente en el ComboBox oculto

                // Ocultar el ComboBox de IDs (si es necesario)
                cmbHidden.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las aulas: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        public void LlenarComboBoxesGrupos(ComboBox cmbVisible, ComboBox cmbHidden)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre FROM grupos ORDER BY id"; // Ajusta la consulta según tu base de datos

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbVisible.Items.Clear(); // Limpiar items anteriores
                    cmbHidden.Items.Clear(); // Limpiar items en el ComboBox oculto

                    while (reader.Read())
                    {
                        // Crear una nueva instancia de Grupos
                        Grupos grupo = new Grupos
                        {
                            id = Convert.ToInt32(reader["id"]), // Asegúrate de que sea int
                            nombre = reader["nombre"].ToString(),
                        };

                        // Agregar al ComboBox visible
                        cmbVisible.Items.Add(grupo);

                        // Agregar la ID al ComboBox oculto
                        cmbHidden.Items.Add(grupo.id);
                    }
                }

                // Verificar si se encontraron grupos disponibles
                if (cmbVisible.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos disponibles.");
                }

                // Establecer DisplayMember y ValueMember para el ComboBox visible
                cmbVisible.DisplayMember = "NombreCompleto"; // Mostrar nombre en el ComboBox visible
                cmbVisible.ValueMember = "id"; // Guardar ID internamente en el ComboBox oculto

                // Ocultar el ComboBox de IDs (si es necesario)
                cmbHidden.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los grupos: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        public void LlenarComboBoxesDias(ComboBox cmbVisible, ComboBox cmbHidden)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();
                string query = "SELECT id, nombre FROM dia_semana ORDER BY id"; // Ajusta la consulta según tu base de datos

                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    cmbVisible.Items.Clear(); // Limpiar items anteriores
                    cmbHidden.Items.Clear(); // Limpiar items en el ComboBox oculto

                    while (reader.Read())
                    {
                        // Crear una nueva instancia de Grupos
                        Dias dia = new Dias
                        {
                            id = Convert.ToInt32(reader["id"]), // Asegúrate de que sea int
                            nombre = reader["nombre"].ToString(),
                        };

                        // Agregar al ComboBox visible
                        cmbVisible.Items.Add(dia);

                        // Agregar la ID al ComboBox oculto
                        cmbHidden.Items.Add(dia.id);
                    }
                }

                // Verificar si se encontraron grupos disponibles
                if (cmbVisible.Items.Count == 0)
                {
                    MessageBox.Show("No hay grupos disponibles.");
                }

                // Establecer DisplayMember y ValueMember para el ComboBox visible
                cmbVisible.DisplayMember = "NombreCompleto"; // Mostrar nombre en el ComboBox visible
                cmbVisible.ValueMember = "id"; // Guardar ID internamente en el ComboBox oculto

                // Ocultar el ComboBox de IDs (si es necesario)
                cmbHidden.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los grupos: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        public void mostrarHorarios(DataGridView tablaHorarios)
        {
            try
            {
                string query = @"
    SELECT
    h.id,
    h.id_asignatura,
    h.id_profesor,
    h.id_aula,
    h.id_grupo,
    h.id_dia_semana,
    m.nombre AS Materia,
    CONCAT(p.nombre, ' ', p.apellido) AS Profesor,
    a.nombre AS Aula,
    g.nombre AS Grupo,
    d.nombre AS Dia,
    DATE_FORMAT(h.hora_entrada, '%H:%i') AS Hora_Entrada,
    DATE_FORMAT(h.hora_salida, '%H:%i') AS Hora_Salida
FROM
    horario h
JOIN
    materias m ON h.id_asignatura = m.id
JOIN
    profesores p ON h.id_profesor = p.id
JOIN
    aulas a ON h.id_aula = a.id
JOIN
    grupos g ON h.id_grupo = g.id
JOIN
    dia_semana d ON h.id_dia_semana = d.id; ";

                Cconexion objConex = new Cconexion();
                tablaHorarios.DataSource = null;

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConex.establecerConexion()))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tablaHorarios.DataSource = dt;
                }

                // Encabezados amigables para el usuario
                tablaHorarios.Columns["Materia"].HeaderText = "Materia";
                tablaHorarios.Columns["Profesor"].HeaderText = "Profesor";
                tablaHorarios.Columns["Aula"].HeaderText = "Aula";
                tablaHorarios.Columns["Grupo"].HeaderText = "Grupo";
                tablaHorarios.Columns["Dia"].HeaderText = "Día";
                tablaHorarios.Columns["Hora_Entrada"].HeaderText = "Hora Entrada";
                tablaHorarios.Columns["Hora_Salida"].HeaderText = "Hora Salida";

                // Ocultar columnas no necesarias
                tablaHorarios.Columns["id_asignatura"].Visible = false; // Ocultar columna ID Asignatura
                tablaHorarios.Columns["id_profesor"].Visible = false;   // Ocultar columna ID Profesor
                tablaHorarios.Columns["id_aula"].Visible = false;       // Ocultar columna ID Aula
                tablaHorarios.Columns["id_grupo"].Visible = false;      // Ocultar columna ID Grupo
                tablaHorarios.Columns["id_dia_semana"].Visible = false;

                objConex.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los horarios correctamente: " + ex.ToString());
            }
        }

        public void eliminarHorario(int usuarioID, TextBox id)
        {
            Cconexion objConex = new Cconexion();
            try
            {
                string query = "DELETE FROM horario WHERE id = @id"; // Usar un parámetro en lugar de concatenar

                using (MySqlCommand cmd = new MySqlCommand(query, objConex.establecerConexion()))
                {
                    // Asignar el valor del parámetro
                    cmd.Parameters.AddWithValue("@id", id.Text);

                    // Ejecutar la consulta
                    int rowsAffected = cmd.ExecuteNonQuery(); // Cambiar a ExecuteNonQuery para DELETE

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Se eliminó correctamente el horario.");

                        // Registrar el movimiento de eliminación
                        regis.RegistrarMovimiento(usuarioID, $"Eliminó horario con ID: {id.Text}");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un horario con ese ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los horarios correctamente: " + ex.Message);
            }
            finally
            {
                objConex.cerrarConexion(); // Asegúrate de cerrar la conexión en el bloque finally
            }
        }
    }
}
