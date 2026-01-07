static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    
    // Crear y mostrar formulario de login
    using (var frmLogin = new FrmLogin())
    {
        if (frmLogin.ShowDialog() == DialogResult.OK)
        {
            // Usuario autenticado correctamente
            Application.Run(new FrmPrincipal());
        }
        // Si no se autentica, la aplicación termina
    }
}