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
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            this.btnModificarProveedor = new System.Windows.Forms.Button();
            this.btnDeshabilitarProveedor = new System.Windows.Forms.Button();
            this.btnHabilitarProveedor = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroRegion = new System.Windows.Forms.TextBox();
            this.txtFiltroRazonSocial = new System.Windows.Forms.TextBox();
            this.txtFiltroCUIT = new System.Windows.Forms.TextBox();
            this.lblFiltroRegion = new System.Windows.Forms.Label();
            this.lblFiltroRazonSocial = new System.Windows.Forms.Label();
            this.lblFiltroCUIT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(16, 197);
            this.dgvProveedores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersWidth = 51;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(1361, 492);
            this.dgvProveedores.TabIndex = 0;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAgregarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProveedor.Location = new System.Drawing.Point(16, 702);
            this.btnAgregarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(200, 49);
            this.btnAgregarProveedor.TabIndex = 1;
            this.btnAgregarProveedor.Text = "+ Agregar Proveedor";
            this.btnAgregarProveedor.UseVisualStyleBackColor = false;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // btnModificarProveedor
            // 
            this.btnModificarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnModificarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProveedor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnModificarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnModificarProveedor.Location = new System.Drawing.Point(224, 702);
            this.btnModificarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarProveedor.Name = "btnModificarProveedor";
            this.btnModificarProveedor.Size = new System.Drawing.Size(240, 49);
            this.btnModificarProveedor.TabIndex = 2;
            this.btnModificarProveedor.Text = "Modificar Proveedor";
            this.btnModificarProveedor.UseVisualStyleBackColor = false;
            this.btnModificarProveedor.Click += new System.EventHandler(this.btnModificarProveedor_Click);
            // 
            // btnDeshabilitarProveedor
            // 
            this.btnDeshabilitarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDeshabilitarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshabilitarProveedor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeshabilitarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnDeshabilitarProveedor.Location = new System.Drawing.Point(472, 702);
            this.btnDeshabilitarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeshabilitarProveedor.Name = "btnDeshabilitarProveedor";
            this.btnDeshabilitarProveedor.Size = new System.Drawing.Size(253, 49);
            this.btnDeshabilitarProveedor.TabIndex = 3;
            this.btnDeshabilitarProveedor.Text = "Deshabilitar Proveedor";
            this.btnDeshabilitarProveedor.UseVisualStyleBackColor = false;
            this.btnDeshabilitarProveedor.Click += new System.EventHandler(this.btnDeshabilitarProveedor_Click);
            // 
            // btnHabilitarProveedor
            // 
            this.btnHabilitarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnHabilitarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilitarProveedor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnHabilitarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnHabilitarProveedor.Location = new System.Drawing.Point(733, 702);
            this.btnHabilitarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHabilitarProveedor.Name = "btnHabilitarProveedor";
            this.btnHabilitarProveedor.Size = new System.Drawing.Size(240, 49);
            this.btnHabilitarProveedor.TabIndex = 8;
            this.btnHabilitarProveedor.Text = "Habilitar Proveedor";
            this.btnHabilitarProveedor.UseVisualStyleBackColor = false;
            this.btnHabilitarProveedor.Click += new System.EventHandler(this.btnHabilitarProveedor_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 18);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(330, 32);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Gestión de Proveedores";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.txtFiltroRegion);
            this.grpFiltros.Controls.Add(this.txtFiltroRazonSocial);
            this.grpFiltros.Controls.Add(this.txtFiltroCUIT);
            this.grpFiltros.Controls.Add(this.lblFiltroRegion);
            this.grpFiltros.Controls.Add(this.lblFiltroRazonSocial);
            this.grpFiltros.Controls.Add(this.lblFiltroCUIT);
            this.grpFiltros.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.Location = new System.Drawing.Point(16, 62);
            this.grpFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltros.Size = new System.Drawing.Size(1280, 123);
            this.grpFiltros.TabIndex = 5;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(1133, 68);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(133, 37);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(992, 68);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(133, 37);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltroRegion
            // 
            this.txtFiltroRegion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFiltroRegion.Location = new System.Drawing.Point(687, 74);
            this.txtFiltroRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroRegion.Name = "txtFiltroRegion";
            this.txtFiltroRegion.Size = new System.Drawing.Size(265, 25);
            this.txtFiltroRegion.TabIndex = 5;
            // 
            // txtFiltroRazonSocial
            // 
            this.txtFiltroRazonSocial.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFiltroRazonSocial.Location = new System.Drawing.Point(356, 74);
            this.txtFiltroRazonSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroRazonSocial.Name = "txtFiltroRazonSocial";
            this.txtFiltroRazonSocial.Size = new System.Drawing.Size(292, 25);
            this.txtFiltroRazonSocial.TabIndex = 4;
            // 
            // txtFiltroCUIT
            // 
            this.txtFiltroCUIT.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFiltroCUIT.Location = new System.Drawing.Point(27, 74);
            this.txtFiltroCUIT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroCUIT.Name = "txtFiltroCUIT";
            this.txtFiltroCUIT.Size = new System.Drawing.Size(292, 25);
            this.txtFiltroCUIT.TabIndex = 3;
            // 
            // lblFiltroRegion
            // 
            this.lblFiltroRegion.AutoSize = true;
            this.lblFiltroRegion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFiltroRegion.Location = new System.Drawing.Point(683, 43);
            this.lblFiltroRegion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroRegion.Name = "lblFiltroRegion";
            this.lblFiltroRegion.Size = new System.Drawing.Size(58, 17);
            this.lblFiltroRegion.TabIndex = 2;
            this.lblFiltroRegion.Text = "Región:";
            // 
            // lblFiltroRazonSocial
            // 
            this.lblFiltroRazonSocial.AutoSize = true;
            this.lblFiltroRazonSocial.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFiltroRazonSocial.Location = new System.Drawing.Point(352, 43);
            this.lblFiltroRazonSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroRazonSocial.Name = "lblFiltroRazonSocial";
            this.lblFiltroRazonSocial.Size = new System.Drawing.Size(99, 17);
            this.lblFiltroRazonSocial.TabIndex = 1;
            this.lblFiltroRazonSocial.Text = "Razón Social:";
            // 
            // lblFiltroCUIT
            // 
            this.lblFiltroCUIT.AutoSize = true;
            this.lblFiltroCUIT.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFiltroCUIT.Location = new System.Drawing.Point(23, 43);
            this.lblFiltroCUIT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroCUIT.Name = "lblFiltroCUIT";
            this.lblFiltroCUIT.Size = new System.Drawing.Size(43, 17);
            this.lblFiltroCUIT.TabIndex = 0;
            this.lblFiltroCUIT.Text = "CUIT:";
            // 
            // FrmGestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1405, 764);
            this.Controls.Add(this.btnHabilitarProveedor);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnDeshabilitarProveedor);
            this.Controls.Add(this.btnModificarProveedor);
            this.Controls.Add(this.btnAgregarProveedor);
            this.Controls.Add(this.dgvProveedores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmGestionProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Proveedores - RedAceite";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnAgregarProveedor;
        private System.Windows.Forms.Button btnModificarProveedor;
        private System.Windows.Forms.Button btnDeshabilitarProveedor;
        private System.Windows.Forms.Button btnHabilitarProveedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroRegion;
        private System.Windows.Forms.TextBox txtFiltroRazonSocial;
        private System.Windows.Forms.TextBox txtFiltroCUIT;
        private System.Windows.Forms.Label lblFiltroRegion;
        private System.Windows.Forms.Label lblFiltroRazonSocial;
        private System.Windows.Forms.Label lblFiltroCUIT;
    }
}
