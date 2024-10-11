// Este archivo est� cubierto por los t�rminos de la licencia MIT.
// Consulta el archivo LICENSE en la ra�z del proyecto para m�s detalles.

using Pokedex_No_copyrigt.Vistas;

namespace Pokedex_No_copyrigt
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }
    }
}