namespace pruebaaa
{
    partial class Login
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
            pictureBox1 = new PictureBox();
            txtuser = new TextBox();
            txtpass = new TextBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            btnLogin = new Button();
            lnkforgot = new LinkLabel();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            btnMinimizar = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Location = new Point(0, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 316);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkSlateBlue;
            pictureBox1.Enabled = false;
            pictureBox1.Location = new Point(312, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 1);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtuser
            // 
            txtuser.BackColor = Color.Linen;
            txtuser.BorderStyle = BorderStyle.None;
            txtuser.Font = new Font("Bahnschrift Light", 12F);
            txtuser.ForeColor = Color.DarkSlateBlue;
            txtuser.Location = new Point(313, 90);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(400, 20);
            txtuser.TabIndex = 1;
            txtuser.Text = "USUARIO";
            txtuser.Enter += txtuser_Enter;
            txtuser.Leave += txtuser_Leave;
            // 
            // txtpass
            // 
            txtpass.BackColor = Color.Linen;
            txtpass.BorderStyle = BorderStyle.None;
            txtpass.Font = new Font("Bahnschrift Light", 12F);
            txtpass.ForeColor = Color.DarkSlateBlue;
            txtpass.Location = new Point(312, 182);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(400, 20);
            txtpass.TabIndex = 2;
            txtpass.Text = "CONTRASEÑA";
            txtpass.Enter += txtpass_Enter;
            txtpass.Leave += txtpass_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkSlateBlue;
            pictureBox2.Enabled = false;
            pictureBox2.Location = new Point(311, 202);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(400, 1);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Light", 14F);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(494, 19);
            label1.Name = "label1";
            label1.Size = new Size(63, 23);
            label1.TabIndex = 5;
            label1.Text = "LOGIN";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Gainsboro;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift Light", 12F);
            btnLogin.ForeColor = Color.DarkSlateBlue;
            btnLogin.Location = new Point(311, 241);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(401, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "INGRESAR";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkforgot
            // 
            lnkforgot.AutoSize = true;
            lnkforgot.LinkColor = Color.DarkSlateBlue;
            lnkforgot.Location = new Point(451, 306);
            lnkforgot.Name = "lnkforgot";
            lnkforgot.Size = new Size(123, 15);
            lnkforgot.TabIndex = 0;
            lnkforgot.TabStop = true;
            lnkforgot.Text = "Recuperar Contraseña";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.DarkSlateBlue;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCerrar.IconSize = 24;
            btnCerrar.Location = new Point(507, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(28, 19);
            btnCerrar.TabIndex = 8;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimizar.IconColor = Color.DarkSlateBlue;
            btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimizar.IconSize = 24;
            btnMinimizar.Location = new Point(473, -1);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(28, 19);
            btnMinimizar.TabIndex = 9;
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.Controls.Add(btnCerrar);
            panel2.Controls.Add(btnMinimizar);
            panel2.Location = new Point(245, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(535, 18);
            panel2.TabIndex = 10;
            panel2.MouseDown += panel2_MouseDown;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel3.BackColor = Color.DarkSlateBlue;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 18);
            panel3.TabIndex = 11;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(780, 330);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(lnkforgot);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(txtpass);
            Controls.Add(pictureBox2);
            Controls.Add(txtuser);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            MouseDown += Login_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox txtuser;
        private TextBox txtpass;
        private PictureBox pictureBox2;
        private Label label1;
        private Button btnLogin;
        private LinkLabel lnkforgot;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnMinimizar;
        private Panel panel2;
        private Panel panel3;
    }
}