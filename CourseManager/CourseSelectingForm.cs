using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        CourseModel _courseModel;
        List<CourseTabPageInfo> _courseTabPageInfos;

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

            SetUpCourseDataGridView(0);
        }

        // setup datagridview
        private void SetUpCourseDataGridView(int currentIndex)
        {
            List<CourseInfo> courseInfos = _courseModel.GetCourseInfos(currentIndex);
            courseDataGridView.Rows.Clear();
            foreach (CourseInfo info in courseInfos)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (string cellValue in info.GetCourseInfoStrings())
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cellValue });
                }
                row.Cells.Insert(0, new DataGridViewCheckBoxCell());
                courseDataGridView.Rows.Add(row);
            }
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
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(courseDataGridView.Rows[e.RowIndex].Cells[0].Value))
                {
                    courseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    courseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
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
            //courseDataGridView.DataSource = _courseModel.GetCourseInfos(tabIndex);
            SetUpCourseDataGridView(tabIndex);
            
            courseTabControl.Controls[tabIndex].Controls.Add(courseDataGridView);
        }

        // show course result form
        private void CourseSelectionResultButtonClick(object sender, EventArgs e)
        {
            Form form = new CourseSelectionResultForm();
            form.Show();
        }

        // submit courses
        private void SubmitButtonClick(object sender, EventArgs e)
        {
            int courseConut = courseDataGridView.Rows.Count;
            List<int> selectedIndexes = new List<int>();

            for (int index = 0; index < courseConut; index++)
            {
                if (Convert.ToBoolean(courseDataGridView.Rows[index].Cells[0].Value))
                {
                    selectedIndexes.Add(index);
                }
            }

            MessageBox.Show("加選成功");
        }
    }
}
