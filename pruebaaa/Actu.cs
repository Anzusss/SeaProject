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
using static pruebaaa.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace pruebaaa
{
    public partial class Actu : Form
    {

        private Usuario _usuario; // Almacena el objeto Usuario
        public Actu(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            Clogin login = new Clogin();


        }
        private void CargarDatosUsuario()
        {
            // Accede a las propiedades del objeto _usuario
            txtnombre.Text = _usuario.Nombre;
            txtapellido.Text = _usuario.Apellido;


            // Si necesitas mostrar el ID, puedes hacerlo así:
            lblId.Text = _usuario.Id.ToString(); // Suponiendo que tienes un Label para mostrar el ID
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

        public bool ActualizarDatosUsuario(int id, string loginname, string password, string nombre, string apellido, string email, string telefono, string cedula)
        {
            MySqlConnection conex = null;
            try
            {
                conex = new Cconexion().establecerConexion();

                string hashedPassword = HashPassword(password);

                // Consulta SQL para actualizar los datos del usuario
                string queryActualizar = @"UPDATE users SET LoginName = @LoginName, Password = @Password, FirstName = @Nombre, LastName = @Apellido, Email = @Email, Telefono = @Telefono, Cedula = @Cedula WHERE UserID = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryActualizar, conex))
                {
                    // Agregamos los parámetros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@LoginName", loginname);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    // Ejecutamos el comando
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Datos del usuario actualizados exitosamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario para modificar. (ID del usuario incorrecto o inaccesible)");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al actualizar los datos del usuario: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
                return false;
            }
            finally
            {
                if (conex != null && conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtener los nuevos valores desde los TextBox
            string nuevoUsuario = txtuser.Text.Trim();
            string nuevoContraseña = txtcontraseña.Text.Trim();
            string nuevoNombre = txtnombre.Text.Trim();
            string nuevoApellido = txtapellido.Text.Trim();
            string nuevoCedula = txtcedula.Text.Trim();
            string nuevoEmail = txtemail.Text.Trim();
            string nuevoTelefono = txttlf.Text.Trim();

            // Validar campos antes de actualizar
            if (string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrEmpty(nuevoApellido) || string.IsNullOrEmpty(nuevoEmail) || string.IsNullOrEmpty(nuevoTelefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            string hashedPassword = HashPassword(nuevoContraseña); // Hashea la contraseña
            // Actualizar las propiedades del objeto _usuario
            _usuario.Nombre = nuevoNombre;
            _usuario.Apellido = nuevoApellido;

            // Llamar al método para actualizar en la base de datos
            Clogin loginDatos = new Clogin();
            bool actualizacionExitosa = ActualizarDatosUsuario(_usuario.Id, nuevoUsuario, hashedPassword, nuevoNombre, nuevoApellido, nuevoEmail, nuevoTelefono, nuevoCedula);

            if (actualizacionExitosa)
            {
               
                var mainForm = (SEA)this.Owner; // Asegúrate de establecer el Owner al abrir el formulario
                mainForm.ActualizarDatos(new Usuario 
        { 
            Id = _usuario.Id, 
            Nombre = nuevoNombre, 
            Apellido = nuevoApellido 
        });
                this.Close(); // Cerrar el formulario después de actualizar
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

        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "EMAIL")
            {
                txtemail.Text = "";
                txtemail.ForeColor = Color.SlateBlue;
                
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                txtemail.Text = "EMAIL";
                txtemail.ForeColor = Color.DarkSlateBlue;
               
            }
        }

        
    }

}
