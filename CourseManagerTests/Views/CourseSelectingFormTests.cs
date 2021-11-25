﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class CourseSelectingFormTests
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";
        private const string COURSE_SELECTING_FORM = "CourseSelectingForm";
        private const string COURSE_SELECTION_RESULT_FORM = "CourseSelectionResultForm";
        private const string COURSE_DATA_GRID_VIEW = "courseDataGridView";

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

        [TestMethod()]
        public void SelectCourseAndRemoveCourseTest()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.SwitchTo(COURSE_SELECTING_FORM);

            _robot.ClickTabControl("資工三");
            const int FIRST_SELECTED_INDEX = 9;
            string[] firstCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, FIRST_SELECTED_INDEX);
            string[] expectedCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, FIRST_SELECTED_INDEX + 1);
            _robot.ClickDataGridViewCellBy(COURSE_DATA_GRID_VIEW, FIRST_SELECTED_INDEX, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, FIRST_SELECTED_INDEX, expectedCourseDataStrings);

            _robot.ClickTabControl("電子三甲");
            const int SECOND_SELECTED_INDEX = 9;
            string[] secondCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, SECOND_SELECTED_INDEX);
            expectedCourseDataStrings = _robot.GetDataGridViewRowDataStrings(COURSE_DATA_GRID_VIEW, SECOND_SELECTED_INDEX + 1);
            _robot.ClickDataGridViewCellBy(COURSE_DATA_GRID_VIEW, SECOND_SELECTED_INDEX, "選");
            _robot.ClickButton("確認送出");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, SECOND_SELECTED_INDEX, expectedCourseDataStrings);

            _robot.ClickButton("查看選課結果");
            _robot.SwitchTo(COURSE_SELECTION_RESULT_FORM);
            expectedCourseDataStrings = GetSelectedCourseDataStrings(firstCourseDataStrings);
            //expectedCourseDataStrings[0] = "退選";
            _robot.AssertDataGridViewRowDataBy("selectedCourseDataGridView", 0, expectedCourseDataStrings);
            expectedCourseDataStrings = GetSelectedCourseDataStrings(secondCourseDataStrings);
            //expectedCourseDataStrings[0] = "退選";
            _robot.AssertDataGridViewRowDataBy("selectedCourseDataGridView", 1, expectedCourseDataStrings);
            _robot.ClickDataGridViewCellBy("selectedCourseDataGridView", 1, "退");
            _robot.ClickDataGridViewCellBy("selectedCourseDataGridView", 0, "退");

            _robot.CloseWindow();
            _robot.SwitchTo(COURSE_SELECTING_FORM);
            _robot.ClickTabControl("資工三");
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, FIRST_SELECTED_INDEX, firstCourseDataStrings);
            _robot.ClickTabControl("電子三甲");
            _robot.AssertDataGridViewRowDataBy(COURSE_DATA_GRID_VIEW, SECOND_SELECTED_INDEX, secondCourseDataStrings);
        }

        // convert and deep copy strings
        private string[] GetSelectedCourseDataStrings(string[] courseDataStrings)
        {
            List<string> newCourseDataString = new List<string>();
            for (int i = 0; i < courseDataStrings.Count(); i++)
            {
                newCourseDataString.Add(courseDataStrings[i]);
            }
            newCourseDataString[0] = "退選";
            return newCourseDataString.ToArray();
        }

    }
}