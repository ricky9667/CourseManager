using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourseManager.Tests
{
    [TestClass()]
    public class ImportCourseProgressFormViewModelTests
    {
        Model model;
        ImportCourseProgressFormViewModel viewModel;

        // unit test case setup
        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            viewModel = new ImportCourseProgressFormViewModel(model);
        }

        // test load tab indexes property
        [TestMethod()]
        public void GetComputerScienceTabIndexesTest()
        {
            List<int> expectedIndexes = new List<int> { 2, 3, 0, 4, 5 };
            Assert.AreEqual(expectedIndexes.Count, viewModel.ComputerScienceTabIndexes.Count);
        }

        // test load tab page courses
        [TestMethod()]
        public void LoadTabPageCoursesTest()
        {
            Assert.IsFalse(model.CourseTabPageInfos[3].Loaded);
            viewModel.LoadTabPageCourses(3);
            Assert.IsTrue(model.CourseTabPageInfos[3].Loaded);
        }

        // test generate progress label text
        [TestMethod()]
        public void GenerateProgressLabelTextTest()
        {
            double percentage = 33.33;
            Assert.AreEqual("正在匯入課程... " + percentage + "%", viewModel.GenerateProgressLabelText(percentage));
        }
    }
}