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

        [TestMethod]
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

        [TestMethod]
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
    }
}