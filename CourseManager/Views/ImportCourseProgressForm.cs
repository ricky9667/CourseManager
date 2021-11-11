using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CourseManager
{
    public partial class ImportCourseProgressForm : Form
    {
        ImportCourseProgressFormViewModel _viewModel;
        private readonly int _computerScienceTabCount = 3;
        public ImportCourseProgressForm(ImportCourseProgressFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            _importCourseProgressBar.DataBindings.Add(nameof(_importCourseProgressBar.Text), _viewModel, nameof(_viewModel.ImportCourseProgressBarText));
        }

        // progress form load
        private void ImportCourseProgressFormLoad(object sender, EventArgs e)
        {
            _importCourseProgressLabel.Text = _viewModel.GenerateProgressLabelText(0);
        }
        
        // load and run progress bar
        async private void ImportCourseProgressFormShown(object sender, EventArgs e)
        {
            const int INDEX_OFFSET = 2;
            _importCourseProgressBar.Maximum = 100;
            _importCourseProgressBar.Value = 0;

            for (int index = 0; index < _computerScienceTabCount; index++)
            {
                _viewModel.LoadTabPageCourses(index + INDEX_OFFSET);
                await Delay();

                double percentage = Convert.ToDouble((index + 1) * 100 / _computerScienceTabCount);
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
