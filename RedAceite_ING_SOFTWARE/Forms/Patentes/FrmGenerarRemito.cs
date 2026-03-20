using SERVICES.Facade;
using DOMAIN;
using BLL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario para la generacion de remitos de recoleccion de residuos.
    /// Permite ingresar los datos del generador y los detalles del residuo a recolectar.
    /// </summary>
    public partial class FrmGenerarRemito : Form
    {
        private readonly RemitoService _remitoService;
        private readonly ProveedorService _proveedorService;

        public FrmGenerarRemito()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmGenerarRemito";
            _remitoService = new RemitoService();
            _proveedorService = new ProveedorService();

            // Suscribirse al evento Load
            this.Load += FrmGenerarRemito_Load;

            ConfigurarComboBoxes();
            CargarProveedoresHabilitados();
            MostrarFechaActual();
            ConfigurarEstadoInicial();
        }

        private void FrmGenerarRemito_Load(object sender, EventArgs e)
        {
            // (FASE 1) Sin traduccion automotica
        }

        /// <summary>
        /// Configura el estado inicial de los controles del formulario.
        /// </summary>
        private void ConfigurarEstadoInicial()
        {
            // Por defecto, el checkbox de "Se requiere envio" esta desmarcado
            chkRequiereEnvio.Checked = false;

            // Deshabilitar los campos de envio al iniciar el formulario
            HabilitarCamposEnvio(false);
        }

        /// <summary>
        /// Habilita o deshabilita los campos relacionados con el envio.
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
            // Verificar si hay un proveedor seleccionado (SelectedIndex >= 0 significa que hay seleccion valida)
            if (cmbNombreGenerador.SelectedItem == null || cmbNombreGenerador.SelectedIndex < 0)
            {
                // Limpiar el campo si no hay seleccion valida
                txtDomicilioPlanta.Clear();
                return;
            }

            try
            {
                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;

                // Autocompletar el domicilio de la planta con la direccion del proveedor
                txtDomicilioPlanta.Text = proveedorSeleccionado.Direccion ?? string.Empty;

                // Si el checkbox de envio esta marcado, autocompletar tambien esos campos
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
        /// Autocompleta los datos de envio del proveedor seleccionado.
        /// </summary>
        private void AutocompletarDatosEnvio()
        {
            // Verificar si hay un proveedor seleccionado (SelectedIndex >= 0 significa que hay seleccion valida)
            if (cmbNombreGenerador.SelectedItem == null || cmbNombreGenerador.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;

                // Autocompletar los campos de envio
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
        /// Maneja el evento de cambio de estado del checkbox de "Se requiere envio".
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
            cmbEstado.Items.Add("L\u00edquido");
            cmbEstado.Items.Add("S\u00f3lido");
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
                    cmbNombreGenerador.ValueMember = "IdProveedor"; // Valor interno sera el ID

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
        /// Dibuja una linea superior en el panel de firma.
        /// </summary>
        private void pnlLineaFirma_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar solo la linea superior para simular el espacio de firma
            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, pnlLineaFirma.Width, 0);
            }
        }

        /// <summary>
        /// Maneja el cambio de seleccion en el ComboBox de Nombre del Generador.
        /// Autocompleta los datos del proveedor seleccionado.
        /// </summary>
        private void cmbNombreGenerador_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutocompletarDatosProveedor();
            
            // Habilitar o deshabilitar el boton de editar segun si hay un proveedor seleccionado
            ActualizarEstadoBotonEditar();
        }

        /// <summary>
        /// Actualiza el estado del boton Editar Proveedor segun la seleccion actual.
        /// El boton solo se habilita cuando hay un proveedor valido seleccionado.
        /// </summary>
        private void ActualizarEstadoBotonEditar()
        {
            // Habilitar el boton solo si hay un proveedor seleccionado
            bool hayProveedorSeleccionado = cmbNombreGenerador.SelectedItem != null && 
                                            cmbNombreGenerador.SelectedIndex >= 0;
            
            btnEditarProveedor.Enabled = hayProveedorSeleccionado;
            
            // Log para debugging
            if (hayProveedorSeleccionado)
            {
                var proveedor = (Proveedor)cmbNombreGenerador.SelectedItem;
                LoggerService.WriteLog($"Boton editar habilitado para proveedor: {proveedor.Nombre}",
                    System.Diagnostics.TraceLevel.Verbose);
            }
        }

        /// <summary>
        /// Maneja el cambio de seleccion en el ComboBox de Tipo de Residuo.
        /// Establece automoticamente el estado segun el tipo seleccionado.
        /// </summary>
        private void cmbTipoResiduo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Establecer el estado por defecto segun el tipo de residuo
            if (cmbTipoResiduo.SelectedItem != null)
            {
                if (cmbTipoResiduo.SelectedItem.ToString() == "Aceite")
                {
                    cmbEstado.SelectedItem = "L\u00edquido";
                }
                else if (cmbTipoResiduo.SelectedItem.ToString() == "Grasa")
                {
                    cmbEstado.SelectedItem = "S\u00f3lido";
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic del boton Generar Remito.
        /// Valida los datos ingresados y genera el remito en la base de datos.
        /// </summary>
        private void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos esten completos
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

                // Validar que la cantidad sea un numero valido
                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un numero valido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                if (cmbEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                // Validar campos de envio solo si el checkbox esta marcado
                if (chkRequiereEnvio.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCuit.Text))
                    {
                        MessageBox.Show("Debe ingresar el CUIT cuando se requiere envio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCuit.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtNombreFantasia.Text))
                    {
                        MessageBox.Show("Debe ingresar el nombre de fantasia cuando se requiere envio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNombreFantasia.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Debe ingresar la direccion cuando se requiere envio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDireccion.Focus();
                        return;
                    }
                }

                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;
                string nombreGenerador = proveedorSeleccionado.Nombre;

                // **FIX: Si NO se requiere envio, usar los datos del proveedor seleccionado**
                string cuitFinal = chkRequiereEnvio.Checked ? txtCuit.Text.Trim() : proveedorSeleccionado.CUIT;
                string nombreFantasiaFinal = chkRequiereEnvio.Checked ? txtNombreFantasia.Text.Trim() : proveedorSeleccionado.RazonSocial;
                string direccionFinal = chkRequiereEnvio.Checked ? txtDireccion.Text.Trim() : proveedorSeleccionado.Direccion;

                // Si todas las validaciones pasan, proceder a generar el remito
                // Llamar al servicio BLL.RemitoService para generar el remito
                Guid idRemito = _remitoService.GenerarRemito(
                    nombreGenerador,
                    txtDomicilioPlanta.Text.Trim(),
                    cmbTipoResiduo.SelectedItem.ToString(),
                    cantidad,
                    cmbEstado.SelectedItem.ToString(),
                    cuitFinal,
                    nombreFantasiaFinal,
                    direccionFinal
                );

                // Registrar el evento en el log
                LoggerService.WriteLog($"Se genero el remito con ID: {idRemito} para el generador {nombreGenerador}.",
                    System.Diagnostics.TraceLevel.Info);

                MessageBox.Show($"Remito generado exitosamente.\nID del Remito: {idRemito}", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Indicar al formulario padre que se creo exitosamente y cerrar
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Registrar el error en el log
                MessageBox.Show($"Ocurrio un error al generar el remito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Actualizar la fecha despues de limpiar
            MostrarFechaActual();
        }

        /// <summary>
        /// Maneja el evento de clic del boton Cancelar.
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Maneja el evento de clic del boton Agregar Proveedor (+).
        /// Abre el formulario de alta de proveedor y actualiza la lista al finalizar.
        /// </summary>
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                LoggerService.WriteLog("Usuario solicito agregar nuevo proveedor desde FrmGenerarRemito",
                    System.Diagnostics.TraceLevel.Info);

                // Crear instancia del formulario de alta de proveedor
                using (var frmAlta = new FrmAltaProveedor())
                {
                    // Mostrar el formulario como dialogo modal
                    var resultado = frmAlta.ShowDialog();

                    // Si el proveedor se creo exitosamente, recargar la lista
                    if (resultado == DialogResult.OK)
                    {
                        // Obtener el ID del proveedor recien creado
                        Guid idProveedorNuevo = frmAlta.IdProveedorCreado;

                        // Recargar la lista de proveedores
                        RecargarProveedoresYSeleccionar(idProveedorNuevo);

                        LoggerService.WriteLog($"Proveedor {idProveedorNuevo} agregado y preseleccionado desde FrmGenerarRemito",
                            System.Diagnostics.TraceLevel.Info);
                    }
                    else
                    {
                        LoggerService.WriteLog("Usuario cancelo la creacion de proveedor",
                            System.Diagnostics.TraceLevel.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del boton Editar Proveedor (??).
        /// Abre el formulario de modificacion con el proveedor seleccionado y actualiza la lista al finalizar.
        /// </summary>
        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un proveedor seleccionado
                if (cmbNombreGenerador.SelectedItem == null || cmbNombreGenerador.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor para editarlo.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el proveedor seleccionado
                var proveedorSeleccionado = (Proveedor)cmbNombreGenerador.SelectedItem;
                Guid idProveedorAEditar = proveedorSeleccionado.IdProveedor;

                LoggerService.WriteLog($"Usuario solicito editar proveedor: {proveedorSeleccionado.Nombre} (ID: {idProveedorAEditar})",
                    System.Diagnostics.TraceLevel.Info);

                // Crear instancia del formulario de modificacion pasando el ID del proveedor
                using (var frmModificar = new FrmModificarProveedor(idProveedorAEditar))
                {
                    // Mostrar el formulario como dialogo modal
                    var resultado = frmModificar.ShowDialog();

                    // Si el proveedor se modifico exitosamente, recargar la lista
                    if (resultado == DialogResult.OK)
                    {
                        // Recargar la lista de proveedores y mantener seleccionado el que se edito
                        RecargarProveedoresYSeleccionar(idProveedorAEditar);

                        LoggerService.WriteLog($"Proveedor {proveedorSeleccionado.Nombre} modificado exitosamente desde FrmGenerarRemito",
                            System.Diagnostics.TraceLevel.Info);

                        // Mostrar mensaje de confirmacion
                        MessageBox.Show($"El proveedor '{proveedorSeleccionado.Nombre}' ha sido actualizado correctamente.",
                            "Modificacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        LoggerService.WriteLog($"Usuario cancelo la modificacion del proveedor {proveedorSeleccionado.Nombre}",
                            System.Diagnostics.TraceLevel.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Recarga la lista de proveedores y preselecciona el proveedor especificado.
        /// </summary>
        /// <param name="idProveedorASeleccionar">ID del proveedor a preseleccionar.</param>
        private void RecargarProveedoresYSeleccionar(Guid idProveedorASeleccionar)
        {
            try
            {
                LoggerService.WriteLog($"Iniciando recarga de proveedores. ID a preseleccionar: {idProveedorASeleccionar}",
                    System.Diagnostics.TraceLevel.Verbose);

                // Obtener proveedores activos actualizados
                var proveedoresActivos = _proveedorService.ObtenerProveedoresActivos();

                if (proveedoresActivos != null && proveedoresActivos.Count > 0)
                {
                    LoggerService.WriteLog($"Se cargaron {proveedoresActivos.Count} proveedores activos",
                        System.Diagnostics.TraceLevel.Verbose);

                    // Actualizar el DataSource del ComboBox
                    cmbNombreGenerador.DataSource = null; // Limpiar primero
                    cmbNombreGenerador.DataSource = proveedoresActivos;
                    cmbNombreGenerador.DisplayMember = "Nombre";
                    cmbNombreGenerador.ValueMember = "IdProveedor";

                    // Buscar y seleccionar el proveedor recion creado/modificado
                    var proveedorASeleccionar = proveedoresActivos.FirstOrDefault(p => p.IdProveedor == idProveedorASeleccionar);
                    
                    if (proveedorASeleccionar != null)
                    {
                        cmbNombreGenerador.SelectedItem = proveedorASeleccionar;
                        
                        LoggerService.WriteLog($"Proveedor '{proveedorASeleccionar.Nombre}' preseleccionado automoticamente",
                            System.Diagnostics.TraceLevel.Info);
                    }
                    else
                    {
                        // Si no se encuentra, seleccionar el primero
                        cmbNombreGenerador.SelectedIndex = 0;
                        
                        LoggerService.WriteLog($"Proveedor con ID {idProveedorASeleccionar} no encontrado. Seleccionado el primer proveedor de la lista.",
                            System.Diagnostics.TraceLevel.Warning);
                    }
                }
                else
                {
                    LoggerService.WriteLog("No se encontraron proveedores activos despues de recargar",
                        System.Diagnostics.TraceLevel.Warning);
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog($"Error al recargar proveedores: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw;
            }
        }
    }
}