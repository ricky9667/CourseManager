using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseManager
{
    class CourseDataGridView : DataGridView
    {
        private Button _submitButton;
        public CourseDataGridView(string name, List<CourseInfo> courseInfos, Button submitButton)
        {
            Name = name;
            _submitButton = submitButton;

            SetBasicProperties();
            SetUpCourseGridViewColumns();
            AddCheckBoxColumn();

            CellClick += new DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            CellContentClick += new DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            CurrentCellDirtyStateChanged += new EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);

            DataSource = courseInfos;
        }

        // init datagridview basic properties
        private void SetBasicProperties()
        {
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dock = DockStyle.Fill;
            Location = new System.Drawing.Point(3, 3);
            ReadOnly = true;
            RowHeadersVisible = false;
            RowHeadersWidth = 100;
            RowTemplate.Height = 20;
            Size = new System.Drawing.Size(1552, 537);
            TabIndex = 2;
        }

        // rename header text of datagridview
        private void SetUpCourseGridViewColumns()
        {
            Console.WriteLine(Columns.Count);

            int columnCount = 23;
            string[] columnHeaderText = { "number", "name", "stage", "credit", "hour", "courseType", "teacher", "classtime0", "classtime1", "classtime2", "classtime3", "classtime4", "classtime5", "classtime6", "classroom", "numberOfStudent", "numberOfDropStudent", "teachingAssistant", "language", "note", "outline", "audit", "experiment" };
            string[] columnHeaderTextChinese = { "課號", "課程名稱", "階段", "學分", "時數", "修", "教師", "日", "一", "二", "三", "四", "五", "六", "教室", "人", "撤", "教學助理", "授課語言", "教學大綱與進度表", "備註", "隨班附讀", "實驗實習" };

            for (int index = 0; index < columnCount; index++)
            {
                string headerText = columnHeaderText[index];
                string headerTextChinese = columnHeaderTextChinese[index];
                Console.WriteLine(index + " : " + headerText + " : " + headerTextChinese);

                //Columns[headerText].HeaderText = headerTextChinese;
                Console.WriteLine("headerText: " + this.Columns[headerText]);
            }
        }

        // add checkbox column in first row
        private void AddCheckBoxColumn()
        {
            Columns.Insert(0, new DataGridViewCheckBoxColumn
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

            foreach (DataGridViewRow row in Rows)
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
                if (Convert.ToBoolean(Rows[e.RowIndex].Cells[0].Value))
                {
                    Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
        }

        // handle dirty state change
        void CourseDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (IsCurrentCellDirty)
            {
                CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
