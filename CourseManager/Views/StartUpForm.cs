using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class StartUpForm : Form
    {
        private readonly StartUpFormViewModel _viewModel;
        Form _courseSelectingForm;
        Form _courseManagementForm;
        public StartUpForm(StartUpFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _courseSelectingForm = new CourseSelectingForm(new CourseSelectingFormViewModel(_viewModel.Model));
            _courseSelectingForm.FormClosing += new FormClosingEventHandler(CourseSelectingFormClosing);
            _courseManagementForm = new CourseManagementForm(new CourseManagementFormViewModel(_viewModel.Model));
            _courseManagementForm.FormClosing += new FormClosingEventHandler(CourseManagementFormClosing);

            InitializeComponent();
            SetBindingProperties();
        }

        // add data binding properties
        private void SetBindingProperties()
        {
            _courseSelectingSystemButton.DataBindings.Add(nameof(_courseSelectingSystemButton.Enabled), _viewModel, nameof(_viewModel.CourseSelectingSystemButtonEnabled));
            _courseManagementSystemButton.DataBindings.Add(nameof(_courseManagementSystemButton.Enabled), _viewModel, nameof(_viewModel.CourseManagementSystemButtonEnabled));
        }

        // show course selecting system
        private void CourseSelectingSystemButtonClick(object sender, EventArgs e)
        {
            _courseSelectingForm.Show();
            _viewModel.CourseSelectingSystemButtonEnabled = false;
        }

        // handle course selecting form closing event
        private void CourseSelectingFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _courseSelectingForm.Hide();
                _viewModel.CourseSelectingSystemButtonEnabled = true;
            }
        }

        // show course management system
        private void CourseManagementSystemButtonClick(object sender, EventArgs e)
        {
            _courseManagementForm.Show();
            _viewModel.CourseManagementSystemButtonEnabled = false;
        }

        // handle course management form closing event
        private void CourseManagementFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _courseManagementForm.Hide();
                _viewModel.CourseManagementSystemButtonEnabled = true;
            }
        }

        // exit application
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
