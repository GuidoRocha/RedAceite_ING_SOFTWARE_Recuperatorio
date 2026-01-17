using BLL;
using DOMAIN;
using SERVICES.Facade;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Forms
{
    /// <summary>
    /// Formulario para dar de alta un nuevo proveedor en el sistema.
    /// </summary>
    public partial class FrmAltaProveedor : Form
    {
        private readonly ProveedorService _proveedorService;

        /// <summary>
        /// ID del proveedor creado. Se establece después de guardar exitosamente.
        /// </summary>
        public Guid IdProveedorCreado { get; private set; }

        public FrmAltaProveedor()
        {
            InitializeComponent();
            _proveedorService = new ProveedorService();
            IdProveedorCreado = Guid.Empty;
        }

        /// <summary>
        /// Maneja el evento de clic del botón Guardar.
        /// Valida y guarda el nuevo proveedor.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (!ValidarCampos())
                {
                    return;
                }

                // Limpiar el CUIT (quitar guiones y espacios) antes de guardarlo
                string cuitLimpio = txtCUIT.Text.Replace("-", "").Replace(" ", "");

                // Crear el proveedor
                var proveedor = new Proveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    CUIT = cuitLimpio,
                    DNI = txtDNI.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Region = cmbRegion.SelectedItem?.ToString() ?? ""
                };

                _proveedorService.CrearProveedor(proveedor);

                // Guardar el ID del proveedor creado para que pueda ser accedido desde el formulario padre
                IdProveedorCreado = proveedor.IdProveedor;

                // Registrar en el log
                LoggerService.WriteLog($"Proveedor creado: {txtNombre.Text} (CUIT: {cuitLimpio}) con ID: {IdProveedorCreado}",
                    System.Diagnostics.TraceLevel.Info);

                MessageBox.Show("Proveedor creado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el proveedor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        /// <summary>
        /// Valida los campos del formulario.
        /// </summary>
        /// <returns>True si todos los campos son válidos, false en caso contrario.</returns>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCUIT.Text))
            {
                MessageBox.Show("El CUIT del proveedor es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCUIT.Focus();
                return false;
            }

            // Validar formato de CUIT
            string cuitLimpio = txtCUIT.Text.Replace("-", "").Replace(" ", "");
            if (cuitLimpio.Length != 11 || !cuitLimpio.All(char.IsDigit))
            {
                MessageBox.Show("El CUIT debe tener 11 dígitos. Formato: XX-XXXXXXXX-X", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCUIT.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                    if (addr.Address != txtEmail.Text)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show("El formato del correo electrónico no es válido.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Maneja el evento de clic del botón Cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Formatea el CUIT mientras se escribe.
        /// Formato: XX-XXXXXXXX-X
        /// </summary>
        private void txtCUIT_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = txtCUIT.SelectionStart;
            string textBeforeChange = txtCUIT.Text;

            // Obtener solo los dígitos del texto actual
            string digitsOnly = new string(txtCUIT.Text.Where(char.IsDigit).ToArray());

            // Limitar a 11 dígitos
            if (digitsOnly.Length > 11)
            {
                digitsOnly = digitsOnly.Substring(0, 11);
            }

            // Construir el texto formateado
            string formattedText = "";

            if (digitsOnly.Length > 0)
            {
                // Primeros 2 dígitos
                formattedText = digitsOnly.Substring(0, Math.Min(2, digitsOnly.Length));

                if (digitsOnly.Length > 2)
                {
                    // Agregar primer guion y siguientes 8 dígitos
                    formattedText += "-" + digitsOnly.Substring(2, Math.Min(8, digitsOnly.Length - 2));

                    if (digitsOnly.Length > 10)
                    {
                        // Agregar segundo guion y último dígito
                        formattedText += "-" + digitsOnly.Substring(10, 1);
                    }
                }
            }

            // Solo actualizar si el texto cambió
            if (txtCUIT.Text != formattedText)
            {
                // Calcular nueva posición del cursor
                int newCursorPosition;

                // Contar cuántos dígitos hay en total
                int totalDigits = digitsOnly.Length;

                // Determinar la nueva posición basándonos en la cantidad de dígitos
                if (totalDigits <= 2)
                {
                    // Si tenemos 2 o menos dígitos, el cursor va al final
                    newCursorPosition = totalDigits;
                }
                else if (totalDigits <= 10)
                {
                    // Si tenemos entre 3 y 10 dígitos, agregamos 1 por el primer guion
                    newCursorPosition = totalDigits + 1;
                }
                else
                {
                    // Si tenemos 11 dígitos, agregamos 2 por ambos guiones
                    newCursorPosition = totalDigits + 2;
                }

                // Actualizar el texto
                txtCUIT.Text = formattedText;

                // Posicionar el cursor al final (después del último carácter ingresado)
                txtCUIT.SelectionStart = Math.Min(newCursorPosition, txtCUIT.Text.Length);
            }
        }
    }
}