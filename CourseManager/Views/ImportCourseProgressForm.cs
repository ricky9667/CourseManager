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
    public partial class ImportCourseProgressForm : Form
    {
        ImportCourseProgressFormViewModel _viewModel;
        public ImportCourseProgressForm(ImportCourseProgressFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            _importCourseProgressBar.DataBindings.Add(nameof(_importCourseProgressBar.Text), _viewModel, nameof(_viewModel.ImportCourseProgressBarText));
        }

        // progress form load
        private void ImportCourseProgressFormLoad(object sender, EventArgs e)
        {
            int count = _viewModel.ComputerScienceCourseTabPageInfos.Count;
            
            _importCourseProgressBar.Maximum = count;
            _importCourseProgressBar.Value = 0;

            for (int i = 0; i < count; i++)
            {
                _viewModel.LoadTabPageCourses(i); // need to make function async
                _importCourseProgressBar.Increment(1);
                _importCourseProgressLabel.Text = GenerateProgressLabelText(Convert.ToDouble((i + 1) * 100 / count));
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
