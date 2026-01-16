using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmCrearUsuario : Form
    {
        public FrmCrearUsuario()
        {
            InitializeComponent();
        }

        private void CrearUsuario_Click(object sender, EventArgs e)
        {
            // Obtener datos de los campos
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text;
            string telefono = txtTelefono.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dni = txtDNI.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || 
                string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(email))
            {
                string message = LanguageService.Translate("Todos_Los_Campos_Obligatorios"); 
                string title = LanguageService.Translate("Error");

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear objeto usuario
                var usuario = new Usuario
                {
                    UserName = username,
                    Telefono = telefono,
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    DNI = string.IsNullOrWhiteSpace(dni) ? null : dni
                };

                // Registrar usuario
                UserService.RegisterUsuario(usuario, password);
                
                // Registrar en log
                LoggerService.WriteLog(
                    $"Se creó al usuario {username} - {nombre} {apellido} (DNI: {dni ?? "N/A"}).", 
                    System.Diagnostics.TraceLevel.Info
                );

                string message = LanguageService.Translate("Usuario_Creado");
                string title = LanguageService.Translate("Información");
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de error
                MessageBox.Show($"Error al crear el usuario: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtTelefono.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtDNI.Clear();
        }
    }
}
