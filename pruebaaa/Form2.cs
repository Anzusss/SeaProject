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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pruebaaa
{
    public partial class formMaterias : Form
    {
        private Cmaterias datos;
        public formMaterias()
        {
            InitializeComponent();
            datos = new Cmaterias();
            InicializarFormulario();
        }
        private void InicializarFormulario()
        {
            CargarCategorias();
        }
        private void CargarCategorias()
        {
            var categorias = datos.ObtenerCategorias();
            cmbCategorias.DataSource = categorias;
            cmbCategorias.DisplayMember = "nombre";
            cmbCategorias.ValueMember = "id";
        }

        private void formMaterias_Load(object sender, EventArgs e)
        {
            ActualizarComboBoxMaterias();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterias.SelectedItem != null)
            {
                string seleccion = cmbMaterias.SelectedItem.ToString();
                string nombre = seleccion.Split('-')[0].Trim();

                Cmaterias datos = new Cmaterias();
                Dictionary<string, string> datosMateria = datos.ObtenerDatosMateria(nombre);

                if (datosMateria.Count > 0)
                {
                    txtId.Text = datosMateria["id"];
                    cmbCategorias.SelectedValue = datosMateria["id_categoria"].ToString();
                    txtNombre.Text = datosMateria["nombre"];
                    txtDesc.Text = datosMateria["descripcion"];
                    lblMatricula.Text = datosMateria["matricula"];
                }
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(cmbCategorias.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios (Nombre, categoria).");
                    return;
                }

                // Obtener los valores con trim para eliminar espacios innecesarios
                string nombre = txtNombre.Text.Trim();
                string categoria = cmbCategorias.SelectedValue.ToString(); // Obtiene el ID de la categoría
                string descripcion = txtDesc.Text.Trim();
                int usuarioId = ((SEA)this.Owner).UsuarioId;

                Cmaterias datos = new Cmaterias();
                bool resultado = datos.AgregarMateria(
                    usuarioId,nombre, descripcion, categoria);

                if (resultado)
                {
                    LimpiarCampos();
                    ActualizarComboBoxMaterias(); // Actualiza el ComboBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el botón guardar: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private void LimpiarCampos()
        {
            cmbCategorias.Select();
            txtNombre.Clear();
            txtDesc.Clear();
            lblMatricula.Text = "";
        }

        private void ActualizarComboBoxMaterias()
        {
            Cmaterias datos = new Cmaterias();
            List<string> materias = datos.ObtenerMaterias();
            cmbMaterias.DataSource = null; // Limpia el ComboBox
            cmbMaterias.DataSource = materias;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbCategorias.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios (Categoria y Nombre).");
                    return;
                }

                // Obtener el ID del estudiante seleccionado
                if (cmbMaterias.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione una materia para modificar.");
                    return;
                }

                // Asumiendo que tienes un campo oculto con el ID o lo obtienes del estudiante seleccionado
                int id = Convert.ToInt32(txtId.Text); // Asegúrate de tener este campo en tu formulario


                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea modificar esta materia?",
                    "Confirmar Modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string nombre = txtNombre.Text.Trim();
                    string categoria = cmbCategorias.SelectedValue.ToString(); // Obtiene el ID de la categoría
                    string descripcion = txtDesc.Text.Trim();
                    int usuarioId = ((SEA)this.Owner).UsuarioId;

                    Cmaterias datos = new Cmaterias();
                    bool modificacionExitosa = datos.ModificarMateria(
                        usuarioId,id, nombre, descripcion, categoria);

                    if (modificacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxMaterias();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar estudiante: {ex.Message}");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay un estudiante seleccionado
                if (cmbMaterias.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione una materia para eliminar.");
                    return;
                }

                // Verificar que el ID sea válido
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("No se ha podido obtener el ID de la materia.");
                    return;
                }

                // Intentar convertir el ID
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID de la materia no es válido.");
                    return;
                }

                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta materia?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                int usuarioId = ((SEA)this.Owner).UsuarioId;

                if (resultado == DialogResult.Yes)
                {
                    Cmaterias datos = new Cmaterias();
                    bool eliminacionExitosa = datos.EliminarMateria(usuarioId,id);

                    if (eliminacionExitosa)
                    {
                        // Actualizar el ComboBox y limpiar campos
                        ActualizarComboBoxMaterias();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar estudiante: {ex.Message}");
            }
        }

        private void cmbProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}


