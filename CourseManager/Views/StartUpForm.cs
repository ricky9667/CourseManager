using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class StartUpForm : Form
    {
        StartUpFormViewModel _viewModel;
        Form _courseSelectingForm;
        public StartUpForm(StartUpFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        // set button enabled property
        private void SetControlsStatus(bool enabled)
        {
            _viewModel.CourseSelectingSystemButtonEnabled = enabled;
            _viewModel.CourseManagementSystemButtonEnabled = enabled;
            _viewModel.ExitButtonEnabled = enabled;
            RefreshWindowStatus();
        }

        // refresh component enabled
        private void RefreshWindowStatus()
        {
            _courseSelectingSystemButton.Enabled = _viewModel.CourseSelectingSystemButtonEnabled;
            _courseManagementSystemButton.Enabled = _viewModel.CourseManagementSystemButtonEnabled;
            _exitButton.Enabled = _viewModel.ExitButtonEnabled;
        }

        // show course selecting system
        private void CourseSelectingSystemButtonClick(object sender, EventArgs e)
        {
            CourseSelectingFormViewModel courseSelectingFormViewModel = new CourseSelectingFormViewModel(_viewModel.Model);
            _courseSelectingForm = new CourseSelectingForm(courseSelectingFormViewModel);
            _courseSelectingForm.FormClosed += new FormClosedEventHandler(FormClosed);
            _courseSelectingForm.Show();
            SetControlsStatus(false);
        }

        // show course management system
        private void CourseManagementSystemButtonClick(object sender, EventArgs e)
        {
            CourseManagementFormViewModel courseManagementFormViewModel = new CourseManagementFormViewModel(_viewModel.Model);
            Form form = new CourseManagementForm(courseManagementFormViewModel);
            form.FormClosed += new FormClosedEventHandler(FormClosed);
            form.Show();
            SetControlsStatus(false);
        }

        // handle form close event
        private new void FormClosed(object sender, FormClosedEventArgs e)
        {
            SetControlsStatus(true);
        }

        // exit application
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
