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
            string username = txtusername.Text;
            string password = txtpassword.Text;
            string telefono = txtTelefono.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(telefono))
            {
                string message = LanguageService.Translate("Ingresar_Nombre_Contraseña"); // Traducción del mensaje
                string title = LanguageService.Translate("Error"); // Traducción del título

                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserService.Register(username, password, telefono);
                LoggerService.WriteLog($"Se creó al usuario {username}.", System.Diagnostics.TraceLevel.Info);
                string message = LanguageService.Translate("Usuario_Creado"); // Traducción del mensaje
                string title = LanguageService.Translate("Información"); // Traducción del título
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtusername.Clear();
                txtpassword.Clear();
                txtTelefono.Clear();
            }
            catch (Exception ex)
            {
                // Mostrar el mensaje de error sin cerrar el programa
                MessageBox.Show($"Error al crear el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
