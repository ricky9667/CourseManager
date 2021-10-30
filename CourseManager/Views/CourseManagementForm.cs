﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseManager
{
    public partial class CourseManagementForm : Form
    {
        private readonly string _courseChars = "1234N56789ABCD";
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
            AddTimeDataGridViewRows();
            SetBindingProperties();
        }

        // add data binding properties
        private void SetBindingProperties()
        {
            _addCourseButton.DataBindings.Add(nameof(_addCourseButton.Enabled), _viewModel, nameof(_viewModel.AddCourseButtonEnabled));
            _saveButton.DataBindings.Add(nameof(_saveButton.Enabled), _viewModel, nameof(_viewModel.SaveButtonEnabled));
            _courseGroupBox.DataBindings.Add(nameof(_courseGroupBox.Enabled), _viewModel, nameof(_viewModel.CourseGroupBoxEnabled));
            foreach (Control courseGroupBoxControl in _courseGroupBox.Controls)
            {
                courseGroupBoxControl.DataBindings.Add(nameof(courseGroupBoxControl.Enabled), _viewModel, nameof(_viewModel.CourseGroupBoxEnabled));
            }
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
        private void AddTimeDataGridViewRows()
        {
            _timeDataGridView.Rows.Clear();
            for (int index = 0; index < _courseChars.Length; index++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = _courseChars[index],
                });
                for (int day = 0; day < 7; day++)
                {
                    row.Cells.Add(new DataGridViewCheckBoxCell
                    {
                        Value = false
                    });
                }
                _timeDataGridView.Rows.Add(row);
            }
        }

        // reset datagridview checkbox to false
        private void ResetTimeDataGridViewCheckboxes()
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
            _courseNumberTextbox.Text = "";
            _courseNameTextbox.Text = "";
            _stageTextbox.Text = "";
            _creditTextbox.Text = "";
            _teacherTextbox.Text = "";
            _courseTypeComboBox.SelectedIndex = 0;
            _teachingAssistantTextbox.Text = "";
            _languageTextbox.Text = "";
            _noteTextbox.Text = "";
            _hourComboBox.SelectedIndex = 0;
            _classComboBox.SelectedIndex = 0;

            ResetTimeDataGridViewCheckboxes();
        }

        // change group box data when select index in list box
        private void CourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.AddCourseButtonEnabled = true;
            _courseGroupBox.Text = "編輯課程";
            if (_courseListBox.SelectedIndex != -1)
            {
                Tuple<int, int, string> course = _viewModel.CourseManagementList[_courseListBox.SelectedIndex];
                CourseInfo courseInfo = _viewModel.GetCourseInfo(course.Item1, course.Item2);
                RenderCourseGroupBoxData(courseInfo, course.Item1);
                _viewModel.CourseGroupBoxEnabled = true;
            }
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

            ResetTimeDataGridViewCheckboxes();
            List<Tuple<int, int>> classTimes = courseInfo.GetCourseClassTimes();
            foreach (Tuple<int, int> classTime in classTimes)
            {
                _timeDataGridView.Rows[classTime.Item2].Cells[classTime.Item1 + 1].Value = true;
            }
        }

        // save updated course info
        private void SaveButtonClick(object sender, EventArgs e)
        {
            int listBoxIndex = _courseListBox.SelectedIndex;
            if (listBoxIndex == -1)
            {
                CourseInfo courseInfo = new CourseInfo();
                courseInfo = SetNewCourseInfoData(courseInfo);
                _viewModel.AddNewCourse(courseInfo, _classComboBox.SelectedIndex);
            }
            else
            {
                Tuple<int, int, string> course = _viewModel.CourseManagementList[listBoxIndex];
                CourseInfo courseInfo = _viewModel.GetCourseInfo(course.Item1, course.Item2);
                courseInfo = SetNewCourseInfoData(courseInfo);
                _viewModel.UpdateCourseInfo(course.Item1, course.Item2, courseInfo, _classComboBox.SelectedIndex);
            }

            _viewModel.CourseGroupBoxEnabled = false;
            _viewModel.SaveButtonEnabled = false;
            LoadCoursesAndClasses();
            ResetGroupBox();
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

        // check if course info can be saved and change button status
        private void CourseInfoDataChanged(object sender, EventArgs e)
        {
            _viewModel.SaveButtonEnabled = CheckTextboxDataValid();
        }

        // check if textbox is valid
        private bool CheckTextboxDataValid()
        {
            string courseNumberText = _courseNumberTextbox.Text.Trim();
            string courseNameText = _courseNameTextbox.Text.Trim();
            string stageText = _stageTextbox.Text.Trim();
            string creditText = _creditTextbox.Text.Trim();
            string teacherText = _teacherTextbox.Text.Trim();

            if (courseNumberText == "" || courseNameText == "" || stageText == "" || creditText == "" || teacherText == "")
            {
                return false;
            }

            bool numberIsNumeric = int.TryParse(courseNumberText, out _);
            bool stageIsNumeric = int.TryParse(stageText, out _);
            bool creditIsNumeric = double.TryParse(creditText, out _);

            if (!numberIsNumeric || !stageIsNumeric || !creditIsNumeric)
            {
                return false;
            }

            return true;
        }

        // change checkbox cell value when clicked
        private void TimeDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (rowIndex >= 0 && columnIndex > 0)
            {
                if (Convert.ToBoolean(_timeDataGridView.Rows[rowIndex].Cells[columnIndex].Value))
                {
                    _timeDataGridView.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
                else
                {
                    _timeDataGridView.Rows[rowIndex].Cells[columnIndex].Value = true;
                }
            }

            _viewModel.SaveButtonEnabled = IsTimeDataGridViewValid();
        }

        // check if datagridview matches course hours
        private bool IsTimeDataGridViewValid()
        {
            int hourCount = 0;
            foreach (DataGridViewRow row in _timeDataGridView.Rows)
            {
                for (int index = 1; index < row.Cells.Count; index++)
                {
                    if (Convert.ToBoolean(row.Cells[index].Value))
                    {
                        hourCount++;
                    }
                }
            }

            return hourCount == int.Parse(_hourComboBox.SelectedItem.ToString());
        }

        // create new course and clear all data in group box
        private void AddCourseButtonClick(object sender, EventArgs e)
        {
            _courseListBox.ClearSelected();
            _viewModel.AddCourseButtonEnabled = false;
            _viewModel.CourseGroupBoxEnabled = true;
            _courseGroupBox.Text = "新增課程";
            ResetGroupBox();
        }
    }
}
