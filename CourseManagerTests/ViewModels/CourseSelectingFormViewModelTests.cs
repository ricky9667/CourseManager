using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourseManager.Tests
{
    [TestClass()]
    public class CourseSelectingFormViewModelTests
    {
        Model model;
        CourseSelectingFormViewModel viewModel;

        // unit test case setup
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new CourseSelectingFormViewModel(model);
        }

        // test constructor
        [TestMethod()]
        public void CourseSelectingFormViewModelTest()
        {
            Assert.IsTrue(viewModel.CourseTabControlEnabled);
            Assert.IsTrue(viewModel.CourseSelectionResultButtonEnabled);
            Assert.IsFalse(viewModel.SubmitButtonEnabled);
            Assert.AreEqual(0, viewModel.CurrentTabIndex);
            Assert.AreEqual(model.GetCourseInfos(0).Count, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(model.GetCourseInfos(0).Count, viewModel.CurrentShowingIndexes.Count);
        }

        // test model property
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, viewModel.Model);
        }

        // test notify observer
        [TestMethod()]
        public void NotifyObserverTest()
        {
            bool isMethodCalled = false;
            viewModel._viewModelChanged += () =>
            {
                isMethodCalled = true;
            };

            viewModel.SelectCoursesAndGetMessage(0, new List<int> { 1, 2, 3 });
            Assert.IsTrue(isMethodCalled);
        }

        // test controls enabled property
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

        // test course tab page infos property
        [TestMethod()]
        public void CourseTabPageInfosTest()
        {
            Assert.AreEqual(2, viewModel.CourseTabPageInfos.Count);
        }

        // test current course infos and current showing indexes
        [TestMethod()]
        public void UpdateCurrentTabDataTest()
        {
            viewModel.CurrentTabIndex = 1;
            int courseCount = model.GetCourseInfos(viewModel.CurrentTabIndex).Count;
            Assert.AreEqual(courseCount, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(courseCount, viewModel.CurrentShowingIndexes.Count);

            viewModel.CurrentTabIndex = 0;
            courseCount = model.GetCourseInfos(viewModel.CurrentTabIndex).Count;
            Assert.AreEqual(courseCount, viewModel.CurrentCourseInfos.Count);
            Assert.AreEqual(courseCount, viewModel.CurrentShowingIndexes.Count);
        }

        // test select courses and get message test
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