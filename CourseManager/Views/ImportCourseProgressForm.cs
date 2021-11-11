using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CourseManager
{
    public partial class ImportCourseProgressForm : Form
    {
        ImportCourseProgressFormViewModel _viewModel;
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
            _importCourseProgressBar.Maximum = 100;
            _importCourseProgressBar.Value = 0;

            int count = 1;
            foreach (int index in _viewModel.ComputerScienceTabIndexes)
            {
                _viewModel.LoadTabPageCourses(index);
                await Delay();

                double percentage = Convert.ToDouble(count++ * 100 / _viewModel.ComputerScienceTabIndexes.Count);
                _importCourseProgressBar.Value = (int)Math.Round(percentage);
                _importCourseProgressLabel.Text = _viewModel.GenerateProgressLabelText(percentage);
            }
        }

        // delay for ui to refresh
        private async Task Delay()
        {
            await Task.Delay(1000);
        }
    }
}
