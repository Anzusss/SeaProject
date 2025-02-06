using MySql.Data.MySqlClient;
using pruebaaa.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaaa
{
    public partial class Inscripcion : Form
    {
        Cconexion conex = new Cconexion();

        public class Horario
        {
            public int IdHorario { get; set; }
            public string Descripcion { get; set; }

            public override string ToString()
            {
                return Descripcion; // Esto es opcional, pero puede ayudar en la depuración
            }
        }
        public Inscripcion()
        {
            InitializeComponent();
            LlenarComboBoxHorarios(cmbHorarios);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaEstudiante.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            // Llamar al método que busca y muestra los datos
            MostrarDatosPorCedula(cedula);
        }
        private void LlenarDataGridView(DataTable dt)
        {
            // Asignar el DataTable al DataGridView
            dgvResultados.DataSource = dt;

            // Renombrar las columnas del DataGridView

            dgvResultados.Columns["HoraEntrada"].HeaderText = "Hora Entrada";
            dgvResultados.Columns["HoraSalida"].HeaderText = "Hora Salida";

            // Opción: Ocultar columnas innecesarias si es necesario
            dgvResultados.Columns["id_inscripcion"].Visible = false; // Ocultar ID de inscripción
            dgvResultados.Columns["EstudianteId"].Visible = false;
            dgvResultados.Columns["NombreCompleto"].Visible = false;
        }

        private void MostrarDatosPorCedula(string cedula)
        {
            // Define tu cadena de conexión aquí
            string connectionString = "server=localhost;port=3306;user=root;password=;database=pruebaconn";

            try
            {
                // Consulta para obtener inscripciones y datos del estudiante
                string query = @"
            SELECT 
                i.id_inscripcion, 
                m.nombre AS Materia, 
                CONCAT(p.nombre, ' ', p.apellido) AS Profesor, 
                g.nombre AS Grupo, 
                d.nombre AS Dia, 
                h.hora_entrada AS HoraEntrada, 
                h.hora_salida AS HoraSalida,
                e.id AS EstudianteId,
                CONCAT(e.nombre, ' ', e.apellido) AS NombreCompleto  
            FROM 
                inscripcion i 
            INNER JOIN 
                horario h ON i.id_horario = h.id 
            INNER JOIN 
                profesores p ON h.id_profesor = p.id 
            INNER JOIN 
                materias m ON h.id_asignatura = m.id 
            INNER JOIN 
                dia_semana d ON h.id_dia_semana = d.id 
            INNER JOIN 
                grupos g ON h.id_grupo = g.id 
            INNER JOIN 
                estudiantes e ON i.id_estudiante = e.id 
            WHERE 
                e.cedula = @cedula 
            ORDER BY 
                h.hora_salida ASC";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Abre la conexión

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@cedula", cedula);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            // Si no se encontraron inscripciones, buscar solo el estudiante
                            string queryEstudiante = "SELECT id, nombre, apellido FROM estudiantes WHERE cedula = @cedula";
                            using (MySqlCommand cmdEstudiante = new MySqlCommand(queryEstudiante, connection))
                            {
                                cmdEstudiante.Parameters.AddWithValue("@cedula", cedula);
                                using (MySqlDataReader reader = cmdEstudiante.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Mostrar el nombre completo del estudiante
                                        string nombreCompletoEstudiante = $"{reader["nombre"]} {reader["apellido"]}";
                                        lblNombreEstudiante.Text = $"Estudiante: {nombreCompletoEstudiante}"; // Mostrar nombre completo
                                        txtEstudianteId.Text = reader["id"].ToString(); // Almacenar ID del estudiante en el TextBox

                                        MessageBox.Show("No se encontraron inscripciones para este estudiante. Puede agregar nuevas inscripciones.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se encontraron registros para la cédula ingresada. Por favor, verifique e intente nuevamente.");
                                        return; // Salir si no se encuentra el estudiante
                                    }
                                }
                            }
                            return; // Salir después de manejar la búsqueda del estudiante
                        }

                        // Si se encontraron inscripciones, llenar el DataGridView
                        LlenarDataGridView(dt);

                        // Mostrar el nombre completo del estudiante y su ID
                        string nombreCompletoEstudianteInscripcion = dt.Rows[0]["NombreCompleto"].ToString();
                        lblNombreEstudiante.Text = $"Estudiante: {nombreCompletoEstudianteInscripcion}"; // Mostrar nombre completo
                        txtEstudianteId.Text = dt.Rows[0]["EstudianteId"].ToString(); // Almacenar ID del estudiante
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }
        private List<Horario> originalHorarios = new List<Horario>();

        private void LlenarComboBoxHorarios(ComboBox comboBox)
        {
            // Define tu cadena de conexión aquí
            string connectionString = "server=localhost;port=3306;user=root;password=;database=pruebaconn";

            try
            {
                string query = @"SELECT h.id AS IdHorario, CONCAT(m.nombre, ' - ', p.nombre, ' ', p.apellido, ' - ', g.nombre, ' - ', d.nombre, ' - ', h.hora_entrada, ' - ', h.hora_salida) AS HorarioCompleto FROM horario h INNER JOIN materias m ON h.id_asignatura = m.id INNER JOIN profesores p ON h.id_profesor = p.id INNER JOIN grupos g ON h.id_grupo = g.id INNER JOIN dia_semana d ON h.id_dia_semana = d.id;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Abre la conexión

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear(); // Limpiar elementos existentes en el ComboBox
                            originalHorarios.Clear(); // Limpiar la lista original

                            while (reader.Read())
                            {
                                var horario = new Horario
                                {
                                    IdHorario = Convert.ToInt32(reader["IdHorario"]),
                                    Descripcion = reader["HorarioCompleto"].ToString()
                                };
                                comboBox.Items.Add(horario);
                                originalHorarios.Add(horario); // Agregar a la lista original
                            }
                        }
                    }
                }

                comboBox.DisplayMember = "Descripcion";
                comboBox.ValueMember = "IdHorario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message);
            }
        }
        private void AgregarInscripcion(int idHorario, int usuarioID)
        {
            string connectionString = "server=localhost;port=3306;user=root;password=;database=pruebaconn";

            try
            {
                // Obtener el ID del estudiante desde el TextBox
                int idEstudiante;
                if (!int.TryParse(txtEstudianteId.Text, out idEstudiante))
                {
                    MessageBox.Show("ID de estudiante no válido.");
                    return;
                }
                // Obtener el nombre completo del estudiante desde el Label
                string nombreCompletoEstudiante = lblNombreEstudiante.Text; // Asumiendo que lblNombreCompleto es tu Label
                if (string.IsNullOrEmpty(nombreCompletoEstudiante))
                {
                    MessageBox.Show("El nombre completo del estudiante no está disponible.");
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryInsertarInscripcion = @"
                INSERT INTO inscripcion (id_horario, id_estudiante) 
                VALUES (@idHorario, @idEstudiante);";

                    using (MySqlCommand cmdInsertarInscripcion = new MySqlCommand(queryInsertarInscripcion, connection))
                    {
                        cmdInsertarInscripcion.Parameters.AddWithValue("@idHorario", idHorario);
                        cmdInsertarInscripcion.Parameters.AddWithValue("@idEstudiante", idEstudiante);

                        cmdInsertarInscripcion.ExecuteNonQuery();
                    }
                }
                Cregistromovimientos regis = new Cregistromovimientos();
                regis.RegistrarMovimiento(usuarioID, $"Agregó inscripción para el {nombreCompletoEstudiante}");
                MessageBox.Show("El horario ha sido agregado al estudiante exitosamente.");
                ActualizarDataGridView();// Opcional: Actualizar ComboBox o DataGridView si es necesario
            }
            catch (MySqlException ex) when (ex.Number == 1644)
            {
                MessageBox.Show("Error al agregar la inscripción: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la inscripción: " + ex.Message);
            }
        }

        private void ActualizarDataGridView()
        {
            // Asumiendo que tienes una forma de obtener la cédula actual del estudiante
            string cedulaEstudiante = txtCedulaEstudiante.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedulaEstudiante))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida para actualizar los datos.");
                return;
            }

            MostrarDatosPorCedula(cedulaEstudiante); // Llama al método existente para mostrar datos
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener la cédula del estudiante desde el TextBox
            string cedulaEstudiante = txtCedulaEstudiante.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedulaEstudiante))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            // Obtener el horario seleccionado del ComboBox
            var horarioSeleccionado = cmbHorarios.SelectedItem;

            if (horarioSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un horario.");
                return;
            }

            // Obtener el id_horario del objeto seleccionado
            int idHorario = ((dynamic)horarioSeleccionado).IdHorario;
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            // Obtener el ID del estudiante desde el TextBox
            int idEstudiante;
            if (!int.TryParse(txtEstudianteId.Text, out idEstudiante))
            {
                MessageBox.Show("ID de estudiante no válido.");
                return;
            }

            // Llamar al método AgregarInscripcion con los parámetros necesarios
            AgregarInscripcion(idHorario, usuarioId);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que haya una ID válida en el TextBox
            if (string.IsNullOrWhiteSpace(txtInscripcionId.Text))
            {
                MessageBox.Show("Por favor, seleccione una inscripción para eliminar.");
                return;
            }

            // Confirmar la eliminación
            var result = MessageBox.Show("¿Está seguro de que desea eliminar esta inscripción?", "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return; // Cancelar la eliminación si el usuario selecciona No
            }
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            // Obtener la ID de inscripción del TextBox
            int idInscripcion = Convert.ToInt32(txtInscripcionId.Text);

            // Llamar al método para eliminar la inscripción
            EliminarInscripcion(idInscripcion, usuarioId);
        }

        private void dgvResultados_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Confirmar la eliminación
            var result = MessageBox.Show("¿Está seguro de que desea eliminar esta inscripción?", "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancelar la eliminación si el usuario selecciona No
                return;
            }
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            // Obtener el ID de inscripción de la fila que se está eliminando
            int idInscripcion = Convert.ToInt32(e.Row.Cells["id_inscripcion"].Value);

            // Llamar al método para eliminar la inscripción
            EliminarInscripcion(idInscripcion, usuarioId);
        }

        private void EliminarInscripcion(int idInscripcion, int usuarioID)
        {
            string connectionString = "server=localhost;port=3306;user=root;password=;database=pruebaconn";

            try
            {
                string nombreCompletoEstudiante = lblNombreEstudiante.Text; // Asumiendo que lblNombreCompleto es tu Label
                if (string.IsNullOrEmpty(nombreCompletoEstudiante))
                {
                    MessageBox.Show("El nombre completo del estudiante no está disponible.");
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryEliminarInscripcion = @"
                DELETE FROM inscripcion 
                WHERE id_inscripcion = @idInscripcion;";

                    using (MySqlCommand cmdEliminarInscripcion = new MySqlCommand(queryEliminarInscripcion, connection))
                    {
                        cmdEliminarInscripcion.Parameters.AddWithValue("@idInscripcion", idInscripcion);
                        cmdEliminarInscripcion.ExecuteNonQuery();
                    }
                }
                Cregistromovimientos regis = new Cregistromovimientos();
                regis.RegistrarMovimiento(usuarioID, $"Agregó inscripción para el estudiante: {nombreCompletoEstudiante}");
                MessageBox.Show("La inscripción ha sido eliminada exitosamente.");

                // Opcional: Actualizar el DataGridView después de eliminar
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la inscripción: " + ex.Message);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            // Verificar que haya una ID válida en el TextBox
            if (string.IsNullOrWhiteSpace(txtInscripcionId.Text))
            {
                MessageBox.Show("Por favor, seleccione una inscripción para eliminar.");
                return;
            }

            // Confirmar la eliminación
            var result = MessageBox.Show("¿Está seguro de que desea eliminar esta inscripción?", "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return; // Cancelar la eliminación si el usuario selecciona No
            }
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            // Obtener la ID de inscripción del TextBox
            int idInscripcion = Convert.ToInt32(txtInscripcionId.Text);

            // Llamar al método para eliminar la inscripción
            EliminarInscripcion(idInscripcion, usuarioId);
        }

        private void dgvResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se ha hecho clic en una fila válida
            if (e.RowIndex >= 0) // Asegurarse de que no se clicó en los encabezados
            {
                // Obtener el ID de inscripción de la fila seleccionada
                int idInscripcion = Convert.ToInt32(dgvResultados.Rows[e.RowIndex].Cells["id_inscripcion"].Value);

                // Mostrar el ID en el TextBox
                txtInscripcionId.Text = idInscripcion.ToString(); // Suponiendo que txtInscripcionId es tu TextBox para mostrar el ID
            }
        }

        private void cmbHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHorarios.SelectedItem is Horario selectedHorario)
            {
                int idHorario = selectedHorario.IdHorario;
                // Ahora puedes usar idHorario según sea necesario
                //MessageBox.Show($"ID del horario seleccionado: {idHorario}");
            }
        }
    }
}
