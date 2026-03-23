namespace SERVICES.Forms
{
    partial class FrmRecuperarPassword
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            // Paso 1 - Username
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnEnviarCodigo = new System.Windows.Forms.Button();

            // Paso 2 - Código OTP
            this.lblCodigoOTP = new System.Windows.Forms.Label();
            this.txtCodigoOTP = new System.Windows.Forms.TextBox();
            this.btnVerificarCodigo = new System.Windows.Forms.Button();

            // Paso 3 - Nueva contraseña
            this.lblNuevaPassword = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.btnCambiarPassword = new System.Windows.Forms.Button();

            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();

            //
            // panelPrincipal
            //
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Controls.Add(this.lblUsername);
            this.panelPrincipal.Controls.Add(this.txtUsername);
            this.panelPrincipal.Controls.Add(this.btnEnviarCodigo);
            this.panelPrincipal.Controls.Add(this.lblCodigoOTP);
            this.panelPrincipal.Controls.Add(this.txtCodigoOTP);
            this.panelPrincipal.Controls.Add(this.btnVerificarCodigo);
            this.panelPrincipal.Controls.Add(this.lblNuevaPassword);
            this.panelPrincipal.Controls.Add(this.txtNuevaPassword);
            this.panelPrincipal.Controls.Add(this.lblConfirmarPassword);
            this.panelPrincipal.Controls.Add(this.txtConfirmarPassword);
            this.panelPrincipal.Controls.Add(this.btnCambiarPassword);
            this.panelPrincipal.Location = new System.Drawing.Point(30, 20);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(400, 400);
            this.panelPrincipal.TabIndex = 0;

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblTitulo.Location = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recuperar contraseña";

            // ===== PASO 1 - Username =====
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblUsername.Location = new System.Drawing.Point(50, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(200, 21);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Nombre de usuario";
            //
            // txtUsername
            //
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtUsername.Location = new System.Drawing.Point(50, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 30);
            this.txtUsername.TabIndex = 2;
            //
            // btnEnviarCodigo
            //
            this.btnEnviarCodigo.BackColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnEnviarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarCodigo.FlatAppearance.BorderSize = 0;
            this.btnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEnviarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnEnviarCodigo.Location = new System.Drawing.Point(50, 160);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(300, 45);
            this.btnEnviarCodigo.TabIndex = 3;
            this.btnEnviarCodigo.Text = "Enviar código";
            this.btnEnviarCodigo.UseVisualStyleBackColor = false;
            this.btnEnviarCodigo.Click += new System.EventHandler(this.btnEnviarCodigo_Click);

            // ===== PASO 2 - Código OTP =====
            //
            // lblCodigoOTP
            //
            this.lblCodigoOTP.AutoSize = true;
            this.lblCodigoOTP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCodigoOTP.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCodigoOTP.Location = new System.Drawing.Point(50, 80);
            this.lblCodigoOTP.Name = "lblCodigoOTP";
            this.lblCodigoOTP.Size = new System.Drawing.Size(250, 21);
            this.lblCodigoOTP.TabIndex = 4;
            this.lblCodigoOTP.Text = "Código de verificación";
            this.lblCodigoOTP.Visible = false;
            //
            // txtCodigoOTP
            //
            this.txtCodigoOTP.BackColor = System.Drawing.Color.White;
            this.txtCodigoOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoOTP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtCodigoOTP.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtCodigoOTP.Location = new System.Drawing.Point(50, 110);
            this.txtCodigoOTP.MaxLength = 6;
            this.txtCodigoOTP.Name = "txtCodigoOTP";
            this.txtCodigoOTP.Size = new System.Drawing.Size(300, 39);
            this.txtCodigoOTP.TabIndex = 5;
            this.txtCodigoOTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoOTP.Visible = false;
            //
            // btnVerificarCodigo
            //
            this.btnVerificarCodigo.BackColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnVerificarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarCodigo.FlatAppearance.BorderSize = 0;
            this.btnVerificarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerificarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnVerificarCodigo.Location = new System.Drawing.Point(50, 170);
            this.btnVerificarCodigo.Name = "btnVerificarCodigo";
            this.btnVerificarCodigo.Size = new System.Drawing.Size(300, 45);
            this.btnVerificarCodigo.TabIndex = 6;
            this.btnVerificarCodigo.Text = "Verificar código";
            this.btnVerificarCodigo.UseVisualStyleBackColor = false;
            this.btnVerificarCodigo.Visible = false;
            this.btnVerificarCodigo.Click += new System.EventHandler(this.btnVerificarCodigo_Click);

            // ===== PASO 3 - Nueva contraseña =====
            //
            // lblNuevaPassword
            //
            this.lblNuevaPassword.AutoSize = true;
            this.lblNuevaPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNuevaPassword.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblNuevaPassword.Location = new System.Drawing.Point(50, 80);
            this.lblNuevaPassword.Name = "lblNuevaPassword";
            this.lblNuevaPassword.Size = new System.Drawing.Size(200, 21);
            this.lblNuevaPassword.TabIndex = 7;
            this.lblNuevaPassword.Text = "Nueva contraseña";
            this.lblNuevaPassword.Visible = false;
            //
            // txtNuevaPassword
            //
            this.txtNuevaPassword.BackColor = System.Drawing.Color.White;
            this.txtNuevaPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuevaPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNuevaPassword.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtNuevaPassword.Location = new System.Drawing.Point(50, 110);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.PasswordChar = '*';
            this.txtNuevaPassword.Size = new System.Drawing.Size(300, 30);
            this.txtNuevaPassword.TabIndex = 8;
            this.txtNuevaPassword.Visible = false;
            //
            // lblConfirmarPassword
            //
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConfirmarPassword.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblConfirmarPassword.Location = new System.Drawing.Point(50, 155);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(250, 21);
            this.lblConfirmarPassword.TabIndex = 9;
            this.lblConfirmarPassword.Text = "Confirmar contraseña";
            this.lblConfirmarPassword.Visible = false;
            //
            // txtConfirmarPassword
            //
            this.txtConfirmarPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmarPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmarPassword.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtConfirmarPassword.Location = new System.Drawing.Point(50, 185);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '*';
            this.txtConfirmarPassword.Size = new System.Drawing.Size(300, 30);
            this.txtConfirmarPassword.TabIndex = 10;
            this.txtConfirmarPassword.Visible = false;
            //
            // btnCambiarPassword
            //
            this.btnCambiarPassword.BackColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnCambiarPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarPassword.FlatAppearance.BorderSize = 0;
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.btnCambiarPassword.Location = new System.Drawing.Point(50, 235);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(300, 45);
            this.btnCambiarPassword.TabIndex = 11;
            this.btnCambiarPassword.Text = "Cambiar contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Visible = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);

            //
            // FrmRecuperarPassword
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(460, 440);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecuperarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RedAceite - Recuperar contraseña";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;

        // Paso 1
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnEnviarCodigo;

        // Paso 2
        private System.Windows.Forms.Label lblCodigoOTP;
        private System.Windows.Forms.TextBox txtCodigoOTP;
        private System.Windows.Forms.Button btnVerificarCodigo;

        // Paso 3
        private System.Windows.Forms.Label lblNuevaPassword;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Button btnCambiarPassword;
    }
}
