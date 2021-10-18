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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();
            StartUpFormViewModel startUpFormViewModel = new StartUpFormViewModel(model);
            Form startUpForm = new StartUpForm(startUpFormViewModel);
            Application.Run(startUpForm);
        }
    }
}
