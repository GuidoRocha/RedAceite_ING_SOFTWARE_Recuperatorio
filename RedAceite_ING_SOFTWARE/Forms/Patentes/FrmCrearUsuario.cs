using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmCrearUsuario : Form
    {
        public FrmCrearUsuario()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmCrearUsuario";

            // Suscribirse al evento Load
            this.Load += FrmCrearUsuario_Load;
        }

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {
            // (FASE 1) Sin traducción automática
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
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("Usuario creado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        /// <summary>
        /// Maneja el evento del botón Cancelar.
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Preguntar si realmente desea cancelar si hay datos ingresados
            if (!string.IsNullOrWhiteSpace(txtusername.Text) || 
                !string.IsNullOrWhiteSpace(txtpassword.Text) ||
                !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtEmail.Text) ||
                !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro que desea cancelar? Se perderán los datos ingresados.",
                    "Confirmar cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Cerrar el formulario
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
