namespace HomeBankingDV
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DATOS DE PRUEBA

            //bool u1 = AltaUsuario(95939524, "pepito", "gomez", "as@a", "123");

            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Contenedor());
        }
    }
}