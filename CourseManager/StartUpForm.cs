using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        // show course selecting system
        private void courseSelectingSystemButtonClick(object sender, EventArgs e)
        {
            CourseModel courseModel = new CourseModel();
            Form form = new CourseSelectingForm(courseModel);
            form.Show();
        }

        // show course management system
        private void courseManagementSystemButtonClick(object sender, EventArgs e)
        {
            Form form = new CourseManagementForm();
            form.Show();
        }

        // exit application
        private void exitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
