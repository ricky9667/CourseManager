using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class SelectCourseForm : Form
    {
        CourseModel _courseModel;
        DataGridViewCheckBoxColumn _checkBoxColumn;

        readonly int _columnCount = 23;
        string[] _columnHeaderText = { "number", "name", "stage", "credit", "hour", "courseType", "teacher", "classtime0", "classtime1", "classtime2", "classtime3", "classtime4", "classtime5", "classtime6", "classroom", "numberOfStudent", "numberOfDropStudent", "teachingAssistant", "language", "note", "outline", "audit", "experiment" };
        string[] _columnHeaderTextChinese = { "課號", "課程名稱", "階段", "學分", "時數", "修", "教師", "日", "一", "二", "三", "四", "五", "六", "教室", "人", "撤", "教學助理", "授課語言", "教學大綱與進度表", "備註", "隨班附讀", "實驗實習" };
        
        public SelectCourseForm(CourseModel courseModel)
        {
            _courseModel = courseModel;
            InitializeComponent();
        }

        // load select course form
        private void SelectCourseFormLoad(object sender, EventArgs e)
        {
            _courseDataGridView.DataSource = _courseModel.GetCourseInfos();
            SetUpCourseGridViewColumns();
            AddCheckBoxColumn();
        }

        // rename header text of datagridview
        private void SetUpCourseGridViewColumns()
        {
            for (int index = 0; index < _columnCount; index++)
            {
                _courseDataGridView.Columns[_columnHeaderText[index]].HeaderText = _columnHeaderTextChinese[index];
            }
        }

        // add checkbox column in first row
        private void AddCheckBoxColumn()
        {
            _checkBoxColumn = new DataGridViewCheckBoxColumn();
            _checkBoxColumn.HeaderText = "選";
            _checkBoxColumn.Width = 30;
            _checkBoxColumn.ReadOnly = false;
            _checkBoxColumn.TrueValue = true;
            _checkBoxColumn.FalseValue = false;
            
            _courseDataGridView.Columns.Insert(0, _checkBoxColumn);
        }

        // triggers when checkboxes in datagridview has value change 
        private void CourseDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCourses = 0;

            foreach (DataGridViewRow row in _courseDataGridView.Rows)
            {
                if (row.Cells[0].Value == _checkBoxColumn.TrueValue)
                {
                    selectedCourses++;
                }
            }

            _submitButton.Enabled = selectedCourses > 0;
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
