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
            CourseSelectingFormViewModel courseSelectingFormViewModel = new CourseSelectingFormViewModel(_viewModel.Model);
            _courseSelectingForm = new CourseSelectingForm(courseSelectingFormViewModel);
            _courseSelectingForm.FormClosed += new FormClosedEventHandler(FormClosed);
            _courseSelectingForm.Show();
            _viewModel.CourseSelectingSystemButtonEnabled = false;
        }

        // show course management system
        private void CourseManagementSystemButtonClick(object sender, EventArgs e)
        {
            CourseManagementFormViewModel courseManagementFormViewModel = new CourseManagementFormViewModel(_viewModel.Model);
            Form form = new CourseManagementForm(courseManagementFormViewModel);
            form.FormClosed += new FormClosedEventHandler(FormClosed);
            form.Show();
            _viewModel.CourseManagementSystemButtonEnabled = false;
        }

        // handle form close event
        private new void FormClosed(object sender, FormClosedEventArgs e)
        {
            _viewModel.CourseSelectingSystemButtonEnabled = true;
            _viewModel.CourseManagementSystemButtonEnabled = true;
        }

        // exit application
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
