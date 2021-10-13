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
            //_courseDataGridView.DataSource = _courseModel.GetCourseInfos();
            //SetUpCourseGridViewColumns();
            //AddCheckBoxColumn();

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

            DataGridView courseDataGridView = GetCourseDataGridView(courseLink);

            //SetUpCourseGridViewColumns(courseDataGridView);
            //int columnCount = 23;
            //string[] columnHeaderText = { "number", "name", "stage", "credit", "hour", "courseType", "teacher", "classtime0", "classtime1", "classtime2", "classtime3", "classtime4", "classtime5", "classtime6", "classroom", "numberOfStudent", "numberOfDropStudent", "teachingAssistant", "language", "note", "outline", "audit", "experiment" };
            //string[] columnHeaderTextChinese = { "課號", "課程名稱", "階段", "學分", "時數", "修", "教師", "日", "一", "二", "三", "四", "五", "六", "教室", "人", "撤", "教學助理", "授課語言", "教學大綱與進度表", "備註", "隨班附讀", "實驗實習" };
            //for (int index = 0; index < columnCount; index++)
            //{
            //    courseDataGridView.Columns[columnHeaderText[index]].HeaderText = columnHeaderTextChinese[index];
            //}

            //AddCheckBoxColumn(courseDataGridView);
            //courseDataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn
            //{
            //    HeaderText = "選",
            //    Width = 30,
            //    ReadOnly = false,
            //    TrueValue = true,
            //    FalseValue = false
            //});

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

        // dynamically create course data grid view
        private DataGridView GetCourseDataGridView(string courseLink)
        {
            DataGridView courseDataGridView = new DataGridView();
            courseDataGridView.DataSource = _courseModel.GetCourseInfos(courseLink);

            courseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            courseDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            courseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            courseDataGridView.Dock = DockStyle.Fill;
            courseDataGridView.Location = new System.Drawing.Point(3, 3);
            courseDataGridView.Name = "_courseDataGridView";
            courseDataGridView.ReadOnly = true;
            courseDataGridView.RowHeadersVisible = false;
            courseDataGridView.RowHeadersWidth = 100;
            courseDataGridView.RowTemplate.Height = 20;
            courseDataGridView.Size = new System.Drawing.Size(1552, 537);
            courseDataGridView.TabIndex = 2;
            courseDataGridView.CellClick += new DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            courseDataGridView.CellContentClick += new DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            courseDataGridView.CurrentCellDirtyStateChanged += new EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);

            return courseDataGridView;
        }

        // rename header text of datagridview
        private void SetUpCourseGridViewColumns(DataGridView courseDataGridView)
        {
            int columnCount = 23;
            string[] columnHeaderText = { "number", "name", "stage", "credit", "hour", "courseType", "teacher", "classtime0", "classtime1", "classtime2", "classtime3", "classtime4", "classtime5", "classtime6", "classroom", "numberOfStudent", "numberOfDropStudent", "teachingAssistant", "language", "note", "outline", "audit", "experiment" };
            string[] columnHeaderTextChinese = { "課號", "課程名稱", "階段", "學分", "時數", "修", "教師", "日", "一", "二", "三", "四", "五", "六", "教室", "人", "撤", "教學助理", "授課語言", "教學大綱與進度表", "備註", "隨班附讀", "實驗實習" };


            for (int index = 0; index < columnCount; index++)
            {
                courseDataGridView.Columns[columnHeaderText[index]].HeaderText = columnHeaderTextChinese[index];
            }
        }

        // add checkbox column in first row
        private void AddCheckBoxColumn(DataGridView courseDataGridView)
        {
            courseDataGridView.Columns.Insert(0, new DataGridViewCheckBoxColumn
            {
                HeaderText = "選",
                Width = 30,
                ReadOnly = false,
                TrueValue = true,
                FalseValue = false
            });
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
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(_courseDataGridView.Rows[e.RowIndex].Cells[0].Value))
                {
                    _courseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    _courseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
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
    }
}
