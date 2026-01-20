using SERVICES.Dominio;
using SERVICES.DAL.Contratos;
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
    /// <summary>
    /// Formulario para asignar y desasignar patentes a un usuario.
    /// </summary>
    public partial class FrmAsignarPatentes : Form, ILanguageObserver
    {
        private Guid _idUsuario;
        private Usuario _usuarioActual;
        private List<Patente> _todasLasPatentes;
        private List<Patente> _patentesAsignadas;

        public FrmAsignarPatentes(Guid idUsuario)
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmAsignarPatentes";
            _idUsuario = idUsuario;

            // Suscribirse al evento Load
            this.Load += FrmAsignarPatentes_Load;

            // Suscribirse al Observer de idioma
            LanguageService.Subscribe(this);

            CargarDatos();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario se carga.
        /// Traduce el formulario según el idioma actual.
        /// </summary>
        private void FrmAsignarPatentes_Load(object sender, EventArgs e)
        {
            LanguageService.TranslateForm(this);
        }

        /// <summary>
        /// Carga los datos del usuario y las patentes disponibles.
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                // Obtener usuario actual
                _usuarioActual = UserService.GetUsuarioById(_idUsuario);
                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se encontró el usuario especificado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Mostrar nombre del usuario en el título
                lblUsuario.Text = $"Usuario: {_usuarioActual.UserName} - {_usuarioActual.Nombre} {_usuarioActual.Apellido}";

                // Obtener todas las patentes del sistema
                _todasLasPatentes = UserService.GetAllPatentes();

                // Obtener patentes ya asignadas al usuario
                _patentesAsignadas = UserService.GetPatentesByUsuario(_idUsuario);

                // Cargar las listas
                CargarListaDisponibles();
                CargarListaAsignadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
                this.Close();
            }
        }

        /// <summary>
        /// Carga la lista de patentes disponibles (no asignadas).
        /// </summary>
        private void CargarListaDisponibles()
        {
            lstDisponibles.Items.Clear();

            // Patentes disponibles = todas - asignadas
            var patentesDisponibles = _todasLasPatentes
                .Where(p => !_patentesAsignadas.Any(pa => pa.Id == p.Id))
                .ToList();

            foreach (var patente in patentesDisponibles)
            {
                lstDisponibles.Items.Add(new PatenteItem
                {
                    Id = patente.Id,
                    Nombre = patente.Nombre
                });
            }
        }

        /// <summary>
        /// Carga la lista de patentes asignadas.
        /// </summary>
        private void CargarListaAsignadas()
        {
            lstAsignadas.Items.Clear();

            foreach (var patente in _patentesAsignadas)
            {
                lstAsignadas.Items.Add(new PatenteItem
                {
                    Id = patente.Id,
                    Nombre = patente.Nombre
                });
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón Asignar (>>).
        /// </summary>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDisponibles.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una patente para asignar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var patenteSeleccionada = (PatenteItem)lstDisponibles.SelectedItem;

                // Asignar la patente al usuario
                UserService.AsignarPatenteAUsuario(_idUsuario, patenteSeleccionada.Id);

                // Actualizar las listas
                var patente = _todasLasPatentes.First(p => p.Id == patenteSeleccionada.Id);
                _patentesAsignadas.Add(patente);

                CargarListaDisponibles();
                CargarListaAsignadas();

                MessageBox.Show($"Patente '{patenteSeleccionada.Nombre}' asignada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar patente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón Desasignar (<<).
        /// </summary>
        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAsignadas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una patente para desasignar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var patenteSeleccionada = (PatenteItem)lstAsignadas.SelectedItem;

                // Desasignar la patente del usuario
                UserService.RemoverPatenteDeUsuario(_idUsuario, patenteSeleccionada.Id);

                // Actualizar las listas
                _patentesAsignadas.RemoveAll(p => p.Id == patenteSeleccionada.Id);

                CargarListaDisponibles();
                CargarListaAsignadas();

                MessageBox.Show($"Patente '{patenteSeleccionada.Nombre}' desasignada exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desasignar patente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón Cerrar.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Clase auxiliar para mostrar las patentes en los ListBox.
        /// </summary>
        private class PatenteItem
        {
            public Guid Id { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        // Implementación de ILanguageObserver

        /// <summary>
        /// Método llamado automáticamente cuando cambia el idioma.
        /// Traduce el formulario.
        /// </summary>
        public void UpdateLanguage()
        {
            try
            {
                LanguageService.TranslateForm(this);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
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
    }
}
