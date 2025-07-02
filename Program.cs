using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Configuración para alta resolución
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                MostrarErrorYTerminar(ex);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MostrarErrorYTerminar(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MostrarErrorYTerminar(ex);
        }

        private static void MostrarErrorYTerminar(Exception ex)
        {
            string mensaje = "Ha ocurrido un error inesperado. La aplicación se cerrará.\n\n¿Deseas ver más detalles?";

            DialogResult result = MessageBox.Show(mensaje, "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GuardarErrorEnLog(ex);

            Application.Exit();
            Environment.Exit(1);
        }

        private static void GuardarErrorEnLog(Exception ex)
        {
            try
            {
                string rutaLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
                string contenido = $"[{DateTime.Now}] {ex.ToString()}\n";
                File.AppendAllText(rutaLog, contenido);
            }
            catch
            {
                // En caso de fallo al escribir el log, no hacer nada para evitar excepciones encadenadas
            }
        }
    }
}
