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
        private void SelectCourseFormLoad(object sender, EventArgs e)
        {
            List<CourseTabPageInfo> courseTabPageInfos = _courseModel.GetCourseTabPageInfos();
            int tabCount = courseTabPageInfos.Count;

            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = courseTabPageInfos[index];
                TabPage courseTabPage = GetCourseTabPage(tabPageInfo.TabName, tabPageInfo.TabText, index, tabPageInfo.CourseLink);
                courseTabControl.Controls.Add(courseTabPage);
            }
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
    }
}
