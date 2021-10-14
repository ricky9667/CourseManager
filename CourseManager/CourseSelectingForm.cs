using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        CourseModel _courseModel;

        public CourseSelectingForm(CourseModel courseModel)
        {
            _courseModel = courseModel;
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectingFormLoad(object sender, EventArgs e)
        {
            List<CourseTabPageInfo> courseTabPageInfos = _courseModel.GetCourseTabPageInfos();
            int tabCount = courseTabPageInfos.Count;

            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = courseTabPageInfos[index];
                courseTabControl.Controls[index].Name = tabPageInfo.TabName;
                courseTabControl.Controls[index].Text = tabPageInfo.TabText;
                
                //TabPage courseTabPage = GetCourseTabPage(tabPageInfo.TabName, tabPageInfo.TabText, index, tabPageInfo.CourseLink);
                //courseTabControl.Controls.Add(courseTabPage);
            }

            courseDataGridView.DataSource = _courseModel.GetCourseInfos(courseTabPageInfos[0].CourseLink);
        }

        // dynamically create course tab page 
        private TabPage GetCourseTabPage(string tabName, string tabText, int tabIndex, string courseLink)
        {
            TabPage courseTabPage = new TabPage();
            DataGridView courseDataGridView = new CourseDataGridView(tabName, _courseModel.GetCourseInfos(courseLink), _submitButton);

            courseTabPage.Controls.Add(courseDataGridView);
            courseTabPage.Location = new System.Drawing.Point(8, 39);
            courseTabPage.Name = tabName;
            courseTabPage.Padding = new Padding(3);
            courseTabPage.Size = new System.Drawing.Size(1558, 543);
            courseTabPage.TabIndex = tabIndex;
            courseTabPage.Text = tabText;
            courseTabPage.UseVisualStyleBackColor = true;

            return courseTabPage;
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

            _submitButton.Enabled = selectedCourses > 0;
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

        void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Tab index changed");
        }
    }
}
