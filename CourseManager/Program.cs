using System;
using System.Windows.Forms;

namespace CourseManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDpiAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();
            StartUpFormViewModel startUpFormViewModel = new StartUpFormViewModel(model);
            Form startUpForm = new StartUpForm(startUpFormViewModel);
            Application.Run(startUpForm);
        }

        // DPI Display Fix
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDpiAware();
    }
}
