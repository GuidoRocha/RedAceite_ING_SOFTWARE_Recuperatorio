using System;
using System.Drawing;
using System.Windows.Forms;
using SERVICES.Facade.Extentions;

namespace RedAceite_ING_SOFTWARE.Forms
{
    public class FrmConfiguracion : Form
    {
        private readonly Label _title;
        private readonly Panel _optionGestionRoles;
        private readonly Label _lblGestionRoles;
        private readonly Panel _optionConfigurarPrecios;
        private readonly Label _lblConfigurarPrecios;

        public event EventHandler GestionRolesSelected;
        public event EventHandler ConfigurarPreciosSelected;

        public FrmConfiguracion()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            BackColor = Color.White;
            Text = "Configuraci\u00f3n";
            Font = new Font("Segoe UI", 10F);

            _title = new Label
            {
                Text = "Configuraci\u00f3n",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 50,
                Padding = new Padding(16, 0, 0, 0),
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            var content = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16),
                BackColor = Color.White
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            _optionGestionRoles = CreateOptionRow("Gesti\u00f3n de Roles", out _lblGestionRoles);
            WireOptionClick(_optionGestionRoles, () =>
            {
                GestionRolesSelected?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
                Close();
            });

            _optionConfigurarPrecios = CreateOptionRow("Configurar Precios", out _lblConfigurarPrecios);
            WireOptionClick(_optionConfigurarPrecios, () =>
            {
                ConfigurarPreciosSelected?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
                Close();
            });

            layout.Controls.Add(_optionGestionRoles, 0, 0);
            layout.Controls.Add(_optionConfigurarPrecios, 0, 1);

            content.Controls.Add(layout);

            Controls.Add(content);
            Controls.Add(_title);

            ClientSize = new Size(320, 200);

            ApplyTranslations();
        }

        private void ApplyTranslations()
        {
            var titulo = "menu_Configuracion".Translate();
            Text = titulo;
            if (_title != null)
                _title.Text = titulo;
            if (_lblGestionRoles != null)
                _lblGestionRoles.Text = "menu_GestionRoles".Translate();
            if (_lblConfigurarPrecios != null)
                _lblConfigurarPrecios.Text = "menu_ConfigurarPrecios".Translate();
        }

        private static Panel CreateOptionRow(string text, out Label label)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.White,
                Height = 40,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Hand
            };

            label = new Label
            {
                Text = text,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 10, 0),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            var arrow = new Label
            {
                Text = ">",
                AutoSize = false,
                Width = 30,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(150, 150, 150),
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            panel.Controls.Add(label);
            panel.Controls.Add(arrow);

            panel.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1f))
                {
                    var r = panel.ClientRectangle;
                    r.Width -= 1;
                    r.Height -= 1;
                    e.Graphics.DrawRectangle(pen, r);
                }
            };

            return panel;
        }

        private static void WireOptionClick(Control root, Action onClick)
        {
            root.Click += (s, e) => onClick();
            foreach (Control c in root.Controls)
                c.Click += (s, e) => onClick();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ApplyTranslations();
        }
    }
}
