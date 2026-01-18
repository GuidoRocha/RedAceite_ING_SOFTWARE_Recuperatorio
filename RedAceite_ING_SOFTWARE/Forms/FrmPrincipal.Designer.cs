namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnRemitos = new System.Windows.Forms.Button();
            this.btnManifiestos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.menuStripIdioma = new System.Windows.Forms.MenuStrip();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEspañol = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIngles = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelManifiestos = new System.Windows.Forms.Panel();
            this.lblManifiestosCount = new System.Windows.Forms.Label();
            this.lblManifiestos = new System.Windows.Forms.Label();
            this.panelRemitos = new System.Windows.Forms.Panel();
            this.lblRemitosCount = new System.Windows.Forms.Label();
            this.lblRemitos = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.panelInventarioAceite = new System.Windows.Forms.Panel();
            this.lblStockAceite = new System.Windows.Forms.Label();
            this.lblTituloAceite = new System.Windows.Forms.Label();
            this.panelInventarioGrasa = new System.Windows.Forms.Panel();
            this.lblStockGrasa = new System.Windows.Forms.Label();
            this.lblTituloGrasa = new System.Windows.Forms.Label();
            this.panelInventarioTotal = new System.Windows.Forms.Panel();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.lblTituloTotal = new System.Windows.Forms.Label();
            this.lblEntradasMes = new System.Windows.Forms.Label();
            this.lblSalidasMes = new System.Windows.Forms.Label();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.menuStripIdioma.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.panelManifiestos.SuspendLayout();
            this.panelRemitos.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelInventarioAceite.SuspendLayout();
            this.panelInventarioGrasa.SuspendLayout();
            this.panelInventarioTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelSidebar.Controls.Add(this.btnUsuarios);
            this.panelSidebar.Controls.Add(this.btnProveedores);
            this.panelSidebar.Controls.Add(this.btnRemitos);
            this.panelSidebar.Controls.Add(this.btnManifiestos);
            this.panelSidebar.Controls.Add(this.btnInicio);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 700);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 305);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(200, 45);
            this.btnUsuarios.TabIndex = 7;
            this.btnUsuarios.Tag = "btn_Usuarios";
            this.btnUsuarios.Text = "👥 Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(0, 260);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProveedores.Size = new System.Drawing.Size(200, 45);
            this.btnProveedores.TabIndex = 6;
            this.btnProveedores.Tag = "btn_Proveedores";
            this.btnProveedores.Text = "🏢 Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnRemitos
            // 
            this.btnRemitos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemitos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemitos.FlatAppearance.BorderSize = 0;
            this.btnRemitos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnRemitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemitos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRemitos.ForeColor = System.Drawing.Color.White;
            this.btnRemitos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemitos.Location = new System.Drawing.Point(0, 215);
            this.btnRemitos.Name = "btnRemitos";
            this.btnRemitos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRemitos.Size = new System.Drawing.Size(200, 45);
            this.btnRemitos.TabIndex = 4;
            this.btnRemitos.Tag = "btn_Remitos";
            this.btnRemitos.Text = "📄 Remitos";
            this.btnRemitos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemitos.UseVisualStyleBackColor = true;
            this.btnRemitos.Click += new System.EventHandler(this.btnRemitos_Click);
            // 
            // btnManifiestos
            // 
            this.btnManifiestos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManifiestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManifiestos.FlatAppearance.BorderSize = 0;
            this.btnManifiestos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnManifiestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManifiestos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManifiestos.ForeColor = System.Drawing.Color.White;
            this.btnManifiestos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManifiestos.Location = new System.Drawing.Point(0, 170);
            this.btnManifiestos.Name = "btnManifiestos";
            this.btnManifiestos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManifiestos.Size = new System.Drawing.Size(200, 45);
            this.btnManifiestos.TabIndex = 3;
            this.btnManifiestos.Tag = "btn_Manifiestos";
            this.btnManifiestos.Text = "📋 Manifiestos";
            this.btnManifiestos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManifiestos.UseVisualStyleBackColor = true;
            this.btnManifiestos.Click += new System.EventHandler(this.btnManifiestos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 125);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(200, 45);
            this.btnInicio.TabIndex = 9;
            this.btnInicio.Tag = "btn_Inicio";
            this.btnInicio.Text = "🏠 Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 125);
            this.panelLogo.TabIndex = 1;
            this.panelLogo.Click += new System.EventHandler(this.panelLogo_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(200, 125);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "RedAceite";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // menuStripIdioma
            // 
            this.menuStripIdioma.BackColor = System.Drawing.Color.White;
            this.menuStripIdioma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIdioma});
            this.menuStripIdioma.Location = new System.Drawing.Point(200, 0);
            this.menuStripIdioma.Name = "menuStripIdioma";
            this.menuStripIdioma.Size = new System.Drawing.Size(1179, 24);
            this.menuStripIdioma.TabIndex = 3;
            this.menuStripIdioma.Text = "menuStripIdioma";
            // 
            // menuIdioma
            // 
            this.menuIdioma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEspañol,
            this.menuIngles});
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(61, 20);
            this.menuIdioma.Tag = "menu_Idioma";
            this.menuIdioma.Text = "Idioma";
            // 
            // menuEspañol
            // 
            this.menuEspañol.Name = "menuEspañol";
            this.menuEspañol.Size = new System.Drawing.Size(180, 22);
            this.menuEspañol.Tag = "menu_Español";
            this.menuEspañol.Text = "Español";
            this.menuEspañol.Click += new System.EventHandler(this.menuEspañol_Click);
            // 
            // menuIngles
            // 
            this.menuIngles.Name = "menuIngles";
            this.menuIngles.Size = new System.Drawing.Size(180, 22);
            this.menuIngles.Tag = "menu_Ingles";
            this.menuIngles.Text = "English";
            this.menuIngles.Click += new System.EventHandler(this.menuIngles_Click);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.White;
            this.panelTopBar.Controls.Add(this.lblUserName);
            this.panelTopBar.Controls.Add(this.btnProfile);
            this.panelTopBar.Controls.Add(this.btnNotifications);
            this.panelTopBar.Controls.Add(this.lblTitle);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(200, 24);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1179, 60);
            this.panelTopBar.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserName.Location = new System.Drawing.Point(1034, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(56, 19);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Tag = "lbl_Usuario";
            this.lblUserName.Text = "Usuario";
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProfile.Location = new System.Drawing.Point(1103, 15);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(40, 40);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "U";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnNotifications
            // 
            this.btnNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNotifications.Location = new System.Drawing.Point(979, 15);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(40, 40);
            this.btnNotifications.TabIndex = 1;
            this.btnNotifications.Text = "🔔";
            this.btnNotifications.UseVisualStyleBackColor = true;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Tag = "lbl_MenuPrincipal";
            this.lblTitle.Text = "Menu Principal";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMain.Controls.Add(this.panelDashboard);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 84);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panelMain.Size = new System.Drawing.Size(1179, 616);
            this.panelMain.TabIndex = 2;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.panelManifiestos);
            this.panelDashboard.Controls.Add(this.panelRemitos);
            this.panelDashboard.Controls.Add(this.panelStats);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(20, 20);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(1139, 600);
            this.panelDashboard.TabIndex = 0;
            // 
            // panelManifiestos
            // 
            this.panelManifiestos.BackColor = System.Drawing.Color.White;
            this.panelManifiestos.Controls.Add(this.lblManifiestosCount);
            this.panelManifiestos.Controls.Add(this.lblManifiestos);
            this.panelManifiestos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelManifiestos.Location = new System.Drawing.Point(290, 10);
            this.panelManifiestos.Name = "panelManifiestos";
            this.panelManifiestos.Size = new System.Drawing.Size(220, 120);
            this.panelManifiestos.TabIndex = 3;
            this.panelManifiestos.Click += new System.EventHandler(this.panelManifiestos_Click);
            // 
            // lblManifiestosCount
            // 
            this.lblManifiestosCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblManifiestosCount.Location = new System.Drawing.Point(10, 50);
            this.lblManifiestosCount.Name = "lblManifiestosCount";
            this.lblManifiestosCount.Size = new System.Drawing.Size(200, 50);
            this.lblManifiestosCount.TabIndex = 1;
            this.lblManifiestosCount.Text = "963";
            this.lblManifiestosCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblManifiestosCount.Click += new System.EventHandler(this.panelManifiestos_Click);
            // 
            // lblManifiestos
            // 
            this.lblManifiestos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblManifiestos.Location = new System.Drawing.Point(10, 15);
            this.lblManifiestos.Name = "lblManifiestos";
            this.lblManifiestos.Size = new System.Drawing.Size(200, 25);
            this.lblManifiestos.TabIndex = 0;
            this.lblManifiestos.Tag = "lbl_Manifiestos";
            this.lblManifiestos.Text = "Manifiestos";
            this.lblManifiestos.Click += new System.EventHandler(this.panelManifiestos_Click);
            // 
            // panelRemitos
            // 
            this.panelRemitos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelRemitos.Controls.Add(this.lblRemitosCount);
            this.panelRemitos.Controls.Add(this.lblRemitos);
            this.panelRemitos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRemitos.Location = new System.Drawing.Point(10, 10);
            this.panelRemitos.Name = "panelRemitos";
            this.panelRemitos.Size = new System.Drawing.Size(220, 120);
            this.panelRemitos.TabIndex = 1;
            this.panelRemitos.Click += new System.EventHandler(this.panelRemitos_Click);
            // 
            // lblRemitosCount
            // 
            this.lblRemitosCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblRemitosCount.ForeColor = System.Drawing.Color.White;
            this.lblRemitosCount.Location = new System.Drawing.Point(10, 50);
            this.lblRemitosCount.Name = "lblRemitosCount";
            this.lblRemitosCount.Size = new System.Drawing.Size(200, 50);
            this.lblRemitosCount.TabIndex = 1;
            this.lblRemitosCount.Text = "9,328";
            this.lblRemitosCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemitosCount.Click += new System.EventHandler(this.panelRemitos_Click);
            // 
            // lblRemitos
            // 
            this.lblRemitos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRemitos.ForeColor = System.Drawing.Color.White;
            this.lblRemitos.Location = new System.Drawing.Point(10, 15);
            this.lblRemitos.Name = "lblRemitos";
            this.lblRemitos.Size = new System.Drawing.Size(200, 25);
            this.lblRemitos.TabIndex = 0;
            this.lblRemitos.Tag = "lbl_Remitos";
            this.lblRemitos.Text = "Remitos";
            this.lblRemitos.Click += new System.EventHandler(this.panelRemitos_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.White;
            this.panelStats.Controls.Add(this.lblUltimaActualizacion);
            this.panelStats.Controls.Add(this.lblSalidasMes);
            this.panelStats.Controls.Add(this.lblEntradasMes);
            this.panelStats.Controls.Add(this.panelInventarioTotal);
            this.panelStats.Controls.Add(this.panelInventarioGrasa);
            this.panelStats.Controls.Add(this.panelInventarioAceite);
            this.panelStats.Controls.Add(this.lblStatsTitle);
            this.panelStats.Location = new System.Drawing.Point(10, 150);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(780, 330);
            this.panelStats.TabIndex = 0;
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(300, 30);
            this.lblStatsTitle.TabIndex = 0;
            this.lblStatsTitle.Tag = "lbl_EstadisticasInventario";
            this.lblStatsTitle.Text = "Estadísticas de Inventario";
            // 
            // panelInventarioAceite
            // 
            this.panelInventarioAceite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelInventarioAceite.Controls.Add(this.lblStockAceite);
            this.panelInventarioAceite.Controls.Add(this.lblTituloAceite);
            this.panelInventarioAceite.Location = new System.Drawing.Point(20, 60);
            this.panelInventarioAceite.Name = "panelInventarioAceite";
            this.panelInventarioAceite.Size = new System.Drawing.Size(200, 100);
            this.panelInventarioAceite.TabIndex = 1;
            // 
            // lblStockAceite
            // 
            this.lblStockAceite.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockAceite.ForeColor = System.Drawing.Color.White;
            this.lblStockAceite.Location = new System.Drawing.Point(10, 45);
            this.lblStockAceite.Name = "lblStockAceite";
            this.lblStockAceite.Size = new System.Drawing.Size(180, 40);
            this.lblStockAceite.TabIndex = 1;
            this.lblStockAceite.Text = "0 L";
            this.lblStockAceite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloAceite
            // 
            this.lblTituloAceite.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloAceite.ForeColor = System.Drawing.Color.White;
            this.lblTituloAceite.Location = new System.Drawing.Point(10, 10);
            this.lblTituloAceite.Name = "lblTituloAceite";
            this.lblTituloAceite.Size = new System.Drawing.Size(180, 25);
            this.lblTituloAceite.TabIndex = 0;
            this.lblTituloAceite.Tag = "lbl_StockAceite";
            this.lblTituloAceite.Text = "🛢️ Stock Aceite";
            // 
            // panelInventarioGrasa
            // 
            this.panelInventarioGrasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.panelInventarioGrasa.Controls.Add(this.lblStockGrasa);
            this.panelInventarioGrasa.Controls.Add(this.lblTituloGrasa);
            this.panelInventarioGrasa.Location = new System.Drawing.Point(240, 60);
            this.panelInventarioGrasa.Name = "panelInventarioGrasa";
            this.panelInventarioGrasa.Size = new System.Drawing.Size(200, 100);
            this.panelInventarioGrasa.TabIndex = 2;
            // 
            // lblStockGrasa
            // 
            this.lblStockGrasa.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockGrasa.ForeColor = System.Drawing.Color.White;
            this.lblStockGrasa.Location = new System.Drawing.Point(10, 45);
            this.lblStockGrasa.Name = "lblStockGrasa";
            this.lblStockGrasa.Size = new System.Drawing.Size(180, 40);
            this.lblStockGrasa.TabIndex = 1;
            this.lblStockGrasa.Text = "0 Kg";
            this.lblStockGrasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloGrasa
            // 
            this.lblTituloGrasa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrasa.ForeColor = System.Drawing.Color.White;
            this.lblTituloGrasa.Location = new System.Drawing.Point(10, 10);
            this.lblTituloGrasa.Name = "lblTituloGrasa";
            this.lblTituloGrasa.Size = new System.Drawing.Size(180, 25);
            this.lblTituloGrasa.TabIndex = 0;
            this.lblTituloGrasa.Tag = "lbl_StockGrasa";
            this.lblTituloGrasa.Text = "🧈 Stock Grasa";
            // 
            // panelInventarioTotal
            // 
            this.panelInventarioTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelInventarioTotal.Controls.Add(this.lblStockTotal);
            this.panelInventarioTotal.Controls.Add(this.lblTituloTotal);
            this.panelInventarioTotal.Location = new System.Drawing.Point(460, 60);
            this.panelInventarioTotal.Name = "panelInventarioTotal";
            this.panelInventarioTotal.Size = new System.Drawing.Size(200, 100);
            this.panelInventarioTotal.TabIndex = 3;
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockTotal.ForeColor = System.Drawing.Color.White;
            this.lblStockTotal.Location = new System.Drawing.Point(10, 45);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(180, 40);
            this.lblStockTotal.TabIndex = 1;
            this.lblStockTotal.Text = "0 L/Kg";
            this.lblStockTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloTotal
            // 
            this.lblTituloTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloTotal.ForeColor = System.Drawing.Color.White;
            this.lblTituloTotal.Location = new System.Drawing.Point(10, 10);
            this.lblTituloTotal.Name = "lblTituloTotal";
            this.lblTituloTotal.Size = new System.Drawing.Size(180, 25);
            this.lblTituloTotal.TabIndex = 0;
            this.lblTituloTotal.Tag = "lbl_StockTotal";
            this.lblTituloTotal.Text = "📦 Stock Total";
            // 
            // lblEntradasMes
            // 
            this.lblEntradasMes.AutoSize = true;
            this.lblEntradasMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEntradasMes.Location = new System.Drawing.Point(20, 180);
            this.lblEntradasMes.Name = "lblEntradasMes";
            this.lblEntradasMes.Size = new System.Drawing.Size(180, 19);
            this.lblEntradasMes.TabIndex = 4;
            this.lblEntradasMes.Text = "📥 Entradas (último mes): 0";
            // 
            // lblSalidasMes
            // 
            this.lblSalidasMes.AutoSize = true;
            this.lblSalidasMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSalidasMes.Location = new System.Drawing.Point(20, 210);
            this.lblSalidasMes.Name = "lblSalidasMes";
            this.lblSalidasMes.Size = new System.Drawing.Size(169, 19);
            this.lblSalidasMes.TabIndex = 5;
            this.lblSalidasMes.Text = "📤 Salidas (último mes): 0";
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.Gray;
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(20, 300);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(180, 15);
            this.lblUltimaActualizacion.TabIndex = 6;
            this.lblUltimaActualizacion.Text = "Última actualización: --/--/----";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.menuStripIdioma);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripIdioma;
            this.MinimumSize = new System.Drawing.Size(1065, 638);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedAceite - Sistema de Gestión";
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.menuStripIdioma.ResumeLayout(false);
            this.menuStripIdioma.PerformLayout();
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelManifiestos.ResumeLayout(false);
            this.panelRemitos.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelInventarioAceite.ResumeLayout(false);
            this.panelInventarioGrasa.ResumeLayout(false);
            this.panelInventarioTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnManifiestos;
        private System.Windows.Forms.Button btnRemitos;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.MenuStrip menuStripIdioma;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
        private System.Windows.Forms.ToolStripMenuItem menuEspañol;
        private System.Windows.Forms.ToolStripMenuItem menuIngles;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelRemitos;
        private System.Windows.Forms.Label lblRemitos;
        private System.Windows.Forms.Label lblRemitosCount;
        private System.Windows.Forms.Panel panelManifiestos;
        private System.Windows.Forms.Label lblManifiestosCount;
        private System.Windows.Forms.Label lblManifiestos;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Panel panelInventarioAceite;
        private System.Windows.Forms.Label lblStockAceite;
        private System.Windows.Forms.Label lblTituloAceite;
        private System.Windows.Forms.Panel panelInventarioGrasa;
        private System.Windows.Forms.Label lblStockGrasa;
        private System.Windows.Forms.Label lblTituloGrasa;
        private System.Windows.Forms.Panel panelInventarioTotal;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Label lblTituloTotal;
        private System.Windows.Forms.Label lblEntradasMes;
        private System.Windows.Forms.Label lblSalidasMes;
        private System.Windows.Forms.Label lblUltimaActualizacion;
    }
}