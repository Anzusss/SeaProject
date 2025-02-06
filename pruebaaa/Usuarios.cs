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
    public partial class Usuarios : Form
    {
        Clogin login = new Clogin();
        public Usuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbRol.SelectedIndex = -1;
            txtTlf.Clear();
            txtEmail.Clear();
        }

        private void CargarUsuarios()
        {
            login = new Clogin();
            List<string> usuarios = login.ObtenerUsuarios();
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DataSource = usuarios;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay un estudiante seleccionado
                if (cmbUsuarios.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                    return;
                }

                // Verificar que el ID sea válido
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("No se ha podido obtener el ID del usuario.");
                    return;
                }

                // Intentar convertir el ID
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID del usuario no es válido.");
                    return;
                }

                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar este usuario?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Clogin login = new Clogin();
                    bool eliminacionExitosa = login.EliminarCuenta(id);

                    if (eliminacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar estudiante: {ex.Message}");
            }
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem != null)
            {
                string seleccion = cmbUsuarios.SelectedItem.ToString();
                string cedula = seleccion.Split('-')[0].Trim();

                Clogin datos = new Clogin();
                Dictionary<string, string> datosUsuario = datos.ObtenerDatosUsuario(cedula);

                if (datosUsuario.Count > 0)
                {
                    txtId.Text = datosUsuario["UserID"];
                    txtCedula.Text = datosUsuario["Cedula"];
                    txtNombre.Text = datosUsuario["FirstName"];
                    txtApellido.Text = datosUsuario["LastName"];
                    cmbRol.Text = datosUsuario["Position"];
                    txtTlf.Text = datosUsuario["Telefono"];
                    txtEmail.Text = datosUsuario["Email"];

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del estudiante seleccionado
                if (cmbUsuarios.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario para modificar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Por favor, ingrese un ID de usuario válido.");
                    return;
                }

                int id;
                if (!int.TryParse(txtId.Text, out id))
                {
                    MessageBox.Show("El ID ingresado no es válido.");
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea modificar el rol de este usuario?",
                    "Confirmar Modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string rol = cmbRol.SelectedItem?.ToString().Trim() ?? "";

                    // Validar que se haya seleccionado un rol
                    if (string.IsNullOrEmpty(rol))
                    {
                        MessageBox.Show("Por favor, seleccione un rol para modificar.");
                        return;
                    }


                    Clogin datos = new Clogin();
                    bool modificacionExitosa = datos.ModificarRol(
                        id, rol);

                    if (modificacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar rol: {ex.Message}");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cuentaactu regis = new Cuentaactu();
            regis.Show();
        }
    }
}
