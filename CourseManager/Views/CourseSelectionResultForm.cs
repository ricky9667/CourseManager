using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectionResultForm : Form
    {
        private readonly CourseSelectionResultFormViewModel _viewModel;
        public CourseSelectionResultForm(CourseSelectionResultFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.ViewModelChanged += LoadSelectedCourseDataGridView;
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectionResultFormLoad(object sender, EventArgs e)
        {
            LoadSelectedCourseDataGridView();
        }

        // setup datagridview
        private void LoadSelectedCourseDataGridView()
        {
            _selectedCourseDataGridView.Rows.Clear();
            foreach (CourseInfo courseInfo in _viewModel.SelectedCourseInfos)
            {
                _selectedCourseDataGridView.Rows.Add(CreateSelectionResultCourseRow(courseInfo));
            }
            _selectedCourseDataGridView.Refresh();
        }

        // create data grid view row
        private DataGridViewRow CreateSelectionResultCourseRow(CourseInfo courseInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (string cellValue in courseInfo.GetCourseInfoStrings())
            {
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = cellValue
                });
            }
            row.Cells.Insert(0, new DataGridViewButtonCell
            {
                Value = "退選",
            });
            return row;
        }

        // handle drop out button
        private void SelectedCourseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                _viewModel.RemoveCourse(e.RowIndex);
            }

            LoadSelectedCourseDataGridView();
        }
    }
}
