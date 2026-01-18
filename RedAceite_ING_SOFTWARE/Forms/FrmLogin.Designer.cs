namespace SERVICES.Forms
{
    partial class LogIn
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ButtonIngresar = new System.Windows.Forms.Button();
            this.CheckPass = new System.Windows.Forms.CheckBox();
            this.lblMostrarPassword = new System.Windows.Forms.Label();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.Contraseña = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.Label();
            this.lnkRecuperarPassword = new System.Windows.Forms.LinkLabel();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.lblTitulo);
            this.panelLogin.Controls.Add(this.ButtonIngresar);
            this.panelLogin.Controls.Add(this.CheckPass);
            this.panelLogin.Controls.Add(this.lblMostrarPassword);
            this.panelLogin.Controls.Add(this.txtcontraseña);
            this.panelLogin.Controls.Add(this.Contraseña);
            this.panelLogin.Controls.Add(this.txtusuario);
            this.panelLogin.Controls.Add(this.Usuario);
            this.panelLogin.Controls.Add(this.lnkRecuperarPassword);
            this.panelLogin.Location = new System.Drawing.Point(200, 80);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(400, 420);
            this.panelLogin.TabIndex = 28;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(100, 40);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(201, 41);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Tag = "";
            this.lblTitulo.Text = "Iniciar sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonIngresar
            // 
            this.ButtonIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ButtonIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonIngresar.FlatAppearance.BorderSize = 0;
            this.ButtonIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonIngresar.ForeColor = System.Drawing.Color.White;
            this.ButtonIngresar.Location = new System.Drawing.Point(50, 310);
            this.ButtonIngresar.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonIngresar.Name = "ButtonIngresar";
            this.ButtonIngresar.Size = new System.Drawing.Size(300, 45);
            this.ButtonIngresar.TabIndex = 3;
            this.ButtonIngresar.Tag = "Entrar";
            this.ButtonIngresar.Text = "Entrar";
            this.ButtonIngresar.UseVisualStyleBackColor = false;
            this.ButtonIngresar.Click += new System.EventHandler(this.ButtonIngresar_Click);
            // 
            // CheckPass
            // 
            this.CheckPass.AutoSize = true;
            this.CheckPass.Location = new System.Drawing.Point(50, 260);
            this.CheckPass.Margin = new System.Windows.Forms.Padding(4);
            this.CheckPass.Name = "CheckPass";
            this.CheckPass.Size = new System.Drawing.Size(18, 17);
            this.CheckPass.TabIndex = 19;
            this.CheckPass.UseVisualStyleBackColor = true;
            this.CheckPass.CheckedChanged += new System.EventHandler(this.CheckPass_CheckedChanged);
            // 
            // lblMostrarPassword
            // 
            this.lblMostrarPassword.AutoSize = true;
            this.lblMostrarPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrarPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblMostrarPassword.Location = new System.Drawing.Point(72, 258);
            this.lblMostrarPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMostrarPassword.Name = "lblMostrarPassword";
            this.lblMostrarPassword.Size = new System.Drawing.Size(136, 20);
            this.lblMostrarPassword.TabIndex = 28;
            this.lblMostrarPassword.Tag = "";
            this.lblMostrarPassword.Text = "Mostrar contraseña";
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.BackColor = System.Drawing.Color.White;
            this.txtcontraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcontraseña.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtcontraseña.Location = new System.Drawing.Point(50, 210);
            this.txtcontraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.PasswordChar = '*';
            this.txtcontraseña.Size = new System.Drawing.Size(300, 30);
            this.txtcontraseña.TabIndex = 2;
            // 
            // Contraseña
            // 
            this.Contraseña.AutoSize = true;
            this.Contraseña.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Contraseña.Location = new System.Drawing.Point(46, 180);
            this.Contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(96, 21);
            this.Contraseña.TabIndex = 25;
            this.Contraseña.Tag = "Contrasena";
            this.Contraseña.Text = "Contraseña";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(637, 24);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(110, 28);
            this.cbLanguage.TabIndex = 4;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // txtusuario
            // 
            this.txtusuario.BackColor = System.Drawing.Color.White;
            this.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtusuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtusuario.Location = new System.Drawing.Point(50, 130);
            this.txtusuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(300, 30);
            this.txtusuario.TabIndex = 1;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Usuario.Location = new System.Drawing.Point(46, 100);
            this.Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(53, 21);
            this.Usuario.TabIndex = 24;
            this.Usuario.Tag = "Email";
            this.Usuario.Text = "Email";
            // 
            // lnkRecuperarPassword
            // 
            this.lnkRecuperarPassword.AutoSize = true;
            this.lnkRecuperarPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRecuperarPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lnkRecuperarPassword.Location = new System.Drawing.Point(113, 369);
            this.lnkRecuperarPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkRecuperarPassword.Name = "lnkRecuperarPassword";
            this.lnkRecuperarPassword.Size = new System.Drawing.Size(178, 20);
            this.lnkRecuperarPassword.TabIndex = 29;
            this.lnkRecuperarPassword.TabStop = true;
            this.lnkRecuperarPassword.Tag = "";
            this.lnkRecuperarPassword.Text = "¿Olvidaste tu contraseña?";
            this.lnkRecuperarPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRecuperarPassword_LinkClicked);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.cbLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedAceite - Iniciar Sesión";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button ButtonIngresar;
        private System.Windows.Forms.CheckBox CheckPass;
        private System.Windows.Forms.TextBox txtcontraseña;
        private System.Windows.Forms.Label Contraseña;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label lblMostrarPassword;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.LinkLabel lnkRecuperarPassword;
    }
}