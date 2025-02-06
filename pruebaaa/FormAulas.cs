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
    public partial class FormAulas : Form
    {
        public FormAulas()
        {
            InitializeComponent();
            Clases.Caulas objAulas = new Clases.Caulas();
            objAulas.mostrarAulas(dgvAulas);
            CargarDispEnComboBox();
        }
        private void CargarDispEnComboBox()
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            List<string> valoresDisp = objAulas.obtenerDisponible();

            cmbDisp.Items.Clear();
            cmbDisp.Items.AddRange(valoresDisp.ToArray());
        }

        private void txtCapacidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            objAulas.agregarAula(usuarioId,txtNombre, txtCapacidad);
            objAulas.mostrarAulas(dgvAulas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            objAulas.eliminarAula(usuarioId,txtId);
            objAulas.mostrarAulas(dgvAulas);
        }

        private void dgvAulas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            objAulas.seleccionarAula(dgvAulas, txtId, txtNombre, txtCapacidad, cmbDisp);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            objAulas.modificarAula(usuarioId,txtId, txtNombre, txtCapacidad, cmbDisp);
            objAulas.mostrarAulas(dgvAulas);
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            Clases.Caulas objAulas = new Clases.Caulas();
            int usuarioId = ((SEA)this.Owner).UsuarioId;
            objAulas.modificarAula(usuarioId,txtId, txtNombre, txtCapacidad, cmbDisp);
            objAulas.mostrarAulas(dgvAulas);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
