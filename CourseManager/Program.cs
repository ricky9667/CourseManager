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
            CourseModel courseModel = new CourseModel();
            Form form = new SelectCourseForm(courseModel);
            Application.Run(form);
        }
    }
}
