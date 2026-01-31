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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRemitos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRemitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRemitos.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemitos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRemitos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRemitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRemitos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRemitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemitos.EnableHeadersVisualStyles = false;
            this.dgvRemitos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvRemitos.Location = new System.Drawing.Point(0, 81);
            this.dgvRemitos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRemitos.MultiSelect = false;
            this.dgvRemitos.Name = "dgvRemitos";
            this.dgvRemitos.ReadOnly = true;
            this.dgvRemitos.RowHeadersWidth = 51;
            this.dgvRemitos.RowTemplate.Height = 35;
            this.dgvRemitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemitos.Size = new System.Drawing.Size(750, 325);
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
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.panelFiltros.Size = new System.Drawing.Size(750, 81);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(660, 37);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(75, 28);
            this.btnLimpiarFiltros.TabIndex = 9;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(570, 37);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 28);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // cmbTipoResiduo
            // 
            this.cmbTipoResiduo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoResiduo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoResiduo.FormattingEnabled = true;
            this.cmbTipoResiduo.Location = new System.Drawing.Point(301, 44);
            this.cmbTipoResiduo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipoResiduo.Name = "cmbTipoResiduo";
            this.cmbTipoResiduo.Size = new System.Drawing.Size(114, 23);
            this.cmbTipoResiduo.TabIndex = 7;
            // 
            // lblFiltroTipoResiduo
            // 
            this.lblFiltroTipoResiduo.AutoSize = true;
            this.lblFiltroTipoResiduo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTipoResiduo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroTipoResiduo.Location = new System.Drawing.Point(202, 46);
            this.lblFiltroTipoResiduo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroTipoResiduo.Name = "lblFiltroTipoResiduo";
            this.lblFiltroTipoResiduo.Size = new System.Drawing.Size(98, 15);
            this.lblFiltroTipoResiduo.TabIndex = 6;
            this.lblFiltroTipoResiduo.Text = "Tipo de Residuo:";
            // 
            // txtFiltroCUIT
            // 
            this.txtFiltroCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroCUIT.Location = new System.Drawing.Point(93, 45);
            this.txtFiltroCUIT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFiltroCUIT.Name = "txtFiltroCUIT";
            this.txtFiltroCUIT.Size = new System.Drawing.Size(98, 23);
            this.txtFiltroCUIT.TabIndex = 5;
            // 
            // lblFiltroCUIT
            // 
            this.lblFiltroCUIT.AutoSize = true;
            this.lblFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroCUIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroCUIT.Location = new System.Drawing.Point(53, 48);
            this.lblFiltroCUIT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroCUIT.Name = "lblFiltroCUIT";
            this.lblFiltroCUIT.Size = new System.Drawing.Size(37, 15);
            this.lblFiltroCUIT.TabIndex = 4;
            this.lblFiltroCUIT.Text = "CUIT:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(301, 10);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(91, 23);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFechaFin.Location = new System.Drawing.Point(238, 14);
            this.lblFechaFin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(61, 15);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(93, 10);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(91, 23);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFechaInicio.Location = new System.Drawing.Point(17, 12);
            this.lblFechaInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(75, 15);
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
            this.panelBotones.Location = new System.Drawing.Point(0, 406);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.panelBotones.Size = new System.Drawing.Size(750, 57);
            this.panelBotones.TabIndex = 2;
            // 
            // btnEliminarRemito
            // 
            this.btnEliminarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRemito.Enabled = false;
            this.btnEliminarRemito.FlatAppearance.BorderSize = 0;
            this.btnEliminarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRemito.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRemito.Location = new System.Drawing.Point(255, 14);
            this.btnEliminarRemito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarRemito.Name = "btnEliminarRemito";
            this.btnEliminarRemito.Size = new System.Drawing.Size(112, 31);
            this.btnEliminarRemito.TabIndex = 2;
            this.btnEliminarRemito.Text = "Eliminar Remito";
            this.btnEliminarRemito.UseVisualStyleBackColor = false;
            // 
            // btnModificarRemito
            // 
            this.btnModificarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnModificarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarRemito.Enabled = false;
            this.btnModificarRemito.FlatAppearance.BorderSize = 0;
            this.btnModificarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarRemito.ForeColor = System.Drawing.Color.White;
            this.btnModificarRemito.Location = new System.Drawing.Point(135, 14);
            this.btnModificarRemito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificarRemito.Name = "btnModificarRemito";
            this.btnModificarRemito.Size = new System.Drawing.Size(112, 31);
            this.btnModificarRemito.TabIndex = 1;
            this.btnModificarRemito.Text = "Modificar Remito";
            this.btnModificarRemito.UseVisualStyleBackColor = false;
            // 
            // btnAgregarRemito
            // 
            this.btnAgregarRemito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAgregarRemito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRemito.FlatAppearance.BorderSize = 0;
            this.btnAgregarRemito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRemito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarRemito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRemito.Location = new System.Drawing.Point(15, 14);
            this.btnAgregarRemito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarRemito.Name = "btnAgregarRemito";
            this.btnAgregarRemito.Size = new System.Drawing.Size(112, 31);
            this.btnAgregarRemito.TabIndex = 0;
            this.btnAgregarRemito.Text = "Añadir Remito";
            this.btnAgregarRemito.UseVisualStyleBackColor = false;
            this.btnAgregarRemito.Click += new System.EventHandler(this.btnAgregarRemito_Click_1);
            // 
            // FrmGestionRemitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(750, 463);
            this.Controls.Add(this.dgvRemitos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
