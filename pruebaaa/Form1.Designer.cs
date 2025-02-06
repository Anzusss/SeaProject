namespace pruebaaa
{
    partial class SEA
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEstudiantes = new Button();
            panelContenedor = new Panel();
            panel2 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            btnMinimizar = new FontAwesome.Sharp.IconButton();
            btnMaterias = new Button();
            btnProf = new Button();
            btnAulas = new Button();
            btnHorario = new Button();
            panel1 = new Panel();
            btnLogout = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            btnInscripcion = new Button();
            lblid = new Label();
            lblFullname = new Label();
            button2 = new Button();
            button1 = new Button();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.BackColor = Color.FromArgb(249, 244, 255);
            btnEstudiantes.FlatStyle = FlatStyle.Popup;
            btnEstudiantes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEstudiantes.Location = new Point(7, 167);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Size = new Size(159, 30);
            btnEstudiantes.TabIndex = 0;
            btnEstudiantes.Text = "Estudiantes";
            btnEstudiantes.UseVisualStyleBackColor = false;
            btnEstudiantes.Click += button1_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.BackColor = Color.Linen;
            panelContenedor.Location = new Point(172, 21);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1092, 679);
            panelContenedor.TabIndex = 5;
            panelContenedor.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(60, 0, 122);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(btnCerrar);
            panel2.Controls.Add(btnMinimizar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 21);
            panel2.TabIndex = 9;
            panel2.Paint += panel2_Paint;
            panel2.MouseDown += panel2_MouseDown;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 24;
            iconButton1.Location = new Point(1199, 0);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(28, 21);
            iconButton1.TabIndex = 11;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.White;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCerrar.IconSize = 24;
            btnCerrar.Location = new Point(1233, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(28, 24);
            btnCerrar.TabIndex = 9;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimizar.IconColor = Color.White;
            btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimizar.IconSize = 24;
            btnMinimizar.Location = new Point(1165, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(28, 21);
            btnMinimizar.TabIndex = 10;
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaterias
            // 
            btnMaterias.BackColor = Color.FromArgb(249, 244, 255);
            btnMaterias.FlatStyle = FlatStyle.Popup;
            btnMaterias.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMaterias.Location = new Point(7, 239);
            btnMaterias.Name = "btnMaterias";
            btnMaterias.Size = new Size(159, 30);
            btnMaterias.TabIndex = 0;
            btnMaterias.Text = "Materias";
            btnMaterias.UseVisualStyleBackColor = false;
            btnMaterias.Click += btnMaterias_Click;
            // 
            // btnProf
            // 
            btnProf.BackColor = Color.FromArgb(249, 244, 255);
            btnProf.FlatStyle = FlatStyle.Popup;
            btnProf.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProf.Location = new Point(7, 203);
            btnProf.Name = "btnProf";
            btnProf.Size = new Size(159, 30);
            btnProf.TabIndex = 6;
            btnProf.Text = "Profesores";
            btnProf.UseVisualStyleBackColor = false;
            btnProf.Click += btnProf_Click;
            // 
            // btnAulas
            // 
            btnAulas.BackColor = Color.FromArgb(249, 244, 255);
            btnAulas.FlatStyle = FlatStyle.Popup;
            btnAulas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAulas.Location = new Point(7, 275);
            btnAulas.Name = "btnAulas";
            btnAulas.Size = new Size(159, 30);
            btnAulas.TabIndex = 7;
            btnAulas.Text = "Aulas";
            btnAulas.UseVisualStyleBackColor = false;
            btnAulas.Click += btnAulas_Click;
            // 
            // btnHorario
            // 
            btnHorario.BackColor = Color.FromArgb(249, 244, 255);
            btnHorario.FlatStyle = FlatStyle.Popup;
            btnHorario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHorario.Location = new Point(7, 311);
            btnHorario.Name = "btnHorario";
            btnHorario.Size = new Size(159, 30);
            btnHorario.TabIndex = 8;
            btnHorario.Text = "Horarios";
            btnHorario.UseVisualStyleBackColor = false;
            btnHorario.Click += btnHorario_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(60, 0, 122);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnInscripcion);
            panel1.Controls.Add(lblid);
            panel1.Controls.Add(lblFullname);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnHorario);
            panel1.Controls.Add(btnAulas);
            panel1.Controls.Add(btnEstudiantes);
            panel1.Controls.Add(btnMaterias);
            panel1.Controls.Add(btnProf);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 700);
            panel1.TabIndex = 9;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            btnLogout.IconColor = Color.Black;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 40;
            btnLogout.Location = new Point(3, 665);
            btnLogout.Name = "btnLogout";
            btnLogout.Rotation = 180D;
            btnLogout.Size = new Size(35, 32);
            btnLogout.TabIndex = 0;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.Image = Properties.Resources.user_profile_icon_free_vector__2_;
            pictureBox1.Location = new Point(26, 16);
            pictureBox1.MaximumSize = new Size(120, 108);
            pictureBox1.MinimumSize = new Size(120, 108);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 108);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnInscripcion
            // 
            btnInscripcion.BackColor = Color.FromArgb(249, 244, 255);
            btnInscripcion.FlatStyle = FlatStyle.Popup;
            btnInscripcion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInscripcion.Location = new Point(7, 347);
            btnInscripcion.Name = "btnInscripcion";
            btnInscripcion.Size = new Size(159, 30);
            btnInscripcion.TabIndex = 13;
            btnInscripcion.Text = "Inscripciones";
            btnInscripcion.UseVisualStyleBackColor = false;
            btnInscripcion.Click += btnInscripcion_Click;
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Font = new Font("Bahnschrift Light", 12F);
            lblid.Location = new Point(0, 21);
            lblid.Name = "lblid";
            lblid.Size = new Size(51, 19);
            lblid.TabIndex = 12;
            lblid.Text = "label1";
            lblid.Visible = false;
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Font = new Font("Bahnschrift Light", 12F);
            lblFullname.ForeColor = Color.FromArgb(249, 244, 255);
            lblFullname.Location = new Point(3, 132);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(51, 19);
            lblFullname.TabIndex = 0;
            lblFullname.Text = "label1";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(249, 244, 255);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(7, 572);
            button2.Name = "button2";
            button2.Size = new Size(159, 30);
            button2.TabIndex = 10;
            button2.Text = "Registros";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(249, 244, 255);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(7, 536);
            button1.Name = "button1";
            button1.Size = new Size(159, 30);
            button1.TabIndex = 9;
            button1.Text = "Usuarios";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.Location = new Point(137, 127);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(35, 32);
            iconButton2.TabIndex = 14;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // SEA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1264, 700);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelContenedor);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1170, 700);
            Name = "SEA";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S.E.A";
            FormClosed += SEA_FormClosed;
            Load += SEA_Load_1;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEstudiantes;
        private Panel panelContenedor;
        private Button btnMaterias;
        private Button btnProf;
        private Button btnAulas;
        private Button btnHorario;
        private Panel panel2;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnMinimizar;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button button2;
        private Button button1;
        private Label lblFullname;
        private Label lblid;
        private Label lblApellido;
        private Button btnInscripcion;
        private FontAwesome.Sharp.IconButton iconButton1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}
