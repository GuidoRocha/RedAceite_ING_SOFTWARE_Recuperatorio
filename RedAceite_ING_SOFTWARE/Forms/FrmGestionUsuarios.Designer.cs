namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmGestionUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroDNI = new System.Windows.Forms.TextBox();
            this.lblFiltroDNI = new System.Windows.Forms.Label();
            this.txtFiltroUsername = new System.Windows.Forms.TextBox();
            this.lblFiltroUsername = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnAsignarPatentes = new System.Windows.Forms.Button();
            this.btnAsignarFamilias = new System.Windows.Forms.Button();
            this.btnHabilitarUsuario = new System.Windows.Forms.Button();
            this.btnDeshabilitarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.ColumnHeadersHeight = 40;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvUsuarios.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsuarios.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvUsuarios.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsuarios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvUsuarios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvUsuarios.RowTemplate.Height = 35;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 80);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1000, 420);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.txtFiltroDNI);
            this.panelFiltros.Controls.Add(this.lblFiltroDNI);
            this.panelFiltros.Controls.Add(this.txtFiltroUsername);
            this.panelFiltros.Controls.Add(this.lblFiltroUsername);
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(780, 22);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarFiltros.TabIndex = 5;
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
            this.btnFiltrar.Location = new System.Drawing.Point(660, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 35);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltroDNI
            // 
            this.txtFiltroDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroDNI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroDNI.Location = new System.Drawing.Point(400, 27);
            this.txtFiltroDNI.Name = "txtFiltroDNI";
            this.txtFiltroDNI.Size = new System.Drawing.Size(200, 23);
            this.txtFiltroDNI.TabIndex = 3;
            // 
            // lblFiltroDNI
            // 
            this.lblFiltroDNI.AutoSize = true;
            this.lblFiltroDNI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroDNI.Location = new System.Drawing.Point(350, 30);
            this.lblFiltroDNI.Name = "lblFiltroDNI";
            this.lblFiltroDNI.Size = new System.Drawing.Size(34, 15);
            this.lblFiltroDNI.TabIndex = 2;
            this.lblFiltroDNI.Text = "DNI:";
            // 
            // txtFiltroUsername
            // 
            this.txtFiltroUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiltroUsername.Location = new System.Drawing.Point(100, 27);
            this.txtFiltroUsername.Name = "txtFiltroUsername";
            this.txtFiltroUsername.Size = new System.Drawing.Size(200, 23);
            this.txtFiltroUsername.TabIndex = 1;
            // 
            // lblFiltroUsername
            // 
            this.lblFiltroUsername.AutoSize = true;
            this.lblFiltroUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFiltroUsername.Location = new System.Drawing.Point(30, 30);
            this.lblFiltroUsername.Name = "lblFiltroUsername";
            this.lblFiltroUsername.Size = new System.Drawing.Size(57, 15);
            this.lblFiltroUsername.TabIndex = 0;
            this.lblFiltroUsername.Text = "Usuario:";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Controls.Add(this.btnAsignarPatentes);
            this.panelBotones.Controls.Add(this.btnAsignarFamilias);
            this.panelBotones.Controls.Add(this.btnHabilitarUsuario);
            this.panelBotones.Controls.Add(this.btnDeshabilitarUsuario);
            this.panelBotones.Controls.Add(this.btnModificarUsuario);
            this.panelBotones.Controls.Add(this.btnAgregarUsuario);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 500);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.panelBotones.Size = new System.Drawing.Size(1000, 70);
            this.panelBotones.TabIndex = 2;
            // 
            // btnAsignarPatentes
            // 
            this.btnAsignarPatentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAsignarPatentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarPatentes.Enabled = false;
            this.btnAsignarPatentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarPatentes.FlatAppearance.BorderSize = 0;
            this.btnAsignarPatentes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarPatentes.ForeColor = System.Drawing.Color.White;
            this.btnAsignarPatentes.Location = new System.Drawing.Point(820, 17);
            this.btnAsignarPatentes.Name = "btnAsignarPatentes";
            this.btnAsignarPatentes.Size = new System.Drawing.Size(150, 38);
            this.btnAsignarPatentes.TabIndex = 5;
            this.btnAsignarPatentes.Text = "Asignar Patentes";
            this.btnAsignarPatentes.UseVisualStyleBackColor = false;
            this.btnAsignarPatentes.Click += new System.EventHandler(this.btnAsignarPatentes_Click);
            // 
            // btnAsignarFamilias
            // 
            this.btnAsignarFamilias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAsignarFamilias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarFamilias.Enabled = false;
            this.btnAsignarFamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarFamilias.FlatAppearance.BorderSize = 0;
            this.btnAsignarFamilias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarFamilias.ForeColor = System.Drawing.Color.White;
            this.btnAsignarFamilias.Location = new System.Drawing.Point(660, 17);
            this.btnAsignarFamilias.Name = "btnAsignarFamilias";
            this.btnAsignarFamilias.Size = new System.Drawing.Size(150, 38);
            this.btnAsignarFamilias.TabIndex = 4;
            this.btnAsignarFamilias.Text = "Asignar Familias";
            this.btnAsignarFamilias.UseVisualStyleBackColor = false;
            this.btnAsignarFamilias.Click += new System.EventHandler(this.btnAsignarFamilias_Click);
            // 
            // btnHabilitarUsuario
            // 
            this.btnHabilitarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnHabilitarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHabilitarUsuario.Enabled = false;
            this.btnHabilitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilitarUsuario.FlatAppearance.BorderSize = 0;
            this.btnHabilitarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHabilitarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnHabilitarUsuario.Location = new System.Drawing.Point(500, 17);
            this.btnHabilitarUsuario.Name = "btnHabilitarUsuario";
            this.btnHabilitarUsuario.Size = new System.Drawing.Size(150, 38);
            this.btnHabilitarUsuario.TabIndex = 3;
            this.btnHabilitarUsuario.Text = "Habilitar";
            this.btnHabilitarUsuario.UseVisualStyleBackColor = false;
            this.btnHabilitarUsuario.Click += new System.EventHandler(this.btnHabilitarUsuario_Click);
            // 
            // btnDeshabilitarUsuario
            // 
            this.btnDeshabilitarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeshabilitarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeshabilitarUsuario.Enabled = false;
            this.btnDeshabilitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshabilitarUsuario.FlatAppearance.BorderSize = 0;
            this.btnDeshabilitarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeshabilitarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnDeshabilitarUsuario.Location = new System.Drawing.Point(340, 17);
            this.btnDeshabilitarUsuario.Name = "btnDeshabilitarUsuario";
            this.btnDeshabilitarUsuario.Size = new System.Drawing.Size(150, 38);
            this.btnDeshabilitarUsuario.TabIndex = 2;
            this.btnDeshabilitarUsuario.Text = "Deshabilitar";
            this.btnDeshabilitarUsuario.UseVisualStyleBackColor = false;
            this.btnDeshabilitarUsuario.Click += new System.EventHandler(this.btnDeshabilitarUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnModificarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarUsuario.Enabled = false;
            this.btnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarUsuario.FlatAppearance.BorderSize = 0;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnModificarUsuario.Location = new System.Drawing.Point(180, 17);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(150, 38);
            this.btnModificarUsuario.TabIndex = 1;
            this.btnModificarUsuario.Text = "Modificar";
            this.btnModificarUsuario.UseVisualStyleBackColor = false;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAgregarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            this.btnAgregarUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUsuario.Location = new System.Drawing.Point(20, 17);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(150, 38);
            this.btnAgregarUsuario.TabIndex = 0;
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = false;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // FrmGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionUsuarios";
            this.Text = "Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroDNI;
        private System.Windows.Forms.Label lblFiltroDNI;
        private System.Windows.Forms.TextBox txtFiltroUsername;
        private System.Windows.Forms.Label lblFiltroUsername;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnAsignarPatentes;
        private System.Windows.Forms.Button btnAsignarFamilias;
        private System.Windows.Forms.Button btnHabilitarUsuario;
        private System.Windows.Forms.Button btnDeshabilitarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnAgregarUsuario;
    }
}
