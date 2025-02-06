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
    public partial class Cuentaactu : Form
    {
        Clogin login = new Clogin();
        public Cuentaactu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.SlateBlue;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DarkSlateBlue;
            }
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            if (txtnombre.Text == "NOMBRE")
            {
                txtnombre.Text = "";
                txtnombre.ForeColor = Color.SlateBlue;
            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                txtnombre.Text = "NOMBRE";
                txtnombre.ForeColor = Color.DarkSlateBlue;
            }
        }

        private void txtapellido_Enter(object sender, EventArgs e)
        {
            if (txtapellido.Text == "APELLIDO")
            {
                txtapellido.Text = "";
                txtapellido.ForeColor = Color.SlateBlue;
            }
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            if (txtapellido.Text == "")
            {
                txtapellido.Text = "APELLIDO";
                txtapellido.ForeColor = Color.DarkSlateBlue;
            }
        }

        private void txtcedula_Enter(object sender, EventArgs e)
        {
            if (txtcedula.Text == "CEDULA")
            {
                txtcedula.Text = "";
                txtcedula.ForeColor = Color.SlateBlue;
            }
        }

        private void txtcedula_Leave(object sender, EventArgs e)
        {
            if (txtcedula.Text == "")
            {
                txtcedula.Text = "CEDULA";
                txtcedula.ForeColor = Color.DarkSlateBlue;
            }
        }

        private void txttlf_Enter(object sender, EventArgs e)
        {
            if (txttlf.Text == "TELEFONO")
            {
                txttlf.Text = "";
                txttlf.ForeColor = Color.SlateBlue;
            }
        }

        private void txttlf_Leave(object sender, EventArgs e)
        {
            if (txttlf.Text == "")
            {
                txttlf.Text = "TELEFONO";
                txttlf.ForeColor = Color.DarkSlateBlue;
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "CONTRASEÑA")
            {
                txtcontraseña.Text = "";
                txtcontraseña.ForeColor = Color.SlateBlue;
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "CONTRASEÑA";
                txtcontraseña.ForeColor = Color.DarkSlateBlue;
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(txtuser.Text) ||
                string.IsNullOrWhiteSpace(txtcontraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Recoger los datos del formulario
            string nombreUsuario = txtuser.Text;
            string contraseña = txtcontraseña.Text;

            try
            {
                // Llamar al método de registro
                login.RegistrarUsuario(nombreUsuario, contraseña);
                MessageBox.Show("Registro exitoso. Bienvenido!");

                // Opcional: Redirigir a otra parte de la aplicación o limpiar los campos
                LimpiarCampos(); // Método que puedes implementar para limpiar los campos
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtuser.Clear();
            txtnombre.Clear();
            txtcedula.Clear();
            txtapellido.Clear();
            txtemail.Clear();
            txttlf.Clear();
            txtcontraseña.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
