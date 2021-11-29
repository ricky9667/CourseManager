using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CourseManager.Tests
{
    [TestClass()]
    public class ImportComputerScienceCoursesTests
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";
        private const string COURSE_SELECTING_FORM = "CourseSelectingForm";
        private const string COURSE_MANAGEMENT_FORM = "CourseManagementForm";
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

        // test import computer science all courses test
        [TestMethod()]
        public void ImportComputerScienceCoursesTest()
        {
            _robot.ClickByName("Course Selecting System");
            _robot.SwitchTo(START_UP_FORM);
            _robot.ClickByName("Course Management System");
            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);

            _robot.ClickTabControl("課程管理");
            _robot.ClickByName("匯入資工系全部課程");
            _robot.Sleep(10);

            _robot.SwitchTo(COURSE_MANAGEMENT_FORM);
            _robot.ScrollDownListBox(20);
            _robot.ClickByName("微積分");
            _robot.ScrollDownListBox(20);
            _robot.ClickByName("微算機系統");
            _robot.ScrollDownListBox(20);
            _robot.ClickByName("高等計算機圖學");
            _robot.ScrollDownListBox(20);
            _robot.ClickByName("軟體工程");
            _robot.ScrollUpListBox(80);

            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工一");
            _robot.ClickTabControl("資工二");
            _robot.ClickTabControl("資工三");
            _robot.ClickTabControl("資工四");
            _robot.ClickTabControl("資工所");
        }
    }
}