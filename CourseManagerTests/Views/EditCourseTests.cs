using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseManager.Tests
{
    [TestClass()]
    public class EditCourseTests
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";
        private const string COURSE_SELECTING_FORM = "CourseSelectingForm";
        private const string COURSE_SELECTION_RESULT_FORM = "CourseSelectionResultForm";
        private const string COURSE_MANAGEMENT_FORM = "CourseManagementForm";
        private const string COURSE_DATA_GRID_VIEW = "courseDataGridView";
        private const string WINDOWS_PROGRAMMING_COURSE_NAME = "視窗程式設計";
        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "CourseManager";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "CourseManager.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);

        }

        // dispose
        [TestCleanup]
        public void Cleanup()
        {
            _robot.Sleep(2);
            _robot.CleanUp();
        }

        // test edit course info and check enabled
        [TestMethod()]
        public void EditCourseInfoAndCheckEnabledTest()
        {
            _robot.ClickByName("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);

            _robot.ClickTabControl("課程管理");
            _robot.ClickByName(WINDOWS_PROGRAMMING_COURSE_NAME);
            _robot.InputValueToTextBox("_courseNameTextBox", "視窗程式設計好難");
            _robot.AssertEnable("儲存", true);

            _robot.InputValueToTextBox("_courseNameTextBox", "");
            _robot.AssertEnable("儲存", false);
        }

        // test edit course time and check enabled
        [TestMethod()]
        public void EditCourseTimeAndCheckEnabledTest()
        {
            _robot.ClickByName("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);

            _robot.ClickTabControl("課程管理");
            _robot.ClickByName(WINDOWS_PROGRAMMING_COURSE_NAME);
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 6, "四");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 5, "四");
            _robot.AssertEnable("儲存", true);

            _robot.ClickDataGridViewCellBy("_timeDataGridView", 6, "四");
            _robot.AssertEnable("儲存", false);
        }

        // test edit course with class changed
        [TestMethod()]
        public void EditCourseInfoWithClassChangedTest()
        {
            _robot.ClickByName("Course Selecting System");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            const int SELECT_INDEX = 9;
            string[] windowsProgrammingCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, SELECT_INDEX);
            string[] expectedCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, SELECT_INDEX + 1);

            OpenWindowsAndGoToCourseManagementForm();
            EditWindowsProgrammingCourse();

            _robot.ScrollDownListBox(10);
            _robot.ClickByName("物件導向分析與設計"); // test if new course can be found
            _robot.ScrollUpListBox(10);

            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, SELECT_INDEX, expectedCourseDataStrings);

            _robot.ClickTabControl("電子三甲");
            ModifyWindowsProgrammingCourseStrings(windowsProgrammingCourseDataStrings);

            _robot.ScrollDownDataGridView(15);
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, 25, windowsProgrammingCourseDataStrings);
            _robot.ScrollUpDataGridView(15);
        }

        // test edit course with class changed and course selected
        [TestMethod()]
        public void EditCourseInfoWithCourseSelectedClassChangedTest()
        {
            _robot.ClickByName("Course Selecting System");
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            const int SELECT_INDEX = 9;
            string[] windowsProgrammingCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, SELECT_INDEX);

            _robot.ClickTabControl("資工三");
            _robot.ClickDataGridViewCellBy(COURSE_DATA_GRID_VIEW, SELECT_INDEX, "選");
            _robot.ClickByName("確認送出");
            _robot.CloseMessageBox();

            OpenWindowsAndGoToCourseManagementForm();
            EditWindowsProgrammingCourse();

            _robot.ScrollDownListBox(10);
            _robot.ClickByName("物件導向分析與設計"); // test if new course can be found
            _robot.ScrollUpListBox(10);

            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickByName("查看選課結果");
            _robot.SwitchTo(COURSE_SELECTION_RESULT_FORM);
            ModifyWindowsProgrammingCourseStrings(windowsProgrammingCourseDataStrings);
            windowsProgrammingCourseDataStrings[0] = "退選";
            _robot.AssertDataGridViewRowDataBy("selectedCourseDataGridView", 0, windowsProgrammingCourseDataStrings);
        }
    
        // open windows and go to course management form
        private void OpenWindowsAndGoToCourseManagementForm()
        {
            _robot.SwitchTo(START_UP_FORM);
            _robot.ClickByName("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ClickTabControl("課程管理");
            _robot.ClickByName(WINDOWS_PROGRAMMING_COURSE_NAME);
        }

        // edit windows programming course
        private void EditWindowsProgrammingCourse()
        {
            _robot.InputValueToTextBox("_courseNumberTextBox", "270915");
            _robot.InputValueToTextBox("_courseNameTextBox", "物件導向分析與設計");
            _robot.InputValueToTextBox("_creditTextBox", "2.0");
            _robot.ClickByName("時數(*)");
            _robot.ClickByName("2");
            _robot.ClickByName("班級(*)");
            _robot.ClickByName("電子三甲");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 2, "四");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 3, "四");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 6, "四");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 2, "一");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 2, "二");
            _robot.ClickByName("儲存");
        }

        // modify windows programming course strings
        private string[] ModifyWindowsProgrammingCourseStrings(string[] windowsProgrammingCourseDataStrings)
        {
            windowsProgrammingCourseDataStrings[1] = "270915";
            windowsProgrammingCourseDataStrings[2] = "物件導向分析與設計";
            windowsProgrammingCourseDataStrings[4] = "2.0";
            windowsProgrammingCourseDataStrings[5] = "2";
            windowsProgrammingCourseDataStrings[9] = "3";
            windowsProgrammingCourseDataStrings[10] = "3";
            windowsProgrammingCourseDataStrings[12] = "";
            return windowsProgrammingCourseDataStrings;
        }
    }
}