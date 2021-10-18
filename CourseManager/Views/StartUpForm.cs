using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class StartUpForm : Form
    {
        Model _model;
        Form _courseSelectingForm;
        public StartUpForm()
        {
            _model = new Model();
            InitializeComponent();
        }

        // set button enabled property
        private void SetEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = enabled;
            }
        }

        // show course selecting system
        private void CourseSelectingSystemButtonClick(object sender, EventArgs e)
        {
            CourseSelectingFormViewModel courseSelectingFormViewModel = new CourseSelectingFormViewModel(_model);
            _courseSelectingForm = new CourseSelectingForm(courseSelectingFormViewModel);
            _courseSelectingForm.FormClosed += new FormClosedEventHandler(FormClosed);
            _courseSelectingForm.Show();
            SetEnabled(false);
        }

        // show course management system
        private void CourseManagementSystemButtonClick(object sender, EventArgs e)
        {
            Form form = new CourseManagementForm();
            form.FormClosed += new FormClosedEventHandler(FormClosed);
            form.Show();
            SetEnabled(false);
        }

        // handle form close event
        private new void FormClosed(object sender, FormClosedEventArgs e)
        {
            SetEnabled(true);
        }

        // exit application
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
