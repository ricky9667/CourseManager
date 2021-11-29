using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CourseManager.Tests
{
    [TestClass()]
    public class CourseManagementFormViewModelTests
    {
        Model model;
        CourseManagementFormViewModel viewModel;
        readonly int computerScience3TabIndex = 0;
        readonly int electronicEngineering3ATabIndex = 1;

        // unit test case setup
        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            viewModel = new CourseManagementFormViewModel(model);
        }

        // test constructor
        [TestMethod()]
        public void CourseManagementFormViewModelTest()
        {
            Assert.IsFalse(viewModel.CourseGroupBoxEnabled);
            Assert.IsTrue(viewModel.AddCourseButtonEnabled);
            Assert.IsFalse(viewModel.SaveButtonEnabled);
            Assert.IsTrue(viewModel.ImportCourseButtonEnabled);
            Assert.AreEqual(-1, viewModel.CurrentSelectedCourse);

            Assert.IsTrue(viewModel.AddClassButtonEnabled);
            Assert.IsFalse(viewModel.AddButtonEnabled);
            Assert.IsFalse(viewModel.ClassNameTextBoxEnabled);
        }

        // test model property
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, viewModel.Model);
        }

        // test current tab index
        [TestMethod()]
        public void GetCourseManagementListTest()
        {
            Assert.AreEqual(model.GetCourseManagementList().Count, viewModel.CourseManagementList.Count);
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

            viewModel.UpdateCourseManagementList();
            Assert.IsTrue(isMethodCalled);
        }

        // test controls enabled property
        [TestMethod()]
        public void ControlsEnabledTest()
        {
            viewModel.CourseGroupBoxEnabled = true;
            Assert.IsTrue(viewModel.CourseGroupBoxEnabled);
            viewModel.AddCourseButtonEnabled = false;
            Assert.IsFalse(viewModel.AddCourseButtonEnabled);
            viewModel.SaveButtonEnabled = true;
            Assert.IsTrue(viewModel.SaveButtonEnabled);
            viewModel.ImportCourseButtonEnabled = false;
            Assert.IsFalse(viewModel.ImportCourseButtonEnabled);

            viewModel.AddClassButtonEnabled = false;
            Assert.IsFalse(viewModel.AddClassButtonEnabled);
            viewModel.AddButtonEnabled = true;
            Assert.IsTrue(viewModel.AddButtonEnabled);
            viewModel.ClassNameTextBoxEnabled = true;
            Assert.IsTrue(viewModel.ClassNameTextBoxEnabled);
        }

        // test get course info
        [TestMethod()]
        public void GetCourseInfoTest()
        {
            Assert.AreEqual(model.GetCourseInfo(computerScience3TabIndex, 0), viewModel.GetCourseInfo(computerScience3TabIndex, 0));
            Assert.AreEqual(model.GetCourseInfo(electronicEngineering3ATabIndex, 10), viewModel.GetCourseInfo(electronicEngineering3ATabIndex, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => viewModel.GetCourseInfo(computerScience3TabIndex, 22));
        }

        // test current selected course property
        [TestMethod()]
        public void CurrentSelectedCourseTest()
        {
            viewModel.CurrentSelectedCourse = 10;
            Assert.AreEqual(10, viewModel.CurrentSelectedCourse);
        }

        // test update course info
        [TestMethod()]
        public void UpdateCourseInfoTest()
        {
            viewModel.CurrentSelectedCourse = 4;
            CourseInfo courseInfo = viewModel.GetCourseInfo(computerScience3TabIndex, 4);
            courseInfo.Name = "ChangedCourseName";
            viewModel.UpdateCourseInfo(courseInfo, computerScience3TabIndex, 0);
            Assert.AreEqual(courseInfo, viewModel.GetCourseInfo(computerScience3TabIndex, 4));

            viewModel.UpdateCourseInfo(courseInfo, electronicEngineering3ATabIndex, 0);
            Assert.AreEqual(courseInfo, viewModel.GetCourseInfo(electronicEngineering3ATabIndex, model.GetCourseInfos(electronicEngineering3ATabIndex).Count - 1));
        }

        // test add new course
        [TestMethod()]
        public void AddNewCourseTest()
        {
            CourseInfo testCourseInfo = new CourseInfo("123456", "TestCourse", "1", "3.0", "3", "★", "胡紹宇", "", "1", "2", "3", "", "", "", "二教206(e)", "43", "15", "", "", "", "查詢", "", "");
            viewModel.AddNewCourse(testCourseInfo, computerScience3TabIndex, 0);
            Assert.AreEqual(testCourseInfo, viewModel.GetCourseInfo(computerScience3TabIndex, model.GetCourseInfos(computerScience3TabIndex).Count - 1));
        }

        // test check save button state
        [TestMethod()]
        public void CheckSaveButtonStateByCourseDataTest()
        {
            CourseInfo testCourseInfo = new CourseInfo("123456", "TestCourse", "1", "3.0", "3", "★", "胡紹宇", "", "1", "2", "3", "", "", "", "二教206(e)", "43", "15", "", "", "", "查詢", "", "");
            Assert.IsTrue(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, computerScience3TabIndex, 0));

            testCourseInfo.Name = "";
            testCourseInfo.Stage = "NotNumeric";
            Assert.IsFalse(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, computerScience3TabIndex, 0));

            viewModel.CurrentSelectedCourse = 4;
            testCourseInfo = viewModel.GetCourseInfo(computerScience3TabIndex, 4).GetCopy();
            testCourseInfo.Name = "ChangedCourseName";
            Assert.IsTrue(viewModel.CheckSaveButtonStateByCourseData(testCourseInfo, computerScience3TabIndex, 0));
        }

        // test add new class
        [TestMethod()]
        public void AddNewClassTest()
        {
            int oldCount = model.CourseTabPageInfos.Count;
            const string className = "newClass";
            viewModel.AddNewClass(className);

            Assert.AreEqual(oldCount + 1, model.CourseTabPageInfos.Count);
            int lastIndex = model.CourseTabPageInfos.Count - 1;
            Assert.AreEqual(className, model.CourseTabPageInfos[lastIndex].TabName);
            Assert.AreEqual(className, model.CourseTabPageInfos[lastIndex].TabText);
            Assert.IsTrue(model.CourseTabPageInfos[lastIndex].Loaded);
        }
    }
}