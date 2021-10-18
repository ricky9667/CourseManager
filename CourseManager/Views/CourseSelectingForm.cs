using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        Form _courseSelectionResultForm;
        List<CourseTabPageInfo> _courseTabPageInfos;
        List<int> _currentShowingIndexes;
        CourseSelectingFormViewModel _viewModel;

        public CourseSelectingForm(CourseSelectingFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _courseTabPageInfos = _viewModel.GetCourseTabPageInfos();
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(ThisFormClosed);
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

        // set components enabled property
        private void SetComponentsEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = enabled;
            }
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
            HandleSubmitButtonEnabled();
        }

        // change checkbox cell value when clicked
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
            HandleSubmitButtonEnabled();
        }

        // handle button state when event occurs
        private void HandleSubmitButtonEnabled()
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

        // handle dirty state change
        private void CourseDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_courseDataGridView.IsCurrentCellDirty)
            {
                _courseDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // add datagridview to selected tab index
        private void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabIndex = _courseTabControl.SelectedIndex;
            LoadCourseDataGridView(tabIndex);
            _courseTabControl.Controls[tabIndex].Controls.Add(_courseDataGridView);
        }

        // show course result form
        private void CourseSelectionResultButtonClick(object sender, EventArgs e)
        {
            _courseSelectionResultForm = new CourseSelectionResultForm(new CourseSelectionResultFormViewModel(_viewModel.GetModel()));
            _courseSelectionResultForm.FormClosed += new FormClosedEventHandler(CourseSelectionResultFormClosed);
            _courseSelectionResultForm.Show();
            SetComponentsEnabled(false);
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

        // handle this form close event
        private void ThisFormClosed(object sender, FormClosedEventArgs e)
        {
            _courseSelectionResultForm.Close();
        }

        // handle course selection form close event
        private void CourseSelectionResultFormClosed(object sender, FormClosedEventArgs e)
        {
            SetComponentsEnabled(true);
            _submitButton.Enabled = false;
            LoadCourseDataGridView(_courseTabControl.SelectedIndex);
        }
    }
}
