using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Tests
{
    [TestClass()]
    public class CourseSelectionResultFormViewModelTests
    {
        Model model;
        CourseSelectionResultFormViewModel viewModel;
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new CourseSelectionResultFormViewModel(model);
        }

        [TestMethod()]
        public void CourseSelectionResultFormViewModelTest()
        {
            Assert.AreEqual(0, viewModel.SelectedCourseInfos.Count);
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            bool isMethodCalled = false;
            viewModel._viewModelChanged += () =>
            {
                isMethodCalled = true;
            };

            model.SelectCourses(0, new List<int> { 1, 2, 3 });
            viewModel.RemoveCourse(0);
            Assert.IsTrue(isMethodCalled);
        }

        [TestMethod()]
        public void UpdateSelectedCourseInfosTest()
        {
            model.SelectCourses(0, new List<int> { 3, 4, 5 });
            model.SelectCourses(1, new List<int> { 7 });

            Assert.AreEqual(4, viewModel.SelectedCourseInfos.Count);
            Assert.AreEqual(model.GetCourseInfo(0, 3), viewModel.SelectedCourseInfos[0]);
            Assert.AreEqual(model.GetCourseInfo(0, 4), viewModel.SelectedCourseInfos[1]);
            Assert.AreEqual(model.GetCourseInfo(0, 5), viewModel.SelectedCourseInfos[2]);
            Assert.AreEqual(model.GetCourseInfo(1, 7), viewModel.SelectedCourseInfos[3]);
        }

        [TestMethod()]
        public void RemoveCourseTest()
        {
            model.SelectCourses(0, new List<int> { 3, 4, 5 });
            model.SelectCourses(1, new List<int> { 7 });
            viewModel.RemoveCourse(2);
            viewModel.RemoveCourse(1);

            Assert.AreEqual(2, viewModel.SelectedCourseInfos.Count);
            Assert.AreEqual(model.GetCourseInfo(0, 3), viewModel.SelectedCourseInfos[0]);
            Assert.AreEqual(model.GetCourseInfo(1, 7), viewModel.SelectedCourseInfos[1]);
        }
    }
}