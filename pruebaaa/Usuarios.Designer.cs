namespace pruebaaa
{
    partial class Usuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEliminar = new Button();
            txtId = new TextBox();
            cmbEstudiantes = new ComboBox();
            txtTlf = new TextBox();
            txtEmail = new TextBox();
            txtCedula = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbRol = new ComboBox();
            label3 = new Label();
            cmbUsuarios = new ComboBox();
            button1 = new Button();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(12, 485);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 39;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Window;
            txtId.Location = new Point(490, 430);
            txtId.Name = "txtId";
            txtId.Size = new Size(85, 23);
            txtId.TabIndex = 38;
            txtId.Visible = false;
            // 
            // cmbEstudiantes
            // 
            cmbEstudiantes.Anchor = AnchorStyles.Top;
            cmbEstudiantes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEstudiantes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEstudiantes.FormattingEnabled = true;
            cmbEstudiantes.Location = new Point(197, -92);
            cmbEstudiantes.Name = "cmbEstudiantes";
            cmbEstudiantes.Size = new Size(372, 23);
            cmbEstudiantes.TabIndex = 33;
            // 
            // txtTlf
            // 
            txtTlf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtTlf.BackColor = Color.Linen;
            txtTlf.Enabled = false;
            txtTlf.Location = new Point(333, 430);
            txtTlf.Name = "txtTlf";
            txtTlf.Size = new Size(151, 23);
            txtTlf.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtEmail.BackColor = Color.Linen;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(333, 390);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 23);
            txtEmail.TabIndex = 31;
            // 
            // txtCedula
            // 
            txtCedula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtCedula.BackColor = Color.Linen;
            txtCedula.Enabled = false;
            txtCedula.Location = new Point(333, 350);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(151, 23);
            txtCedula.TabIndex = 30;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtApellido.BackColor = Color.Linen;
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(333, 270);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(151, 23);
            txtApellido.TabIndex = 29;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtNombre.BackColor = Color.Linen;
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(333, 230);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 23);
            txtNombre.TabIndex = 28;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(266, 430);
            label6.Name = "label6";
            label6.Size = new Size(61, 17);
            label6.TabIndex = 26;
            label6.Text = "Telefono:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(285, 390);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 25;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(276, 350);
            label4.Name = "label4";
            label4.Size = new Size(51, 17);
            label4.TabIndex = 24;
            label4.Text = "Cedula:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(268, 270);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 22;
            label2.Text = "Apellido:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(267, 230);
            label1.Name = "label1";
            label1.Size = new Size(60, 17);
            label1.TabIndex = 21;
            label1.Text = "Nombre:";
            // 
            // cmbRol
            // 
            cmbRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbRol.BackColor = Color.Linen;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "", "Administrador", "Empleado" });
            cmbRol.Location = new Point(333, 312);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(151, 23);
            cmbRol.TabIndex = 40;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 313);
            label3.Name = "label3";
            label3.Size = new Size(30, 17);
            label3.TabIndex = 41;
            label3.Text = "Rol:";
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.Anchor = AnchorStyles.Top;
            cmbUsuarios.BackColor = Color.Linen;
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(266, 12);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(292, 23);
            cmbUsuarios.TabIndex = 42;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(713, 485);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 43;
            button1.Text = "Modificar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom;
            btnRegistrar.Location = new Point(361, 485);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 44;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 520);
            Controls.Add(btnRegistrar);
            Controls.Add(button1);
            Controls.Add(cmbUsuarios);
            Controls.Add(label3);
            Controls.Add(cmbRol);
            Controls.Add(btnEliminar);
            Controls.Add(txtId);
            Controls.Add(cmbEstudiantes);
            Controls.Add(txtTlf);
            Controls.Add(txtEmail);
            Controls.Add(txtCedula);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Usuarios";
            Text = "Usuarios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtId;
        private ComboBox cmbEstudiantes;
        private TextBox txtTlf;
        private TextBox txtEmail;
        private TextBox txtCedula;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private ComboBox cmbRol;
        private Label label3;
        private ComboBox cmbUsuarios;
        private Button button1;
        private Button btnRegistrar;
    }
}