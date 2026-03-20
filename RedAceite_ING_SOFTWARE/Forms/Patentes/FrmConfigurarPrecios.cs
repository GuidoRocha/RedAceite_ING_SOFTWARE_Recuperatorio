using BLL.Manifiesto;
using DOMAIN;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario para configurar los precios unitarios por tipo de residuo.
    /// Permite ver precios actuales y actualizarlos.
    /// </summary>
    public partial class FrmConfigurarPrecios : Form
    {
        private readonly ManifiestoService _manifiestoService;

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmConfigurarPrecios()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmConfigurarPrecios";

            ApplyTranslationsConfigurarPrecios();

            _manifiestoService = new ManifiestoService();
            this.Load += FrmConfigurarPrecios_Load;
        }

        private void ApplyTranslationsConfigurarPrecios()
        {
            this.Text = "Titulo_FrmConfigurarPrecios".Translate() + " - RedAceite";

            if (lblTitulo != null) lblTitulo.Text = "Precios_LblTitulo".Translate();
            if (grpAceite != null) grpAceite.Text = "Precios_GrpAceite".Translate();
            if (grpGrasa != null) grpGrasa.Text = "Precios_GrpGrasa".Translate();
            if (lblPrecioAceite != null) lblPrecioAceite.Text = "Precios_LblPrecio".Translate();
            if (lblPrecioGrasa != null) lblPrecioGrasa.Text = "Precios_LblPrecio".Translate();
            if (btnGuardarAceite != null) btnGuardarAceite.Text = "Precios_BtnGuardar".Translate();
            if (btnGuardarGrasa != null) btnGuardarGrasa.Text = "Precios_BtnGuardar".Translate();
            if (lblHistorial != null) lblHistorial.Text = "Precios_LblHistorial".Translate();
            if (btnCerrar != null) btnCerrar.Text = "Precios_BtnCerrar".Translate();
        }

        private void ApplyPreciosGridHeaders()
        {
            if (dgvHistorialPrecios == null || dgvHistorialPrecios.Columns == null) return;

            foreach (DataGridViewColumn col in dgvHistorialPrecios.Columns)
            {
                if (col == null || string.IsNullOrWhiteSpace(col.Name)) continue;

                string key = "Precios_Col_" + col.Name;
                col.HeaderText = key.Translate();
            }
        }

        /// <summary>
        /// Evento Load: carga los precios actuales.
        /// </summary>
        private void FrmConfigurarPrecios_Load(object sender, EventArgs e)
        {
            CargarPreciosActuales();
        }

        /// <summary>
        /// Carga los precios activos desde la BD y los muestra en los campos.
        /// </summary>
        private void CargarPreciosActuales()
        {
            try
            {
                var precioAceite = _manifiestoService.ObtenerPrecioActivoPorTipo("Aceite");
                var precioGrasa = _manifiestoService.ObtenerPrecioActivoPorTipo("Grasa");

                if (precioAceite != null)
                {
                    txtPrecioAceite.Text = precioAceite.PrecioUnitario.ToString("N2");
                    lblVigenciaAceite.Text = string.Format("Precios_VigenteDesde".Translate(),
                        precioAceite.FechaVigencia.ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    txtPrecioAceite.Text = "0.00";
                    lblVigenciaAceite.Text = "Precios_SinPrecio".Translate();
                }

                if (precioGrasa != null)
                {
                    txtPrecioGrasa.Text = precioGrasa.PrecioUnitario.ToString("N2");
                    lblVigenciaGrasa.Text = string.Format("Precios_VigenteDesde".Translate(),
                        precioGrasa.FechaVigencia.ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    txtPrecioGrasa.Text = "0.00";
                    lblVigenciaGrasa.Text = "Precios_SinPrecio".Translate();
                }

                // Cargar historial
                CargarHistorialPrecios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar precios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Carga el historial de precios en el DataGridView.
        /// </summary>
        private void CargarHistorialPrecios()
        {
            try
            {
                var precios = _manifiestoService.ObtenerTodosLosPrecios();
                dgvHistorialPrecios.DataSource = null;
                dgvHistorialPrecios.DataSource = precios;

                // Configurar columnas
                if (dgvHistorialPrecios.Columns.Count > 0)
                {
                    dgvHistorialPrecios.Columns["IdPrecio"].Visible = false;

                    if (dgvHistorialPrecios.Columns.Contains("TipoResiduo"))
                        dgvHistorialPrecios.Columns["TipoResiduo"].HeaderText = "Tipo Residuo";

                    if (dgvHistorialPrecios.Columns.Contains("PrecioUnitario"))
                    {
                        dgvHistorialPrecios.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                        dgvHistorialPrecios.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                    }

                    if (dgvHistorialPrecios.Columns.Contains("FechaVigencia"))
                    {
                        dgvHistorialPrecios.Columns["FechaVigencia"].HeaderText = "Fecha Vigencia";
                        dgvHistorialPrecios.Columns["FechaVigencia"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }

                    if (dgvHistorialPrecios.Columns.Contains("Activo"))
                        dgvHistorialPrecios.Columns["Activo"].HeaderText = "Activo";

                    ApplyPreciosGridHeaders();
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Guardar Precio Aceite.
        /// </summary>
        private void btnGuardarAceite_Click(object sender, EventArgs e)
        {
            GuardarPrecio("Aceite", txtPrecioAceite.Text);
        }

        /// <summary>
        /// Boton Guardar Precio Grasa.
        /// </summary>
        private void btnGuardarGrasa_Click(object sender, EventArgs e)
        {
            GuardarPrecio("Grasa", txtPrecioGrasa.Text);
        }

        /// <summary>
        /// Guarda un nuevo precio para un tipo de residuo.
        /// </summary>
        private void GuardarPrecio(string tipoResiduo, string textoPrecio)
        {
            try
            {
                if (!decimal.TryParse(textoPrecio, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Ingrese un precio valido (mayor o igual a 0).", "Validacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Confirma actualizar el precio de {tipoResiduo} a ${precio:N2}?",
                    "Confirmar cambio de precio",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                _manifiestoService.ActualizarPrecio(tipoResiduo, precio);

                MessageBox.Show($"Precio de {tipoResiduo} actualizado exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPreciosActuales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar precio: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Cerrar.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
