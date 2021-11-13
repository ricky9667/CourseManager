using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CourseManager.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;
        readonly CourseInfo windowsProgrammingCourseInfo = new CourseInfo("291710", "視窗程式設計", "1", "3.0", "3", "★", "陳偉凱", "", "", "", "", "3 4 6", "", "", "二教206(e)\n二教205(e)", "43", "15", "", "", "", "查詢", "", "");
        readonly CourseInfo databaseSystemsCourseInfo = new CourseInfo("291705", "資料庫系統", "1", "3.0", "3", "▲", "劉建宏", "", "", "7", "8 9", "", "", "", "六教327(e)", "100", "0", "", "", "", "查詢", "", "");
        readonly CourseInfo artificialIntelligenceCourseInfo = new CourseInfo("294738", "人工智慧", "1", "3.0", "3", "▲", "黃育賢\n賴冠廷\n賴建宏", "", "", "", "2 3 4", "", "", "", "六教325(e)", "58", "1", "", "", "電子三、四甲乙合開", "查詢\n查詢\n查詢", "", "");
        readonly int computerScience3TabIndex = 0;
        readonly int electronicEngineering3ATabIndex = 1;
        // unit test case setup
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
        }

        // test constructor
        [TestMethod()]
        public void GetCourseInfoTest()
        {
            CourseInfo testCourseInfo = model.GetCourseInfo(computerScience3TabIndex, 9);
            Assert.IsTrue(testCourseInfo.CheckPropertiesIdentical(windowsProgrammingCourseInfo, new int[]{ 16, 17, 18, 19, 20, 21, 22 }));
        }

        // test notify observer
        [TestMethod()]
        public void NotifyObserverTest()
        {
            bool isMethodCalled = false;
            model._modelChanged += () =>
            {
                isMethodCalled = true;
            };

            model.AddNewCourseInfo(1, databaseSystemsCourseInfo);
            Assert.IsTrue(isMethodCalled);
        }

        // test set course info
        [TestMethod()]
        public void SetCourseInfoTest()
        {
            model.LoadAllTabCourses();
            int courseIndex = 0;
            model.SetCourseInfo(computerScience3TabIndex, courseIndex, windowsProgrammingCourseInfo);
            Assert.IsTrue(windowsProgrammingCourseInfo.CheckPropertiesIdentical(model.GetCourseInfo(computerScience3TabIndex, courseIndex), new int[] { 16, 17, 18, 19, 20, 21, 22 }));
        }

        // test add new course info
        [TestMethod()]
        public void AddNewCourseInfoTest()
        {
            model.LoadAllTabCourses();

            int courseCountOld = model.GetCourseInfos(computerScience3TabIndex).Count;
            model.AddNewCourseInfo(computerScience3TabIndex, artificialIntelligenceCourseInfo);
            Assert.AreEqual(courseCountOld + 1, model.GetCourseInfos(computerScience3TabIndex).Count);

            List<CourseInfo> courseInfos = model.GetCourseInfos(computerScience3TabIndex);
            int courseIndex = courseInfos.Count - 1;
            Assert.IsTrue(courseInfos[courseIndex].CheckPropertiesIdentical(artificialIntelligenceCourseInfo, new int[] { }));
            Assert.IsFalse(model.CheckCourseSelected(computerScience3TabIndex, courseIndex));
        }

        //  test check course selected
        [TestMethod()]
        public void CheckCourseSelectedTest()
        {
            Assert.IsFalse(model.CheckCourseSelected(computerScience3TabIndex, 0));
            Assert.IsFalse(model.CheckCourseSelected(electronicEngineering3ATabIndex, 20));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.CheckCourseSelected(computerScience3TabIndex, 20));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.CheckCourseSelected(electronicEngineering3ATabIndex, 40));
        }

        // test get course infos
        [TestMethod()]
        public void GetCourseInfosTest()
        {
            List<CourseInfo> courseInfos = model.GetCourseInfos(computerScience3TabIndex);

            Assert.AreEqual(12, courseInfos.Count);
            Assert.IsTrue(model.GetCourseInfo(computerScience3TabIndex, 0).CheckPropertiesIdentical(courseInfos[0], new int[] { }));
            Assert.IsTrue(model.GetCourseInfo(computerScience3TabIndex, 4).CheckPropertiesIdentical(courseInfos[4], new int[] { }));
            Assert.IsTrue(model.GetCourseInfo(computerScience3TabIndex, 8).CheckPropertiesIdentical(courseInfos[8], new int[] { }));
        }

        // test get showing indexes
        [TestMethod()]
        public void GetShowingIndexesTest()
        {
            List<int> showingIndexes = model.GetShowingIndexes(computerScience3TabIndex);
            Assert.AreEqual(model.GetCourseInfos(computerScience3TabIndex).Count, showingIndexes.Count);

            List<int> selectedIndexes = new List<int>() { 3, 5 };
            int selectedIndexesCount = selectedIndexes.Count;
            model.SelectCourses(computerScience3TabIndex, selectedIndexes);
            showingIndexes = model.GetShowingIndexes(computerScience3TabIndex);
            Assert.IsFalse(showingIndexes.Exists(item => item == 3));
            Assert.IsFalse(showingIndexes.Exists(item => item == 5));
        }

        // test select courses
        [TestMethod()]
        public void SelectCoursesTest()
        {
            Assert.AreEqual(0, model.SelectedIndexPairs.Count);
            List<int> selectedIndexes = new List<int>() { 3, 5 };
            int selectedIndexesCount = selectedIndexes.Count;

            model.SelectCourses(computerScience3TabIndex, selectedIndexes);
            Assert.AreEqual(selectedIndexesCount, model.SelectedIndexPairs.Count);
            Assert.AreEqual(Tuple.Create(computerScience3TabIndex, 3), model.SelectedIndexPairs[0]);
            Assert.IsTrue(model.CheckCourseSelected(computerScience3TabIndex, 3));
            Assert.AreEqual(Tuple.Create(computerScience3TabIndex, 5), model.SelectedIndexPairs[1]);
            Assert.IsTrue(model.CheckCourseSelected(computerScience3TabIndex, 5));
        }

        // test discard course
        [TestMethod()]
        public void DiscardCourseTest()
        {
            Assert.AreEqual(0, model.SelectedIndexPairs.Count);
            List<int> selectedIndexes = new List<int>() { 3, 5, 7 };

            model.SelectCourses(computerScience3TabIndex, selectedIndexes);
            Assert.IsTrue(model.CheckCourseSelected(computerScience3TabIndex, 7));

            model.DiscardCourse(2);
            Assert.IsFalse(model.CheckCourseSelected(computerScience3TabIndex, 7));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.DiscardCourse(6));
        }

        // test check same numbers
        [TestMethod()]
        public void CheckSameNumbersTest()
        {
            model.LoadAllTabCourses();
            model.SelectCourses(computerScience3TabIndex, new List<int> { 3, 4, 5 });
            string message = model.CheckSameNumbers(1, new List<int> { 5, 6 });
            Assert.AreEqual("", message);

            message = model.CheckSameNumbers(computerScience3TabIndex, new List<int> { 3, 4 });
            CourseInfo courseInfo1 = model.GetCourseInfo(computerScience3TabIndex, 3);
            CourseInfo courseInfo2 = model.GetCourseInfo(computerScience3TabIndex, 4);
            string expectedMessage = courseInfo1.GetCompareSameNumberMessage(courseInfo1) + courseInfo2.GetCompareSameNumberMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);
        }

        // test check same names
        [TestMethod()]
        public void CheckSameNamesTest()
        {
            model.LoadAllTabCourses();
            model.SelectCourses(computerScience3TabIndex, new List<int> { 3, 4 });
            string message = model.CheckSameNames(computerScience3TabIndex, new List<int> { 7, 9 });
            Assert.AreEqual("", message);

            message = model.CheckSameNames(computerScience3TabIndex, new List<int> { 2, 6 });
            CourseInfo courseInfo1 = model.GetCourseInfo(computerScience3TabIndex, 2);
            string expectedMessage = courseInfo1.GetCompareSameNameMessage(courseInfo1);
            Assert.AreEqual(expectedMessage, message);
        }

        // test check conflict times
        [TestMethod()]
        public void CheckConflictTimesTest()
        {
            model.LoadAllTabCourses();
            model.SelectCourses(computerScience3TabIndex, new List<int> { 3, 4 });
            string message = model.CheckSameNames(computerScience3TabIndex, new List<int> { 7, 9 });
            Assert.AreEqual("", message); // 23

            message = model.CheckConflictTimes(electronicEngineering3ATabIndex, new List<int> { 23 });
            CourseInfo courseInfo1 = model.GetCourseInfo(electronicEngineering3ATabIndex, 23);
            CourseInfo courseInfo2 = model.GetCourseInfo(computerScience3TabIndex, 4);
            string expectedMessage = courseInfo1.GetCompareClassTimeMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);

            message = model.CheckConflictTimes(electronicEngineering3ATabIndex, new List<int> { 11, 16 });
            courseInfo1 = model.GetCourseInfo(electronicEngineering3ATabIndex, 11);
            courseInfo2 = model.GetCourseInfo(electronicEngineering3ATabIndex, 16);
            expectedMessage = courseInfo1.GetBothCompareClassTimeMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);
        }

        // test get course management list
        [TestMethod()]
        public void GetCourseManagementListTest()
        {
            model.LoadAllTabCourses();
            List<Tuple<int, int, string>> courseList = model.GetCourseManagementList();
            int tabCount = model.CourseTabPageInfos.Count;
            int courseCount = 0;
            for (int i = 0; i < tabCount; i++)
            {
                courseCount += model.GetCourseInfos(i).Count;
            }
            Assert.AreEqual(courseCount, courseList.Count);
        }

        // test move course info
        [TestMethod()]
        public void MoveCourseInfoTest()
        {
            model.LoadAllTabCourses();
            CourseInfo courseInfo = model.GetCourseInfo(computerScience3TabIndex, 3);

            model.MoveCourseInfo(computerScience3TabIndex, 3, 1);
            List<CourseInfo> courseInfos = model.GetCourseInfos(1);
            int courseIndex = courseInfos.Count - 1;
            Assert.IsTrue(courseInfos[courseIndex].CheckPropertiesIdentical(courseInfo, new int[] { }));
            Assert.IsFalse(model.CheckCourseSelected(electronicEngineering3ATabIndex, courseIndex));

            model.SelectCourses(1, new List<int>{ courseIndex - 2, courseIndex - 1, courseIndex });
            model.MoveCourseInfo(1, courseIndex - 2, computerScience3TabIndex);
            List<CourseInfo> newCourseInfos = model.GetCourseInfos(computerScience3TabIndex);
            int newCourseIndex = newCourseInfos.Count - 1;
            Assert.IsTrue(model.CheckCourseSelected(computerScience3TabIndex, newCourseIndex));
            Assert.IsTrue(model.CheckCourseSelected(electronicEngineering3ATabIndex, courseIndex - 2));
            Assert.IsTrue(model.CheckCourseSelected(electronicEngineering3ATabIndex, courseIndex - 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.CheckCourseSelected(1, courseIndex));
        }
    }
}