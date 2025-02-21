namespace pruebaaa.Clases
{
    partial class FormProfesores
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
            btnModificar = new Button();
            btnAgregar = new Button();
            cmbSexo = new ComboBox();
            lblMatricula = new Label();
            txtTlf = new TextBox();
            txtEmail = new TextBox();
            txtCedula = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbProfesores = new ComboBox();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Location = new Point(12, 437);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 38;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Window;
            txtId.Location = new Point(230, 157);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 37;
            txtId.Visible = false;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom;
            btnModificar.Location = new Point(239, 437);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 36;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.Location = new Point(447, 437);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 35;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cmbSexo
            // 
            cmbSexo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(207, 278);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(152, 23);
            cmbSexo.TabIndex = 34;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(207, 158);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(0, 17);
            lblMatricula.TabIndex = 33;
            // 
            // txtTlf
            // 
            txtTlf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtTlf.Location = new Point(208, 398);
            txtTlf.Name = "txtTlf";
            txtTlf.Size = new Size(151, 23);
            txtTlf.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtEmail.Location = new Point(208, 358);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 23);
            txtEmail.TabIndex = 31;
            // 
            // txtCedula
            // 
            txtCedula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtCedula.Location = new Point(208, 318);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(151, 23);
            txtCedula.TabIndex = 30;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtApellido.Location = new Point(208, 238);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(151, 23);
            txtApellido.TabIndex = 29;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtNombre.Location = new Point(208, 198);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 23);
            txtNombre.TabIndex = 28;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(163, 278);
            label7.Name = "label7";
            label7.Size = new Size(39, 17);
            label7.TabIndex = 27;
            label7.Text = "Sexo:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(141, 398);
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
            label5.Location = new Point(160, 358);
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
            label4.Location = new Point(151, 318);
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
            label2.Location = new Point(143, 238);
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
            label1.Location = new Point(142, 198);
            label1.Name = "label1";
            label1.Size = new Size(60, 17);
            label1.TabIndex = 21;
            label1.Text = "Nombre:";
            // 
            // cmbProfesores
            // 
            cmbProfesores.Anchor = AnchorStyles.Top;
            cmbProfesores.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProfesores.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProfesores.FormattingEnabled = true;
            cmbProfesores.Location = new Point(94, 12);
            cmbProfesores.Name = "cmbProfesores";
            cmbProfesores.Size = new Size(347, 23);
            cmbProfesores.TabIndex = 39;
            cmbProfesores.SelectedIndexChanged += cmbProfesores_SelectedIndexChanged;
            // 
            // FormProfesores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 472);
            Controls.Add(cmbProfesores);
            Controls.Add(btnEliminar);
            Controls.Add(txtId);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(cmbSexo);
            Controls.Add(lblMatricula);
            Controls.Add(txtTlf);
            Controls.Add(txtEmail);
            Controls.Add(txtCedula);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProfesores";
            Text = "FormProfesores";
            Load += FormProfesores_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private TextBox txtId;
        private Button btnModificar;
        private Button btnAgregar;
        private ComboBox cmbSexo;
        private Label lblMatricula;
        private TextBox txtTlf;
        private TextBox txtEmail;
        private TextBox txtCedula;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private ComboBox cmbProfesores;
    }
}