using RedAceite_ING_SOFTWARE.Domain.Observer;
using RedAceite_ING_SOFTWARE.Forms;
using SERVICES.DAL.Contratos;
using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SERVICES.Forms
{
    public partial class LogIn : Form, ILanguageObserver, IFormObserver
    {


        private static List<IFormObserver> formularios = new List<IFormObserver>();


        public static void Detach(IFormObserver formulario)
        {
            formularios.Remove(formulario);
        }


        public void Notify()
        {
            foreach (IFormObserver formulario in formularios)
            {
                formulario.Update(this);
            }
        }


        public void SetLenguaje(string leng)
        {
            if (leng == "es-ES")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                Notify();
            }
            else
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                Notify();
            }
        }

        private void AddFormularios()
        {
            formularios.Add(new FrmPrincipal());

        }


        public LogIn()

        {
            InitializeComponent();
            this.Tag = "Titulo_FrmLogin";

            // Cargar idioma guardado y establecerlo usando el flujo centralizado
            var code = LanguageService.LoadUserLanguage();
            
            // Usar SetCurrentLanguage para mantener consistencia (punto único de entrada)
            // Aunque notifique, aún no hay observers suscritos, no hay impacto
            LanguageService.SetCurrentLanguage(code);

            InitializeLanguageComboBox();
            LanguageService.TranslateForm(this);

            // Suscribirse al Observer para recibir notificaciones de cambio de idioma
            LanguageService.Subscribe(this);
        }

        public void UpdateLanguage()
        {
            LanguageService.TranslateForm(this);
            this.Refresh();
        }

        private void ButtonIngresar_Click(object sender, EventArgs e)
        {
            string username = txtusuario.Text;
            string password = txtcontraseña.Text;

            try
            {
                if (UserService.Login(username, password))
                {
                    Usuario user = UserService.GetUsuarioByUsername(username);
                    SesionService.UsuarioLogueado = user;
                    
                    // Ocultar el formulario de login
                    this.Hide();
                    
                    // Crear y mostrar el formulario principal maximizado
                    var frmPrincipal = new FrmPrincipal();
                    
                    // Configurar ventana maximizada para ocupar toda la pantalla
                    frmPrincipal.WindowState = FormWindowState.Maximized;
                    
                    frmPrincipal.Show();
                    
                    // Cuando se cierre el formulario principal, cerrar también el login
                    frmPrincipal.FormClosed += (s, args) => this.Close();

                    LoggerService.WriteLog($"El usuario {username} inició sesión correctamente.", TraceLevel.Info);
                }
                else
                {
                    LoggerService.WriteLog($"Intento fallido de inicio de sesión por el usuario {username}.", TraceLevel.Warning);
                    MessageBox.Show(LanguageService.Translate("Inicio_Sesion_Fallido_UsuarioContrasena"));
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);

                MessageBox.Show($"{LanguageService.Translate("OcurrioErrorDuranteInicioSesion")}{ex.Message}");
            }
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedLanguage = cbLanguage.SelectedItem.ToString() == "Español" ? "es-ES" : "en-US";

                // SetCurrentLanguage establece culture + persist + notify observers
                // No es necesario llamar TranslateForm manualmente porque el Observer lo hace
                LanguageService.SetCurrentLanguage(selectedLanguage);
                
                LoggerService.WriteLog(
                    $"Idioma cambiado a {selectedLanguage} desde Login.",
                    System.Diagnostics.TraceLevel.Info
                );
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void CheckPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPass.Checked)
            {
                txtcontraseña.PasswordChar = '\0';
            }
            else
            {
                txtcontraseña.PasswordChar = '*';
            }
        }


        // Método para inicializar el ComboBox con las opciones de idioma
        private void InitializeLanguageComboBox()
        {
            cbLanguage.Items.Add("Español");
            cbLanguage.Items.Add("Inglés");
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;



            // Seleccionar el idioma actual
            string currentLanguage = LanguageService.LoadUserLanguage();
            cbLanguage.SelectedItem = currentLanguage == "es-ES" ? "Español" : "Inglés";
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
        }

        /// <summary>
        /// Maneja el evento de clic en el link de recuperar contraseña.
        /// </summary>
        private void lnkRecuperarPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Por favor, contacte al administrador del sistema para recuperar su contraseña.",
                "Recuperar Contraseña",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario.
        /// Desuscribe del Observer para evitar memory leaks.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            LanguageService.Unsubscribe(this);
            base.OnFormClosing(e);
        }

        public void Update(Form form)
        {
            throw new NotImplementedException();
        }
    }
}
