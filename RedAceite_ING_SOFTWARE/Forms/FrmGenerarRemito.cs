using SERVICES.Facade;
using DOMAIN;
using BLL;
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
    /// Formulario para la generación de remitos de recolección de residuos.
    /// Permite ingresar los datos del generador y los detalles del residuo a recolectar.
    /// </summary>
    public partial class FrmGenerarRemito : Form
    {
        private readonly RemitoService _remitoService;
        private readonly ProveedorService _proveedorService;

        public FrmGenerarRemito()
        {
            InitializeComponent();
            _remitoService = new RemitoService();
            _proveedorService = new ProveedorService();
            ConfigurarComboBoxes();
            CargarProveedoresHabilitados();
            MostrarFechaActual();
            ConfigurarEstadoInicial();
        }

        /// <summary>
        /// Configura el estado inicial de los controles del formulario.
        /// </summary>
        private void ConfigurarEstadoInicial()
        {
            // Por defecto, el checkbox de "Se requiere envío" está desmarcado
            chkRequiereEnvio.Checked = false;

            // Deshabilitar los campos de envío al iniciar el formulario
            HabilitarCamposEnvio(false);
        }

        /// <summary>
        /// Habilita o deshabilita los campos relacionados con el envío.
        /// </summary>
        /// <param name="habilitar">True para habilitar, False para deshabilitar.</param>
        private void HabilitarCamposEnvio(bool habilitar)
        {
            txtCuit.Enabled = habilitar;
            txtNombreFantasia.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;

            // Si se deshabilitan, limpiar los campos
            if (!habilitar)
            {
                txtCuit.Clear();
                txtNombreFantasia.Clear();
                txtDireccion.Clear();
            }
            else
            {
                // Si se habilitan y hay un proveedor seleccionado, autocompletar
                AutocompletarDatosEnvio();
            }
        }

        /// <summary>
        /// Autocompleta los datos del proveedor seleccionado en los campos correspondientes.
        /// </summary>
        private void AutocompletarDatosProveedor()
        {
            // Verificar si hay un proveedor seleccionado (SelectedIndex >= 0 significa que hay selección válida)
            if (cmbNombreGenerador.SelectedItem == null || cmbNombreGenerador.SelectedIndex < 0)
            {
                // Limpiar el campo si no hay selección válida
                txtDomicilioPlanta.Clear();
                return;
            }

            try
            {
                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;

                // Autocompletar el domicilio de la planta con la dirección del proveedor
                txtDomicilioPlanta.Text = proveedorSeleccionado.Direccion ?? string.Empty;

                // Si el checkbox de envío está marcado, autocompletar también esos campos
                if (chkRequiereEnvio.Checked)
                {
                    AutocompletarDatosEnvio();
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Autocompleta los datos de envío del proveedor seleccionado.
        /// </summary>
        private void AutocompletarDatosEnvio()
        {
            // Verificar si hay un proveedor seleccionado (SelectedIndex >= 0 significa que hay selección válida)
            if (cmbNombreGenerador.SelectedItem == null || cmbNombreGenerador.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;

                // Autocompletar los campos de envío
                txtCuit.Text = proveedorSeleccionado.CUIT ?? string.Empty;
                txtNombreFantasia.Text = proveedorSeleccionado.RazonSocial ?? string.Empty;
                txtDireccion.Text = proveedorSeleccionado.Email ?? string.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de estado del checkbox de "Se requiere envío".
        /// </summary>
        private void chkRequiereEnvio_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCamposEnvio(chkRequiereEnvio.Checked);
        }

        /// <summary>
        /// Configura los ComboBoxes con las opciones disponibles.
        /// </summary>
        private void ConfigurarComboBoxes()
        {
            // Configurar ComboBox de Tipo de Residuo
            cmbTipoResiduo.Items.Add("Aceite");
            cmbTipoResiduo.Items.Add("Grasa");
            cmbTipoResiduo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar ComboBox de Estado
            cmbEstado.Items.Add("Líquido");
            cmbEstado.Items.Add("Sólido");
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar ComboBox de Nombre del Generador
            cmbNombreGenerador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Carga los proveedores habilitados en el ComboBox de Nombre del Generador.
        /// </summary>
        private void CargarProveedoresHabilitados()
        {
            try
            {
                // Obtener solo los proveedores activos/habilitados
                var proveedoresActivos = _proveedorService.ObtenerProveedoresActivos();

                // Limpiar el ComboBox antes de cargar
                cmbNombreGenerador.Items.Clear();

                // Verificar si hay proveedores disponibles
                if (proveedoresActivos != null && proveedoresActivos.Count > 0)
                {
                    // Configurar el ComboBox con los proveedores
                    cmbNombreGenerador.DataSource = proveedoresActivos;
                    cmbNombreGenerador.DisplayMember = "Nombre"; // Mostrar el nombre del proveedor
                    cmbNombreGenerador.ValueMember = "IdProveedor"; // Valor interno será el ID

                    // Deseleccionar por defecto - esto es importante para evitar que se autocomplete al cargar
                    cmbNombreGenerador.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No hay proveedores habilitados en el sistema. Por favor, habilite al menos un proveedor antes de generar un remito.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Muestra la fecha actual en el formato DD/MM/AAAA.
        /// </summary>
        private void MostrarFechaActual()
        {
            // Mostrar la fecha actual en formato dd/MM/yyyy
            lblFechaEntrega.Text = $"Fecha de Entrega: {DateTime.Now:dd/MM/yyyy}";
        }

        /// <summary>
        /// Dibuja una línea superior en el panel de firma.
        /// </summary>
        private void pnlLineaFirma_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar solo la línea superior para simular el espacio de firma
            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlLineaFirma.Width, 0);
            }
        }

        /// <summary>
        /// Maneja el cambio de selección en el ComboBox de Nombre del Generador.
        /// Autocompleta los datos del proveedor seleccionado.
        /// </summary>
        private void cmbNombreGenerador_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutocompletarDatosProveedor();
        }

        /// <summary>
        /// Maneja el cambio de selección en el ComboBox de Tipo de Residuo.
        /// Establece automáticamente el estado según el tipo seleccionado.
        /// </summary>
        private void cmbTipoResiduo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Establecer el estado por defecto según el tipo de residuo
            if (cmbTipoResiduo.SelectedItem != null)
            {
                if (cmbTipoResiduo.SelectedItem.ToString() == "Aceite")
                {
                    cmbEstado.SelectedItem = "Líquido";
                }
                else if (cmbTipoResiduo.SelectedItem.ToString() == "Grasa")
                {
                    cmbEstado.SelectedItem = "Sólido";
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón Generar Remito.
        /// Valida los datos ingresados y genera el remito en la base de datos.
        /// </summary>
        private void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (cmbNombreGenerador.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un proveedor como generador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNombreGenerador.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDomicilioPlanta.Text))
                {
                    MessageBox.Show("Debe ingresar el domicilio de la planta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDomicilioPlanta.Focus();
                    return;
                }

                if (cmbTipoResiduo.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar el tipo de residuo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoResiduo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Debe ingresar la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                // Validar que la cantidad sea un número válido
                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                // Validar campos de envío solo si el checkbox está marcado
                if (chkRequiereEnvio.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCuit.Text))
                    {
                        MessageBox.Show("Debe ingresar el CUIT cuando se requiere envío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCuit.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtNombreFantasia.Text))
                    {
                        MessageBox.Show("Debe ingresar el nombre de fantasía cuando se requiere envío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreFantasia.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Debe ingresar la dirección cuando se requiere envío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                        return;
                    }
                }

                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;
                string nombreGenerador = proveedorSeleccionado.Nombre;

                // Si todas las validaciones pasan, proceder a generar el remito
                // Llamar al servicio BLL.RemitoService para generar el remito
                Guid idRemito = _remitoService.GenerarRemito(
                    nombreGenerador,
                    txtDomicilioPlanta.Text.Trim(),
                    cmbTipoResiduo.SelectedItem.ToString(),
                    cantidad,
                    cmbEstado.SelectedItem.ToString(),
                    txtCuit.Text.Trim(),
                    txtNombreFantasia.Text.Trim(),
                    txtDireccion.Text.Trim()
                );

                // Registrar el evento en el log
                LoggerService.WriteLog($"Se generó el remito con ID: {idRemito} para el generador {nombreGenerador}.",
                    System.Diagnostics.TraceLevel.Info);

                MessageBox.Show($"Remito generado exitosamente.\nID del Remito: {idRemito}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos después de generar el remito
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Registrar el error en el log
                MessageBox.Show($"Ocurrió un error al generar el remito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiarFormulario()
        {
            cmbNombreGenerador.SelectedIndex = -1;
            txtDomicilioPlanta.Clear();
            cmbTipoResiduo.SelectedIndex = -1;
            txtCantidad.Clear();
            cmbEstado.SelectedIndex = -1;
            chkRequiereEnvio.Checked = false;
            txtCuit.Clear();
            txtNombreFantasia.Clear();
            txtDireccion.Clear();

            // Actualizar la fecha después de limpiar
            MostrarFechaActual();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Cancelar.
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}