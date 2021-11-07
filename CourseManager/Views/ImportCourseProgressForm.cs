using System;
using System.Windows.Forms;

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
            const int INDEX_OFFSET = 2;
            _importCourseProgressBar.Maximum = _computerScienceTabCount;
            _importCourseProgressBar.Value = 0;

            for (int index = 0; index < _computerScienceTabCount; index++)
            {
                _viewModel.LoadTabPageCourses(index + INDEX_OFFSET); // need to make function async
                _importCourseProgressBar.Increment(1);
                _importCourseProgressLabel.Text = GenerateProgressLabelText(Convert.ToDouble((index + 1) * 100 / _computerScienceTabCount));
            }
        }

        // generate progress label string
        private string GenerateProgressLabelText(double percentage)
        {
            const string LOADING_TEXT = "正在匯入課程... ";
            const string PERCENT = "%";
            return LOADING_TEXT + percentage + PERCENT;
        }
    }
}
