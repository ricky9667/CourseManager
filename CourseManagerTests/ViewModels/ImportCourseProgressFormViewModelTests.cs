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
    public class ImportCourseProgressFormViewModelTests
    {
        Model model;
        ImportCourseProgressFormViewModel viewModel;

        // unit test case setup
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new ImportCourseProgressFormViewModel(model);
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