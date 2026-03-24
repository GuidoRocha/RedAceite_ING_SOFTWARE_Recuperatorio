using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmCrearRol : Form
    {
        private Familia _familiaEditar;
        private List<Patente> _todasLasPatentes;

        /// <summary>
        /// Constructor para modo creación.
        /// </summary>
        public FrmCrearRol()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmCrearRol";
            this.Load += FrmCrearRol_Load;
        }

        /// <summary>
        /// Constructor para modo edición.
        /// </summary>
        /// <param name="familia">Familia a editar (con sus patentes cargadas).</param>
        public FrmCrearRol(Familia familia) : this()
        {
            _familiaEditar = familia;
        }

        private void FrmCrearRol_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar todas las patentes disponibles
                _todasLasPatentes = FamiliaService.GetAllPatentes();

                cbPatentes.Items.Clear();
                cbPatentes.DisplayMember = "Nombre";

                foreach (var patente in _todasLasPatentes)
                {
                    cbPatentes.Items.Add(patente);
                }

                // Si es modo edición, precargar datos
                if (_familiaEditar != null)
                {
                    lblTituloRol.Text = "Editar Rol";
                    CrearRol.Text = "Guardar";
                    txtNombreFamilia.Text = _familiaEditar.Nombre;

                    // Marcar las patentes que ya tiene la familia
                    var patentesExistentes = new List<Patente>();
                    ExtraerPatentes(_familiaEditar.Accesos, patentesExistentes);

                    for (int i = 0; i < _todasLasPatentes.Count; i++)
                    {
                        if (patentesExistentes.Any(p => p.Id == _todasLasPatentes[i].Id))
                        {
                            cbPatentes.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                var nombreFamilia = txtNombreFamilia.Text.Trim();
                if (string.IsNullOrEmpty(nombreFamilia))
                {
                    MessageBox.Show("El nombre del rol no puede estar vacío.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var patentesSeleccionadas = new List<Patente>();
                foreach (var item in cbPatentes.CheckedItems)
                {
                    patentesSeleccionadas.Add((Patente)item);
                }

                if (patentesSeleccionadas.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos una patente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_familiaEditar != null)
                {
                    // Modo edición
                    _familiaEditar.Nombre = nombreFamilia;
                    _familiaEditar.Accesos.Clear();
                    foreach (var patente in patentesSeleccionadas)
                    {
                        _familiaEditar.Add(patente);
                    }

                    FamiliaService.ActualizarFamilia(_familiaEditar);
                    MessageBox.Show("Rol actualizado con éxito.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modo creación
                    FamiliaService.CrearFamiliaConPatentes(nombreFamilia, patentesSeleccionadas);
                    MessageBox.Show("Rol creado con éxito.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarTodas_Click(object sender, EventArgs e)
        {
            bool todasMarcadas = cbPatentes.CheckedItems.Count == cbPatentes.Items.Count;

            for (int i = 0; i < cbPatentes.Items.Count; i++)
            {
                cbPatentes.SetItemChecked(i, !todasMarcadas);
            }
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
