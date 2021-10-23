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
            LoadCoursesAndClasses();
            RefreshWindowStatus();
        }

        // load courses in course list box
        private void LoadCoursesAndClasses()
        {
            _courseListBox.Items.Clear();
            foreach (Tuple<int, int, string> course in _viewModel.CourseManagementList)
            {
                _courseListBox.Items.Add(course.Item3);
            }

            _classComboBox.Items.Clear();
            foreach (string className in _viewModel.ClassNames)
            {
                _classComboBox.Items.Add(className);
            }
        }

        // refresh components
        private void RefreshWindowStatus()
        {
            // course group box
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

            _saveButton.Enabled = _viewModel.SaveButtonEnabled;
        }

        // change group box data when select index in list box
        private void CourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<int, int, string> course = _viewModel.CourseManagementList[_courseListBox.SelectedIndex];
            CourseInfo courseInfo = _viewModel.GetCourseInfo(course.Item1, course.Item2);
            RenderCourseGroupBoxData(courseInfo, course.Item1);
            _viewModel.CourseGroupBoxEnabled = true;
            _viewModel.SaveButtonEnabled = true;
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

        // save updated course info
        private void SaveButtonClick(object sender, EventArgs e)
        {
            int listBoxIndex = _courseListBox.SelectedIndex;
            Tuple<int, int, string> course = _viewModel.CourseManagementList[listBoxIndex];
            CourseInfo courseInfo = _viewModel.GetCourseInfo(course.Item1, course.Item2);
            courseInfo = SetNewCourseInfoData(courseInfo);
            _viewModel.UpdateCourseInfo(course.Item1, course.Item2, courseInfo, _classComboBox.SelectedIndex);

            _viewModel.CourseGroupBoxEnabled = false;
            _viewModel.SaveButtonEnabled = false;
            LoadCoursesAndClasses();
            RefreshWindowStatus();
        }

        // update data to course info
        private CourseInfo SetNewCourseInfoData(CourseInfo courseInfo)
        {
            courseInfo.Number = _courseNumberTextbox.Text;
            courseInfo.Name = _courseNameTextbox.Text;
            courseInfo.Stage = _stageTextbox.Text;
            courseInfo.Credit = _creditTextbox.Text;
            courseInfo.Teacher = _teacherTextbox.Text;
            courseInfo.CourseType = _courseTypeComboBox.SelectedItem.ToString();
            courseInfo.TeachingAssistant = _teachingAssistantTextbox.Text;
            courseInfo.Language = _languageTextbox.Text;
            courseInfo.Note = _noteTextbox.Text;
            courseInfo.Hour = _hourComboBox.SelectedItem.ToString();
            return courseInfo;
        }

        // check if course info can be saved and change button status
        private void TextBoxDataChanged(object sender, EventArgs e)
        {
            _viewModel.SaveButtonEnabled = CanSaveCourse();
            RefreshWindowStatus();
        }

        // check if textbox is valid
        private bool CanSaveCourse()
        {
            string courseNumberText = _courseNumberTextbox.Text.Trim();
            string courseNameText = _courseNameTextbox.Text.Trim();
            string stageText = _stageTextbox.Text.Trim();
            string creditText = _creditTextbox.Text.Trim();
            string teacherText = _teacherTextbox.Text.Trim();

            return courseNumberText != "" && courseNameText != "" && stageText != "" && creditText != "" && teacherText != "";
        }
    }
}
