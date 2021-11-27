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
    public class AddNewCourseTests
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

        [TestCleanup]
        public void Cleanup()
        {
            _robot.Sleep(2);
            _robot.CleanUp();
        }

        // test add course
        [TestMethod()]
        public void AddCourseTests()
        {
            _robot.ClickByName("Course Selecting System");
            _robot.SwitchTo(START_UP_FORM);
            _robot.ClickByName("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);

            _robot.ClickTabControl("課程管理");
            _robot.ClickByName("新增課程");
            _robot.ClickByName("新增課程");
            _robot.AssertText("_courseGroupBox", "新增課程");
            _robot.AssertText("_saveButton", "新增");
            _robot.AssertEnable("新增課程", true);

            string[] courseInfoDataStrings = new string[] { "False", "999999", "北科大名校實屬牛逼", "1", "2.0", "2", "○", "胡紹宇", "", "", "", "1 2", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            _robot.InputValueToTextBox("_courseNumberTextBox", courseInfoDataStrings[1]);
            _robot.InputValueToTextBox("_courseNameTextBox", courseInfoDataStrings[2]);
            _robot.InputValueToTextBox("_stageTextBox", courseInfoDataStrings[3]);
            _robot.InputValueToTextBox("_creditTextBox", courseInfoDataStrings[4]);
            _robot.InputValueToTextBox("_teacherTextBox", courseInfoDataStrings[7]);
            _robot.ClickByName("時數(*)");
            _robot.ClickByName("2");
            _robot.ClickByName("班級(*)");
            _robot.ClickByName("電子三甲");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 0, "三");
            _robot.ClickDataGridViewCellBy("_timeDataGridView", 1, "三");
            _robot.ClickByName("新增");
            _robot.AssertEnable("新增課程", false);

            _robot.ScrollDownListBox(10);
            _robot.ClickByName(courseInfoDataStrings[2]);
            _robot.ScrollUpListBox(10);

            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("電子三甲");
            _robot.ScrollDownDataGridView(10);
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, 25, courseInfoDataStrings);
            _robot.ScrollUpDataGridView(10);
        }
    }
}