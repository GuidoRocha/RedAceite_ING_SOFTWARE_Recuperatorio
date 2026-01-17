namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmGestionProveedores
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
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroRegion = new System.Windows.Forms.TextBox();
            this.lblFiltroRegion = new System.Windows.Forms.Label();
            this.txtFiltroRazonSocial = new System.Windows.Forms.TextBox();
            this.lblFiltroRazonSocial = new System.Windows.Forms.Label();
            this.txtFiltroCUIT = new System.Windows.Forms.TextBox();
            this.lblFiltroCUIT = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnHabilitarProveedor = new System.Windows.Forms.Button();
            this.btnDeshabilitarProveedor = new System.Windows.Forms.Button();
            this.btnModificarProveedor = new System.Windows.Forms.Button();
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.ColumnHeadersHeight = 40;
            this.dgvProveedores.EnableHeadersVisualStyles = false;
            this.dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvProveedores.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvProveedores.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvProveedores.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvProveedores.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProveedores.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvProveedores.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvProveedores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvProveedores.RowTemplate.Height = 35;
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(0, 80);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersWidth = 51;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(1000, 420);
            this.dgvProveedores.TabIndex = 0;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.txtFiltroRegion);
            this.panelFiltros.Controls.Add(this.lblFiltroRegion);
            this.panelFiltros.Controls.Add(this.txtFiltroRazonSocial);
            this.panelFiltros.Controls.Add(this.lblFiltroRazonSocial);
            this.panelFiltros.Controls.Add(this.txtFiltroCUIT);
            this.panelFiltros.Controls.Add(this.lblFiltroCUIT);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panelFiltros.Size = new System.Drawing.Size(1000, 80);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(880, 22);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(760, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 35);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltroRegion
            // 
            this.txtFiltroRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroRegion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroRegion.Location = new System.Drawing.Point(530, 27);
            this.txtFiltroRegion.Name = "txtFiltroRegion";
            this.txtFiltroRegion.Size = new System.Drawing.Size(180, 23);
            this.txtFiltroRegion.TabIndex = 5;
            // 
            // lblFiltroRegion
            // 
            this.lblFiltroRegion.AutoSize = true;
            this.lblFiltroRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroRegion.Location = new System.Drawing.Point(470, 30);
            this.lblFiltroRegion.Name = "lblFiltroRegion";
            this.lblFiltroRegion.Size = new System.Drawing.Size(54, 15);
            this.lblFiltroRegion.TabIndex = 4;
            this.lblFiltroRegion.Text = "Región:";
            // 
            // txtFiltroRazonSocial
            // 
            this.txtFiltroRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroRazonSocial.Location = new System.Drawing.Point(295, 27);
            this.txtFiltroRazonSocial.Name = "txtFiltroRazonSocial";
            this.txtFiltroRazonSocial.Size = new System.Drawing.Size(150, 23);
            this.txtFiltroRazonSocial.TabIndex = 3;
            // 
            // lblFiltroRazonSocial
            // 
            this.lblFiltroRazonSocial.AutoSize = true;
            this.lblFiltroRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroRazonSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroRazonSocial.Location = new System.Drawing.Point(195, 30);
            this.lblFiltroRazonSocial.Name = "lblFiltroRazonSocial";
            this.lblFiltroRazonSocial.Size = new System.Drawing.Size(87, 15);
            this.lblFiltroRazonSocial.TabIndex = 2;
            this.lblFiltroRazonSocial.Text = "Razón Social:";
            // 
            // txtFiltroCUIT
            // 
            this.txtFiltroCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroCUIT.Location = new System.Drawing.Point(75, 27);
            this.txtFiltroCUIT.Name = "txtFiltroCUIT";
            this.txtFiltroCUIT.Size = new System.Drawing.Size(100, 23);
            this.txtFiltroCUIT.TabIndex = 1;
            // 
            // lblFiltroCUIT
            // 
            this.lblFiltroCUIT.AutoSize = true;
            this.lblFiltroCUIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroCUIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroCUIT.Location = new System.Drawing.Point(30, 30);
            this.lblFiltroCUIT.Name = "lblFiltroCUIT";
            this.lblFiltroCUIT.Size = new System.Drawing.Size(38, 15);
            this.lblFiltroCUIT.TabIndex = 0;
            this.lblFiltroCUIT.Text = "CUIT:";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Controls.Add(this.btnHabilitarProveedor);
            this.panelBotones.Controls.Add(this.btnDeshabilitarProveedor);
            this.panelBotones.Controls.Add(this.btnModificarProveedor);
            this.panelBotones.Controls.Add(this.btnAgregarProveedor);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 500);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.panelBotones.Size = new System.Drawing.Size(1000, 70);
            this.panelBotones.TabIndex = 2;
            // 
            // btnHabilitarProveedor
            // 
            this.btnHabilitarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnHabilitarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHabilitarProveedor.Enabled = false;
            this.btnHabilitarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilitarProveedor.FlatAppearance.BorderSize = 0;
            this.btnHabilitarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHabilitarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnHabilitarProveedor.Location = new System.Drawing.Point(500, 17);
            this.btnHabilitarProveedor.Name = "btnHabilitarProveedor";
            this.btnHabilitarProveedor.Size = new System.Drawing.Size(150, 38);
            this.btnHabilitarProveedor.TabIndex = 3;
            this.btnHabilitarProveedor.Text = "Habilitar";
            this.btnHabilitarProveedor.UseVisualStyleBackColor = false;
            this.btnHabilitarProveedor.Click += new System.EventHandler(this.btnHabilitarProveedor_Click);
            // 
            // btnDeshabilitarProveedor
            // 
            this.btnDeshabilitarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeshabilitarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeshabilitarProveedor.Enabled = false;
            this.btnDeshabilitarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshabilitarProveedor.FlatAppearance.BorderSize = 0;
            this.btnDeshabilitarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeshabilitarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnDeshabilitarProveedor.Location = new System.Drawing.Point(340, 17);
            this.btnDeshabilitarProveedor.Name = "btnDeshabilitarProveedor";
            this.btnDeshabilitarProveedor.Size = new System.Drawing.Size(150, 38);
            this.btnDeshabilitarProveedor.TabIndex = 2;
            this.btnDeshabilitarProveedor.Text = "Deshabilitar";
            this.btnDeshabilitarProveedor.UseVisualStyleBackColor = false;
            this.btnDeshabilitarProveedor.Click += new System.EventHandler(this.btnDeshabilitarProveedor_Click);
            // 
            // btnModificarProveedor
            // 
            this.btnModificarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnModificarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarProveedor.Enabled = false;
            this.btnModificarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProveedor.FlatAppearance.BorderSize = 0;
            this.btnModificarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnModificarProveedor.Location = new System.Drawing.Point(180, 17);
            this.btnModificarProveedor.Name = "btnModificarProveedor";
            this.btnModificarProveedor.Size = new System.Drawing.Size(150, 38);
            this.btnModificarProveedor.TabIndex = 1;
            this.btnModificarProveedor.Text = "Modificar";
            this.btnModificarProveedor.UseVisualStyleBackColor = false;
            this.btnModificarProveedor.Click += new System.EventHandler(this.btnModificarProveedor_Click);
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAgregarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProveedor.FlatAppearance.BorderSize = 0;
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProveedor.Location = new System.Drawing.Point(20, 17);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(150, 38);
            this.btnAgregarProveedor.TabIndex = 0;
            this.btnAgregarProveedor.Text = "Agregar";
            this.btnAgregarProveedor.UseVisualStyleBackColor = false;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // FrmGestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionProveedores";
            this.Text = "Gestión de Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroRegion;
        private System.Windows.Forms.Label lblFiltroRegion;
        private System.Windows.Forms.TextBox txtFiltroRazonSocial;
        private System.Windows.Forms.Label lblFiltroRazonSocial;
        private System.Windows.Forms.TextBox txtFiltroCUIT;
        private System.Windows.Forms.Label lblFiltroCUIT;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnHabilitarProveedor;
        private System.Windows.Forms.Button btnDeshabilitarProveedor;
        private System.Windows.Forms.Button btnModificarProveedor;
        private System.Windows.Forms.Button btnAgregarProveedor;
    }
}
