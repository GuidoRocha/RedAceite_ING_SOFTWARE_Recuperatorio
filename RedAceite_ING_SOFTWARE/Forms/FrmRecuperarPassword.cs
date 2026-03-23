using SERVICES.Facade;
using SERVICES.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SERVICES.Forms
{
    public partial class FrmRecuperarPassword : Form
    {
        private string _username;
        private string _otpGenerado;

        public FrmRecuperarPassword()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Paso 1: El usuario ingresa su nombre de usuario y se genera el OTP.
        /// </summary>
        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Debe ingresar su nombre de usuario.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _username = txtUsername.Text.Trim();
                var resultado = UserService.StartPasswordRecovery(_username);
                _otpGenerado = resultado.otp;

                LoggerService.WriteLog(
                    $"Se generó un código de recuperación para el usuario: {_username}",
                    TraceLevel.Info);

                // Enviar OTP vía Botmaker API (WhatsApp)
                bool enviado = BotmakerService.EnviarOTPWhatsApp(resultado.telefono, _otpGenerado);

                if (enviado)
                {
                    LoggerService.WriteLog(
                        $"Código de recuperación enviado por WhatsApp al usuario: {_username}",
                        TraceLevel.Info);

                    MessageBox.Show(
                        "Se ha enviado un código de verificación a su WhatsApp.",
                        "Código enviado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    LoggerService.WriteLog(
                        $"No se pudo enviar el código por WhatsApp al usuario: {_username}. El código fue generado en la base de datos.",
                        TraceLevel.Warning);

                    MessageBox.Show(
                        "El código fue generado pero no se pudo enviar por WhatsApp. Contacte al administrador.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                MostrarPaso2();
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Paso 2: El usuario ingresa el código OTP y se valida contra la base de datos.
        /// </summary>
        private void btnVerificarCodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoOTP.Text))
            {
                MessageBox.Show("Debe ingresar el código de verificación.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool esValido = UserService.ValidateOTP(_username, txtCodigoOTP.Text.Trim());

                if (esValido)
                {
                    LoggerService.WriteLog(
                        $"Código OTP validado correctamente para el usuario: {_username}",
                        TraceLevel.Info);

                    MostrarPaso3();
                }
                else
                {
                    LoggerService.WriteLog(
                        $"Código OTP inválido o expirado para el usuario: {_username}",
                        TraceLevel.Warning);

                    MessageBox.Show(
                        "El código ingresado es inválido o ha expirado. Intente nuevamente desde el inicio.",
                        "Verificación fallida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show($"Error al verificar el código: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Paso 3: El usuario ingresa y confirma la nueva contraseña.
        /// </summary>
        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaPassword.Text))
            {
                MessageBox.Show("Debe ingresar una nueva contraseña.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserService.ChangePassword(_username, txtNuevaPassword.Text);

                LoggerService.WriteLog(
                    $"Contraseña cambiada exitosamente para el usuario: {_username}",
                    TraceLevel.Warning);

                MessageBox.Show(
                    "Su contraseña fue cambiada exitosamente. Ya puede iniciar sesión.",
                    "Contraseña actualizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show($"Error al cambiar la contraseña: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Oculta los controles del paso 1 y muestra los del paso 2 (ingreso de código OTP).
        /// </summary>
        private void MostrarPaso2()
        {
            // Ocultar paso 1
            lblUsername.Visible = false;
            txtUsername.Visible = false;
            btnEnviarCodigo.Visible = false;

            // Mostrar paso 2
            lblCodigoOTP.Visible = true;
            txtCodigoOTP.Visible = true;
            btnVerificarCodigo.Visible = true;
            txtCodigoOTP.Focus();
        }

        /// <summary>
        /// Oculta los controles del paso 2 y muestra los del paso 3 (nueva contraseña).
        /// </summary>
        private void MostrarPaso3()
        {
            // Ocultar paso 2
            lblCodigoOTP.Visible = false;
            txtCodigoOTP.Visible = false;
            btnVerificarCodigo.Visible = false;

            // Mostrar paso 3
            lblNuevaPassword.Visible = true;
            txtNuevaPassword.Visible = true;
            lblConfirmarPassword.Visible = true;
            txtConfirmarPassword.Visible = true;
            btnCambiarPassword.Visible = true;
            txtNuevaPassword.Focus();
        }
    }
}
