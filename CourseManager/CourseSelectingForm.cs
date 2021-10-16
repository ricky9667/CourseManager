using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        CourseModel _courseModel;
        List<CourseTabPageInfo> _courseTabPageInfos;
        List<int> _currentShowingIndexes;

        public CourseSelectingForm(CourseModel courseModel)
        {
            _courseModel = courseModel;
            _courseTabPageInfos = _courseModel.GetCourseTabPageInfos();
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectingFormLoad(object sender, EventArgs e)
        {
            int tabCount = _courseTabPageInfos.Count;
            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = _courseTabPageInfos[index];
                courseTabControl.Controls[index].Name = tabPageInfo.TabName;
                courseTabControl.Controls[index].Text = tabPageInfo.TabText;
            }

            LoadCourseDataGridView(0);
        }

        // setup datagridview
        private void LoadCourseDataGridView(int tabIndex)
        {
            courseDataGridView.Rows.Clear();
            List<CourseInfo> courseInfos = _courseModel.GetCourseInfos(tabIndex);
            _currentShowingIndexes = _courseModel.GetShowingList(tabIndex);

            foreach (int index in _currentShowingIndexes)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (string cellValue in courseInfos[index].GetCourseInfoStrings())
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cellValue });
                }
                row.Cells.Insert(0, new DataGridViewCheckBoxCell());
                courseDataGridView.Rows.Add(row);
            }

            courseDataGridView.Refresh();
        }

        // triggers when checkboxes in datagridview has value change 
        private void CourseDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCourses = 0;

            foreach (DataGridViewRow row in courseDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    selectedCourses++;
                }
            }

            submitButton.Enabled = selectedCourses > 0;
        }

        // make datagridview data readonly
        private void CourseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (rowIndex >= 0 && columnIndex == 0)
            {
                if (Convert.ToBoolean(courseDataGridView.Rows[rowIndex].Cells[0].Value))
                {
                    courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
                else
                {
                    courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = true;
                }
            }
        }

        // handle dirty state change
        void CourseDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (courseDataGridView.IsCurrentCellDirty)
            {
                courseDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // add datagridview to selected tab index
        void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabIndex = courseTabControl.SelectedIndex;
            LoadCourseDataGridView(tabIndex);
            courseTabControl.Controls[tabIndex].Controls.Add(courseDataGridView);
        }

        // show course result form
        private void CourseSelectionResultButtonClick(object sender, EventArgs e)
        {
            Form form = new CourseSelectionResultForm(_courseModel);
            form.ShowDialog();
            LoadCourseDataGridView(courseTabControl.SelectedIndex);
        }

        // submit courses
        private void SubmitButtonClick(object sender, EventArgs e)
        {
            int tabIndex = courseTabControl.SelectedIndex;
            int count = courseDataGridView.Rows.Count;
            List<int> selectedIndexes = new List<int>();

            for (int index = 0; index < count; index++)
            {
                if (Convert.ToBoolean(courseDataGridView.Rows[index].Cells[0].Value))
                {
                    selectedIndexes.Add(_currentShowingIndexes[index]);
                }
            }

            string selectCourseMessage = _courseModel.CheckSelectCoursesWithMessage(tabIndex, selectedIndexes);
            if (selectCourseMessage == "")
            {
                _courseModel.SelectCourses(tabIndex, selectedIndexes);
                MessageBox.Show("加選成功");
            }
            else
            {
                MessageBox.Show("加選失敗" + selectCourseMessage);
            }
            
            LoadCourseDataGridView(tabIndex);
            submitButton.Enabled = false;
        }
    }
}
