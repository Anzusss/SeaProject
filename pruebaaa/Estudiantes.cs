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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pruebaaa
{
    public partial class Estudiantes : Form
    {
        private Cdatos datos;

        public Estudiantes()
        {
            InitializeComponent();
            datos = new Cdatos();
            CargarSexoEnComboBox();
        }
        private void Estudiantes_Load(object sender, EventArgs e)
        {

            ActualizarComboBoxEstudiantes();

            CargarSexoEnComboBox();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedItem != null)
            {
                string seleccion = cmbEstudiantes.SelectedItem.ToString();
                string cedula = seleccion.Split('-')[0].Trim();

                Cdatos datos = new Cdatos();
                Dictionary<string, string> datosEstudiante = datos.ObtenerDatosEstudiante(cedula);

                if (datosEstudiante.Count > 0)
                {
                    txtId.Text = datosEstudiante["id"];
                    txtCedula.Text = datosEstudiante["cedula"];
                    txtNombre.Text = datosEstudiante["nombre"];
                    txtApellido.Text = datosEstudiante["apellido"];
                    cmbSexo.Text = datosEstudiante["sexo"];
                    txtTlf.Text = datosEstudiante["telefono"];
                    txtEmail.Text = datosEstudiante["email"];
                    lblMatricula.Text = datosEstudiante["matricula"];
                }
            }
        }


        private void CargarSexoEnComboBox()
        {
            Cdatos datos = new Cdatos();
            List<string> valoresSexo = datos.obtenerValoresSexo();

            cmbSexo.Items.Clear();
            cmbSexo.Items.AddRange(valoresSexo.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                string sexo = cmbSexo.SelectedItem?.ToString().Trim() ?? "";
                string telefono = txtTlf.Text.Trim();
                string email = txtEmail.Text.Trim();

                int usuarioId = ((SEA)this.Owner).UsuarioId;

                Cdatos datos = new Cdatos();
                bool resultado = datos.AgregarEstudiante(
                    usuarioId, cedula, nombre, apellido, sexo,
                    telefono, email);

                if (resultado)
                {
                    LimpiarCampos();
                    ActualizarComboBoxEstudiantes(); // Actualiza el ComboBox
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
            lblMatricula.Text = "";
        }

        private void ActualizarComboBoxEstudiantes()
        {
            Cdatos datos = new Cdatos();
            List<string> estudiantes = datos.ObtenerEstudiantes();
            cmbEstudiantes.DataSource = null; // Limpia el ComboBox
            cmbEstudiantes.DataSource = estudiantes;
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

                // Obtener el ID del estudiante seleccionado
                if (cmbEstudiantes.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un estudiante para modificar.");
                    return;
                }

                // Asumiendo que tienes un campo oculto con el ID o lo obtienes del estudiante seleccionado
                int id = Convert.ToInt32(txtId.Text); // Asegúrate de tener este campo en tu formulario

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea modificar este estudiante?",
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

                    Cdatos datos = new Cdatos();
                    bool modificacionExitosa = datos.ModificarEstudiante(
                        usuarioId, id, cedula, nombre, apellido, sexo,
                        telefono, email);

                    if (modificacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxEstudiantes();
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
                if (cmbEstudiantes.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un estudiante para eliminar.");
                    return;
                }

                // Verificar que el ID sea válido
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("No se ha podido obtener el ID del estudiante.");
                    return;
                }

                // Intentar convertir el ID
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID del estudiante no es válido.");
                    return;
                }
                int usuarioId = ((SEA)this.Owner).UsuarioId;
                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar este estudiante?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Cdatos datos = new Cdatos();
                    bool eliminacionExitosa = datos.EliminarEstudiante(usuarioId,id);

                    if (eliminacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxEstudiantes();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar estudiante: {ex.Message}");
            }
        }

        private void cmbEstudiantes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

