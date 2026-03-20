using BLL.Remito;
using SERVICES.Facade;
using System;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario para modificar un remito existente en el sistema.
    /// Permite actualizar cantidad, estado fisico, domicilio, CUIT, nombre fantasia y direccion.
    /// Los campos fecha, generador, tipo residuo y transportista no son editables.
    /// </summary>
    public partial class FrmModificarRemito : Form
    {
        private readonly Guid _idRemito;
        private DOMAIN.Remito _remitoOriginal;
        private decimal _cantidadOriginal;
        private string _estadoOriginal;
        private readonly RemitoGestionService _remitoGestionService;

        /// <summary>
        /// Constructor que recibe el ID del remito a modificar.
        /// </summary>
        /// <param name="idRemito">ID del remito a modificar.</param>
        public FrmModificarRemito(Guid idRemito)
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmModificarRemito";
            _idRemito = idRemito;
            _remitoGestionService = new RemitoGestionService();

            CargarDatosRemito();
        }

        /// <summary>
        /// Carga los datos del remito desde la base de datos y los muestra en el formulario.
        /// </summary>
        private void CargarDatosRemito()
        {
            try
            {
                _remitoOriginal = _remitoGestionService.ObtenerRemitoPorId(_idRemito);

                if (_remitoOriginal == null)
                {
                    MessageBox.Show("El remito no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_remitoOriginal.EstadoRemito == "Anulado")
                {
                    MessageBox.Show("No se puede modificar un remito anulado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardar.Enabled = false;
                }

                // Guardar valores originales para ajuste de inventario
                _cantidadOriginal = _remitoOriginal.Cantidad;
                _estadoOriginal = _remitoOriginal.Estado;

                // Campos read-only
                txtFechaCreacion.Text = _remitoOriginal.FechaCreacion.ToString("dd/MM/yyyy HH:mm");
                txtNombreGenerador.Text = _remitoOriginal.NombreGenerador;
                txtTipoResiduo.Text = _remitoOriginal.TipoResiduo;
                txtTransportista.Text = _remitoOriginal.NombreTransportista;

                // Campos editables
                txtCantidad.Text = _remitoOriginal.Cantidad.ToString();
                txtDomicilioPlanta.Text = _remitoOriginal.DomicilioPlanta;
                txtCUIT.Text = _remitoOriginal.Cuit;
                txtNombreFantasia.Text = _remitoOriginal.NombreFantasia;
                txtDireccion.Text = _remitoOriginal.Direccion;

                // Seleccionar estado fisico en el combo
                int index = cmbEstadoFisico.FindStringExact(_remitoOriginal.Estado);
                if (index >= 0)
                {
                    cmbEstadoFisico.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del remito: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
                this.Close();
            }
        }

        /// <summary>
        /// Valida los campos del formulario antes de guardar.
        /// </summary>
        /// <returns>True si todos los campos son validos.</returns>
        private bool ValidarCampos()
        {
            // Validar cantidad
            decimal cantidad;
            if (!decimal.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un numero mayor a 0.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            // Validar estado fisico
            if (cmbEstadoFisico.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un estado fisico.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstadoFisico.Focus();
                return false;
            }

            // Validar domicilio planta
            if (string.IsNullOrWhiteSpace(txtDomicilioPlanta.Text))
            {
                MessageBox.Show("El domicilio de planta es obligatorio.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomicilioPlanta.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Maneja el evento de clic del boton Guardar.
        /// Valida y actualiza los datos del remito usando UnitOfWork.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                // Actualizar los campos editables en el objeto remito
                _remitoOriginal.Cantidad = decimal.Parse(txtCantidad.Text.Trim());
                _remitoOriginal.Estado = cmbEstadoFisico.SelectedItem.ToString();
                _remitoOriginal.DomicilioPlanta = txtDomicilioPlanta.Text.Trim();
                _remitoOriginal.Cuit = txtCUIT.Text.Trim();
                _remitoOriginal.NombreFantasia = txtNombreFantasia.Text.Trim();
                _remitoOriginal.Direccion = txtDireccion.Text.Trim();

                // Modificar usando el servicio (con UnitOfWork internamente)
                _remitoGestionService.ModificarRemito(
                    _remitoOriginal, _cantidadOriginal, _estadoOriginal);

                LoggerService.WriteLog(
                    $"Remito modificado: {_remitoOriginal.NombreGenerador} (ID: {_idRemito})",
                    System.Diagnostics.TraceLevel.Info);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el remito: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del boton Cancelar.
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
