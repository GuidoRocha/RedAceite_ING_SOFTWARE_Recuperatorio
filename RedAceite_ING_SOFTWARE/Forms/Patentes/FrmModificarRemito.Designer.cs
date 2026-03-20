namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmModificarRemito
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
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblNombreGenerador = new System.Windows.Forms.Label();
            this.lblTipoResiduo = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblEstadoFisico = new System.Windows.Forms.Label();
            this.lblDomicilioPlanta = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblNombreFantasia = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtFechaCreacion = new System.Windows.Forms.TextBox();
            this.txtNombreGenerador = new System.Windows.Forms.TextBox();
            this.txtTipoResiduo = new System.Windows.Forms.TextBox();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cmbEstadoFisico = new System.Windows.Forms.ComboBox();
            this.txtDomicilioPlanta = new System.Windows.Forms.TextBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtNombreFantasia = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNoModificable = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(191, 22);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Modificar Remito";
            //
            // lblFechaCreacion
            //
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFechaCreacion.Location = new System.Drawing.Point(15, 55);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(44, 15);
            this.lblFechaCreacion.TabIndex = 1;
            this.lblFechaCreacion.Text = "Fecha:";
            //
            // lblNombreGenerador
            //
            this.lblNombreGenerador.AutoSize = true;
            this.lblNombreGenerador.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNombreGenerador.Location = new System.Drawing.Point(15, 90);
            this.lblNombreGenerador.Name = "lblNombreGenerador";
            this.lblNombreGenerador.Size = new System.Drawing.Size(72, 15);
            this.lblNombreGenerador.TabIndex = 2;
            this.lblNombreGenerador.Text = "Generador:";
            //
            // lblTipoResiduo
            //
            this.lblTipoResiduo.AutoSize = true;
            this.lblTipoResiduo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTipoResiduo.Location = new System.Drawing.Point(15, 125);
            this.lblTipoResiduo.Name = "lblTipoResiduo";
            this.lblTipoResiduo.Size = new System.Drawing.Size(85, 15);
            this.lblTipoResiduo.TabIndex = 3;
            this.lblTipoResiduo.Text = "Tipo Residuo:";
            //
            // lblTransportista
            //
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTransportista.Location = new System.Drawing.Point(15, 160);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(80, 15);
            this.lblTransportista.TabIndex = 4;
            this.lblTransportista.Text = "Transportista:";
            //
            // lblSeparador
            //
            this.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparador.Location = new System.Drawing.Point(15, 195);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(490, 2);
            this.lblSeparador.TabIndex = 24;
            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCantidad.Location = new System.Drawing.Point(15, 210);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(66, 15);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "*Cantidad:";
            //
            // lblEstadoFisico
            //
            this.lblEstadoFisico.AutoSize = true;
            this.lblEstadoFisico.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEstadoFisico.Location = new System.Drawing.Point(15, 245);
            this.lblEstadoFisico.Name = "lblEstadoFisico";
            this.lblEstadoFisico.Size = new System.Drawing.Size(87, 15);
            this.lblEstadoFisico.TabIndex = 6;
            this.lblEstadoFisico.Text = "*Estado Fisico:";
            //
            // lblDomicilioPlanta
            //
            this.lblDomicilioPlanta.AutoSize = true;
            this.lblDomicilioPlanta.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDomicilioPlanta.Location = new System.Drawing.Point(15, 280);
            this.lblDomicilioPlanta.Name = "lblDomicilioPlanta";
            this.lblDomicilioPlanta.Size = new System.Drawing.Size(101, 15);
            this.lblDomicilioPlanta.TabIndex = 7;
            this.lblDomicilioPlanta.Text = "*Dom. Planta:";
            //
            // lblCUIT
            //
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCUIT.Location = new System.Drawing.Point(15, 315);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(37, 15);
            this.lblCUIT.TabIndex = 8;
            this.lblCUIT.Text = "CUIT:";
            //
            // lblNombreFantasia
            //
            this.lblNombreFantasia.AutoSize = true;
            this.lblNombreFantasia.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNombreFantasia.Location = new System.Drawing.Point(15, 350);
            this.lblNombreFantasia.Name = "lblNombreFantasia";
            this.lblNombreFantasia.Size = new System.Drawing.Size(105, 15);
            this.lblNombreFantasia.TabIndex = 9;
            this.lblNombreFantasia.Text = "Nombre Fantasia:";
            //
            // lblDireccion
            //
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDireccion.Location = new System.Drawing.Point(15, 385);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(62, 15);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Direccion:";
            //
            // txtFechaCreacion
            //
            this.txtFechaCreacion.BackColor = System.Drawing.Color.LightGray;
            this.txtFechaCreacion.Enabled = false;
            this.txtFechaCreacion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtFechaCreacion.Location = new System.Drawing.Point(140, 52);
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(365, 21);
            this.txtFechaCreacion.TabIndex = 11;
            //
            // txtNombreGenerador
            //
            this.txtNombreGenerador.BackColor = System.Drawing.Color.LightGray;
            this.txtNombreGenerador.Enabled = false;
            this.txtNombreGenerador.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombreGenerador.Location = new System.Drawing.Point(140, 87);
            this.txtNombreGenerador.Name = "txtNombreGenerador";
            this.txtNombreGenerador.ReadOnly = true;
            this.txtNombreGenerador.Size = new System.Drawing.Size(365, 21);
            this.txtNombreGenerador.TabIndex = 12;
            //
            // txtTipoResiduo
            //
            this.txtTipoResiduo.BackColor = System.Drawing.Color.LightGray;
            this.txtTipoResiduo.Enabled = false;
            this.txtTipoResiduo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTipoResiduo.Location = new System.Drawing.Point(140, 122);
            this.txtTipoResiduo.Name = "txtTipoResiduo";
            this.txtTipoResiduo.ReadOnly = true;
            this.txtTipoResiduo.Size = new System.Drawing.Size(200, 21);
            this.txtTipoResiduo.TabIndex = 13;
            //
            // txtTransportista
            //
            this.txtTransportista.BackColor = System.Drawing.Color.LightGray;
            this.txtTransportista.Enabled = false;
            this.txtTransportista.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTransportista.Location = new System.Drawing.Point(140, 157);
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.ReadOnly = true;
            this.txtTransportista.Size = new System.Drawing.Size(365, 21);
            this.txtTransportista.TabIndex = 14;
            //
            // txtCantidad
            //
            this.txtCantidad.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCantidad.Location = new System.Drawing.Point(140, 207);
            this.txtCantidad.MaxLength = 15;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(150, 21);
            this.txtCantidad.TabIndex = 15;
            //
            // cmbEstadoFisico
            //
            this.cmbEstadoFisico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFisico.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbEstadoFisico.FormattingEnabled = true;
            this.cmbEstadoFisico.Items.AddRange(new object[] {
            "L\u00edquido",
            "S\u00f3lido"});
            this.cmbEstadoFisico.Location = new System.Drawing.Point(140, 242);
            this.cmbEstadoFisico.Name = "cmbEstadoFisico";
            this.cmbEstadoFisico.Size = new System.Drawing.Size(200, 23);
            this.cmbEstadoFisico.TabIndex = 16;
            //
            // txtDomicilioPlanta
            //
            this.txtDomicilioPlanta.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDomicilioPlanta.Location = new System.Drawing.Point(140, 277);
            this.txtDomicilioPlanta.MaxLength = 200;
            this.txtDomicilioPlanta.Name = "txtDomicilioPlanta";
            this.txtDomicilioPlanta.Size = new System.Drawing.Size(365, 21);
            this.txtDomicilioPlanta.TabIndex = 17;
            //
            // txtCUIT
            //
            this.txtCUIT.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCUIT.Location = new System.Drawing.Point(140, 312);
            this.txtCUIT.MaxLength = 13;
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(200, 21);
            this.txtCUIT.TabIndex = 18;
            //
            // txtNombreFantasia
            //
            this.txtNombreFantasia.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombreFantasia.Location = new System.Drawing.Point(140, 347);
            this.txtNombreFantasia.MaxLength = 150;
            this.txtNombreFantasia.Name = "txtNombreFantasia";
            this.txtNombreFantasia.Size = new System.Drawing.Size(365, 21);
            this.txtNombreFantasia.TabIndex = 19;
            //
            // txtDireccion
            //
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(140, 382);
            this.txtDireccion.MaxLength = 200;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(365, 21);
            this.txtDireccion.TabIndex = 20;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(275, 430);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 35);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(395, 430);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // lblNoModificable
            //
            this.lblNoModificable.AutoSize = true;
            this.lblNoModificable.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblNoModificable.ForeColor = System.Drawing.Color.Gray;
            this.lblNoModificable.Location = new System.Drawing.Point(15, 445);
            this.lblNoModificable.Name = "lblNoModificable";
            this.lblNoModificable.Size = new System.Drawing.Size(250, 14);
            this.lblNoModificable.TabIndex = 23;
            this.lblNoModificable.Text = "Los campos en gris no pueden modificarse.";
            //
            // FrmModificarRemito
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(520, 480);
            this.Controls.Add(this.lblSeparador);
            this.Controls.Add(this.lblNoModificable);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombreFantasia);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtDomicilioPlanta);
            this.Controls.Add(this.cmbEstadoFisico);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtTransportista);
            this.Controls.Add(this.txtTipoResiduo);
            this.Controls.Add(this.txtNombreGenerador);
            this.Controls.Add(this.txtFechaCreacion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNombreFantasia);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblDomicilioPlanta);
            this.Controls.Add(this.lblEstadoFisico);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblTransportista);
            this.Controls.Add(this.lblTipoResiduo);
            this.Controls.Add(this.lblNombreGenerador);
            this.Controls.Add(this.lblFechaCreacion);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarRemito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Remito - RedAceite";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblNombreGenerador;
        private System.Windows.Forms.Label lblTipoResiduo;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblEstadoFisico;
        private System.Windows.Forms.Label lblDomicilioPlanta;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblNombreFantasia;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtFechaCreacion;
        private System.Windows.Forms.TextBox txtNombreGenerador;
        private System.Windows.Forms.TextBox txtTipoResiduo;
        private System.Windows.Forms.TextBox txtTransportista;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cmbEstadoFisico;
        private System.Windows.Forms.TextBox txtDomicilioPlanta;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtNombreFantasia;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNoModificable;
        private System.Windows.Forms.Label lblSeparador;
    }
}
