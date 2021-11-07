using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class CourseManagementForm : Form
    {
        private readonly string _courseChars = "1234N56789ABCD";
        private bool _isUpdatingCourseGroupBox;
        private readonly CourseManagementFormViewModel _viewModel;
        public CourseManagementForm(CourseManagementFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _isUpdatingCourseGroupBox = false;
            InitializeComponent();
        }

        // load course management form
        private void CourseManagementFormLoad(object sender, EventArgs e)
        {
            LoadCoursesAndClasses();
            LoadTimeDataGridViewRows();
            SetBindingProperties();
        }

        // add data binding properties
        private void SetBindingProperties()
        {
            _addCourseButton.DataBindings.Add(nameof(_addCourseButton.Enabled), _viewModel, nameof(_viewModel.AddCourseButtonEnabled));
            _saveButton.DataBindings.Add(nameof(_saveButton.Enabled), _viewModel, nameof(_viewModel.SaveButtonEnabled));
            _importComputerScienceCoursesButton.DataBindings.Add(nameof(_importComputerScienceCoursesButton.Enabled), _viewModel, nameof(_viewModel.ImportCourseButtonEnabled));
            _courseGroupBox.DataBindings.Add(nameof(_courseGroupBox.Enabled), _viewModel, nameof(_viewModel.CourseGroupBoxEnabled));
            foreach (Control courseGroupBoxControl in _courseGroupBox.Controls)
            {
                courseGroupBoxControl.DataBindings.Add(nameof(courseGroupBoxControl.Enabled), _viewModel, nameof(_viewModel.CourseGroupBoxEnabled));
            }
            _courseListBox.DataBindings.Add(nameof(_courseListBox.SelectedIndex), _viewModel, nameof(_viewModel.CurrentSelectedCourse));
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

        // generate datagridview rows
        private void LoadTimeDataGridViewRows()
        {
            _timeDataGridView.Rows.Clear();
            for (int index = 0; index < _courseChars.Length; index++)
            {
                _timeDataGridView.Rows.Add(CreateTimeDataGridViewRow(_courseChars[index]));
            }
            _timeDataGridView.Refresh();
            _timeDataGridView.ClearSelection();
        }

        // create datagridview row
        private DataGridViewRow CreateTimeDataGridViewRow(char classTime)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = classTime,
            });
            for (int day = 0; day < 7; day++)
            {
                row.Cells.Add(new DataGridViewCheckBoxCell
                {
                    Value = false
                });
            }
            return row;
        }

        // reset datagridview checkbox to false
        private void ResetTimeDataGridViewCheckBoxes()
        {
            foreach (DataGridViewRow row in _timeDataGridView.Rows)
            {
                for (int index = 1; index < row.Cells.Count; index++)
                {
                    row.Cells[index].Value = false;
                }
            }
        }

        // reset all data in group box
        private void ResetGroupBox()
        {
            _startCourseSettingsComboBox.SelectedIndex = 0;
            _courseNumberTextBox.Text = "";
            _courseNameTextBox.Text = "";
            _stageTextBox.Text = "";
            _creditTextBox.Text = "";
            _teacherTextBox.Text = "";
            _courseTypeComboBox.SelectedIndex = 0;
            _teachingAssistantTextBox.Text = "";
            _languageTextBox.Text = "";
            _noteTextBox.Text = "";
            _hourComboBox.SelectedIndex = 0;
            _classComboBox.SelectedIndex = 0;

            ResetTimeDataGridViewCheckBoxes();
        }

        // change group box data when select index in list box
        private void CourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.CurrentSelectedCourse = _courseListBox.SelectedIndex;
            _viewModel.AddCourseButtonEnabled = true;
            _viewModel.SaveButtonEnabled = false;
            _timeDataGridView.ClearSelection();
            _courseGroupBox.Text = "編輯課程";

            _isUpdatingCourseGroupBox = true;
            if (_courseListBox.SelectedIndex != -1)
            {
                ResetTimeDataGridViewCheckBoxes();
                CourseInfo courseInfo = _viewModel.CurrentCourseInfo;
                RenderCourseGroupBoxData(courseInfo, _viewModel.CurrentClassIndex);
                _viewModel.CourseGroupBoxEnabled = true;
            }
            _isUpdatingCourseGroupBox = false;
        }

        // render data to course group box by course info
        private void RenderCourseGroupBoxData(CourseInfo courseInfo, int classIndex)
        {
            _startCourseSettingsComboBox.SelectedIndex = 0;
            _courseNumberTextBox.Text = courseInfo.Number;
            _courseNameTextBox.Text = courseInfo.Name;
            _stageTextBox.Text = courseInfo.Stage;
            _creditTextBox.Text = courseInfo.Credit;
            _teacherTextBox.Text = courseInfo.Teacher;
            _courseTypeComboBox.SelectedIndex = courseInfo.CourseTypeIndex;
            _teachingAssistantTextBox.Text = courseInfo.TeachingAssistant;
            _languageTextBox.Text = courseInfo.Language;
            _noteTextBox.Text = courseInfo.Note;
            _hourComboBox.SelectedIndex = courseInfo.HourIndex;
            _classComboBox.SelectedIndex = classIndex;
            List<Tuple<int, int>> classTimes = courseInfo.GetCourseClassTimes();
            foreach (Tuple<int, int> classTime in classTimes)
            {
                _timeDataGridView.Rows[classTime.Item2].Cells[classTime.Item1 + 1].Value = true;
            }
        }

        // save updated course info
        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (_courseListBox.SelectedIndex == -1)
            {
                CourseInfo courseInfo = new CourseInfo();
                courseInfo = SetNewCourseInfoData(courseInfo);
                _viewModel.AddNewCourse(courseInfo, _classComboBox.SelectedIndex);
            }
            else
            {
                CourseInfo courseInfo = _viewModel.CurrentCourseInfo;
                courseInfo = SetNewCourseInfoData(courseInfo);
                _viewModel.UpdateCourseInfo(courseInfo, _classComboBox.SelectedIndex);
            }

            _viewModel.CourseGroupBoxEnabled = _viewModel.SaveButtonEnabled = false;
            _timeDataGridView.ClearSelection();
            LoadCoursesAndClasses();
            ResetGroupBox();
        }

        // update data to course info
        private CourseInfo SetNewCourseInfoData(CourseInfo courseInfo)
        {
            courseInfo.Number = _courseNumberTextBox.Text.Trim();
            courseInfo.Name = _courseNameTextBox.Text.Trim();
            courseInfo.Stage = _stageTextBox.Text.Trim();
            courseInfo.Credit = _creditTextBox.Text.Trim();
            courseInfo.Teacher = _teacherTextBox.Text.Trim();
            courseInfo.CourseType = _courseTypeComboBox.SelectedIndex == -1 ? "" : _courseTypeComboBox.SelectedItem.ToString();
            courseInfo.TeachingAssistant = _teachingAssistantTextBox.Text.Trim();
            courseInfo.Language = _languageTextBox.Text.Trim();
            courseInfo.Note = _noteTextBox.Text.Trim();
            courseInfo.Hour = _hourComboBox.SelectedIndex == -1 ? "" : _hourComboBox.SelectedItem.ToString();
            return SetDayClassTimes(courseInfo);
        }

        // set class time to time datagridview
        private CourseInfo SetDayClassTimes(CourseInfo courseInfo)
        {
            courseInfo.ClassTime0 = GetDayClassTime(0);
            courseInfo.ClassTime1 = GetDayClassTime(1);
            courseInfo.ClassTime2 = GetDayClassTime(2);
            courseInfo.ClassTime3 = GetDayClassTime(3);
            courseInfo.ClassTime4 = GetDayClassTime(4);
            courseInfo.ClassTime5 = GetDayClassTime(5);
            courseInfo.ClassTime6 = GetDayClassTime(6);
            return courseInfo;
        }

        // get class time string of specific day
        private string GetDayClassTime(int day)
        {
            string classTimeString = "";
            for (int index = 0; index < _courseChars.Length; index++)
            {
                if (Convert.ToBoolean(_timeDataGridView.Rows[index].Cells[day + 1].Value))
                {
                    classTimeString += _courseChars[index] + " ";
                }
            }
            return classTimeString.Trim();
        }

        // handle save button enabled state
        private void HandleSaveButtonEnabled()
        {
            if (!_isUpdatingCourseGroupBox)
            {
                CourseInfo showingCourseInfo = new CourseInfo();
                showingCourseInfo = SetNewCourseInfoData(showingCourseInfo);
                _viewModel.SaveButtonEnabled = _viewModel.CheckSaveButtonStateByCourseData(showingCourseInfo, _classComboBox.SelectedIndex);
            }
        }

        // check if course info can be saved and change button status
        private void CourseInfoDataChanged(object sender, EventArgs e)
        {
            HandleSaveButtonEnabled();
        }

        // change checkbox cell value when clicked and change save button state
        private void TimeDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                if (Convert.ToBoolean(_timeDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    _timeDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    _timeDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }

            HandleSaveButtonEnabled();
        }

        // create new course and clear all data in group box
        private void AddCourseButtonClick(object sender, EventArgs e)
        {
            _courseListBox.ClearSelected();
            _timeDataGridView.ClearSelection();
            _viewModel.AddCourseButtonEnabled = false;
            _viewModel.CourseGroupBoxEnabled = true;
            _courseGroupBox.Text = "新增課程";
            ResetGroupBox();
        }

        // import computer science courses and show loading dialog
        private void ImportComputerScienceCoursesButtonClick(object sender, EventArgs e)
        {
            ImportCourseProgressFormViewModel importCourseProgressFormViewModel = new ImportCourseProgressFormViewModel(_viewModel.Model);
            Form importCourseProgressForm = new ImportCourseProgressForm(importCourseProgressFormViewModel);
            importCourseProgressForm.ShowDialog();
            _viewModel.ImportCourseButtonEnabled = false;
        }
    }
}
