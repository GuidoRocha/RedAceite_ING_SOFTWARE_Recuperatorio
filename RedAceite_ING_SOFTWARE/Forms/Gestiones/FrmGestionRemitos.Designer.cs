namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmGestionRemitos
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
            this.dgvRemitos = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbTipoResiduo = new System.Windows.Forms.ComboBox();
            this.lblFiltroTipoResiduo = new System.Windows.Forms.Label();
            this.txtFiltroCUIT = new System.Windows.Forms.TextBox();
            this.lblFiltroCUIT = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnEliminarRemito = new System.Windows.Forms.Button();
            this.btnModificarRemito = new System.Windows.Forms.Button();
            this.btnAgregarRemito = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRemitos
            // 
            this.dgvRemitos.AllowUserToAddRows = false;
            this.dgvRemitos.AllowUserToDeleteRows = false;
            this.dgvRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRemitos.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemitos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemitos.ColumnHeadersHeight = 40;
            this.dgvRemitos.EnableHeadersVisualStyles = false;
            this.dgvRemitos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvRemitos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRemitos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvRemitos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvRemitos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvRemitos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvRemitos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRemitos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvRemitos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRemitos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRemitos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvRemitos.RowTemplate.Height = 35;
            this.dgvRemitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemitos.Location = new System.Drawing.Point(0, 100);
            this.dgvRemitos.MultiSelect = false;
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.ReadOnly = true;
            this.dgvRemitos.RowHeadersWidth = 51;
            this.dgvRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemitos.Size = new System.Drawing.Size(1000, 400);
            this.dgvRemitos.TabIndex = 0;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.cmbTipoResiduo);
            this.panelFiltros.Controls.Add(this.lblFiltroTipoResiduo);
            this.panelFiltros.Controls.Add(this.txtFiltroCUIT);
            this.panelFiltros.Controls.Add(this.lblFiltroCUIT);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.lblFechaFin);
            this.panelFiltros.Controls.Add(this.dtpFechaInicio);
            this.panelFiltros.Controls.Add(this.lblFechaInicio);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelFiltros.Size = new System.Drawing.Size(1000, 100);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(880, 45);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(760, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 35);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // cmbTipoResiduo
            // 
            this.cmbTipoResiduo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoResiduo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoResiduo.FormattingEnabled = true;
            this.cmbTipoResiduo.Location = new System.Drawing.Point(570, 52);
            this.cmbTipoResiduo.Name = "cmbTipoResiduo";
            this.cmbTipoResiduo.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoResiduo.TabIndex = 7;
            // 
            // lblFiltroTipoResiduo
            // 
            this.lblFiltroTipoResiduo.AutoSize = true;
            this.lblFiltroTipoResiduo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTipoResiduo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroTipoResiduo.Location = new System.Drawing.Point(465, 55);
            this.lblFiltroTipoResiduo.Name = "lblFiltroTipoResiduo";
            this.lblFiltroTipoResiduo.Size = new System.Drawing.Size(99, 15);
            this.lblFiltroTipoResiduo.TabIndex = 6;
            this.lblFiltroTipoResiduo.Text = "Tipo de Residuo:";
            // 
            // txtFiltroCUIT
            // 
            this.txtFiltroCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroCUIT.Location = new System.Drawing.Point(315, 52);
            this.txtFiltroCUIT.Name = "txtFiltroCUIT";
            this.txtFiltroCUIT.Size = new System.Drawing.Size(130, 23);
            this.txtFiltroCUIT.TabIndex = 5;
            // 
            // lblFiltroCUIT
            // 
            this.lblFiltroCUIT.AutoSize = true;
            this.lblFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroCUIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroCUIT.Location = new System.Drawing.Point(270, 55);
            this.lblFiltroCUIT.Name = "lblFiltroCUIT";
            this.lblFiltroCUIT.Size = new System.Drawing.Size(38, 15);
            this.lblFiltroCUIT.TabIndex = 4;
            this.lblFiltroCUIT.Text = "CUIT:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(570, 18);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Checked = false;
            this.dtpFechaFin.Size = new System.Drawing.Size(120, 23);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFechaFin.Location = new System.Drawing.Point(495, 22);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(66, 15);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(315, 18);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.ShowCheckBox = true;
            this.dtpFechaInicio.Checked = false;
            this.dtpFechaInicio.Size = new System.Drawing.Size(120, 23);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFechaInicio.Location = new System.Drawing.Point(225, 22);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(77, 15);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Controls.Add(this.btnEliminarRemito);
            this.panelBotones.Controls.Add(this.btnModificarRemito);
            this.panelBotones.Controls.Add(this.btnAgregarRemito);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 500);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.panelBotones.Size = new System.Drawing.Size(1000, 70);
            this.panelBotones.TabIndex = 2;
            // 
            // btnEliminarRemito
            // 
            this.btnEliminarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRemito.Enabled = false;
            this.btnEliminarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRemito.FlatAppearance.BorderSize = 0;
            this.btnEliminarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRemito.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRemito.Location = new System.Drawing.Point(340, 17);
            this.btnEliminarRemito.Name = "btnEliminarRemito";
            this.btnEliminarRemito.Size = new System.Drawing.Size(150, 38);
            this.btnEliminarRemito.TabIndex = 2;
            this.btnEliminarRemito.Text = "Eliminar Remito";
            this.btnEliminarRemito.UseVisualStyleBackColor = false;
            // 
            // btnModificarRemito
            // 
            this.btnModificarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnModificarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarRemito.Enabled = false;
            this.btnModificarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarRemito.FlatAppearance.BorderSize = 0;
            this.btnModificarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarRemito.ForeColor = System.Drawing.Color.White;
            this.btnModificarRemito.Location = new System.Drawing.Point(180, 17);
            this.btnModificarRemito.Name = "btnModificarRemito";
            this.btnModificarRemito.Size = new System.Drawing.Size(150, 38);
            this.btnModificarRemito.TabIndex = 1;
            this.btnModificarRemito.Text = "Modificar Remito";
            this.btnModificarRemito.UseVisualStyleBackColor = false;
            // 
            // btnAgregarRemito
            // 
            this.btnAgregarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAgregarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRemito.FlatAppearance.BorderSize = 0;
            this.btnAgregarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarRemito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRemito.Location = new System.Drawing.Point(20, 17);
            this.btnAgregarRemito.Name = "btnAgregarRemito";
            this.btnAgregarRemito.Size = new System.Drawing.Size(150, 38);
            this.btnAgregarRemito.TabIndex = 0;
            this.btnAgregarRemito.Text = "Añadir Remito";
            this.btnAgregarRemito.UseVisualStyleBackColor = false;
            // 
            // FrmGestionRemitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.dgvRemitos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionRemitos";
            this.Text = "Gestión de Remitos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemitos)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRemitos;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbTipoResiduo;
        private System.Windows.Forms.Label lblFiltroTipoResiduo;
        private System.Windows.Forms.TextBox txtFiltroCUIT;
        private System.Windows.Forms.Label lblFiltroCUIT;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEliminarRemito;
        private System.Windows.Forms.Button btnModificarRemito;
        private System.Windows.Forms.Button btnAgregarRemito;
    }
}
