namespace pruebaaa
{
    partial class Inscripcion
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
            panel1 = new Panel();
            txtInscripcionId = new TextBox();
            txtEstudianteId = new TextBox();
            lblNombreEstudiante = new Label();
            btnEliminar = new Button();
            btnAgregar = new Button();
            cmbHorarios = new ComboBox();
            btnBuscar = new Button();
            label1 = new Label();
            txtCedulaEstudiante = new TextBox();
            dgvResultados = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtInscripcionId);
            panel1.Controls.Add(txtEstudianteId);
            panel1.Controls.Add(lblNombreEstudiante);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(cmbHorarios);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCedulaEstudiante);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 66);
            panel1.TabIndex = 0;
            // 
            // txtInscripcionId
            // 
            txtInscripcionId.Location = new Point(771, 0);
            txtInscripcionId.Name = "txtInscripcionId";
            txtInscripcionId.Size = new Size(29, 23);
            txtInscripcionId.TabIndex = 8;
            txtInscripcionId.Visible = false;
            // 
            // txtEstudianteId
            // 
            txtEstudianteId.Location = new Point(751, 0);
            txtEstudianteId.Name = "txtEstudianteId";
            txtEstudianteId.Size = new Size(29, 23);
            txtEstudianteId.TabIndex = 7;
            txtEstudianteId.Visible = false;
            // 
            // lblNombreEstudiante
            // 
            lblNombreEstudiante.AutoSize = true;
            lblNombreEstudiante.Location = new Point(3, 4);
            lblNombreEstudiante.Name = "lblNombreEstudiante";
            lblNombreEstudiante.Size = new Size(128, 15);
            lblNombreEstudiante.TabIndex = 6;
            lblNombreEstudiante.Text = "Nombre del estudiante";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(722, 38);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnAgregar.Location = new Point(621, 38);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cmbHorarios
            // 
            cmbHorarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbHorarios.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbHorarios.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbHorarios.FormattingEnabled = true;
            cmbHorarios.Location = new Point(217, 38);
            cmbHorarios.Name = "cmbHorarios";
            cmbHorarios.Size = new Size(398, 23);
            cmbHorarios.TabIndex = 3;
            cmbHorarios.SelectedIndexChanged += cmbHorarios_SelectedIndexChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(118, 37);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 1;
            label1.Text = "Cedula del estudiante";
            // 
            // txtCedulaEstudiante
            // 
            txtCedulaEstudiante.Location = new Point(12, 37);
            txtCedulaEstudiante.Name = "txtCedulaEstudiante";
            txtCedulaEstudiante.Size = new Size(100, 23);
            txtCedulaEstudiante.TabIndex = 0;
            // 
            // dgvResultados
            // 
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.BackgroundColor = Color.SeaShell;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvResultados.Location = new Point(0, 66);
            dgvResultados.MultiSelect = false;
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(800, 384);
            dgvResultados.TabIndex = 1;
            dgvResultados.CellClick += dgvResultados_CellClick;
            dgvResultados.CellContentClick += dataGridView1_CellContentClick;
            dgvResultados.UserDeletingRow += dgvResultados_UserDeletingRow;
            // 
            // Inscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvResultados);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Inscripcion";
            Text = "Inscripcion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvResultados;
        private TextBox txtCedulaEstudiante;
        private Label label1;
        private Button btnBuscar;
        private Button btnAgregar;
        private ComboBox cmbHorarios;
        private Button btnEliminar;
        private Label lblNombreEstudiante;
        private TextBox txtEstudianteId;
        private TextBox txtInscripcionId;
    }
}