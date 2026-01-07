using SERVICES.Dominio;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public partial class FrmCrearRol : Form
    {
        public FrmCrearRol()
        {
            InitializeComponent();
        }

        private void CrearRol_Click(object sender, EventArgs e)
        {
            try
            {

                var nombreFamilia = txtNombreFamilia.Text.Trim();
                if (string.IsNullOrEmpty(nombreFamilia))
                {
                    MessageBox.Show("El nombre de la familia no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var patentesSeleccionadas = new List<Patente>();
                foreach (var item in cbPatentes.CheckedItems)
                {
                    var patente = (Patente)item;
                    patentesSeleccionadas.Add(patente);
                }

                if (patentesSeleccionadas.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos una patente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar a la fachada para crear la familia con las patentes seleccionadas
                FamiliaService.CrearFamiliaConPatentes(nombreFamilia, patentesSeleccionadas);

                MessageBox.Show("Familia creada con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear la familia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
