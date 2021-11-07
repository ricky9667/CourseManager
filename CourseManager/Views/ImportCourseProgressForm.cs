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
            SetUpProgressBar();
        }

        // init progress bar
        private void SetUpProgressBar()
        {
            _importCourseProgressBar.Maximum = 100;
            _importCourseProgressBar.Value = 0;
        }

        // progress form load
        private void ImportCourseProgressFormLoad(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i += 1)
            {
                _importCourseProgressBar.Increment(1);
                _importCourseProgressLabel.Text = "正在匯入課程... " + i + "%";
            }
        }
    }
}
