using MySql.Data.MySqlClient;
using pruebaaa.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pruebaaa.Clases.Chorarios;
using static pruebaaa.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaaa
{
    public partial class Horarios : Form
    {
        private Chorarios datos;
        Cregistromovimientos regis = new Cregistromovimientos();
        public Horarios()
        {
            datos = new Chorarios();
            InitializeComponent();
            datos.mostrarHorarios(dgvHorarios);
            cmbMaterias.SelectedIndexChanged += cmbMaterias_SelectedIndexChanged;
            cmbProfesor.SelectedIndexChanged += cmbProfesor_SelectedIndexChanged;
            cmbAulas.SelectedIndexChanged += cmbAulas_SelectedIndexChanged;
            cmbGrupo.SelectedIndexChanged += cmbGrupo_SelectedIndexChanged;
            cmbDia.SelectedIndexChanged += cmbDia_SelectedIndexChanged;
            cmbHoraE.SelectedIndexChanged += cmbHoraE_SelectedIndexChanged;
            cmbHoraS.SelectedIndexChanged += cmbHoraS_SelectedIndexChanged;
            LlenarComboboxes();
            datos.LlenarComboBoxHoras(cmbHoraE);
            datos.LlenarComboBoxHoras(cmbHoraS);
            //datos.LlenarComboBoxesHoras(cmbHoraE, cmbHoraEID);
            //datos.LlenarComboBoxesHoras(cmbHoraS, cmbHoraSID);
        }
        private void Horarios_Load(object sender, EventArgs e)
        {
            
        }
        
        public void LlenarComboboxes()
        {
            datos.LlenarComboBoxesProfesores(cmbProfesor, cmbProfesorId);
            datos.LlenarComboBoxesMaterias(cmbMaterias, cmbMateriasId);
            datos.LlenarComboBoxesAulas(cmbAulas, cmbAulasId);
            datos.LlenarComboBoxesGrupos(cmbGrupo, cmbGrupoId);
            datos.LlenarComboBoxesDias(cmbDia, cmbDiaId);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles
            int idAsignatura = (cmbMateriasId.SelectedItem != null) ? (int)cmbMateriasId.SelectedItem : 0;
            int idProfesor = (cmbProfesorId.SelectedItem != null) ? (int)cmbProfesorId.SelectedItem : 0;
            int idAula = (cmbAulasId.SelectedItem != null) ? (int)cmbAulasId.SelectedItem : 0;
            int idGrupo = (cmbGrupoId.SelectedItem != null) ? (int)cmbGrupoId.SelectedItem : 0;
            int idDiaSemana = (cmbDiaId.SelectedItem != null) ? (int)cmbDiaId.SelectedItem : 0;

            int usuarioId = ((SEA)this.Owner).UsuarioId;

            // Obtener las horas seleccionadas
            string horaEntradaSeleccionada = cmbHoraE.SelectedItem?.ToString();
            string horaSalidaSeleccionada = cmbHoraS.SelectedItem?.ToString();

            // Validar que todos los campos requeridos estén completos
            if (idAsignatura == 0 || idProfesor == 0 || idAula == 0 || idGrupo == 0 || idDiaSemana == 0 ||
                string.IsNullOrEmpty(horaEntradaSeleccionada) || string.IsNullOrEmpty(horaSalidaSeleccionada))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Construir la consulta SQL para agregar un nuevo horario
            string query = "INSERT INTO horario (id_asignatura, id_profesor, id_aula, id_grupo, id_dia_semana, hora_entrada, hora_salida) " +
                           "VALUES (@idAsignatura, @idProfesor, @idAula, @idGrupo, @idDiaSemana, @idHoraInicio, @idHoraFin)";

            MySqlConnection conex = null;

            try
            {
                conex = new Cconexion().establecerConexion();
                using (MySqlCommand cmd = new MySqlCommand(query, conex))
                {
                    // Asignar valores a los parámetros
                    cmd.Parameters.AddWithValue("@idAsignatura", idAsignatura);
                    cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
                    cmd.Parameters.AddWithValue("@idAula", idAula);
                    cmd.Parameters.AddWithValue("@idGrupo", idGrupo);
                    cmd.Parameters.AddWithValue("@idDiaSemana", idDiaSemana);


                    // Convertir las horas seleccionadas a TimeSpan
                    TimeSpan horaInicio = TimeSpan.Parse(horaEntradaSeleccionada);
                    TimeSpan horaFin = TimeSpan.Parse(horaSalidaSeleccionada);

                    // Asignar las horas a los parámetros
                    cmd.Parameters.AddWithValue("@idHoraInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@idHoraFin", horaFin);

                    // Ejecutar la consulta
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Horario agregado correctamente.");
                regis.RegistrarMovimiento(usuarioId, $"Agregó un horario para la asignatura ID: {idAsignatura}, profesor ID: {idProfesor}, aula ID: {idAula}, grupo ID: {idGrupo}, día ID: {idDiaSemana}, desde {horaEntradaSeleccionada} hasta {horaSalidaSeleccionada}");
                // Opcional: Actualizar el DataGridView o limpiar los campos
                datos.mostrarHorarios(dgvHorarios); // Método para volver a llenar el DataGridView
                LimpiarCampos(); // Método para limpiar los campos del formulario
                LlenarComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el horario: {ex.Message}");
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            cmbMaterias.SelectedIndex = -1;
            cmbMateriasId.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;
            cmbProfesorId.SelectedIndex = -1;
            cmbAulas.SelectedIndex = -1;
            cmbAulasId.SelectedIndex = -1;
            cmbGrupo.SelectedIndex = -1;
            cmbGrupoId.SelectedIndex = -1;
            cmbDia.SelectedIndex = -1;
            cmbDiaId.SelectedIndex = -1;
            cmbHoraE.SelectedIndex = -1;
            cmbHoraS.SelectedIndex = -1;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void dgvHorarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que la fila seleccionada sea válida
            {
                // Obtener los datos de la fila seleccionada
                int idHorario = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id"].Value); // Asegúrate de que la columna "id" esté presente
                int idAsignatura = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id_asignatura"].Value);
                string nombreMateria = dgvHorarios.Rows[e.RowIndex].Cells["Materia"].Value.ToString();
                // Obtener los IDs adicionales
                int idProfesor = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id_profesor"].Value);
                string nombreProfesor = dgvHorarios.Rows[e.RowIndex].Cells["Profesor"].Value.ToString();// Suponiendo que tienes esta columna
                int idAula = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id_aula"].Value);
                string nombreAula = dgvHorarios.Rows[e.RowIndex].Cells["Aula"].Value.ToString();// Suponiendo que tienes esta columna
                int idGrupo = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id_grupo"].Value);
                string nombreGrupo = dgvHorarios.Rows[e.RowIndex].Cells["Grupo"].Value.ToString();// Suponiendo que tienes esta columna
                int idDiaSemana = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["id_dia_semana"].Value);
                string nombreSemana = dgvHorarios.Rows[e.RowIndex].Cells["Dia"].Value.ToString();// Suponiendo que tienes esta columna
                string horaEntrada = dgvHorarios.Rows[e.RowIndex].Cells["Hora_Entrada"].Value.ToString(); // Asegúrate de que la columna "Hora_Entrada" esté presente
                string horaSalida = dgvHorarios.Rows[e.RowIndex].Cells["Hora_Salida"].Value.ToString(); // Asegúrate de que la columna "Hora_Salida" esté presente


                // Actualizar el TextBox con el ID del horario
                txtId.Text = idHorario.ToString(); // Almacenar el ID del horario en el TextBox

                // Actualizar el ComboBox visible con el nombre seleccionado
                foreach (Materia materia in cmbMaterias.Items)
                {
                    if (materia.Nombre == nombreMateria)
                    {
                        cmbMaterias.SelectedItem = materia; // Seleccionar el objeto Materia en el ComboBox visible
                        break;
                    }
                }

                // Actualizar el ComboBox oculto con la ID correspondiente
                cmbMateriasId.SelectedItem = idAsignatura; // Esto almacenará la ID correspondiente en el ComboBox oculto

                // Actualizar el ComboBox de Aulas
                foreach (Profesor profesor in cmbProfesor.Items)
                {
                    if (profesor.NombreCompleto == nombreProfesor)
                    {
                        cmbProfesor.SelectedItem = profesor; // Seleccionar el objeto Aula en el ComboBox visible
                        break;
                    }
                }

                // Actualizar el ComboBox oculto de Aulas
                cmbProfesorId.SelectedItem = idProfesor; // Esto almacenará la ID correspondiente en el ComboBox oculto

                // Actualizar el ComboBox de Aulas
                foreach (Aulas aulas in cmbAulas.Items)
                {
                    if (aulas.nombre == nombreAula)
                    {
                        cmbAulas.SelectedItem = aulas; // Seleccionar el objeto Aula en el ComboBox visible
                        break;
                    }
                }

                // Actualizar el ComboBox oculto de Aulas
                cmbAulasId.SelectedItem = idAula; // Esto almacenará la ID correspondiente en el ComboBox oculto

                foreach (Grupos grupo in cmbGrupo.Items)
                {
                    if (grupo.NombreCompleto == nombreGrupo)
                    {
                        cmbGrupo.SelectedItem = grupo; // Seleccionar el objeto Grupo en el ComboBox visible
                        break;
                    }
                }

                // Actualizar el ComboBox oculto de Grupos
                cmbGrupoId.SelectedItem = idGrupo; // Esto almacenará la ID correspondiente en el ComboBox oculto

                // Actualizar el ComboBox de Aulas
                foreach (Dias dia in cmbDia.Items)
                {
                    if (dia.NombreCompleto == nombreSemana)
                    {
                        cmbDia.SelectedItem = dia; // Seleccionar el objeto Aula en el ComboBox visible
                        break;
                    }
                }

                // Actualizar el ComboBox oculto de Aulas
                cmbDiaId.SelectedItem = idDiaSemana; // Esto almacenará la ID correspondiente en el ComboBox oculto

                cmbHoraE.SelectedItem = horaEntrada; // Asigna la hora de entrada al ComboBox correspondiente
                cmbHoraS.SelectedItem = horaSalida;   // Asigna la hora de salida al ComboBox correspondiente

               
            }
        }



        private void btnMod_Click(object sender, EventArgs e)
        {
            // Obtener el ID del horario que se va a modificar
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int idHorario))
            {
                MessageBox.Show("Por favor, seleccione un horario válido para modificar.");
                return;
            }

            // Obtener los valores de los controles
            int idAsignatura = (cmbMateriasId.SelectedItem != null) ? (int)cmbMateriasId.SelectedItem : 0;
            int idProfesor = (cmbProfesorId.SelectedItem != null) ? (int)cmbProfesorId.SelectedItem : 0;
            int idAula = (cmbAulasId.SelectedItem != null) ? (int)cmbAulasId.SelectedItem : 0;
            int idGrupo = (cmbGrupoId.SelectedItem != null) ? (int)cmbGrupoId.SelectedItem : 0;
            int idDiaSemana = (cmbDiaId.SelectedItem != null) ? (int)cmbDiaId.SelectedItem : 0;
            string horaEntradaSeleccionada = cmbHoraE.SelectedItem?.ToString();
            string horaSalidaSeleccionada = cmbHoraS.SelectedItem?.ToString();
            int usuarioId = ((SEA)this.Owner).UsuarioId;

            // Validar que todos los campos requeridos estén completos
            if (idAsignatura == 0 ||
                idProfesor == 0 ||
                idAula == 0 ||
                idGrupo == 0 ||
                idDiaSemana == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Construir la consulta SQL para modificar el horario
            string query = "UPDATE horario SET id_asignatura = @idAsignatura, id_profesor = @idProfesor, " +
                           "id_aula = @idAula, id_grupo = @idGrupo, id_dia_semana = @idDiaSemana, " +
                           "hora_entrada = @HoraInicio, hora_salida = @HoraFin WHERE id = @idHorario";

            using (MySqlConnection conex = new Cconexion().establecerConexion())
            {
                try
                {
                    // Verificar si la conexión está cerrada antes de abrirla
                    if (conex.State != ConnectionState.Open)
                    {
                        conex.Open();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conex))
                    {
                        // Asignar valores a los parámetros
                        cmd.Parameters.AddWithValue("@idHorario", idHorario);
                        cmd.Parameters.AddWithValue("@idAsignatura", idAsignatura);
                        cmd.Parameters.AddWithValue("@idProfesor", idProfesor);
                        cmd.Parameters.AddWithValue("@idAula", idAula);
                        cmd.Parameters.AddWithValue("@idGrupo", idGrupo);
                        cmd.Parameters.AddWithValue("@idDiaSemana", idDiaSemana);
                        cmd.Parameters.AddWithValue("@HoraInicio", horaEntradaSeleccionada);
                        cmd.Parameters.AddWithValue("@HoraFin", horaSalidaSeleccionada);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Horario modificado correctamente.");
                    regis.RegistrarMovimiento(usuarioId, $"Modificó un horario para la asignatura ID: {idAsignatura}, profesor ID: {idProfesor}, aula ID: {idAula}, grupo ID: {idGrupo}, día ID: {idDiaSemana}, desde {horaEntradaSeleccionada} hasta {horaSalidaSeleccionada}");
                    datos.mostrarHorarios(dgvHorarios);// Opcional: Actualizar el DataGridView o limpiar los campos
                    LimpiarCampos(); // Método para limpiar los campos del formulario
                    LlenarComboboxes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el horario: {ex.Message}");
                }
                finally
                {
                    if (conex.State == ConnectionState.Open)
                    {
                        conex.Close(); // Cerrar la conexión si está abierta
                    }
                }
            }
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterias.SelectedItem != null)
            {
                Materia selectedMateria = (Materia)cmbMaterias.SelectedItem;

                // Almacenar la ID correspondiente en el ComboBox oculto
                int selectedID = selectedMateria.ID;

                // Actualizar el ComboBox oculto con la ID seleccionada
                cmbMateriasId.SelectedItem = selectedID;

                // Mostrar la ID para verificar (opcional)
                //MessageBox.Show($"ID seleccionada: {selectedID}");
            }
        }

        private void cmbProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que hay un elemento seleccionado
            if (cmbProfesor.SelectedItem != null)
            {
                // Obtener el objeto Profesor seleccionado
                Profesor selectedProfesor = (Profesor)cmbProfesor.SelectedItem;

                // Actualizar el ComboBox oculto con la ID correspondiente
                cmbProfesorId.SelectedItem = selectedProfesor.id; // Esto almacenará la ID correspondiente en el ComboBox oculto
            }
        }

        private void cmbAulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que hay un elemento seleccionado
            if (cmbAulas.SelectedItem != null)
            {
                // Obtener el objeto Aulas seleccionado
                Aulas selectedAula = (Aulas)cmbAulas.SelectedItem;

                // Actualizar el ComboBox oculto con la ID correspondiente
                cmbAulasId.SelectedItem = selectedAula.id; // Esto almacenará la ID correspondiente en el ComboBox oculto
            }
        }
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que hay un elemento seleccionado
            if (cmbGrupo.SelectedItem != null)
            {
                // Obtener el objeto Grupos seleccionado
                Grupos selectedGrupo = cmbGrupo.SelectedItem as Grupos; // Usar 'as' para evitar excepciones

                // Asegurarse de que selectedGrupo no sea null
                if (selectedGrupo != null)
                {
                    // Actualizar el ComboBox oculto con la ID correspondiente
                    cmbGrupoId.SelectedItem = selectedGrupo.id; // Esto almacenará la ID correspondiente en el ComboBox oculto


                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del grupo seleccionado.");
                }
            }
            else
            {
                // Manejo del caso donde no hay selección
                //MessageBox.Show("Por favor, seleccione un grupo."); // Mensaje al usuario
            }
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbDia.SelectedItem != null)
            {

                Dias selectedDia = cmbDia.SelectedItem as Dias; // Usar 'as' para evitar excepciones


                if (selectedDia != null)
                {
                    // Actualizar el ComboBox oculto con la ID correspondiente
                    cmbDiaId.SelectedItem = selectedDia.id; // Esto almacenará la ID correspondiente en el ComboBox oculto


                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del dia seleccionado.");
                }
            }
            else
            {
                // Manejo del caso donde no hay selección
                //MessageBox.Show("Por favor, seleccione un dia."); // Mensaje al usuario
            }
        }

        private void cmbHoraE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbHoraS_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Verificar si se ha ingresado un ID válido
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID válido para eliminar.");
                return;
            }

            // Mensaje de verificación
            var result = MessageBox.Show("¿Está seguro de que desea eliminar este horario?", "Confirmar eliminación",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            if (result == DialogResult.Yes)
            {
                
                // Llamar al método para eliminar el horario
                datos.eliminarHorario(usuarioId, txtId); // Asegúrate de pasar el ID del usuario también
                datos.mostrarHorarios(dgvHorarios);
                LimpiarCampos();
                LlenarComboboxes();
            }
        }
    }
}
