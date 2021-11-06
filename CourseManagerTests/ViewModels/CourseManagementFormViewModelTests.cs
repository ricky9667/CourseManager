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
    public class CourseManagementFormViewModelTests
    {
        Model model;
        CourseManagementFormViewModel viewModel;
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new CourseManagementFormViewModel(model);
        }

        [TestMethod()]
        public void CourseManagementFormViewModelTest()
        {
            Assert.IsFalse(viewModel.CourseGroupBoxEnabled);
            Assert.IsTrue(viewModel.AddCourseButtonEnabled);
            Assert.IsFalse(viewModel.SaveButtonEnabled);
            Assert.AreEqual(-1, viewModel.CurrentSelectedCourse);
        }

        [TestMethod()]
        public void ControlsEnabledTest()
        {
            viewModel.CourseGroupBoxEnabled = true;
            Assert.IsTrue(viewModel.CourseGroupBoxEnabled);
            viewModel.AddCourseButtonEnabled = false;
            Assert.IsFalse(viewModel.AddCourseButtonEnabled);
            viewModel.SaveButtonEnabled = true;
            Assert.IsTrue(viewModel.SaveButtonEnabled);
        }

        [TestMethod()]
        public void GetCourseInfoTest()
        {
            Assert.AreEqual(model.GetCourseInfo(0, 0), viewModel.GetCourseInfo(0, 0));
            Assert.AreEqual(model.GetCourseInfo(1, 10), viewModel.GetCourseInfo(1, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => viewModel.GetCourseInfo(0, 22));
        }

        [TestMethod()]
        public void CurrentSelectedCourseTest()
        {
            viewModel.CurrentSelectedCourse = 10;
            Assert.AreEqual(10, viewModel.CurrentSelectedCourse);
        }

        [TestMethod()]
        public void UpdateCourseInfoTest()
        {
            viewModel.CurrentSelectedCourse = 4;
            CourseInfo courseInfo = viewModel.GetCourseInfo(0, 4);
            courseInfo.Name = "ChangedCourseName";
            viewModel.UpdateCourseInfo(courseInfo, 0);
            Assert.AreEqual(courseInfo, viewModel.GetCourseInfo(0, 4));

            viewModel.UpdateCourseInfo(courseInfo, 1);
            Assert.AreEqual(courseInfo, viewModel.GetCourseInfo(1, model.GetCourseInfos(1).Count - 1));
        }

        [TestMethod()]
        public void AddNewCourseTest()
        {
            CourseInfo testCourseInfo = new CourseInfo("123456", "TestCourse", "1", "3.0", "3", "★", "胡紹宇", "", "1", "2", "3", "", "", "", "二教206(e)", "43", "15", "", "", "", "查詢", "", "");
            viewModel.AddNewCourse(testCourseInfo, 0);
            Assert.AreEqual(testCourseInfo, viewModel.GetCourseInfo(0, model.GetCourseInfos(0).Count - 1));
        }

        [TestMethod()]
        public void CheckSaveButtonStateByCourseDataTest()
        {
            CourseInfo testCourseInfo = new CourseInfo("123456", "TestCourse", "1", "3.0", "3", "★", "胡紹宇", "", "1", "2", "3", "", "", "", "二教206(e)", "43", "15", "", "", "", "查詢", "", "");
            Assert.IsTrue(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, 0));

            testCourseInfo.Name = "";
            testCourseInfo.Stage = "NotNumeric";
            Assert.IsFalse(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, 0));

            viewModel.CurrentSelectedCourse = 4;
            testCourseInfo = viewModel.GetCourseInfo(0, 4).Copy();
            testCourseInfo.Name = "ChangedCourseName";
            Assert.IsTrue(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, 0));
        }
    }
}