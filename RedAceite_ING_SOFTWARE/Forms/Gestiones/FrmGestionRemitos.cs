using BLL.Remito;
using DOMAIN;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario principal para la gesti�n de remitos.
    /// Permite listar, filtrar, visualizar y descargar PDFs de remitos generados.
    /// </summary>
    public partial class FrmGestionRemitos : Form
    {
        private readonly RemitoGestionService _remitoGestionService;
        private bool _columnsConfigured = false;

        public FrmGestionRemitos()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmGestionRemitos";

            ApplyTranslationsGestionRemitos();

            _remitoGestionService = new RemitoGestionService();

            // Configurar DataGridView para tener control total sobre las columnas
            dgvRemitos.AutoGenerateColumns = true;

            // Suscribirse a los eventos del DataGridView
            dgvRemitos.CellFormatting += dgvRemitos_CellFormatting;
            dgvRemitos.DataBindingComplete += dgvRemitos_DataBindingComplete;
            dgvRemitos.SelectionChanged += dgvRemitos_SelectionChanged;
            dgvRemitos.CellContentClick += dgvRemitos_CellContentClick;

            // Suscribirse a eventos de filtros
            btnFiltrar.Click += btnFiltrar_Click;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;

            // Suscribirse a eventos de botones de acci�n
            btnAgregarRemito.Click += btnAgregarRemito_Click;
            btnModificarRemito.Click += btnModificarRemito_Click;
            btnEliminarRemito.Click += btnEliminarRemito_Click;

            // Suscribirse al evento KeyDown del ComboBox para manejar Delete/Backspace
            cmbTipoResiduo.KeyDown += cmbTipoResiduo_KeyDown;

            // Configurar estado inicial de los botones
            ConfigurarEstadoBotones();

            // Inicializar combo de tipo de residuo
            InicializarComboTipoResiduo();

            // Cargar remitos al final
            CargarRemitos();
        }

        private void ApplyTranslationsGestionRemitos()
        {
            this.Text = $"RedAceite - {"Titulo_FrmGestionRemitos".Translate()}";

            if (lblFechaInicio != null) lblFechaInicio.Text = "Remitos_LblFechaInicio".Translate();
            if (lblFechaFin != null) lblFechaFin.Text = "Remitos_LblFechaFin".Translate();
            if (lblFiltroCUIT != null) lblFiltroCUIT.Text = "Remitos_LblFiltroCUIT".Translate();
            if (lblFiltroTipoResiduo != null) lblFiltroTipoResiduo.Text = "Remitos_LblFiltroTipoResiduo".Translate();

            if (btnFiltrar != null) btnFiltrar.Text = "Remitos_BtnFiltrar".Translate();
            if (btnLimpiarFiltros != null) btnLimpiarFiltros.Text = "Remitos_BtnLimpiarFiltros".Translate();

            if (btnAgregarRemito != null) btnAgregarRemito.Text = "Remitos_BtnAgregar".Translate();
            if (btnModificarRemito != null) btnModificarRemito.Text = "Remitos_BtnModificar".Translate();
            if (btnEliminarRemito != null) btnEliminarRemito.Text = "Remitos_BtnEliminar".Translate();
        }

        private void ApplyRemitosGridHeaders()
        {
            if (dgvRemitos == null || dgvRemitos.Columns == null) return;

            foreach (DataGridViewColumn col in dgvRemitos.Columns)
            {
                if (col == null || string.IsNullOrWhiteSpace(col.Name)) continue;

                string key = "Remitos_Col_" + col.Name;
                col.HeaderText = key.Translate();
            }
        }

        /// <summary>
        /// Inicializa el ComboBox de tipo de residuo con las opciones disponibles.
        /// </summary>
        private void InicializarComboTipoResiduo()
        {
            cmbTipoResiduo.Items.Clear();
            cmbTipoResiduo.Items.Add("Todos"); // Primera opci�n para mostrar todos
            cmbTipoResiduo.Items.Add("Aceite");
            cmbTipoResiduo.Items.Add("Grasa");
            cmbTipoResiduo.SelectedIndex = 0; // Seleccionar "Todos" por defecto

            // Agregar tooltip explicativo
            var tooltip = new ToolTip();
            tooltip.SetToolTip(cmbTipoResiduo, "Presione Delete o Backspace para volver a 'Todos'");
        }

        /// <summary>
        /// Maneja el evento KeyDown del ComboBox de tipo de residuo.
        /// Permite borrar la selecci�n con Delete o Backspace.
        /// </summary>
        private void cmbTipoResiduo_KeyDown(object sender, KeyEventArgs e)
        {
            // Si se presiona Delete o Backspace, resetear a "Todos"
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                cmbTipoResiduo.SelectedIndex = 0; // Volver a "Todos"
                e.Handled = true; // Marcar el evento como manejado
                e.SuppressKeyPress = true; // Suprimir el sonido de la tecla
            }
        }

        /// <summary>
        /// Carga todos los remitos con su informaci�n de PDF en el DataGridView.
        /// </summary>
        private void CargarRemitos()
        {
            try
            {
                var remitos = _remitoGestionService.ObtenerRemitosParaGestion();
                dgvRemitos.DataSource = remitos;

                // **VERIFICAR SI HAY REMITOS ALTERADOS Y AVISAR AL USUARIO**
                int countAlterados = remitos.Count(r => r.IntegridadEstado == "ALTERADO");
                if (countAlterados > 0)
                {
                    MessageBox.Show(
                        $"?? ALERTA DE SEGURIDAD ??\n\n" +
                        $"Se detectaron {countAlterados} remito(s) con datos ALTERADOS.\n\n" +
                        $"Los registros alterados aparecen marcados en ROJO en la grilla.\n" +
                        $"Esto indica que los datos fueron modificados fuera del sistema.\n\n" +
                        $"Por favor, revise inmediatamente los remitos marcados.",
                        "Alerta de Integridad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    LoggerService.WriteLog(
                        $"Se mostr� alerta al usuario: {countAlterados} remito(s) alterado(s) detectados en gesti�n de remitos.",
                        System.Diagnostics.TraceLevel.Warning);
                }
            }
            catch (Exception ex)
            {
                var detalle = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                MessageBox.Show(
                    $"Error al cargar remitos: {ex.Message}\n\nDetalle: {detalle}\n\n{ex}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando el DataGridView ha terminado de enlazar los datos.
        /// Configura las columnas despu�s de que el grid haya cargado los datos.
        /// </summary>
        private void dgvRemitos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigurarColumnas();
            ApplyRemitosGridHeaders();
        }

        /// <summary>
        /// Evento que se dispara al formatear cada celda del DataGridView.
        /// Pinta las filas de remitos anulados en gris oscuro.
        /// </summary>
        private void dgvRemitos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvRemitos.Rows.Count)
                {
                    var row = dgvRemitos.Rows[e.RowIndex];
                    var remito = row.DataBoundItem as RemitoGestionDto;

                    if (remito != null)
                    {
                        // Formatear el CUIT para mostrarlo con guiones (XX-XXXXXXXX-X)
                        if (dgvRemitos.Columns[e.ColumnIndex].Name == "Cuit" && e.Value != null)
                        {
                            string cuit = e.Value.ToString();
                            if (!cuit.Contains("-") && cuit.Length == 11)
                            {
                                e.Value = $"{cuit.Substring(0, 2)}-{cuit.Substring(2, 8)}-{cuit.Substring(10, 1)}";
                                e.FormattingApplied = true;
                            }
                        }

                        // **PRIORIDAD 1: REMITOS ALTERADOS (Fondo rojo claro)**
                        if (remito.IntegridadEstado == "ALTERADO")
                        {
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            e.CellStyle.SelectionBackColor = Color.IndianRed;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        // **PRIORIDAD 2: REMITOS ANULADOS (Fondo gris)**
                        else if (remito.EstaAnulado)
                        {
                            e.CellStyle.BackColor = Color.LightGray;
                            e.CellStyle.ForeColor = Color.DarkGray;
                            e.CellStyle.SelectionBackColor = Color.Gray;
                            e.CellStyle.SelectionForeColor = Color.White;
                        }
                        // **PRIORIDAD 3: REMITOS SIN D�GITO VERIFICADOR (Fondo amarillo claro)**
                        else if (remito.IntegridadEstado == "SIN_DV")
                        {
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkGoldenrod;
                            e.CellStyle.SelectionBackColor = Color.Goldenrod;
                            e.CellStyle.SelectionForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la selecci�n en el DataGridView.
        /// </summary>
        private void dgvRemitos_SelectionChanged(object sender, EventArgs e)
        {
            ConfigurarEstadoBotones();
        }

        /// <summary>
        /// Evento que se dispara cuando se hace clic en el contenido de una celda.
        /// Usado para detectar clics en el bot�n de descargar PDF.
        /// </summary>
        private void dgvRemitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que sea el bot�n de descarga
            if (e.RowIndex >= 0 && dgvRemitos.Columns[e.ColumnIndex].Name == "DescargarPdf")
            {
                var remito = dgvRemitos.Rows[e.RowIndex].DataBoundItem as RemitoGestionDto;
                
                if (remito != null && remito.TienePdf)
                {
                    DescargarPdfRemito(remito.IdRemito);
                }
                else
                {
                    MessageBox.Show("Este remito no tiene un PDF generado.", "Informaci�n",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Configura el estado (habilitado/deshabilitado) de los botones seg�n la selecci�n.
        /// </summary>
        private void ConfigurarEstadoBotones()
        {
            bool haySeleccion = dgvRemitos.SelectedRows.Count > 0 || dgvRemitos.CurrentRow != null;
            bool remitoActivo = false;

            if (haySeleccion)
            {
                var row = dgvRemitos.SelectedRows.Count > 0
                    ? dgvRemitos.SelectedRows[0]
                    : dgvRemitos.CurrentRow;

                var remito = row?.DataBoundItem as RemitoGestionDto;
                remitoActivo = remito != null && !remito.EstaAnulado;
            }

            btnModificarRemito.Enabled = remitoActivo;
            btnEliminarRemito.Enabled = remitoActivo;
            btnAgregarRemito.Enabled = true;
        }

        /// <summary>
        /// Configura las columnas del DataGridView.
        /// </summary>
        private void ConfigurarColumnas()
        {
            if (dgvRemitos.Columns.Count == 0) return;

            try
            {
                // Suspender el layout para evitar parpadeos
                dgvRemitos.SuspendLayout();

                // Marcar que las columnas ya fueron configuradas
                _columnsConfigured = true;

                // Ocultar columnas que no se deben mostrar
                OcultarColumnasNoNecesarias();

                // Configurar columnas visibles
                ConfigurarColumnasVisibles();

                // Agregar columna de bot�n para descargar PDF
                AgregarColumnaBotonDescarga();

                // Reanudar el layout
                dgvRemitos.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvRemitos.ResumeLayout();
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Oculta las columnas que no deben ser visibles al usuario.
        /// </summary>
        private void OcultarColumnasNoNecesarias()
        {
            string[] columnasOcultas = new string[]
            {
                "IdRemito", "EstadoRemito", "DomicilioPlanta", "NombreFantasia",
                "Direccion", "NombreTransportista", "DomicilioTransportista",
                "IdRemitoPDF", "NombreArchivo", "FechaGeneracionPdf", "Tama�oBytes",
                "HashMD5", "TienePdf", "EstaAnulado", "Tama�oFormateado",
                "DigitoVerificador", "IntegridadValida" // Ocultar DV y bandera booleana
            };

            foreach (string nombreColumna in columnasOcultas)
            {
                if (dgvRemitos.Columns.Contains(nombreColumna))
                {
                    dgvRemitos.Columns[nombreColumna].Visible = false;
                }
            }
        }

        /// <summary>
        /// Configura las propiedades de las columnas visibles.
        /// </summary>
        private void ConfigurarColumnasVisibles()
        {
            int displayIndex = 0;

            // Fecha Creaci�n
            if (dgvRemitos.Columns.Contains("FechaCreacion"))
            {
                var col = dgvRemitos.Columns["FechaCreacion"];
                col.Tag = "Fecha Creacion";
                col.HeaderText = "Fecha Creaci�n";
                col.DisplayIndex = displayIndex++;
                col.Width = 150;
                col.MinimumWidth = 120;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Nombre Generador
            if (dgvRemitos.Columns.Contains("NombreGenerador"))
            {
                var col = dgvRemitos.Columns["NombreGenerador"];
                col.Tag = "Nombre Generador";
                col.HeaderText = "Nombre Generador";
                col.DisplayIndex = displayIndex++;
                col.Width = 200;
                col.MinimumWidth = 150;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // CUIT
            if (dgvRemitos.Columns.Contains("Cuit"))
            {
                var col = dgvRemitos.Columns["Cuit"];
                col.Tag = "CUIT";
                col.HeaderText = "CUIT";
                col.DisplayIndex = displayIndex++;
                col.Width = 140;
                col.MinimumWidth = 120;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // Tipo Residuo
            if (dgvRemitos.Columns.Contains("TipoResiduo"))
            {
                var col = dgvRemitos.Columns["TipoResiduo"];
                col.Tag = "Tipo Residuo";
                col.HeaderText = "Tipo Residuo";
                col.DisplayIndex = displayIndex++;
                col.Width = 100;
                col.MinimumWidth = 80;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // Cantidad
            if (dgvRemitos.Columns.Contains("Cantidad"))
            {
                var col = dgvRemitos.Columns["Cantidad"];
                col.Tag = "Cantidad";
                col.HeaderText = "Cantidad";
                col.DisplayIndex = displayIndex++;
                col.Width = 100;
                col.MinimumWidth = 80;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Estado F�sico
            if (dgvRemitos.Columns.Contains("Estado"))
            {
                var col = dgvRemitos.Columns["Estado"];
                col.Tag = "Estado Fisico";
                col.HeaderText = "Estado F�sico";
                col.DisplayIndex = displayIndex++;
                col.Width = 100;
                col.MinimumWidth = 80;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // **NUEVA COLUMNA: Integridad**
            if (dgvRemitos.Columns.Contains("IntegridadEstado"))
            {
                var col = dgvRemitos.Columns["IntegridadEstado"];
                col.Tag = "Integridad";
                col.HeaderText = "Integridad";
                col.DisplayIndex = displayIndex++;
                col.Width = 100;
                col.MinimumWidth = 90;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        /// <summary>
        /// Agrega o actualiza la columna de bot�n para descargar PDF.
        /// </summary>
        private void AgregarColumnaBotonDescarga()
        {
            // Remover la columna si ya existe para evitar duplicados
            if (dgvRemitos.Columns.Contains("DescargarPdf"))
            {
                dgvRemitos.Columns.Remove("DescargarPdf");
            }

            // Crear la columna de bot�n
            var colDescargarPdf = new DataGridViewButtonColumn
            {
                Name = "DescargarPdf",
                HeaderText = "PDF",
                Tag = "PDF",
                Text = "Descargar",
                UseColumnTextForButtonValue = true,
                Width = 110,
                MinimumWidth = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                FlatStyle = FlatStyle.Flat
            };

            // Agregar la columna al final
            dgvRemitos.Columns.Add(colDescargarPdf);
            
            // Asegurarse de que sea la �ltima columna
            dgvRemitos.Columns["DescargarPdf"].DisplayIndex = dgvRemitos.Columns.Count - 1;
        }

        /// <summary>
        /// Maneja el evento de clic del bot�n Filtrar.
        /// </summary>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaInicio = null;
                DateTime? fechaFin = null;
                string cuit = txtFiltroCUIT.Text.Trim();
                string tipoResiduo = cmbTipoResiduo.SelectedItem?.ToString();

                // Si el tipo de residuo es "Todos" o est� vac�o, no filtrar por tipo
                if (tipoResiduo == "Todos" || string.IsNullOrWhiteSpace(tipoResiduo))
                {
                    tipoResiduo = null;
                }

                // Aplicar filtro de fecha - ahora siempre toma los valores de los DateTimePicker
                fechaInicio = dtpFechaInicio.Value.Date;
                fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del d�a

                // Aplicar los filtros
                var remitosFiltrados = _remitoGestionService.ObtenerRemitosFiltrados(
                    fechaInicio, fechaFin, cuit, tipoResiduo);
                
                dgvRemitos.DataSource = remitosFiltrados;

                // **VERIFICAR SI HAY REMITOS ALTERADOS Y AVISAR AL USUARIO**
                int countAlterados = remitosFiltrados.Count(r => r.IntegridadEstado == "ALTERADO");
                if (countAlterados > 0)
                {
                    MessageBox.Show(
                        $"?? ALERTA DE SEGURIDAD ??\n\n" +
                        $"Se detectaron {countAlterados} remito(s) con datos ALTERADOS en los resultados filtrados.\n\n" +
                        $"Los registros alterados aparecen marcados en ROJO en la grilla.\n" +
                        $"Por favor, revise inmediatamente los remitos marcados.",
                        "Alerta de Integridad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                MessageBox.Show($"Se encontraron {remitosFiltrados.Count} remitos con los filtros aplicados.", 
                    "Filtros Aplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar remitos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del bot�n Limpiar Filtros.
        /// </summary>
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Limpiar todos los filtros
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtFiltroCUIT.Clear();
            cmbTipoResiduo.SelectedIndex = 0;

            // Recargar todos los remitos
            CargarRemitos();
        }

        /// <summary>
        /// Maneja el evento de clic del bot�n A�adir Remito.
        /// Abre el formulario FrmGenerarRemito existente.
        /// </summary>
        private void btnAgregarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                var frmGenerarRemito = new FrmGenerarRemito();
                
                if (frmGenerarRemito.ShowDialog() == DialogResult.OK)
                {
                    // Recargar la lista despu�s de generar un nuevo remito
                    CargarRemitos();
                    MessageBox.Show("Remito generado exitosamente.", "�xito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de generar remito: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del boton Modificar Remito.
        /// Abre el formulario de modificacion con los datos del remito seleccionado.
        /// </summary>
        private void btnModificarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dgvRemitos.SelectedRows.Count > 0
                    ? dgvRemitos.SelectedRows[0]
                    : dgvRemitos.CurrentRow;

                var remito = row?.DataBoundItem as RemitoGestionDto;
                if (remito == null)
                {
                    MessageBox.Show("Seleccione un remito para modificar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (remito.EstaAnulado)
                {
                    MessageBox.Show("No se puede modificar un remito anulado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var frmModificar = new FrmModificarRemito(remito.IdRemito))
                {
                    if (frmModificar.ShowDialog() == DialogResult.OK)
                    {
                        CargarRemitos();
                        MessageBox.Show("Remito modificado exitosamente.", "Exito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de modificar remito: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del boton Eliminar Remito.
        /// Anula el remito seleccionado y descuenta del inventario.
        /// </summary>
        private void btnEliminarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el remito seleccionado
                var row = dgvRemitos.SelectedRows.Count > 0
                    ? dgvRemitos.SelectedRows[0]
                    : dgvRemitos.CurrentRow;

                var remito = row?.DataBoundItem as RemitoGestionDto;
                if (remito == null)
                {
                    MessageBox.Show("Seleccione un remito para anular.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Dialogo de confirmacion con datos del remito
                var resultado = MessageBox.Show(
                    $"Esta seguro que desea anular el siguiente remito?\n\n" +
                    $"Generador: {remito.NombreGenerador}\n" +
                    $"Tipo: {remito.TipoResiduo} - {remito.Estado}\n" +
                    $"Cantidad: {remito.Cantidad}\n" +
                    $"CUIT: {remito.Cuit}\n" +
                    $"Fecha: {remito.FechaCreacion:dd/MM/yyyy HH:mm}\n\n" +
                    $"Esta accion anulara el remito y descontara {remito.Cantidad} del inventario.",
                    "Confirmar anulacion de remito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes)
                    return;

                // Ejecutar anulacion
                this.Cursor = Cursors.WaitCursor;
                _remitoGestionService.AnularRemito(remito.IdRemito);
                this.Cursor = Cursors.Default;

                // Recargar grid
                CargarRemitos();

                MessageBox.Show(
                    "Remito anulado correctamente. El inventario fue actualizado.",
                    "Remito anulado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error al anular el remito: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Descarga el PDF de un remito a la carpeta de descargas del usuario.
        /// </summary>
        /// <param name="idRemito">ID del remito cuyo PDF se desea descargar.</param>
        private void DescargarPdfRemito(Guid idRemito)
        {
            try
            {
                // Mostrar cursor de espera
                this.Cursor = Cursors.WaitCursor;

                // Descargar el PDF
                string rutaDescarga = _remitoGestionService.DescargarPdfRemito(idRemito);

                // Restaurar cursor normal
                this.Cursor = Cursors.Default;

                // Mostrar mensaje de �xito
                var resultado = MessageBox.Show(
                    $"PDF descargado exitosamente en:\n{rutaDescarga}\n\n�Desea abrir el archivo?",
                    "Descarga Exitosa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                // Si el usuario quiere abrir el archivo
                if (resultado == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(rutaDescarga);
                }
            }
            catch (Exception ex)
            {
                // Restaurar cursor normal
                this.Cursor = Cursors.Default;

                MessageBox.Show($"Error al descargar el PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void btnAgregarRemito_Click_1(object sender, EventArgs e)
        {

        }
    }
}
