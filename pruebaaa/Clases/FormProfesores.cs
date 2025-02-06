using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaaa.Clases
{
    public partial class FormProfesores : Form
    {
        private Cprofesores datos;
        public FormProfesores()
        {
            InitializeComponent();
            datos = new Cprofesores();
            CargarSexoEnComboBox();
        }
        private void FormProfesores_Load(object sender, EventArgs e)
        {
            ActualizarComboBoxProfesores();
            CargarSexoEnComboBox();
        }
        private void cmbProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfesores.SelectedItem != null)
            {
                string seleccion = cmbProfesores.SelectedItem.ToString();
                string cedula = seleccion.Split('-')[0].Trim();

                Cprofesores datos = new Cprofesores();
                Dictionary<string, string> datosProfesor = datos.ObtenerDatosProfesor(cedula);

                if (datosProfesor.Count > 0)
                {
                    txtId.Text = datosProfesor["id"];
                    txtCedula.Text = datosProfesor["cedula"];
                    txtNombre.Text = datosProfesor["nombre"];
                    txtApellido.Text = datosProfesor["apellido"];
                    cmbSexo.Text = datosProfesor["sexo"];
                    txtTlf.Text = datosProfesor["telefono"];
                    txtEmail.Text = datosProfesor["email"];
                }
            }
        }
        private void CargarSexoEnComboBox()
        {
            Cprofesores datos = new Cprofesores();
            List<string> valoresSexo = datos.ObtenerValoresSexo();

            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(valoresSexo.ToArray());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios (Cédula, Nombre y Apellido).");
                    return;
                }

                // Obtener los valores con trim para eliminar espacios innecesarios
                string cedula = txtCedula.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string sexo = cmbSexo.SelectedItem.ToString().Trim();
                string telefono = txtTlf.Text.Trim();
                string email = txtEmail.Text.Trim();

                int usuarioId = ((SEA)this.Owner).UsuarioId;

                Cprofesores datos = new Cprofesores();
                bool resultado = datos.AgregarProfesor(
                    usuarioId, cedula, nombre, apellido, sexo,
                    telefono, email);

                if (resultado)
                {
                    LimpiarCampos();
                    ActualizarComboBoxProfesores(); // Actualiza el ComboBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el botón guardar: {ex.Message}\n{ex.StackTrace}");
            }
        }
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbSexo.SelectedIndex = -1;
            txtTlf.Clear();
            txtEmail.Clear();
        }
        private void ActualizarComboBoxProfesores()
        {
            Cprofesores datos = new Cprofesores();
            List<string> profesores = datos.ObtenerProfesores();
            cmbProfesores.DataSource = null; // Limpia el ComboBox
            cmbProfesores.DataSource = profesores;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios (Cédula, Nombre y Apellido).");
                    return;
                }

                // Obtener el ID del profesor seleccionado
                if (cmbProfesores.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un profesor para modificar.");
                    return;
                }

                // Asumiendo que tienes un campo oculto con el ID o lo obtienes del estudiante seleccionado
                int id = Convert.ToInt32(txtId.Text); // Asegúrate de tener este campo en tu formulario

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea modificar este profesor?",
                    "Confirmar Modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string cedula = txtCedula.Text.Trim();
                    string nombre = txtNombre.Text.Trim();
                    string apellido = txtApellido.Text.Trim();
                    string sexo = cmbSexo.SelectedItem?.ToString().Trim() ?? "";
                    string telefono = txtTlf.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    int usuarioId = ((SEA)this.Owner).UsuarioId;

                    Cprofesores datos = new Cprofesores();
                    bool modificacionExitosa = datos.ModificarProfesor(
                        usuarioId, id, cedula, nombre, apellido, sexo,
                        telefono, email);

                    if (modificacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxProfesores();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar estudiante: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay un estudiante seleccionado
                if (cmbProfesores.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un profesor para eliminar.");
                    return;
                }

                // Verificar que el ID sea válido
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("No se ha podido obtener el ID del profesor.");
                    return;
                }

                // Intentar convertir el ID
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID del profesor no es válido.");
                    return;
                }

                int usuarioId = ((SEA)this.Owner).UsuarioId;
                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar este profesor?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Cprofesores datos = new Cprofesores();
                    bool eliminacionExitosa = datos.EliminarProfesor(usuarioId,id);

                    if (eliminacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxProfesores();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar profesor: {ex.Message}");
            }
        }






    }
}
