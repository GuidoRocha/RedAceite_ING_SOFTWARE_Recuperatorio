namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmGestionRoles
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnEditarRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelFiltros
            //
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.txtFiltroNombre);
            this.panelFiltros.Controls.Add(this.lblFiltroNombre);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(20);
            this.panelFiltros.Size = new System.Drawing.Size(1000, 80);
            this.panelFiltros.TabIndex = 0;
            //
            // lblFiltroNombre
            //
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroNombre.Location = new System.Drawing.Point(20, 30);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(55, 20);
            this.lblFiltroNombre.TabIndex = 0;
            this.lblFiltroNombre.Text = "Nombre:";
            //
            // txtFiltroNombre
            //
            this.txtFiltroNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroNombre.Location = new System.Drawing.Point(90, 27);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(250, 27);
            this.txtFiltroNombre.TabIndex = 1;
            //
            // btnFiltrar
            //
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(360, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 35);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            //
            // btnLimpiarFiltros
            //
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(470, 22);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltros.TabIndex = 3;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            //
            // dgvRoles
            //
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRoles.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvRoles.ColumnHeadersHeight = 40;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            cellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoles.DefaultCellStyle = cellStyle;
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRoles.AlternatingRowsDefaultCellStyle = altStyle;
            this.dgvRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoles.EnableHeadersVisualStyles = false;
            this.dgvRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvRoles.Location = new System.Drawing.Point(0, 80);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.RowTemplate.Height = 35;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(1000, 420);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.SelectionChanged += new System.EventHandler(this.dgvRoles_SelectionChanged);
            //
            // panelBotones
            //
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Controls.Add(this.btnCrearRol);
            this.panelBotones.Controls.Add(this.btnEditarRol);
            this.panelBotones.Controls.Add(this.btnEliminarRol);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 500);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.panelBotones.Size = new System.Drawing.Size(1000, 70);
            this.panelBotones.TabIndex = 2;
            //
            // btnCrearRol
            //
            this.btnCrearRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCrearRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRol.FlatAppearance.BorderSize = 0;
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCrearRol.ForeColor = System.Drawing.Color.White;
            this.btnCrearRol.Location = new System.Drawing.Point(20, 17);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(150, 38);
            this.btnCrearRol.TabIndex = 0;
            this.btnCrearRol.Text = "Crear Rol";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            //
            // btnEditarRol
            //
            this.btnEditarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnEditarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarRol.Enabled = false;
            this.btnEditarRol.FlatAppearance.BorderSize = 0;
            this.btnEditarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarRol.ForeColor = System.Drawing.Color.White;
            this.btnEditarRol.Location = new System.Drawing.Point(180, 17);
            this.btnEditarRol.Name = "btnEditarRol";
            this.btnEditarRol.Size = new System.Drawing.Size(150, 38);
            this.btnEditarRol.TabIndex = 1;
            this.btnEditarRol.Text = "Editar Rol";
            this.btnEditarRol.UseVisualStyleBackColor = false;
            this.btnEditarRol.Click += new System.EventHandler(this.btnEditarRol_Click);
            //
            // btnEliminarRol
            //
            this.btnEliminarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRol.Enabled = false;
            this.btnEliminarRol.FlatAppearance.BorderSize = 0;
            this.btnEliminarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRol.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRol.Location = new System.Drawing.Point(340, 17);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(150, 38);
            this.btnEliminarRol.TabIndex = 2;
            this.btnEliminarRol.Text = "Eliminar Rol";
            this.btnEliminarRol.UseVisualStyleBackColor = false;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            //
            // FrmGestionRoles
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionRoles";
            this.Text = "Gestión de Roles";
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnEditarRol;
        private System.Windows.Forms.Button btnEliminarRol;
    }
}
