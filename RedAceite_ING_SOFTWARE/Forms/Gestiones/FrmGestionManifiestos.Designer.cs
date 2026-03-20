namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmGestionManifiestos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvManifiestos = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.dtpFiltroFin = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFin = new System.Windows.Forms.Label();
            this.dtpFiltroInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroInicio = new System.Windows.Forms.Label();
            this.chkFiltroFecha = new System.Windows.Forms.CheckBox();
            this.panelGeneracion = new System.Windows.Forms.Panel();
            this.btnConfigurarPrecios = new System.Windows.Forms.Button();
            this.btnGenerarManifiesto = new System.Windows.Forms.Button();
            this.dtpFechaGenerar = new System.Windows.Forms.DateTimePicker();
            this.lblFechaGenerar = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnDescargarPdf = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnAnularManifiesto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.panelGeneracion.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvManifiestos
            //
            this.dgvManifiestos.AllowUserToAddRows = false;
            this.dgvManifiestos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvManifiestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManifiestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManifiestos.BackgroundColor = System.Drawing.Color.White;
            this.dgvManifiestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvManifiestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManifiestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManifiestos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManifiestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManifiestos.EnableHeadersVisualStyles = false;
            this.dgvManifiestos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvManifiestos.Location = new System.Drawing.Point(0, 131);
            this.dgvManifiestos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvManifiestos.MultiSelect = false;
            this.dgvManifiestos.Name = "dgvManifiestos";
            this.dgvManifiestos.ReadOnly = true;
            this.dgvManifiestos.RowHeadersWidth = 51;
            this.dgvManifiestos.RowTemplate.Height = 35;
            this.dgvManifiestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManifiestos.Size = new System.Drawing.Size(800, 275);
            this.dgvManifiestos.TabIndex = 0;
            this.dgvManifiestos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvManifiestos_CellFormatting);
            this.dgvManifiestos.SelectionChanged += new System.EventHandler(this.dgvManifiestos_SelectionChanged);
            //
            // panelFiltros
            //
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.cmbFiltroEstado);
            this.panelFiltros.Controls.Add(this.lblFiltroEstado);
            this.panelFiltros.Controls.Add(this.dtpFiltroFin);
            this.panelFiltros.Controls.Add(this.lblFiltroFin);
            this.panelFiltros.Controls.Add(this.dtpFiltroInicio);
            this.panelFiltros.Controls.Add(this.lblFiltroInicio);
            this.panelFiltros.Controls.Add(this.chkFiltroFecha);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 50);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFiltros.Size = new System.Drawing.Size(800, 81);
            this.panelFiltros.TabIndex = 1;
            //
            // btnLimpiarFiltros
            //
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(705, 40);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(75, 28);
            this.btnLimpiarFiltros.TabIndex = 8;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            //
            // btnFiltrar
            //
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(620, 40);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 28);
            this.btnFiltrar.TabIndex = 7;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            //
            // cmbFiltroEstado
            //
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Generado",
            "Anulado"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(500, 42);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(110, 23);
            this.cmbFiltroEstado.TabIndex = 6;
            //
            // lblFiltroEstado
            //
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroEstado.Location = new System.Drawing.Point(440, 45);
            this.lblFiltroEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(50, 15);
            this.lblFiltroEstado.TabIndex = 5;
            this.lblFiltroEstado.Text = "Estado:";
            //
            // dtpFiltroFin
            //
            this.dtpFiltroFin.Enabled = false;
            this.dtpFiltroFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFiltroFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFin.Location = new System.Drawing.Point(330, 42);
            this.dtpFiltroFin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFiltroFin.Name = "dtpFiltroFin";
            this.dtpFiltroFin.Size = new System.Drawing.Size(100, 23);
            this.dtpFiltroFin.TabIndex = 4;
            //
            // lblFiltroFin
            //
            this.lblFiltroFin.AutoSize = true;
            this.lblFiltroFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroFin.Location = new System.Drawing.Point(275, 45);
            this.lblFiltroFin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroFin.Name = "lblFiltroFin";
            this.lblFiltroFin.Size = new System.Drawing.Size(51, 15);
            this.lblFiltroFin.TabIndex = 3;
            this.lblFiltroFin.Text = "Hasta:";
            //
            // dtpFiltroInicio
            //
            this.dtpFiltroInicio.Enabled = false;
            this.dtpFiltroInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFiltroInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroInicio.Location = new System.Drawing.Point(170, 42);
            this.dtpFiltroInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFiltroInicio.Name = "dtpFiltroInicio";
            this.dtpFiltroInicio.Size = new System.Drawing.Size(100, 23);
            this.dtpFiltroInicio.TabIndex = 2;
            //
            // lblFiltroInicio
            //
            this.lblFiltroInicio.AutoSize = true;
            this.lblFiltroInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroInicio.Location = new System.Drawing.Point(115, 45);
            this.lblFiltroInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroInicio.Name = "lblFiltroInicio";
            this.lblFiltroInicio.Size = new System.Drawing.Size(49, 15);
            this.lblFiltroInicio.TabIndex = 1;
            this.lblFiltroInicio.Text = "Desde:";
            //
            // chkFiltroFecha
            //
            this.chkFiltroFecha.AutoSize = true;
            this.chkFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.chkFiltroFecha.Location = new System.Drawing.Point(17, 44);
            this.chkFiltroFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFiltroFecha.Name = "chkFiltroFecha";
            this.chkFiltroFecha.Size = new System.Drawing.Size(95, 19);
            this.chkFiltroFecha.TabIndex = 0;
            this.chkFiltroFecha.Text = "Por fechas:";
            this.chkFiltroFecha.UseVisualStyleBackColor = true;
            this.chkFiltroFecha.CheckedChanged += new System.EventHandler(this.chkFiltroFecha_CheckedChanged);
            //
            // panelGeneracion
            //
            this.panelGeneracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.panelGeneracion.Controls.Add(this.btnConfigurarPrecios);
            this.panelGeneracion.Controls.Add(this.btnGenerarManifiesto);
            this.panelGeneracion.Controls.Add(this.dtpFechaGenerar);
            this.panelGeneracion.Controls.Add(this.lblFechaGenerar);
            this.panelGeneracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGeneracion.Location = new System.Drawing.Point(0, 0);
            this.panelGeneracion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelGeneracion.Name = "panelGeneracion";
            this.panelGeneracion.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelGeneracion.Size = new System.Drawing.Size(800, 50);
            this.panelGeneracion.TabIndex = 3;
            //
            // btnConfigurarPrecios
            //
            this.btnConfigurarPrecios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnConfigurarPrecios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigurarPrecios.FlatAppearance.BorderSize = 0;
            this.btnConfigurarPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurarPrecios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfigurarPrecios.ForeColor = System.Drawing.Color.White;
            this.btnConfigurarPrecios.Location = new System.Drawing.Point(630, 10);
            this.btnConfigurarPrecios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfigurarPrecios.Name = "btnConfigurarPrecios";
            this.btnConfigurarPrecios.Size = new System.Drawing.Size(150, 30);
            this.btnConfigurarPrecios.TabIndex = 3;
            this.btnConfigurarPrecios.Text = "Configurar Precios";
            this.btnConfigurarPrecios.UseVisualStyleBackColor = false;
            this.btnConfigurarPrecios.Click += new System.EventHandler(this.btnConfigurarPrecios_Click);
            //
            // btnGenerarManifiesto
            //
            this.btnGenerarManifiesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGenerarManifiesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarManifiesto.FlatAppearance.BorderSize = 0;
            this.btnGenerarManifiesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarManifiesto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerarManifiesto.ForeColor = System.Drawing.Color.White;
            this.btnGenerarManifiesto.Location = new System.Drawing.Point(310, 10);
            this.btnGenerarManifiesto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarManifiesto.Name = "btnGenerarManifiesto";
            this.btnGenerarManifiesto.Size = new System.Drawing.Size(160, 30);
            this.btnGenerarManifiesto.TabIndex = 2;
            this.btnGenerarManifiesto.Text = "Generar Manifiesto";
            this.btnGenerarManifiesto.UseVisualStyleBackColor = false;
            this.btnGenerarManifiesto.Click += new System.EventHandler(this.btnGenerarManifiesto_Click);
            //
            // dtpFechaGenerar
            //
            this.dtpFechaGenerar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaGenerar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaGenerar.Location = new System.Drawing.Point(190, 14);
            this.dtpFechaGenerar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaGenerar.Name = "dtpFechaGenerar";
            this.dtpFechaGenerar.Size = new System.Drawing.Size(110, 23);
            this.dtpFechaGenerar.TabIndex = 1;
            //
            // lblFechaGenerar
            //
            this.lblFechaGenerar.AutoSize = true;
            this.lblFechaGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaGenerar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFechaGenerar.Location = new System.Drawing.Point(17, 17);
            this.lblFechaGenerar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaGenerar.Name = "lblFechaGenerar";
            this.lblFechaGenerar.Size = new System.Drawing.Size(170, 15);
            this.lblFechaGenerar.TabIndex = 0;
            this.lblFechaGenerar.Text = "Generar manifiesto del dia:";
            //
            // panelBotones
            //
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Controls.Add(this.btnDescargarPdf);
            this.panelBotones.Controls.Add(this.btnVerDetalle);
            this.panelBotones.Controls.Add(this.btnAnularManifiesto);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 406);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.panelBotones.Size = new System.Drawing.Size(800, 57);
            this.panelBotones.TabIndex = 2;
            //
            // btnDescargarPdf
            //
            this.btnDescargarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDescargarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarPdf.Enabled = false;
            this.btnDescargarPdf.FlatAppearance.BorderSize = 0;
            this.btnDescargarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarPdf.ForeColor = System.Drawing.Color.White;
            this.btnDescargarPdf.Location = new System.Drawing.Point(255, 14);
            this.btnDescargarPdf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(120, 31);
            this.btnDescargarPdf.TabIndex = 2;
            this.btnDescargarPdf.Text = "Descargar PDF";
            this.btnDescargarPdf.UseVisualStyleBackColor = false;
            this.btnDescargarPdf.Click += new System.EventHandler(this.btnDescargarPdf_Click);
            //
            // btnVerDetalle
            //
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDetalle.Enabled = false;
            this.btnVerDetalle.FlatAppearance.BorderSize = 0;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalle.Location = new System.Drawing.Point(135, 14);
            this.btnVerDetalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(112, 31);
            this.btnVerDetalle.TabIndex = 1;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            //
            // btnAnularManifiesto
            //
            this.btnAnularManifiesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnAnularManifiesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnularManifiesto.Enabled = false;
            this.btnAnularManifiesto.FlatAppearance.BorderSize = 0;
            this.btnAnularManifiesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularManifiesto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAnularManifiesto.ForeColor = System.Drawing.Color.White;
            this.btnAnularManifiesto.Location = new System.Drawing.Point(15, 14);
            this.btnAnularManifiesto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnularManifiesto.Name = "btnAnularManifiesto";
            this.btnAnularManifiesto.Size = new System.Drawing.Size(112, 31);
            this.btnAnularManifiesto.TabIndex = 0;
            this.btnAnularManifiesto.Text = "Anular";
            this.btnAnularManifiesto.UseVisualStyleBackColor = false;
            this.btnAnularManifiesto.Click += new System.EventHandler(this.btnAnularManifiesto_Click);
            //
            // FrmGestionManifiestos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.dgvManifiestos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelGeneracion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmGestionManifiestos";
            this.Text = "Gesti\u00F3n de Manifiestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvManifiestos)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelGeneracion.ResumeLayout(false);
            this.panelGeneracion.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManifiestos;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.DateTimePicker dtpFiltroFin;
        private System.Windows.Forms.Label lblFiltroFin;
        private System.Windows.Forms.DateTimePicker dtpFiltroInicio;
        private System.Windows.Forms.Label lblFiltroInicio;
        private System.Windows.Forms.CheckBox chkFiltroFecha;
        private System.Windows.Forms.Panel panelGeneracion;
        private System.Windows.Forms.Button btnConfigurarPrecios;
        private System.Windows.Forms.Button btnGenerarManifiesto;
        private System.Windows.Forms.DateTimePicker dtpFechaGenerar;
        private System.Windows.Forms.Label lblFechaGenerar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnDescargarPdf;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnAnularManifiesto;
    }
}
