using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario que se abre inmediatamente después de crear un usuario nuevo.
    /// Permite asignar una familia (rol) y/o patentes individuales en un solo paso.
    /// </summary>
    public partial class FrmAsignarPermisosNuevoUsuario : Form
    {
        private readonly Guid _idUsuario;
        private readonly string _nombreUsuario;
        private List<Familia> _familias;
        private List<Patente> _patentes;

        public FrmAsignarPermisosNuevoUsuario(Guid idUsuario, string nombreCompleto)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _nombreUsuario = nombreCompleto;

            this.Load += FrmAsignarPermisosNuevoUsuario_Load;
        }

        private void FrmAsignarPermisosNuevoUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsuarioInfo.Text = $"Usuario: {_nombreUsuario}";

                CargarFamilias();
                CargarPatentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de permisos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void CargarFamilias()
        {
            _familias = UserService.GetAllFamilias();

            cmbFamilia.Items.Clear();
            cmbFamilia.Items.Add("-- Sin rol asignado --");

            foreach (var familia in _familias)
            {
                cmbFamilia.Items.Add(familia.Nombre);
            }

            cmbFamilia.SelectedIndex = 0;
        }

        private void CargarPatentes()
        {
            _patentes = UserService.GetAllPatentes();

            clbPatentes.Items.Clear();

            foreach (var patente in _patentes)
            {
                clbPatentes.Items.Add(patente.Nombre, false);
            }
        }

        /// <summary>
        /// Cuando se selecciona una familia, se marcan automáticamente las patentes
        /// que incluye ese rol para que el usuario vea qué permisos tiene.
        /// </summary>
        private void cmbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desmarcar todas las patentes primero
            for (int i = 0; i < clbPatentes.Items.Count; i++)
            {
                clbPatentes.SetItemChecked(i, false);
            }

            if (cmbFamilia.SelectedIndex <= 0) return;

            var familiaSeleccionada = _familias[cmbFamilia.SelectedIndex - 1];

            // Obtener las patentes que pertenecen a esta familia
            var patentesEnFamilia = new List<Patente>();
            ExtraerPatentes(familiaSeleccionada.Accesos, patentesEnFamilia);

            // Marcar las patentes que la familia incluye
            foreach (var patenteFamilia in patentesEnFamilia)
            {
                for (int i = 0; i < _patentes.Count; i++)
                {
                    if (_patentes[i].Id == patenteFamilia.Id)
                    {
                        clbPatentes.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            // Actualizar descripción
            lblFamiliaDesc.Text = $"El rol \"{familiaSeleccionada.Nombre}\" incluye {patentesEnFamilia.Count} permiso(s). " +
                                  "Puede agregar permisos adicionales marcando las casillas de abajo.";
        }

        private void ExtraerPatentes(List<Acceso> accesos, List<Patente> resultado)
        {
            foreach (var acceso in accesos)
            {
                if (acceso is Patente patente)
                {
                    if (!resultado.Any(p => p.Id == patente.Id))
                        resultado.Add(patente);
                }
                else if (acceso is Familia familia)
                {
                    ExtraerPatentes(familia.Accesos, resultado);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool asignoAlgo = false;

                // 1. Asignar familia si se seleccionó una
                if (cmbFamilia.SelectedIndex > 0)
                {
                    var familiaSeleccionada = _familias[cmbFamilia.SelectedIndex - 1];
                    UserService.AsignarFamiliaAUsuario(_idUsuario, familiaSeleccionada.Id);
                    asignoAlgo = true;
                }

                // 2. Asignar patentes individuales marcadas que no estén ya cubiertas por la familia
                var patentesIndividuales = new List<Patente>();
                for (int i = 0; i < clbPatentes.Items.Count; i++)
                {
                    if (clbPatentes.GetItemChecked(i))
                    {
                        patentesIndividuales.Add(_patentes[i]);
                    }
                }

                // Si se seleccionó una familia, solo asignar como patentes individuales
                // las que NO están incluidas en la familia (para evitar duplicados)
                if (cmbFamilia.SelectedIndex > 0)
                {
                    var familiaSeleccionada = _familias[cmbFamilia.SelectedIndex - 1];
                    var patentesEnFamilia = new List<Patente>();
                    ExtraerPatentes(familiaSeleccionada.Accesos, patentesEnFamilia);

                    patentesIndividuales = patentesIndividuales
                        .Where(p => !patentesEnFamilia.Any(pf => pf.Id == p.Id))
                        .ToList();
                }

                foreach (var patente in patentesIndividuales)
                {
                    UserService.AsignarPatenteAUsuario(_idUsuario, patente.Id);
                    asignoAlgo = true;
                }

                if (asignoAlgo)
                {
                    MessageBox.Show("Permisos asignados correctamente al nuevo usuario.",
                        "Permisos Asignados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se seleccionaron permisos. El usuario no tendrá acceso a ningún módulo.",
                        "Sin Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar permisos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "El usuario no tendrá permisos asignados y no podrá acceder a ningún módulo del sistema.\n\n" +
                "Podrá asignarle permisos más tarde desde la Gestión de Usuarios.\n\n" +
                "¿Desea continuar sin asignar permisos?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
