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
            int idAsignatura = (cmbMateriasId.SelectedItem != null) ? (int)cmbMateriasId.SelectedItem : 0;
            int idProfesor = (cmbProfesorId.SelectedItem != null) ? (int)cmbProfesorId.SelectedItem : 0;
            int idAula = (cmbAulasId.SelectedItem != null) ? (int)cmbAulasId.SelectedItem : 0;
            int idGrupo = (cmbGrupoId.SelectedItem != null) ? (int)cmbGrupoId.SelectedItem : 0;
            int idDiaSemana = (cmbDiaId.SelectedItem != null) ? (int)cmbDiaId.SelectedItem : 0;
            int usuarioId = ((SEA)this.Owner).UsuarioId;

            string horaEntradaSeleccionada = cmbHoraE.SelectedItem?.ToString();
            string horaSalidaSeleccionada = cmbHoraS.SelectedItem?.ToString();

            if (idAsignatura == 0 || idProfesor == 0 || idAula == 0 || idGrupo == 0 || idDiaSemana == 0 ||
       string.IsNullOrEmpty(horaEntradaSeleccionada) || string.IsNullOrEmpty(horaSalidaSeleccionada))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            string nombreAsignatura = datos.ObtenerNombreAsignatura(idAsignatura);
            string nombreProfesor = datos.ObtenerNombreProfesor(idProfesor);
            string nombreAula = datos.ObtenerNombreAula(idAula);
            string nombreGrupo = datos.ObtenerNombreGrupo(idGrupo);
            string nombreDia = datos.ObtenerNombreDia(idDiaSemana);

            string mensaje = $"Agregó un horario para la asignatura {nombreAsignatura} (ID: {idAsignatura}), " +
                    $"profesor {nombreProfesor} (ID: {idProfesor}), aula {nombreAula} (ID: {idAula}), " +
                    $"grupo {nombreGrupo} (ID: {idGrupo}), día {nombreDia} (ID: {idDiaSemana}), " +
                    $"desde {horaEntradaSeleccionada} hasta {horaSalidaSeleccionada}";

            bool exito = datos.AgregarHorario(idAsignatura, idProfesor, idAula, idGrupo, idDiaSemana, horaEntradaSeleccionada, horaSalidaSeleccionada);
            
            if (exito)
            {
                MessageBox.Show("Horario agregado correctamente.");
                regis.RegistrarMovimiento(usuarioId, mensaje);
                // Opcional: Actualizar el DataGridView o limpiar los campos
                datos.mostrarHorarios(dgvHorarios); // Método para volver a llenar el DataGridView
                LimpiarCampos(); // Método para limpiar los campos del formulario
                LlenarComboboxes();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el horario.");
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
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int idHorario))
            {
                MessageBox.Show("Por favor, seleccione un horario válido para modificar.");
                return;
            }

            int idAsignatura = (cmbMateriasId.SelectedItem != null) ? (int)cmbMateriasId.SelectedItem : 0;
            int idProfesor = (cmbProfesorId.SelectedItem != null) ? (int)cmbProfesorId.SelectedItem : 0;
            int idAula = (cmbAulasId.SelectedItem != null) ? (int)cmbAulasId.SelectedItem : 0;
            int idGrupo = (cmbGrupoId.SelectedItem != null) ? (int)cmbGrupoId.SelectedItem : 0;
            int idDiaSemana = (cmbDiaId.SelectedItem != null) ? (int)cmbDiaId.SelectedItem : 0;
            string horaEntradaSeleccionada = cmbHoraE.SelectedItem?.ToString();
            string horaSalidaSeleccionada = cmbHoraS.SelectedItem?.ToString();
            int usuarioId = ((SEA)this.Owner).UsuarioId;

            if (idAsignatura == 0 || idProfesor == 0 || idAula == 0 || idGrupo == 0 || idDiaSemana == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            var horarioAnterior = datos.ObtenerHorarioPorId(idHorario);

            if (horarioAnterior == null)
            {
                MessageBox.Show("No se encontró el horario a modificar.");
                return;
            }

            // Obtener nombres antes de modificar
            string asignaturaAnterior = datos.ObtenerNombreAsignatura(horarioAnterior.IdAsignatura);
            string profesorAnterior = datos.ObtenerNombreProfesor(horarioAnterior.IdProfesor);
            string aulaAnterior = datos.ObtenerNombreAula(horarioAnterior.IdAula);
            string grupoAnterior = datos.ObtenerNombreGrupo(horarioAnterior.IdGrupo);
            string diaAnterior = datos.ObtenerNombreDia(horarioAnterior.IdDiaSemana);

            // Obtener nombres nuevos
            string asignaturaNueva = datos.ObtenerNombreAsignatura(idAsignatura);
            string profesorNuevo = datos.ObtenerNombreProfesor(idProfesor);
            string aulaNueva = datos.ObtenerNombreAula(idAula);
            string grupoNuevo = datos.ObtenerNombreGrupo(idGrupo);
            string diaNuevo = datos.ObtenerNombreDia(idDiaSemana);

            string mensaje = $"Modificó el horario con ID: {idHorario}\n" +
                $"**Antes:** {asignaturaAnterior} (ID: {horarioAnterior.IdAsignatura}), " +
                $"{profesorAnterior} (ID: {horarioAnterior.IdProfesor}), " +
                $"{aulaAnterior} (ID: {horarioAnterior.IdAula}), " +
                $"{grupoAnterior} (ID: {horarioAnterior.IdGrupo}), " +
                $"{diaAnterior} (ID: {horarioAnterior.IdDiaSemana}), " +
                $"de {horarioAnterior.HoraEntrada} a {horarioAnterior.HoraSalida}\n" +
                $"**Después:** {asignaturaNueva} (ID: {idAsignatura}), " +
                $"{profesorNuevo} (ID: {idProfesor}), " +
                $"{aulaNueva} (ID: {idAula}), " +
                $"{grupoNuevo} (ID: {idGrupo}), " +
                $"{diaNuevo} (ID: {idDiaSemana}), " +
                $"de {horaEntradaSeleccionada} a {horaSalidaSeleccionada}";

            bool resultado = datos.ModificarHorario(idHorario, idAsignatura, idProfesor, idAula, idGrupo, idDiaSemana, horaEntradaSeleccionada, horaSalidaSeleccionada);
            if (resultado)
            {
                MessageBox.Show("Horario modificado correctamente.");
                regis.RegistrarMovimiento(usuarioId, mensaje);
                datos.mostrarHorarios(dgvHorarios);
                LimpiarCampos();
                LlenarComboboxes();
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
