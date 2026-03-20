namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmConfigurarPrecios
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

        #region Codigo generado por el Disenador de Windows Forms

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpAceite = new System.Windows.Forms.GroupBox();
            this.lblVigenciaAceite = new System.Windows.Forms.Label();
            this.btnGuardarAceite = new System.Windows.Forms.Button();
            this.txtPrecioAceite = new System.Windows.Forms.TextBox();
            this.lblPrecioAceite = new System.Windows.Forms.Label();
            this.grpGrasa = new System.Windows.Forms.GroupBox();
            this.lblVigenciaGrasa = new System.Windows.Forms.Label();
            this.btnGuardarGrasa = new System.Windows.Forms.Button();
            this.txtPrecioGrasa = new System.Windows.Forms.TextBox();
            this.lblPrecioGrasa = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.dgvHistorialPrecios = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpAceite.SuspendLayout();
            this.grpGrasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPrecios)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(280, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configurar Precios por Residuo";
            //
            // grpAceite
            //
            this.grpAceite.Controls.Add(this.lblVigenciaAceite);
            this.grpAceite.Controls.Add(this.btnGuardarAceite);
            this.grpAceite.Controls.Add(this.txtPrecioAceite);
            this.grpAceite.Controls.Add(this.lblPrecioAceite);
            this.grpAceite.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpAceite.Location = new System.Drawing.Point(15, 50);
            this.grpAceite.Name = "grpAceite";
            this.grpAceite.Size = new System.Drawing.Size(270, 110);
            this.grpAceite.TabIndex = 1;
            this.grpAceite.TabStop = false;
            this.grpAceite.Text = "Aceite (por litro)";
            //
            // lblVigenciaAceite
            //
            this.lblVigenciaAceite.AutoSize = true;
            this.lblVigenciaAceite.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblVigenciaAceite.ForeColor = System.Drawing.Color.Gray;
            this.lblVigenciaAceite.Location = new System.Drawing.Point(10, 85);
            this.lblVigenciaAceite.Name = "lblVigenciaAceite";
            this.lblVigenciaAceite.Size = new System.Drawing.Size(120, 14);
            this.lblVigenciaAceite.TabIndex = 3;
            this.lblVigenciaAceite.Text = "Sin precio configurado";
            //
            // btnGuardarAceite
            //
            this.btnGuardarAceite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardarAceite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAceite.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarAceite.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAceite.Location = new System.Drawing.Point(175, 48);
            this.btnGuardarAceite.Name = "btnGuardarAceite";
            this.btnGuardarAceite.Size = new System.Drawing.Size(80, 30);
            this.btnGuardarAceite.TabIndex = 2;
            this.btnGuardarAceite.Text = "Guardar";
            this.btnGuardarAceite.UseVisualStyleBackColor = false;
            this.btnGuardarAceite.Click += new System.EventHandler(this.btnGuardarAceite_Click);
            //
            // txtPrecioAceite
            //
            this.txtPrecioAceite.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPrecioAceite.Location = new System.Drawing.Point(70, 50);
            this.txtPrecioAceite.MaxLength = 15;
            this.txtPrecioAceite.Name = "txtPrecioAceite";
            this.txtPrecioAceite.Size = new System.Drawing.Size(95, 24);
            this.txtPrecioAceite.TabIndex = 1;
            this.txtPrecioAceite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblPrecioAceite
            //
            this.lblPrecioAceite.AutoSize = true;
            this.lblPrecioAceite.Font = new System.Drawing.Font("Arial", 11F);
            this.lblPrecioAceite.Location = new System.Drawing.Point(10, 53);
            this.lblPrecioAceite.Name = "lblPrecioAceite";
            this.lblPrecioAceite.Size = new System.Drawing.Size(56, 17);
            this.lblPrecioAceite.TabIndex = 0;
            this.lblPrecioAceite.Text = "Precio:";
            //
            // grpGrasa
            //
            this.grpGrasa.Controls.Add(this.lblVigenciaGrasa);
            this.grpGrasa.Controls.Add(this.btnGuardarGrasa);
            this.grpGrasa.Controls.Add(this.txtPrecioGrasa);
            this.grpGrasa.Controls.Add(this.lblPrecioGrasa);
            this.grpGrasa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpGrasa.Location = new System.Drawing.Point(295, 50);
            this.grpGrasa.Name = "grpGrasa";
            this.grpGrasa.Size = new System.Drawing.Size(270, 110);
            this.grpGrasa.TabIndex = 2;
            this.grpGrasa.TabStop = false;
            this.grpGrasa.Text = "Grasa (por kilogramo)";
            //
            // lblVigenciaGrasa
            //
            this.lblVigenciaGrasa.AutoSize = true;
            this.lblVigenciaGrasa.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblVigenciaGrasa.ForeColor = System.Drawing.Color.Gray;
            this.lblVigenciaGrasa.Location = new System.Drawing.Point(10, 85);
            this.lblVigenciaGrasa.Name = "lblVigenciaGrasa";
            this.lblVigenciaGrasa.Size = new System.Drawing.Size(120, 14);
            this.lblVigenciaGrasa.TabIndex = 3;
            this.lblVigenciaGrasa.Text = "Sin precio configurado";
            //
            // btnGuardarGrasa
            //
            this.btnGuardarGrasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardarGrasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarGrasa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarGrasa.ForeColor = System.Drawing.Color.White;
            this.btnGuardarGrasa.Location = new System.Drawing.Point(175, 48);
            this.btnGuardarGrasa.Name = "btnGuardarGrasa";
            this.btnGuardarGrasa.Size = new System.Drawing.Size(80, 30);
            this.btnGuardarGrasa.TabIndex = 2;
            this.btnGuardarGrasa.Text = "Guardar";
            this.btnGuardarGrasa.UseVisualStyleBackColor = false;
            this.btnGuardarGrasa.Click += new System.EventHandler(this.btnGuardarGrasa_Click);
            //
            // txtPrecioGrasa
            //
            this.txtPrecioGrasa.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPrecioGrasa.Location = new System.Drawing.Point(70, 50);
            this.txtPrecioGrasa.MaxLength = 15;
            this.txtPrecioGrasa.Name = "txtPrecioGrasa";
            this.txtPrecioGrasa.Size = new System.Drawing.Size(95, 24);
            this.txtPrecioGrasa.TabIndex = 1;
            this.txtPrecioGrasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // lblPrecioGrasa
            //
            this.lblPrecioGrasa.AutoSize = true;
            this.lblPrecioGrasa.Font = new System.Drawing.Font("Arial", 11F);
            this.lblPrecioGrasa.Location = new System.Drawing.Point(10, 53);
            this.lblPrecioGrasa.Name = "lblPrecioGrasa";
            this.lblPrecioGrasa.Size = new System.Drawing.Size(56, 17);
            this.lblPrecioGrasa.TabIndex = 0;
            this.lblPrecioGrasa.Text = "Precio:";
            //
            // lblHistorial
            //
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(15, 175);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(142, 16);
            this.lblHistorial.TabIndex = 3;
            this.lblHistorial.Text = "Historial de Precios";
            //
            // dgvHistorialPrecios
            //
            this.dgvHistorialPrecios.AllowUserToAddRows = false;
            this.dgvHistorialPrecios.AllowUserToDeleteRows = false;
            this.dgvHistorialPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialPrecios.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialPrecios.Location = new System.Drawing.Point(15, 195);
            this.dgvHistorialPrecios.Name = "dgvHistorialPrecios";
            this.dgvHistorialPrecios.ReadOnly = true;
            this.dgvHistorialPrecios.RowHeadersVisible = false;
            this.dgvHistorialPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialPrecios.Size = new System.Drawing.Size(550, 200);
            this.dgvHistorialPrecios.TabIndex = 4;
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(455, 405);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 35);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FrmConfigurarPrecios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(580, 455);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvHistorialPrecios);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.grpGrasa);
            this.Controls.Add(this.grpAceite);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigurarPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar Precios - RedAceite";
            this.grpAceite.ResumeLayout(false);
            this.grpAceite.PerformLayout();
            this.grpGrasa.ResumeLayout(false);
            this.grpGrasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPrecios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpAceite;
        private System.Windows.Forms.Label lblVigenciaAceite;
        private System.Windows.Forms.Button btnGuardarAceite;
        private System.Windows.Forms.TextBox txtPrecioAceite;
        private System.Windows.Forms.Label lblPrecioAceite;
        private System.Windows.Forms.GroupBox grpGrasa;
        private System.Windows.Forms.Label lblVigenciaGrasa;
        private System.Windows.Forms.Button btnGuardarGrasa;
        private System.Windows.Forms.TextBox txtPrecioGrasa;
        private System.Windows.Forms.Label lblPrecioGrasa;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvHistorialPrecios;
        private System.Windows.Forms.Button btnCerrar;
    }
}
