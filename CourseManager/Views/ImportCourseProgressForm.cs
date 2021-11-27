using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class ImportCourseProgressForm : Form
    {
        private ImportCourseProgressFormViewModel _viewModel;
        public ImportCourseProgressForm(ImportCourseProgressFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        // progress form load
        private void ImportCourseProgressFormLoad(object sender, EventArgs e)
        {
            _importCourseProgressLabel.Text = _viewModel.GenerateProgressLabelText(0);
        }
        
        // load and run progress bar
        async private void ImportCourseProgressFormShown(object sender, EventArgs e)
        {
            const int FULL_PERCENTAGE = 100;
            const int DELAY_TIME = 1000;
            _importCourseProgressBar.Maximum = FULL_PERCENTAGE;
            _importCourseProgressBar.Value = 0;

            int count = 1;
            foreach (int index in _viewModel.ComputerScienceTabIndexes)
            {
                _viewModel.LoadTabPageCourses(index);
                await Task.Delay(DELAY_TIME);

                double percentage = Convert.ToDouble(count++ * FULL_PERCENTAGE / _viewModel.ComputerScienceTabIndexes.Count);
                _importCourseProgressBar.Value = (int)Math.Round(percentage);
                _importCourseProgressLabel.Text = _viewModel.GenerateProgressLabelText(percentage);
            }
            await Task.Delay(DELAY_TIME);
            Close();
        }
    }
}
