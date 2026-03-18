using System;
using System.Drawing;
using System.Windows.Forms;
using SERVICES.Facade.Extentions;

namespace RedAceite_ING_SOFTWARE.Controls
{
    public class UserMenuControl : UserControl
    {
        private readonly FlowLayoutPanel _layout;
        private readonly Button _btnIdioma;

        public event EventHandler IdiomaClick;

        public UserMenuControl()
        {
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Padding = new Padding(6);

            _layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            _btnIdioma = CreateMenuButton("Idioma");
            _btnIdioma.Click += (s, e) => IdiomaClick?.Invoke(this, EventArgs.Empty);

            _layout.Controls.Add(_btnIdioma);

            Controls.Add(_layout);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new Size(160, 0);

            ApplyTranslationsUserMenu();
        }

        public void ApplyTranslationsUserMenu()
        {
            if (_btnIdioma != null)
                _btnIdioma.Text = "menu_Idioma".Translate();
        }

        private static Button CreateMenuButton(string text)
        {
            return new Button
            {
                Text = text,
                AutoSize = false,
                Width = 200,
                Height = 32,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 10, 0),
                Margin = new Padding(0),
                TabStop = false
            };
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (_btnIdioma != null)
                _btnIdioma.FlatAppearance.BorderSize = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
                ApplyTranslationsUserMenu();
        }
    }
}
