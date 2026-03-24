using BLL.Manifiesto;
using DOMAIN;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario de gestion de manifiestos diarios.
    /// Permite ver, filtrar, generar y anular manifiestos, descargar PDFs y configurar precios.
    /// </summary>
    public partial class FrmGestionManifiestos : Form
    {
        private readonly ManifiestoService _manifiestoService;
        private readonly ManifiestoPdfService _manifestoPdfService;

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmGestionManifiestos()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmGestionManifiestos";

            ApplyTranslationsGestionManifiestos();

            _manifiestoService = new ManifiestoService();
            _manifestoPdfService = new ManifiestoPdfService();
            this.Load += FrmGestionManifiestos_Load;
        }

        private void ApplyTranslationsGestionManifiestos()
        {
            this.Text = $"RedAceite - {"Titulo_FrmGestionManifiestos".Translate()}";

            // Panel de generacion
            if (lblFechaGenerar != null) lblFechaGenerar.Text = "Manifiestos_LblFechaGenerar".Translate();
            if (btnGenerarManifiesto != null) btnGenerarManifiesto.Text = "Manifiestos_BtnGenerar".Translate();

            // Panel de filtros
            if (chkFiltroFecha != null) chkFiltroFecha.Text = "Manifiestos_ChkFiltroFecha".Translate();
            if (lblFiltroInicio != null) lblFiltroInicio.Text = "Manifiestos_LblFiltroInicio".Translate();
            if (lblFiltroFin != null) lblFiltroFin.Text = "Manifiestos_LblFiltroFin".Translate();
            if (lblFiltroEstado != null) lblFiltroEstado.Text = "Manifiestos_LblFiltroEstado".Translate();
            if (btnFiltrar != null) btnFiltrar.Text = "Manifiestos_BtnFiltrar".Translate();
            if (btnLimpiarFiltros != null) btnLimpiarFiltros.Text = "Manifiestos_BtnLimpiarFiltros".Translate();

            // Panel de botones
            if (btnAnularManifiesto != null) btnAnularManifiesto.Text = "Manifiestos_BtnAnular".Translate();
            if (btnVerDetalle != null) btnVerDetalle.Text = "Manifiestos_BtnVerDetalle".Translate();
            if (btnDescargarPdf != null) btnDescargarPdf.Text = "Manifiestos_BtnDescargarPdf".Translate();
        }

        private void ApplyManifiestosGridHeaders()
        {
            if (dgvManifiestos == null || dgvManifiestos.Columns == null) return;

            foreach (DataGridViewColumn col in dgvManifiestos.Columns)
            {
                if (col == null || string.IsNullOrWhiteSpace(col.Name)) continue;

                string key = "Manifiestos_Col_" + col.Name;
                col.HeaderText = key.Translate();
            }
        }

        /// <summary>
        /// Evento Load: carga los manifiestos iniciales.
        /// </summary>
        private void FrmGestionManifiestos_Load(object sender, EventArgs e)
        {
            CargarManifiestos();
        }

        /// <summary>
        /// Carga todos los manifiestos en el grid.
        /// </summary>
        private void CargarManifiestos()
        {
            try
            {
                var manifiestos = _manifiestoService.ObtenerManifiestosParaGestion();
                dgvManifiestos.DataSource = null;
                dgvManifiestos.DataSource = manifiestos;

                ConfigurarColumnas();
                ApplyManifiestosGridHeaders();
                ConfigurarEstadoBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar manifiestos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Configura las columnas del DataGridView.
        /// </summary>
        private void ConfigurarColumnas()
        {
            if (dgvManifiestos.Columns.Count == 0) return;

            // Ocultar columnas internas
            string[] ocultar = { "IdManifiesto", "DigitoVerificador", "IntegridadValida",
                                 "EstaAnulado", "MontoTotalFormateado", "Observaciones" };

            foreach (string col in ocultar)
            {
                if (dgvManifiestos.Columns.Contains(col))
                    dgvManifiestos.Columns[col].Visible = false;
            }

            // Renombrar columnas visibles
            if (dgvManifiestos.Columns.Contains("NumeroManifiesto"))
                dgvManifiestos.Columns["NumeroManifiesto"].HeaderText = "Numero";

            if (dgvManifiestos.Columns.Contains("FechaManifiesto"))
            {
                dgvManifiestos.Columns["FechaManifiesto"].HeaderText = "Fecha";
                dgvManifiestos.Columns["FechaManifiesto"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvManifiestos.Columns.Contains("NombreTransportista"))
                dgvManifiestos.Columns["NombreTransportista"].HeaderText = "Transportista";

            if (dgvManifiestos.Columns.Contains("CantidadTotalRemitos"))
                dgvManifiestos.Columns["CantidadTotalRemitos"].HeaderText = "Remitos";

            if (dgvManifiestos.Columns.Contains("MontoTotal"))
            {
                dgvManifiestos.Columns["MontoTotal"].HeaderText = "Monto Total";
                dgvManifiestos.Columns["MontoTotal"].DefaultCellStyle.Format = "C2";
            }

            if (dgvManifiestos.Columns.Contains("Estado"))
                dgvManifiestos.Columns["Estado"].HeaderText = "Estado";

            if (dgvManifiestos.Columns.Contains("FechaCreacion"))
            {
                dgvManifiestos.Columns["FechaCreacion"].HeaderText = "Generado el";
                dgvManifiestos.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvManifiestos.Columns.Contains("IntegridadEstado"))
                dgvManifiestos.Columns["IntegridadEstado"].HeaderText = "Integridad";
        }

        /// <summary>
        /// Habilita/deshabilita botones segun la seleccion del grid.
        /// </summary>
        private void ConfigurarEstadoBotones()
        {
            bool haySeleccion = dgvManifiestos.SelectedRows.Count > 0;
            bool noAnulado = false;

            if (haySeleccion)
            {
                var row = dgvManifiestos.SelectedRows[0];
                if (row.DataBoundItem is ManifiestoGestionDto manifiesto)
                {
                    noAnulado = !manifiesto.EstaAnulado;
                }
            }

            btnAnularManifiesto.Enabled = haySeleccion && noAnulado;
            btnDescargarPdf.Enabled = haySeleccion;
            btnVerDetalle.Enabled = haySeleccion;
        }

        /// <summary>
        /// Colorea las filas segun estado e integridad.
        /// </summary>
        private void dgvManifiestos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvManifiestos.Rows[e.RowIndex];
            if (row.DataBoundItem is ManifiestoGestionDto manifiesto)
            {
                if (manifiesto.IntegridadEstado == "ALTERADO")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                }
                else if (manifiesto.EstaAnulado)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (manifiesto.IntegridadEstado == "SIN_DV")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                }
            }
        }

        /// <summary>
        /// Cambio de seleccion en el grid.
        /// </summary>
        private void dgvManifiestos_SelectionChanged(object sender, EventArgs e)
        {
            ConfigurarEstadoBotones();
        }

        /// <summary>
        /// Boton Generar Manifiesto: genera el manifiesto para la fecha seleccionada.
        /// </summary>
        private void btnGenerarManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada = dtpFechaGenerar.Value.Date;

                // Verificar si ya existe
                if (_manifiestoService.ExisteManifiestoParaFecha(fechaSeleccionada))
                {
                    MessageBox.Show(
                        $"Ya existe un manifiesto activo para la fecha {fechaSeleccionada:dd/MM/yyyy}.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Generar manifiesto para {fechaSeleccionada:dd/MM/yyyy}?",
                    "Confirmar generacion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes) return;

                var manifiesto = _manifiestoService.GenerarManifiestoDiario(fechaSeleccionada);

                // Generar PDF
                try
                {
                    _manifestoPdfService.GenerarPdfManifiesto(manifiesto.IdManifiesto);
                }
                catch (Exception exPdf)
                {
                    LoggerService.WriteLog(
                        $"Manifiesto generado pero error al crear PDF: {exPdf.Message}",
                        System.Diagnostics.TraceLevel.Warning);
                }

                MessageBox.Show(
                    $"Manifiesto {manifiesto.NumeroManifiesto} generado exitosamente.\n" +
                    $"Remitos incluidos: {manifiesto.CantidadTotalRemitos}\n" +
                    $"Monto total: ${manifiesto.MontoTotal:N2}",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarManifiestos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar manifiesto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        // TODO: Generacion automatica a las 00:00 (descomentar cuando se necesite)
        // private System.Windows.Forms.Timer timerGeneracionDiaria;
        // private void InicializarTimerGeneracion()
        // {
        //     timerGeneracionDiaria = new System.Windows.Forms.Timer();
        //     timerGeneracionDiaria.Interval = 60000; // Cada minuto verifica la hora
        //     timerGeneracionDiaria.Tick += TimerGeneracion_Tick;
        //     timerGeneracionDiaria.Start();
        // }
        // private void TimerGeneracion_Tick(object sender, EventArgs e)
        // {
        //     var ahora = DateTime.Now;
        //     if (ahora.Hour == 0 && ahora.Minute == 0)
        //     {
        //         var ayer = DateTime.Today.AddDays(-1);
        //         if (!_manifiestoService.ExisteManifiestoParaFecha(ayer))
        //         {
        //             _manifiestoService.GenerarManifiestoDiario(ayer);
        //         }
        //     }
        // }

        /// <summary>
        /// Boton Anular Manifiesto.
        /// </summary>
        private void btnAnularManifiesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvManifiestos.SelectedRows.Count == 0) return;

                var row = dgvManifiestos.SelectedRows[0];
                if (!(row.DataBoundItem is ManifiestoGestionDto manifiesto)) return;

                if (manifiesto.EstaAnulado)
                {
                    MessageBox.Show("Este manifiesto ya esta anulado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Confirma anular el manifiesto {manifiesto.NumeroManifiesto}?",
                    "Confirmar anulacion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes) return;

                _manifiestoService.AnularManifiesto(manifiesto.IdManifiesto);

                MessageBox.Show("Manifiesto anulado exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarManifiestos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular manifiesto: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Descargar PDF.
        /// </summary>
        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvManifiestos.SelectedRows.Count == 0) return;

                var row = dgvManifiestos.SelectedRows[0];
                if (!(row.DataBoundItem is ManifiestoGestionDto manifiesto)) return;

                string ruta = _manifestoPdfService.DescargarPdfManifiesto(manifiesto.IdManifiesto);

                MessageBox.Show($"PDF descargado en:\n{ruta}", "Descarga exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al descargar PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Ver Detalle: muestra los detalles del manifiesto seleccionado.
        /// </summary>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvManifiestos.SelectedRows.Count == 0) return;

                var row = dgvManifiestos.SelectedRows[0];
                if (!(row.DataBoundItem is ManifiestoGestionDto manifiesto)) return;

                var detalles = _manifiestoService.ObtenerDetallesManifiesto(manifiesto.IdManifiesto);

                string detalle = $"Manifiesto: {manifiesto.NumeroManifiesto}\n";
                detalle += $"Fecha: {manifiesto.FechaManifiesto:dd/MM/yyyy}\n";
                detalle += $"Remitos: {manifiesto.CantidadTotalRemitos}\n\n";
                detalle += "DETALLE:\n";
                detalle += new string('-', 60) + "\n";

                foreach (var d in detalles)
                {
                    string unidad = d.TipoResiduo == "Aceite" ? "L" : "Kg";
                    detalle += $"#{d.Orden} | {d.NombreGenerador} | {d.TipoResiduo} | " +
                               $"{d.Cantidad:N2} {unidad} x ${d.PrecioUnitario:N2} = ${d.Subtotal:N2}\n";
                }

                detalle += new string('-', 60) + "\n";
                detalle += $"TOTAL: ${manifiesto.MontoTotal:N2}";

                MessageBox.Show(detalle, "Detalle del Manifiesto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ver detalle: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Filtrar.
        /// </summary>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaInicio = chkFiltroFecha.Checked ? (DateTime?)dtpFiltroInicio.Value.Date : null;
                DateTime? fechaFin = chkFiltroFecha.Checked ? (DateTime?)dtpFiltroFin.Value.Date : null;
                string estado = cmbFiltroEstado.SelectedItem?.ToString();

                var manifiestos = _manifiestoService.ObtenerManifiestosFiltrados(
                    fechaInicio, fechaFin, estado);

                dgvManifiestos.DataSource = null;
                dgvManifiestos.DataSource = manifiestos;
                ConfigurarColumnas();
                ApplyManifiestosGridHeaders();
                ConfigurarEstadoBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Boton Limpiar Filtros.
        /// </summary>
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            chkFiltroFecha.Checked = false;
            cmbFiltroEstado.SelectedIndex = 0;
            CargarManifiestos();
        }

        /// <summary>
        /// Checkbox de filtro por fecha: habilita/deshabilita los DateTimePickers.
        /// </summary>
        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFiltroInicio.Enabled = chkFiltroFecha.Checked;
            dtpFiltroFin.Enabled = chkFiltroFecha.Checked;
        }
    }
}
