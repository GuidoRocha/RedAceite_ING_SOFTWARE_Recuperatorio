namespace RedAceite_ING_SOFTWARE.Forms
{
    partial class FrmCrearRol
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
            this.lblTituloRol = new System.Windows.Forms.Label();
            this.lblAccesos = new System.Windows.Forms.Label();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.CrearRol = new System.Windows.Forms.Button();
            this.cbPatentes = new System.Windows.Forms.CheckedListBox();
            this.SeleccionarTodas = new System.Windows.Forms.Button();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTituloRol
            // 
            this.lblTituloRol.AutoSize = true;
            this.lblTituloRol.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRol.Location = new System.Drawing.Point(250, 52);
            this.lblTituloRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloRol.Name = "lblTituloRol";
            this.lblTituloRol.Size = new System.Drawing.Size(192, 26);
            this.lblTituloRol.TabIndex = 19;
            this.lblTituloRol.Tag = "CrearNuevoRol";
            this.lblTituloRol.Text = "Crear Nuevo Rol";
            // 
            // lblAccesos
            // 
            this.lblAccesos.AutoSize = true;
            this.lblAccesos.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccesos.Location = new System.Drawing.Point(229, 179);
            this.lblAccesos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccesos.Name = "lblAccesos";
            this.lblAccesos.Size = new System.Drawing.Size(192, 26);
            this.lblAccesos.TabIndex = 18;
            this.lblAccesos.Tag = "AsignarAcceso";
            this.lblAccesos.Text = "Asignar Accesos";
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRol.Location = new System.Drawing.Point(265, 103);
            this.lblNombreRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(132, 26);
            this.lblNombreRol.TabIndex = 17;
            this.lblNombreRol.Tag = "NombreRol";
            this.lblNombreRol.Text = "Nombre Rol";
            // 
            // CrearRol
            // 
            this.CrearRol.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearRol.Location = new System.Drawing.Point(255, 480);
            this.CrearRol.Margin = new System.Windows.Forms.Padding(4);
            this.CrearRol.Name = "CrearRol";
            this.CrearRol.Size = new System.Drawing.Size(141, 50);
            this.CrearRol.TabIndex = 16;
            this.CrearRol.Tag = "CrearRol";
            this.CrearRol.Text = "Crear Rol";
            this.CrearRol.UseVisualStyleBackColor = true;
            this.CrearRol.Click += new System.EventHandler(this.CrearRol_Click);
            // 
            // cbPatentes
            // 
            this.cbPatentes.FormattingEnabled = true;
            this.cbPatentes.Location = new System.Drawing.Point(199, 210);
            this.cbPatentes.Margin = new System.Windows.Forms.Padding(4);
            this.cbPatentes.Name = "cbPatentes";
            this.cbPatentes.Size = new System.Drawing.Size(257, 259);
            this.cbPatentes.TabIndex = 15;
            // 
            // SeleccionarTodas
            // 
            this.SeleccionarTodas.Font = new System.Drawing.Font("Consolas", 8.75F, System.Drawing.FontStyle.Bold);
            this.SeleccionarTodas.Location = new System.Drawing.Point(469, 210);
            this.SeleccionarTodas.Margin = new System.Windows.Forms.Padding(4);
            this.SeleccionarTodas.Name = "SeleccionarTodas";
            this.SeleccionarTodas.Size = new System.Drawing.Size(133, 46);
            this.SeleccionarTodas.TabIndex = 14;
            this.SeleccionarTodas.Tag = "SeleccionarTodas";
            this.SeleccionarTodas.Text = "Seleccionar todas";
            this.SeleccionarTodas.UseVisualStyleBackColor = true;
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(255, 133);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(171, 22);
            this.txtNombreFamilia.TabIndex = 13;
            // 
            // FrmCrearRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 549);
            this.Controls.Add(this.lblTituloRol);
            this.Controls.Add(this.lblAccesos);
            this.Controls.Add(this.lblNombreRol);
            this.Controls.Add(this.CrearRol);
            this.Controls.Add(this.cbPatentes);
            this.Controls.Add(this.SeleccionarTodas);
            this.Controls.Add(this.txtNombreFamilia);
            this.Name = "FrmCrearRol";
            this.Text = "FrmCrearRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloRol;
        private System.Windows.Forms.Label lblAccesos;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.Button CrearRol;
        private System.Windows.Forms.CheckedListBox cbPatentes;
        private System.Windows.Forms.Button SeleccionarTodas;
        private System.Windows.Forms.TextBox txtNombreFamilia;
    }
}