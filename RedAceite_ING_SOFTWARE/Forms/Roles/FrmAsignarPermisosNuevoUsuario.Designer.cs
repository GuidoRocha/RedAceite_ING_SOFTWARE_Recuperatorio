namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmAsignarPermisosNuevoUsuario
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioInfo = new System.Windows.Forms.Label();
            this.grpFamilia = new System.Windows.Forms.GroupBox();
            this.lblFamiliaDesc = new System.Windows.Forms.Label();
            this.cmbFamilia = new System.Windows.Forms.ComboBox();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.grpPatentes = new System.Windows.Forms.GroupBox();
            this.lblPatentesDesc = new System.Windows.Forms.Label();
            this.clbPatentes = new System.Windows.Forms.CheckedListBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnOmitir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.grpFamilia.SuspendLayout();
            this.grpPatentes.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblUsuarioInfo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHeader.Size = new System.Drawing.Size(700, 100);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(340, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignar Permisos al Usuario";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(22, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(450, 20);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Seleccione un rol (familia) y/o permisos individuales (patentes)";
            //
            // lblUsuarioInfo
            //
            this.lblUsuarioInfo.AutoSize = true;
            this.lblUsuarioInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.lblUsuarioInfo.Location = new System.Drawing.Point(22, 70);
            this.lblUsuarioInfo.Name = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size = new System.Drawing.Size(80, 23);
            this.lblUsuarioInfo.TabIndex = 2;
            this.lblUsuarioInfo.Text = "Usuario: ";
            //
            // grpFamilia
            //
            this.grpFamilia.Controls.Add(this.lblFamiliaDesc);
            this.grpFamilia.Controls.Add(this.cmbFamilia);
            this.grpFamilia.Controls.Add(this.lblFamilia);
            this.grpFamilia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFamilia.Location = new System.Drawing.Point(25, 115);
            this.grpFamilia.Name = "grpFamilia";
            this.grpFamilia.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpFamilia.Size = new System.Drawing.Size(650, 120);
            this.grpFamilia.TabIndex = 1;
            this.grpFamilia.TabStop = false;
            this.grpFamilia.Text = "Rol (Familia)";
            //
            // lblFamilia
            //
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFamilia.Location = new System.Drawing.Point(18, 38);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(130, 22);
            this.lblFamilia.TabIndex = 0;
            this.lblFamilia.Text = "Seleccionar rol:";
            //
            // cmbFamilia
            //
            this.cmbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFamilia.FormattingEnabled = true;
            this.cmbFamilia.Location = new System.Drawing.Point(170, 35);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.Size = new System.Drawing.Size(460, 31);
            this.cmbFamilia.TabIndex = 1;
            this.cmbFamilia.SelectedIndexChanged += new System.EventHandler(this.cmbFamilia_SelectedIndexChanged);
            //
            // lblFamiliaDesc
            //
            this.lblFamiliaDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblFamiliaDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblFamiliaDesc.Location = new System.Drawing.Point(18, 78);
            this.lblFamiliaDesc.Name = "lblFamiliaDesc";
            this.lblFamiliaDesc.Size = new System.Drawing.Size(612, 25);
            this.lblFamiliaDesc.TabIndex = 2;
            this.lblFamiliaDesc.Text = "Al seleccionar un rol, se asignan automaticamente los permisos incluidos en ese rol.";
            //
            // grpPatentes
            //
            this.grpPatentes.Controls.Add(this.lblPatentesDesc);
            this.grpPatentes.Controls.Add(this.clbPatentes);
            this.grpPatentes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPatentes.Location = new System.Drawing.Point(25, 250);
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpPatentes.Size = new System.Drawing.Size(650, 240);
            this.grpPatentes.TabIndex = 2;
            this.grpPatentes.TabStop = false;
            this.grpPatentes.Text = "Permisos Individuales (Patentes)";
            //
            // lblPatentesDesc
            //
            this.lblPatentesDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblPatentesDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblPatentesDesc.Location = new System.Drawing.Point(18, 30);
            this.lblPatentesDesc.Name = "lblPatentesDesc";
            this.lblPatentesDesc.Size = new System.Drawing.Size(612, 22);
            this.lblPatentesDesc.TabIndex = 0;
            this.lblPatentesDesc.Text = "Puede asignar permisos adicionales individuales, independientes del rol seleccionado.";
            //
            // clbPatentes
            //
            this.clbPatentes.CheckOnClick = true;
            this.clbPatentes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.clbPatentes.FormattingEnabled = true;
            this.clbPatentes.Location = new System.Drawing.Point(18, 58);
            this.clbPatentes.Name = "clbPatentes";
            this.clbPatentes.Size = new System.Drawing.Size(612, 164);
            this.clbPatentes.TabIndex = 1;
            //
            // panelBotones
            //
            this.panelBotones.Controls.Add(this.btnOmitir);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 505);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(700, 60);
            this.panelBotones.TabIndex = 3;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(370, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Permisos";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnOmitir
            //
            this.btnOmitir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnOmitir.FlatAppearance.BorderSize = 0;
            this.btnOmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmitir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOmitir.ForeColor = System.Drawing.Color.White;
            this.btnOmitir.Location = new System.Drawing.Point(130, 10);
            this.btnOmitir.Name = "btnOmitir";
            this.btnOmitir.Size = new System.Drawing.Size(200, 40);
            this.btnOmitir.TabIndex = 0;
            this.btnOmitir.Text = "Omitir (sin permisos)";
            this.btnOmitir.UseVisualStyleBackColor = false;
            this.btnOmitir.Click += new System.EventHandler(this.btnOmitir_Click);
            //
            // FrmAsignarPermisosNuevoUsuario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(700, 565);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.grpPatentes);
            this.Controls.Add(this.grpFamilia);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAsignarPermisosNuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Permisos - Nuevo Usuario";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpFamilia.ResumeLayout(false);
            this.grpFamilia.PerformLayout();
            this.grpPatentes.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuarioInfo;
        private System.Windows.Forms.GroupBox grpFamilia;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.ComboBox cmbFamilia;
        private System.Windows.Forms.Label lblFamiliaDesc;
        private System.Windows.Forms.GroupBox grpPatentes;
        private System.Windows.Forms.Label lblPatentesDesc;
        private System.Windows.Forms.CheckedListBox clbPatentes;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnOmitir;
        private System.Windows.Forms.Button btnGuardar;
    }
}
