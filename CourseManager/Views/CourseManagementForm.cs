using System;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseManagementForm : Form
    {
        CourseManagementFormViewModel _viewModel;
        public CourseManagementForm(CourseManagementFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        // load course management form
        private void CourseManagementFormLoad(object sender, EventArgs e)
        {
            LoadCourses();
            
            foreach (string className in _viewModel.ClassNames)
            {
                _classComboBox.Items.Add(className);
            }

            RefreshWindowStatus();
        }

        // load courses in course list box
        private void LoadCourses()
        {
            _courseListBox.Items.Clear();
            foreach (Tuple<int, int, string> course in _viewModel.CourseManagementList)
            {
                _courseListBox.Items.Add(course.Item3);
            }
        }

        // refresh components
        private void RefreshWindowStatus()
        {
            _courseGroupBox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _startCourseSettingsComboBox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _courseNumberTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _courseNameTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _stageTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _creditTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _teacherTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _courseTypeComboBox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _teachingAssistantTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _languageTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _noteTextbox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _hourComboBox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _classComboBox.Enabled = _viewModel.CourseGroupBoxEnabled;
            _timeDataGridView.Enabled = _viewModel.CourseGroupBoxEnabled;
        }

        // change group box data when select index in list box
        private void CourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.EnableCourseGroupBox();
            Tuple<int, int, string> course = _viewModel.CourseManagementList[_courseListBox.SelectedIndex];
            CourseInfo courseInfo = _viewModel.GetCourseInfo(course.Item1, course.Item2);
            RenderCourseGroupBoxData(courseInfo, course.Item1);
            RefreshWindowStatus();
        }

        // render data to ui by course info
        private void RenderCourseGroupBoxData(CourseInfo courseInfo, int classIndex)
        {
            _startCourseSettingsComboBox.SelectedIndex = 0;
            _courseNumberTextbox.Text = courseInfo.Number;
            _courseNameTextbox.Text = courseInfo.Name;
            _stageTextbox.Text = courseInfo.Stage;
            _creditTextbox.Text = courseInfo.Credit;
            _teacherTextbox.Text = courseInfo.Teacher;
            _courseTypeComboBox.SelectedIndex = courseInfo.CourseTypeIndex;
            _teachingAssistantTextbox.Text = courseInfo.TeachingAssistant;
            _languageTextbox.Text = courseInfo.Language;
            _noteTextbox.Text = courseInfo.Note;
            _hourComboBox.SelectedIndex = courseInfo.HourIndex;
            _classComboBox.SelectedIndex = classIndex;
        }
    }
}
