using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        List<CourseTabPageInfo> _courseTabPageInfos;
        List<int> _currentShowingIndexes;
        CourseSelectingFormViewModel _viewModel;

        public CourseSelectingForm(CourseSelectingFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _courseTabPageInfos = _viewModel.GetCourseTabPageInfos();
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectingFormLoad(object sender, EventArgs e)
        {
            int tabCount = _courseTabPageInfos.Count;
            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = _courseTabPageInfos[index];
                _courseTabControl.Controls[index].Name = tabPageInfo.TabName;
                _courseTabControl.Controls[index].Text = tabPageInfo.TabText;
            }

            LoadCourseDataGridView(0);
        }

        // setup datagridview
        private void LoadCourseDataGridView(int tabIndex)
        {
            _courseDataGridView.Rows.Clear();
            List<CourseInfo> courseInfos = _viewModel.GetCourseInfos(tabIndex);
            _currentShowingIndexes = _viewModel.GetShowingIndexes(tabIndex);

            foreach (int index in _currentShowingIndexes)
            {
                _courseDataGridView.Rows.Add(CreateSelectingCourseRow(courseInfos[index]));
            }

            _courseDataGridView.Refresh();
        }

        // create data grid view row
        private DataGridViewRow CreateSelectingCourseRow(CourseInfo courseInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (string cellValue in courseInfo.GetCourseInfoStrings())
            {
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = cellValue
                });
            }
            row.Cells.Insert(0, new DataGridViewCheckBoxCell());
            return row;
        }

        // triggers when checkboxes in datagridview has value change 
        private void CourseDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCourses = 0;

            foreach (DataGridViewRow row in _courseDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    selectedCourses++;
                }
            }

            _submitButton.Enabled = selectedCourses > 0;
        }

        // make datagridview data readonly
        private void CourseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (rowIndex >= 0 && columnIndex == 0)
            {
                if (Convert.ToBoolean(_courseDataGridView.Rows[rowIndex].Cells[0].Value))
                {
                    _courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
                else
                {
                    _courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = true;
                }
            }
        }

        // handle dirty state change
        void CourseDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_courseDataGridView.IsCurrentCellDirty)
            {
                _courseDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // add datagridview to selected tab index
        void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabIndex = _courseTabControl.SelectedIndex;
            LoadCourseDataGridView(tabIndex);
            _courseTabControl.Controls[tabIndex].Controls.Add(_courseDataGridView);
        }

        // show course result form
        private void CourseSelectionResultButtonClick(object sender, EventArgs e)
        {
            _submitButton.Enabled = false;
            _courseSelectionResultButton.Enabled = false;
            CourseSelectionResultFormViewModel courseSelectingResultFormViewModel = new CourseSelectionResultFormViewModel(_viewModel.GetModel());
            Form form = new CourseSelectionResultForm(courseSelectingResultFormViewModel);
            form.ShowDialog();
            LoadCourseDataGridView(_courseTabControl.SelectedIndex);
            _courseSelectionResultButton.Enabled = true;
        }

        // submit courses
        private void SubmitButtonClick(object sender, EventArgs e)
        {
            int tabIndex = _courseTabControl.SelectedIndex;
            int count = _courseDataGridView.Rows.Count;
            List<int> selectedIndexes = new List<int>();

            for (int index = 0; index < count; index++)
            {
                if (Convert.ToBoolean(_courseDataGridView.Rows[index].Cells[0].Value))
                {
                    selectedIndexes.Add(_currentShowingIndexes[index]);
                }
            }

            string selectCourseMessage = _viewModel.SelectCoursesAndGetMessage(tabIndex, selectedIndexes);
            MessageBox.Show(selectCourseMessage);
            LoadCourseDataGridView(tabIndex);
            _submitButton.Enabled = false;
        }
    }
}
