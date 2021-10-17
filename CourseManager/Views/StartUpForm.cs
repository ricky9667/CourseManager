using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class StartUpForm : Form
    {
        Model _model;
        public StartUpForm()
        {
            _model = new Model();
            InitializeComponent();
        }

        // set button enabled property
        private void SetEnabled(bool enabled)
        {
            _courseSelectingSystemButton.Enabled = enabled;
            _courseManagementSystemButton.Enabled = enabled;
            _exitButton.Enabled = enabled;
        }

        // show course selecting system
        private void CourseSelectingSystemButtonClick(object sender, EventArgs e)
        {
            SetEnabled(false);
            CourseSelectingFormViewModel courseSelectingFormViewModel = new CourseSelectingFormViewModel(_model);
            Form form = new CourseSelectingForm(courseSelectingFormViewModel);
            form.ShowDialog();
            SetEnabled(true);
        }

        // show course management system
        private void CourseManagementSystemButtonClick(object sender, EventArgs e)
        {
            SetEnabled(false);
            Form form = new CourseManagementForm();
            form.ShowDialog();
            SetEnabled(true);
        }

        // exit application
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
