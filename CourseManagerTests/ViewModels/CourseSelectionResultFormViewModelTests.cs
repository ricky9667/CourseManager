using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourseManager.Tests
{
    [TestClass()]
    public class CourseSelectionResultFormViewModelTests
    {
        Model model;
        CourseSelectionResultFormViewModel viewModel;
        readonly int computerScience3TabIndex = 0;
        readonly int electronicEngineering3ATabIndex = 1;

        // unit test case setup
        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            viewModel = new CourseSelectionResultFormViewModel(model);
        }

        // test constructor
        [TestMethod()]
        public void CourseSelectionResultFormViewModelTest()
        {
            Assert.AreEqual(0, viewModel.SelectedCourseInfos.Count);
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

            model.SelectCourses(computerScience3TabIndex, new List<int> { 1, 2, 3 });
            viewModel.RemoveCourse(0);
            Assert.IsTrue(isMethodCalled);
        }

        // test update selected course infos
        [TestMethod()]
        public void UpdateSelectedCourseInfosTest()
        {
            model.SelectCourses(computerScience3TabIndex, new List<int> { 3, 4, 5 });
            model.SelectCourses(electronicEngineering3ATabIndex, new List<int> { 7 });

            Assert.AreEqual(4, viewModel.SelectedCourseInfos.Count);
            Assert.AreEqual(model.GetCourseInfo(computerScience3TabIndex, 3), viewModel.SelectedCourseInfos[0]);
            Assert.AreEqual(model.GetCourseInfo(computerScience3TabIndex, 4), viewModel.SelectedCourseInfos[1]);
            Assert.AreEqual(model.GetCourseInfo(computerScience3TabIndex, 5), viewModel.SelectedCourseInfos[2]);
            Assert.AreEqual(model.GetCourseInfo(electronicEngineering3ATabIndex, 7), viewModel.SelectedCourseInfos[3]);
        }

        // test remove course
        [TestMethod()]
        public void RemoveCourseTest()
        {
            model.SelectCourses(computerScience3TabIndex, new List<int> { 3, 4, 5 });
            model.SelectCourses(1, new List<int> { 7 });
            viewModel.RemoveCourse(2);
            viewModel.RemoveCourse(1);

            Assert.AreEqual(2, viewModel.SelectedCourseInfos.Count);
            Assert.AreEqual(model.GetCourseInfo(computerScience3TabIndex, 3), viewModel.SelectedCourseInfos[0]);
            Assert.AreEqual(model.GetCourseInfo(electronicEngineering3ATabIndex, 7), viewModel.SelectedCourseInfos[1]);
        }
    }
}