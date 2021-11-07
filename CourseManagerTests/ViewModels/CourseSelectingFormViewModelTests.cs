﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Tests
{
    [TestClass()]
    public class CourseSelectingFormViewModelTests
    {
        Model model;
        CourseSelectingFormViewModel viewModel;
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new CourseSelectingFormViewModel(model);
        }

        [TestMethod()]
        public void CourseSelectingFormViewModelTest()
        {
            Assert.IsTrue(viewModel.CourseTabControlEnabled);
            Assert.IsTrue(viewModel.CourseSelectionResultButtonEnabled);
            Assert.IsFalse(viewModel.SubmitButtonEnabled);
            Assert.AreEqual(0, viewModel.CurrentTabIndex);
            Assert.AreEqual(12, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(12, viewModel.CurrentShowingIndexes.Count);
        }

        [TestMethod()]
        public void ControlEnabledTest()
        {
            viewModel.CourseTabControlEnabled = false;
            Assert.IsFalse(viewModel.CourseTabControlEnabled);
            viewModel.CourseSelectionResultButtonEnabled = false;
            Assert.IsFalse(viewModel.CourseSelectionResultButtonEnabled);
            viewModel.SubmitButtonEnabled = true;
            Assert.IsTrue(viewModel.SubmitButtonEnabled);
        }

        [TestMethod()]
        public void CourseTabPageInfosTest()
        {
            Assert.AreEqual(2, viewModel.CourseTabPageInfos.Count);
        }

        [TestMethod()]
        public void UpdateCurrentTabDataTest()
        {
            viewModel.CurrentTabIndex = 1;
            Assert.AreEqual(25, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(25, viewModel.CurrentShowingIndexes.Count);

            viewModel.CurrentTabIndex = 0;
            Assert.AreEqual(12, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(12, viewModel.CurrentShowingIndexes.Count);
        }

        [TestMethod()]
        public void SelectCoursesAndGetMessageTest()
        {
            string successMessage = viewModel.SelectCoursesAndGetMessage(0, new List<int> { 0, 3, 4, 5 });
            Assert.AreEqual("加選成功", successMessage);

            CourseInfo selectedCourseInfo = model.GetCourseInfo(1, 14);
            string failMessage = viewModel.SelectCoursesAndGetMessage(1, new List<int> { 14 });
            string expectedFailMessage = "加選失敗\n\n課程名稱相同：" + selectedCourseInfo.GetCourseDataString();
            Assert.AreEqual(expectedFailMessage, failMessage);

            selectedCourseInfo = model.GetCourseInfo(1, 0);
            failMessage = viewModel.SelectCoursesAndGetMessage(1, new List<int> { 0 });
            expectedFailMessage = "加選失敗\n\n課號相同：" + selectedCourseInfo.GetCourseDataString()  + "\n\n課程名稱相同：" + selectedCourseInfo.GetCourseDataString() + "\n\n衝堂：" + selectedCourseInfo.GetCourseDataString();
            Assert.AreEqual(expectedFailMessage, failMessage);
        }
    }
}