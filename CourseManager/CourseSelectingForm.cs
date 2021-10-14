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
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectingFormLoad(object sender, EventArgs e)
        {
            _courseTabPageInfos = _courseModel.GetCourseTabPageInfos();
            int tabCount = _courseTabPageInfos.Count;
            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = _courseTabPageInfos[index];
                courseTabControl.Controls[index].Name = tabPageInfo.TabName;
                courseTabControl.Controls[index].Text = tabPageInfo.TabText;
            }

            SetUpCourseDataGridView();
        }

        // setup data grid view
        private void SetUpCourseDataGridView()
        {
            courseDataGridView.DataSource = _courseModel.GetCourseInfos(_courseTabPageInfos[0].CourseLink);
            SetUpCourseGridViewColumns();
            courseDataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn
            {
                HeaderText = "選",
                Width = 30,
                ReadOnly = false,
                TrueValue = true,
                FalseValue = false
            });
        }

        // rename header text of datagridview
        private void SetUpCourseGridViewColumns()
        {
            Console.WriteLine(courseDataGridView.Columns.Count);

            int columnCount = 23;
            string[] columnHeaderText = { "number", "name", "stage", "credit", "hour", "courseType", "teacher", "classtime0", "classtime1", "classtime2", "classtime3", "classtime4", "classtime5", "classtime6", "classroom", "numberOfStudent", "numberOfDropStudent", "teachingAssistant", "language", "note", "outline", "audit", "experiment" };
            string[] columnHeaderTextChinese = { "課號", "課程名稱", "階段", "學分", "時數", "修", "教師", "日", "一", "二", "三", "四", "五", "六", "教室", "人", "撤", "教學助理", "授課語言", "教學大綱與進度表", "備註", "隨班附讀", "實驗實習" };

            for (int index = 0; index < columnCount; index++)
            {
                string headerText = columnHeaderText[index];
                string headerTextChinese = columnHeaderTextChinese[index];
                Console.WriteLine(index + " : " + headerText + " : " + headerTextChinese);

                courseDataGridView.Columns[headerText].HeaderText = headerTextChinese;
                Console.WriteLine("headerText: " + courseDataGridView.Columns[headerText]);
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

        // add datagridview to selected tab index
        void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = courseTabControl.SelectedIndex;
            courseDataGridView.DataSource = _courseModel.GetCourseInfos(_courseTabPageInfos[index].CourseLink);
            courseTabControl.Controls[index].Controls.Add(courseDataGridView);
        }
    }
}
