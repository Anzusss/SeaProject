using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using pruebaaa.Clases;


namespace pruebaaa
{
    public partial class Login : Form
    {

        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Rol { get; set; }
        }

        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //MySqlConnection conexion = new MySqlConnection("server =localhost;port=3306;user=root;password=;database=pruebaconn");
        private string connectionString = "server =localhost;port=3306;user=root;password=;database=pruebaconn";
        Cregistromovimientos regis = new Cregistromovimientos();
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

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.SlateBlue;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DarkSlateBlue;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public Usuario ObtenerUsuario(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;
            string hashedPassword = HashPassword(contraseña); // Hashea la contraseña

            // Modifica la consulta para obtener más datos
            string query = "SELECT UserID, FirstName, LastName, Position FROM Users WHERE LoginName = @NombreUsuario AND Password = @Contraseña";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", hashedPassword); // Usa el hash aquí
                    conexion.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crea un nuevo objeto Usuario con los datos obtenidos
                            usuario = new Usuario
                            {
                                Id = reader.GetInt32("UserID"),
                                Nombre = reader.GetString("FirstName"),
                                Apellido = reader.GetString("LastName"),
                                Rol = reader.GetString("Position")
                            };
                        }
                    }
                }
            }
            return usuario;
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
            try
            {
                string nombreUsuario = txtuser.Text;
                string contraseña = txtpass.Text;

                Usuario usuario = ObtenerUsuario(nombreUsuario, contraseña); // Cambiado para obtener el objeto Usuario

                if (usuario != null)
                {
                    MessageBox.Show("Bienvenido " + usuario.Nombre);
                    regis.RegistrarMovimiento(usuario.Id, "Inicio de sesión");
                    

                    // Crear instancia del nuevo formulario y pasar los datos
                    SEA dashboard = new SEA(usuario);
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Error: Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
