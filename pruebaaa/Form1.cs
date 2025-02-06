using pruebaaa.Clases;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static pruebaaa.Login;

namespace pruebaaa
{
    public partial class SEA : Form
    {
        private Usuario _usuario;
        public SEA(Usuario usuario)
        {
            InitializeComponent();
            this.FormClosed += SEA_FormClosed;
            _usuario = usuario;

            // Mostrar la información del usuario en los controles
            lblid.Text = _usuario.Id.ToString();
            lblFullname.Text = $"{_usuario.Nombre} {_usuario.Apellido}";

            ConfigurarBotonesPorRol(usuario.Rol);
        }

        public void ActualizarDatos(Usuario usuario)
        {
            lblFullname.Text = $"{usuario.Nombre} {usuario.Apellido}";
        }

        private void ConfigurarBotonesPorRol(string rol)
        {
            if (rol == "Administrator")
            {
                button1.Visible = true; // Botón visible para administradores
                button2.Visible = true;   // Botón visible para todos
            }
            else if (rol == "Empleado")
            {
                button1.Visible = false; // Botón oculto para usuarios normales
                button2.Visible = false;   // Botón visible para usuarios
            }
            else if (rol == "Invitado")
            {
                button1.Visible = false; // Botón oculto para invitados
                button2.Visible = false;  // Ningún botón visible
            }
        }
        public int UsuarioId
        {
            get { return _usuario.Id; }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void MostrarFormularioEnPanel(Form formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.Owner = this;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new Estudiantes());
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new formMaterias());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnProf_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FormProfesores());
        }

        private void btnAulas_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FormAulas());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new Horarios());
        }

        private void SEA_Load(object sender, EventArgs e)
        {


        }

        private void SEA_Load_1(object sender, EventArgs e)
        {

        }

        private void SEA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new Usuarios());
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new Log());
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new Inscripcion());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario desde la propiedad _usuario
            int userId = _usuario.Id;

            Actu formEditar = new Actu(_usuario)
            {
                Owner = this // Establecer el formulario padre como propietario
            };

            // Mostrar el formulario de edición como diálogo modal
            formEditar.ShowDialog();
        }
    }
}
