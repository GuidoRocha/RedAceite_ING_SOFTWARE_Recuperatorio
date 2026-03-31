using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using RedAceite_ING_SOFTWARE.Controls;
using SERVICES.Facade;
using SERVICES.Facade.Extentions;
using SERVICES.Services;
using System.Globalization;
using System.Threading;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmPrincipal : Form
    {
        private Form activeForm = null;
        private System.Windows.Forms.Timer timerActualizacion;

        private string currentTitleKey = "lbl_MenuPrincipal";

        private ToolStripDropDown _userDropDown;
        private UserMenuControl _userMenuControl;

        // ScottPlot
        private ScottPlot.FormsPlot plotBarras;
        private ScottPlot.FormsPlot plotDonut;
        private const double LIMITE_STOCK = 3000;


        public FrmPrincipal()
        {
            InitializeComponent();
            this.Tag = "Titulo_FrmPrincipal";

            InicializarTimerActualizacion();
        }

        private void ReloadActiveChild()
        {
            if (activeForm == null) return;

            var type = activeForm.GetType();

            try { activeForm.Close(); } catch { }
            try { activeForm.Dispose(); } catch { }
            activeForm = null;

            if (type == typeof(FrmGestionUsuarios))
                btnUsuarios_Click(this, EventArgs.Empty);
            else if (type == typeof(FrmGestionProveedores))
                btnProveedores_Click(this, EventArgs.Empty);
            else if (type == typeof(FrmGestionRemitos))
                btnRemitos_Click(this, EventArgs.Empty);
            else if (type == typeof(FrmGestionManifiestos))
                btnManifiestos_Click(this, EventArgs.Empty);
            else if (type == typeof(FrmGestionRoles))
                OpenChildForm(new FrmGestionRoles());
            else
                VolverAInicio();
        }

        private void SetLanguage(string code)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(code);
            LanguagePreferenceService.Save(code);

            ApplyTranslationsPrincipal();

            if (activeForm != null)
                ReloadActiveChild();
            else if (panelDashboard != null && panelDashboard.Visible)
                CargarEstadisticasInventario();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                if (btnProfile != null)
                {
                    btnProfile.Region = System.Drawing.Region.FromHrgn(
                        CreateRoundRectRgn(0, 0, btnProfile.Width, btnProfile.Height, 20, 20));
                }

                ApplyTranslationsPrincipal();
                MarcarBotonActivo(btnInicio);

                // Diferir inicializacion de graficos para que el layout ya este resuelto
                this.BeginInvoke((Action)(() =>
                {
                    CargarContadores();
                    InicializarGraficos();
                    CargarEstadisticasInventario();
                }));
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void ApplyTranslationsPrincipal()
        {
            this.Text = $"RedAceite - {"Titulo_FrmPrincipal".Translate()}";

            if (btnInicio != null) btnInicio.Text = "🏠 " + "btn_Inicio".Translate();
            if (btnManifiestos != null) btnManifiestos.Text = "📋 " + "btn_Manifiestos".Translate();
            if (btnRemitos != null) btnRemitos.Text = "📄 " + "btn_Remitos".Translate();
            if (btnProveedores != null) btnProveedores.Text = "🏢 " + "btn_Proveedores".Translate();
            if (btnUsuarios != null) btnUsuarios.Text = "👥 " + "btn_Usuarios".Translate();

            if (lblLogo != null) lblLogo.Text = "RedAceite";

            if (lblTitle != null) lblTitle.Text = currentTitleKey.Translate();

            if (lblUserName != null) lblUserName.Text = "lbl_Usuario".Translate();

            if (lblStatsTitle != null) lblStatsTitle.Text = "lbl_EstadisticasInventario".Translate();


            if (lblRemitos != null) lblRemitos.Text = "lbl_Remitos".Translate();
            if (lblManifiestos != null) lblManifiestos.Text = "lbl_Manifiestos".Translate();
        }

        // Handler requerido por el Designer
        private void FrmPrincipal_Load_1(object sender, EventArgs e)
        {
            FrmPrincipal_Load(sender, e);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private void OpenChildForm(Form childForm)
        {
            if (childForm == null) return;

            if (activeForm != null)
            {
                try
                {
                    activeForm.Close();
                }
                catch
                {
                    // ignore
                }

                activeForm.Dispose();
                activeForm = null;
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void VolverAInicio()
        {
            if (activeForm != null)
            {
                try
                {
                    activeForm.Close();
                }
                catch
                {
                    // ignore
                }

                activeForm.Dispose();
                activeForm = null;
            }

            panelMain.Controls.Clear();
            panelMain.Controls.Add(panelDashboard);
            panelDashboard.Dock = DockStyle.Fill;
            panelDashboard.BringToFront();

            currentTitleKey = "lbl_MenuPrincipal";
            ApplyTranslationsPrincipal();
            CargarContadores();
            CargarEstadisticasInventario();
        }

        // Sidebar - boton activo
        private Button _botonActivo;
        private readonly Color COLOR_SIDEBAR = Color.FromArgb(45, 45, 48);
        private readonly Color COLOR_ACTIVO = Color.FromArgb(62, 62, 66);

        private void MarcarBotonActivo(Button btn)
        {
            // Restaurar el anterior
            if (_botonActivo != null)
                _botonActivo.BackColor = COLOR_SIDEBAR;

            // Marcar el nuevo
            _botonActivo = btn;
            if (_botonActivo != null)
                _botonActivo.BackColor = COLOR_ACTIVO;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnInicio);
            VolverAInicio();
        }

        private void lblLogo_Click(object sender, EventArgs e) { MarcarBotonActivo(btnInicio); VolverAInicio(); }

        private void panelLogo_Click(object sender, EventArgs e) { MarcarBotonActivo(btnInicio); VolverAInicio(); }

        private void btnRemitos_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnRemitos);
            currentTitleKey = "Titulo_FrmGestionRemitos";
            ApplyTranslationsPrincipal();
            OpenChildForm(new FrmGestionRemitos());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnProveedores);
            currentTitleKey = "Titulo_FrmGestionProveedores";
            ApplyTranslationsPrincipal();
            OpenChildForm(new FrmGestionProveedores());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnUsuarios);
            currentTitleKey = "Titulo_FrmGestionUsuarios";
            ApplyTranslationsPrincipal();
            OpenChildForm(new FrmGestionUsuarios());
        }

        private void btnManifiestos_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnManifiestos);
            currentTitleKey = "Titulo_FrmGestionManifiestos";
            ApplyTranslationsPrincipal();
            OpenChildForm(new FrmGestionManifiestos());
        }

        // Barra superior
        private void btnNotifications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No hay notificaciones…", "Notificaciones", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleUserMenu();
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void ToggleUserMenu()
        {
            if (_userDropDown != null && _userDropDown.Visible)
            {
                _userDropDown.Close(ToolStripDropDownCloseReason.CloseCalled);
                return;
            }

            EnsureUserMenuCreated();

            // Convertir a coordenadas de pantalla desde el propio boton
            // para evitar que en multi-monitor se despliegue en otro monitor
            var screenPoint = btnProfile.PointToScreen(new System.Drawing.Point(0, btnProfile.Height));

            // Ajustar para que el dropdown no se salga por la derecha
            int dropWidth = _userDropDown.PreferredSize.Width;
            if (dropWidth > 0)
            {
                var screen = System.Windows.Forms.Screen.FromControl(btnProfile);
                if (screenPoint.X + dropWidth > screen.WorkingArea.Right)
                {
                    screenPoint.X = screen.WorkingArea.Right - dropWidth;
                }
            }

            _userDropDown.Show(screenPoint);
        }

        private void EnsureUserMenuCreated()
        {
            if (_userDropDown != null)
                return;

            _userMenuControl = new UserMenuControl();
            _userMenuControl.IdiomaClick += UserMenuControl_IdiomaClick;
            _userMenuControl.ConfiguracionClick += UserMenuControl_ConfiguracionClick;

            var host = new ToolStripControlHost(_userMenuControl)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = true
            };

            _userDropDown = new ToolStripDropDown
            {
                AutoClose = true,
                Padding = Padding.Empty
            };
            _userDropDown.Items.Add(host);

            _userDropDown.Closed += (s, e) =>
            {
                // no-op
            };

            _userDropDown.Closing += (s, e) =>
            {
                if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                {
                    e.Cancel = true;
                }
            };
        }

        private void UserMenuControl_IdiomaClick(object sender, EventArgs e)
        {
            try
            {
                CloseUserAndLanguageMenus();

                using (var dlg = new FrmCambioIdioma())
                {
                    dlg.EspanolSelected += (s, args) => SetLanguage("es-ES");
                    dlg.EnglishSelected += (s, args) => SetLanguage("en-US");

                    dlg.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void UserMenuControl_ConfiguracionClick(object sender, EventArgs e)
        {
            try
            {
                CloseUserAndLanguageMenus();

                using (var dlg = new FrmConfiguracion())
                {
                    dlg.GestionRolesSelected += (s, args) =>
                    {
                        OpenChildForm(new FrmGestionRoles());
                    };

                    dlg.ConfigurarPreciosSelected += (s, args) =>
                    {
                        using (var frmPrecios = new FrmConfigurarPrecios())
                        {
                            frmPrecios.ShowDialog(this);
                        }
                    };

                    dlg.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void CloseUserAndLanguageMenus()
        {
            if (_userDropDown != null && _userDropDown.Visible)
                _userDropDown.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // No-op: handler requerido por el Designer
        }

        // Dashboard panels
        private void panelRemitos_Click(object sender, EventArgs e) => btnRemitos_Click(sender, e);
        private void panelManifiestos_Click(object sender, EventArgs e) => btnManifiestos_Click(sender, e);

        // Menú idioma (FASE 1: no aplicar runtime)
        private void menuEspañol_Click(object sender, EventArgs e)
        {
            try
            {
                SetLanguage("es-ES");
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void menuIngles_Click(object sender, EventArgs e)
        {
            try
            {
                SetLanguage("en-US");
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        // Timer
        private void InicializarTimerActualizacion()
        {
            try
            {
                timerActualizacion = new System.Windows.Forms.Timer();
                timerActualizacion.Interval = 300000; // 5 min
                timerActualizacion.Tick += TimerActualizacion_Tick;
                timerActualizacion.Start();
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void TimerActualizacion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (activeForm == null && panelDashboard != null && panelDashboard.Visible)
                {
                    CargarContadores();
                    CargarEstadisticasInventario();
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        // =============================================
        // Contadores de cards (Remitos, Manifiestos, Clientes)
        // =============================================
        private void CargarContadores()
        {
            try
            {
                // Remitos activos (no anulados)
                var remitoGestionService = new BLL.Remito.RemitoGestionService();
                var remitos = remitoGestionService.ObtenerRemitosParaGestion();
                int totalRemitos = 0;
                foreach (var r in remitos)
                {
                    if (!r.EstaAnulado) totalRemitos++;
                }
                if (lblRemitosCount != null)
                    lblRemitosCount.Text = totalRemitos.ToString("N0");

                // Manifiestos activos (no anulados)
                var manifiestoService = new BLL.Manifiesto.ManifiestoService();
                var manifiestos = manifiestoService.ObtenerManifiestosParaGestion();
                int totalManifiestos = 0;
                foreach (var m in manifiestos)
                {
                    if (!m.EstaAnulado) totalManifiestos++;
                }
                if (lblManifiestosCount != null)
                    lblManifiestosCount.Text = totalManifiestos.ToString("N0");

                // Proveedores activos
                var proveedorService = new ProveedorService();
                var proveedores = proveedorService.ObtenerProveedoresActivos();
                if (lblProveedoreCount != null)
                    lblProveedoreCount.Text = proveedores.Count.ToString("N0");
            }
            catch (Exception ex)
            {
                if (lblRemitosCount != null) lblRemitosCount.Text = "Error";
                if (lblManifiestosCount != null) lblManifiestosCount.Text = "Error";
                if (lblProveedoreCount != null) lblProveedoreCount.Text = "Error";
                LoggerService.WriteException(ex);
            }
        }

        // =============================================
        // ScottPlot - Inicializacion
        // =============================================
        private void InicializarGraficos()
        {
            try
            {
                // Mover labels debajo de los charts
                int yLabels = panelStats.Height - 30;
                lblEntradasMes.Location = new Point(15, yLabels);
                lblSalidasMes.Location = new Point(250, yLabels);
                lblUltimaActualizacion.Location = new Point(500, yLabels);
                lblEntradasMes.BringToFront();
                lblSalidasMes.BringToFront();
                lblUltimaActualizacion.BringToFront();

                int chartHeight = panelStats.Height - 90;
                var colorAceite = Color.FromArgb(76, 175, 80);
                var colorGrasa = Color.FromArgb(255, 152, 0);

                // ----- Grafico de barras -----
                plotBarras = new ScottPlot.FormsPlot
                {
                    Location = new Point(15, 50),
                    Size = new Size(panelStats.Width * 55 / 100, chartHeight),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right
                };
                plotBarras.Plot.Style(
                    figureBackground: Color.White,
                    dataBackground: Color.White,
                    grid: Color.FromArgb(235, 235, 235));
                plotBarras.Plot.Benchmark(false);
                plotBarras.Configuration.Quality = ScottPlot.Control.QualityMode.High;
                plotBarras.Configuration.Pan = false;
                plotBarras.Configuration.Zoom = false;
                plotBarras.Configuration.DoubleClickBenchmark = false;
                plotBarras.Configuration.RightClickDragZoom = false;
                plotBarras.Configuration.ScrollWheelZoom = false;
                plotBarras.Configuration.MiddleClickDragZoom = false;
                plotBarras.Configuration.LockVerticalAxis = true;
                plotBarras.Configuration.LockHorizontalAxis = true;

                panelStats.Controls.Add(plotBarras);

                // ----- Grafico donut (pie) -----
                int donutLeft = panelStats.Width * 57 / 100;
                plotDonut = new ScottPlot.FormsPlot
                {
                    Location = new Point(donutLeft, 50),
                    Size = new Size(panelStats.Width - donutLeft - 15, chartHeight),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
                };
                plotDonut.Plot.Style(
                    figureBackground: Color.White,
                    dataBackground: Color.White);
                plotDonut.Plot.Benchmark(false);
                plotDonut.Configuration.Quality = ScottPlot.Control.QualityMode.High;
                plotDonut.Configuration.Pan = false;
                plotDonut.Configuration.Zoom = false;
                plotDonut.Configuration.DoubleClickBenchmark = false;
                plotDonut.Configuration.RightClickDragZoom = false;
                plotDonut.Configuration.ScrollWheelZoom = false;
                plotDonut.Configuration.MiddleClickDragZoom = false;
                plotDonut.Configuration.LockVerticalAxis = true;
                plotDonut.Configuration.LockHorizontalAxis = true;

                panelStats.Controls.Add(plotDonut);
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void ActualizarGraficoBarras(double aceite, double grasa)
        {
            if (plotBarras == null) return;

            var plt = plotBarras.Plot;
            plt.Clear();

            // Barra de Aceite (verde)
            var barAceite = plt.AddBar(new double[] { aceite }, new double[] { 0 });
            barAceite.FillColor = Color.FromArgb(76, 175, 80);
            barAceite.Label = "Aceite (L)";
            barAceite.ShowValuesAboveBars = true;
            barAceite.ValueFormatter = v => $"{v:N0} L";

            // Barra de Grasa (naranja)
            var barGrasa = plt.AddBar(new double[] { grasa }, new double[] { 1 });
            barGrasa.FillColor = Color.FromArgb(255, 152, 0);
            barGrasa.Label = "Grasa (Kg)";
            barGrasa.ShowValuesAboveBars = true;
            barGrasa.ValueFormatter = v => $"{v:N0} Kg";

            plt.XTicks(new double[] { 0, 1 }, new[] { "Aceite", "Grasa" });
            plt.YAxis.Label("Cantidad");
            plt.SetAxisLimitsY(0, LIMITE_STOCK);

            // Linea de limite
            var hLine = plt.AddHorizontalLine(LIMITE_STOCK);
            hLine.Color = Color.FromArgb(200, 200, 200);
            hLine.LineStyle = ScottPlot.LineStyle.Dash;
            hLine.PositionLabel = true;
            hLine.PositionLabelBackground = Color.FromArgb(240, 240, 240);

            plt.Legend(true, ScottPlot.Alignment.UpperRight);
            plt.Title("Stock Actual");

            plotBarras.Refresh();
        }

        private void ActualizarGraficoDonut(double aceite, double grasa)
        {
            if (plotDonut == null) return;

            var plt = plotDonut.Plot;
            plt.Clear();

            double[] values = { Math.Max(aceite, 0.1), Math.Max(grasa, 0.1) };
            string[] labels = { $"Aceite\n{aceite:N0} L", $"Grasa\n{grasa:N0} Kg" };
            Color[] colors = {
                Color.FromArgb(76, 175, 80),
                Color.FromArgb(255, 152, 0)
            };

            var pie = plt.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            pie.SliceFillColors = colors;
            pie.DonutSize = 0.55;
            pie.DonutLabel = $"{aceite + grasa:N0}\nL/Kg";
            pie.CenterFont.Size = 16;
            pie.CenterFont.Bold = true;
            pie.CenterFont.Color = Color.FromArgb(60, 60, 60);
            pie.SliceLabelColors = new Color[] { Color.White, Color.White };

            plt.Title("Composicion");

            plotDonut.Refresh();
        }

        // =============================================
        // Estadísticas - Carga de datos
        // =============================================
        private void CargarEstadisticasInventario()
        {
            try
            {
                var inventarioService = new InventarioService();
                var estadisticas = inventarioService.ObtenerEstadisticas();

                double aceite = (double)estadisticas.StockTotalAceite;
                double grasa = (double)estadisticas.StockTotalGrasa;

                // Actualizar graficos ScottPlot
                ActualizarGraficoBarras(aceite, grasa);
                ActualizarGraficoDonut(aceite, grasa);

                // Labels de info
                if (lblEntradasMes != null)
                    lblEntradasMes.Text = string.Format("lbl_EntradasUltimoMes".Translate(), estadisticas.EntradasUltimoMes);

                if (lblSalidasMes != null)
                    lblSalidasMes.Text = string.Format("lbl_SalidasUltimoMes".Translate(), estadisticas.SalidasUltimoMes);

                if (lblUltimaActualizacion != null)
                    lblUltimaActualizacion.Text = string.Format("lbl_UltimaActualizacion".Translate(),
                        estadisticas.FechaActualizacion.ToString("dd/MM/yyyy HH:mm"));

            }
            catch (Exception ex)
            {
                if (lblEntradasMes != null) lblEntradasMes.Text = "Error";
                if (lblSalidasMes != null) lblSalidasMes.Text = "Error";
                if (lblUltimaActualizacion != null) lblUltimaActualizacion.Text = "Error";

                LoggerService.WriteException(ex);
            }
        }

        // Métodos públicos útiles
        public void RefrescarEstadisticas() => CargarEstadisticasInventario();

        public void PausarActualizacionAutomatica()
        {
            if (timerActualizacion != null)
                timerActualizacion.Stop();
        }

        public void ReanudarActualizacionAutomatica()
        {
            if (timerActualizacion != null)
                timerActualizacion.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (_userMenuControl != null)
                {
                    _userMenuControl.IdiomaClick -= UserMenuControl_IdiomaClick;
                    _userMenuControl.Dispose();
                    _userMenuControl = null;
                }

                if (_userDropDown != null)
                {
                    _userDropDown.Dispose();
                    _userDropDown = null;
                }

                if (timerActualizacion != null)
                {
                    timerActualizacion.Stop();
                    timerActualizacion.Tick -= TimerActualizacion_Tick;
                    timerActualizacion.Dispose();
                    timerActualizacion = null;
                }

                if (activeForm != null)
                {
                    activeForm.Dispose();
                    activeForm = null;
                }
            }
            catch
            {
                // ignore
            }

            base.OnFormClosed(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // no-op: handler requerido por el Designer
        }

        private void panel1_Click(object sender, EventArgs e) => btnProveedores_Click(sender, e);
    }
}
