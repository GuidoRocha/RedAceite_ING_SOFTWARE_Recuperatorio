using SERVICES.Dominio;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmGestionRoles : Form
    {
        private List<Familia> _familias;

        public FrmGestionRoles()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmGestionRoles";
            this.Load += FrmGestionRoles_Load;
        }

        private void FrmGestionRoles_Load(object sender, EventArgs e)
        {
            AplicarTraducciones();
            CargarRoles();
        }

        private void AplicarTraducciones()
        {
            lblFiltroNombre.Text = "roles_Nombre".Translate();
            btnFiltrar.Text = "roles_Filtrar".Translate();
            btnLimpiarFiltros.Text = "roles_Limpiar".Translate();
            btnCrearRol.Text = "roles_CrearRol".Translate();
            btnEditarRol.Text = "roles_EditarRol".Translate();
            btnEliminarRol.Text = "roles_EliminarRol".Translate();
        }

        private void CargarRoles()
        {
            try
            {
                _familias = FamiliaService.GetAllFamilias();

                var tabla = new DataTable();
                tabla.Columns.Add("Nombre", typeof(string));
                tabla.Columns.Add("CantidadPermisos", typeof(int));
                tabla.Columns.Add("Permisos", typeof(string));

                foreach (var familia in _familias)
                {
                    var patentes = new List<Patente>();
                    ExtraerPatentes(familia.Accesos, patentes);

                    string nombresPatentes = string.Join(", ", patentes.Select(p => p.Nombre));

                    tabla.Rows.Add(
                        familia.Nombre,
                        patentes.Count,
                        nombresPatentes
                    );
                }

                dgvRoles.DataSource = tabla;

                // Configurar nombres de columnas con traducciones
                if (dgvRoles.Columns.Count > 0)
                {
                    dgvRoles.Columns["Nombre"].HeaderText = "roles_ColNombre".Translate();
                    dgvRoles.Columns["CantidadPermisos"].HeaderText = "roles_ColCantPermisos".Translate();
                    dgvRoles.Columns["CantidadPermisos"].FillWeight = 30;
                    dgvRoles.Columns["Permisos"].HeaderText = "roles_ColPermisos".Translate();
                    dgvRoles.Columns["Permisos"].FillWeight = 80;
                    dgvRoles.Columns["Nombre"].FillWeight = 40;
                }

                ConfigurarEstadoBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void ConfigurarEstadoBotones()
        {
            bool haySeleccion = dgvRoles.SelectedRows.Count > 0 && dgvRoles.Rows.Count > 0;
            btnEditarRol.Enabled = haySeleccion;
            btnEliminarRol.Enabled = haySeleccion;
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            ConfigurarEstadoBotones();
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmCrearRol())
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarRoles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear rol: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void btnEditarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.SelectedRows.Count == 0) return;

                int index = dgvRoles.SelectedRows[0].Index;
                if (index < 0 || index >= _familias.Count) return;

                var familiaSeleccionada = _familias[index];

                using (var frm = new FrmCrearRol(familiaSeleccionada))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarRoles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar rol: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.SelectedRows.Count == 0) return;

                int index = dgvRoles.SelectedRows[0].Index;
                if (index < 0 || index >= _familias.Count) return;

                var familiaSeleccionada = _familias[index];

                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el rol \"{familiaSeleccionada.Nombre}\"?\n\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    FamiliaService.EliminarFamilia(familiaSeleccionada.Id);

                    MessageBox.Show("Rol eliminado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltroNombre.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                CargarRoles();
                return;
            }

            try
            {
                _familias = FamiliaService.GetAllFamilias()
                    .Where(f => f.Nombre.ToLower().Contains(filtro))
                    .ToList();

                var tabla = new DataTable();
                tabla.Columns.Add("Nombre", typeof(string));
                tabla.Columns.Add("CantidadPermisos", typeof(int));
                tabla.Columns.Add("Permisos", typeof(string));

                foreach (var familia in _familias)
                {
                    var patentes = new List<Patente>();
                    ExtraerPatentes(familia.Accesos, patentes);
                    string nombresPatentes = string.Join(", ", patentes.Select(p => p.Nombre));
                    tabla.Rows.Add(familia.Nombre, patentes.Count, nombresPatentes);
                }

                dgvRoles.DataSource = tabla;

                if (dgvRoles.Columns.Count > 0)
                {
                    dgvRoles.Columns["Nombre"].HeaderText = "roles_ColNombre".Translate();
                    dgvRoles.Columns["CantidadPermisos"].HeaderText = "roles_ColCantPermisos".Translate();
                    dgvRoles.Columns["CantidadPermisos"].FillWeight = 30;
                    dgvRoles.Columns["Permisos"].HeaderText = "roles_ColPermisos".Translate();
                    dgvRoles.Columns["Permisos"].FillWeight = 80;
                    dgvRoles.Columns["Nombre"].FillWeight = 40;
                }

                ConfigurarEstadoBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Clear();
            CargarRoles();
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
    }
}
