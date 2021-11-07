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
    public class ModelTests
    {
        Model model;
        CourseInfo windowsProgrammingCourseInfo = new CourseInfo("291710", "視窗程式設計", "1", "3.0", "3", "★", "陳偉凱", "", "", "", "", "3 4 6", "", "", "二教206(e)\n二教205(e)", "43", "15", "", "", "", "查詢", "", "");
        CourseInfo databaseSystemsCourseInfo = new CourseInfo("291705", "資料庫系統", "1", "3.0", "3", "▲", "劉建宏", "", "", "7", "8 9", "", "", "", "六教327(e)", "100", "0", "", "", "", "查詢", "", "");
        CourseInfo artificialIntelligenceCourseInfo = new CourseInfo("294738", "人工智慧", "1", "3.0", "3", "▲", "黃育賢\n賴冠廷\n賴建宏", "", "", "", "2 3 4", "", "", "", "六教325(e)", "58", "1", "", "", "電子三、四甲乙合開", "查詢\n查詢\n查詢", "", "");
        
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
        }

        [TestMethod()]
        public void GetCourseInfoTest()
        {
            CourseInfo testCourseInfo = model.GetCourseInfo(0, 9);
            Assert.IsTrue(testCourseInfo.CheckPropertiesIdentical(windowsProgrammingCourseInfo, new int[]{ 16, 17, 18, 19, 20, 21, 22 }));
        }

        [TestMethod()]
        public void SetCourseInfoTest()
        {
            model.ManuallyLoadAllCourses();
            model.SetCourseInfo(0, 0, windowsProgrammingCourseInfo);
            Assert.IsTrue(windowsProgrammingCourseInfo.CheckPropertiesIdentical(model.GetCourseInfo(0, 0), new int[] { 16, 17, 18, 19, 20, 21, 22 }));
        }

        [TestMethod()]
        public void AddNewCourseInfoTest()
        {
            const int tabIndex = 0;
            model.ManuallyLoadAllCourses();

            int courseCountOld = model.GetCourseInfos(tabIndex).Count;
            model.AddNewCourseInfo(0, artificialIntelligenceCourseInfo);
            Assert.AreEqual(courseCountOld + 1, model.GetCourseInfos(tabIndex).Count);

            List<CourseInfo> courseInfos = model.GetCourseInfos(tabIndex);
            int courseIndex = courseInfos.Count - 1;
            Assert.IsTrue(courseInfos[courseIndex].CheckPropertiesIdentical(artificialIntelligenceCourseInfo, new int[] { }));
            Assert.IsFalse(model.CheckCourseSelected(tabIndex, courseIndex));
        }

        [TestMethod()]
        public void CheckCourseSelectedTest()
        {
            Assert.IsFalse(model.CheckCourseSelected(0, 0));
            Assert.IsFalse(model.CheckCourseSelected(1, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.CheckCourseSelected(0, 20));
        }

        [TestMethod()]
        public void GetCourseInfosTest()
        {
            //Assert.IsFalse(model.CheckTabExists(0));
            List<CourseInfo> courseInfos = model.GetCourseInfos(0);

            //Assert.IsTrue(model.CheckTabExists(0));
            Assert.AreEqual(12, courseInfos.Count);
            Assert.AreEqual("班週會及導師時間", courseInfos[0].Name);
        }

        [TestMethod()]
        public void GetShowingIndexesTest()
        {
            const int tabIndex = 0;
            List<int> showingIndexes = model.GetShowingIndexes(tabIndex);
            Assert.AreEqual(model.GetCourseInfos(tabIndex).Count, showingIndexes.Count);

            List<int> selectedIndexes = new List<int>() { 3, 5 };
            int selectedIndexesCount = selectedIndexes.Count;
            model.SelectCourses(0, selectedIndexes);
            showingIndexes = model.GetShowingIndexes(tabIndex);
            Assert.IsFalse(showingIndexes.Exists(item => item == 3));
            Assert.IsFalse(showingIndexes.Exists(item => item == 5));
        }

        [TestMethod()]
        public void SelectCoursesTest()
        {
            Assert.AreEqual(0, model.SelectedIndexPairs.Count);
            List<int> selectedIndexes = new List<int>() { 3, 5 };
            int selectedIndexesCount = selectedIndexes.Count;

            model.SelectCourses(0, selectedIndexes);
            Assert.AreEqual(selectedIndexesCount, model.SelectedIndexPairs.Count);
            Assert.AreEqual(Tuple.Create(0, 3), model.SelectedIndexPairs[0]);
            Assert.IsTrue(model.CheckCourseSelected(0, 3));
            Assert.AreEqual(Tuple.Create(0, 5), model.SelectedIndexPairs[1]);
            Assert.IsTrue(model.CheckCourseSelected(0, 5));
        }

        [TestMethod()]
        public void DiscardCourseTest()
        {
            Assert.AreEqual(0, model.SelectedIndexPairs.Count);
            List<int> selectedIndexes = new List<int>() { 3, 5, 7 };

            model.SelectCourses(0, selectedIndexes);
            Assert.IsTrue(model.CheckCourseSelected(0, 7));

            model.DiscardCourse(2);
            Assert.IsFalse(model.CheckCourseSelected(0, 7));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.DiscardCourse(6));
        }

        [TestMethod()]
        public void CheckSameNumbersTest()
        {
            model.ManuallyLoadAllCourses();
            model.SelectCourses(0, new List<int> { 3, 4, 5 });
            string message = model.CheckSameNumbers(1, new List<int> { 5, 6 });
            Assert.AreEqual("", message);

            message = model.CheckSameNumbers(0, new List<int> { 3, 4 });
            CourseInfo courseInfo1 = model.GetCourseInfo(0, 3);
            CourseInfo courseInfo2 = model.GetCourseInfo(0, 4);
            string expectedMessage = courseInfo1.GetCompareSameNumberMessage(courseInfo1) + courseInfo2.GetCompareSameNumberMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod()]
        public void CheckSameNamesTest()
        {
            model.ManuallyLoadAllCourses();
            model.SelectCourses(0, new List<int> { 3, 4 });
            string message = model.CheckSameNames(0, new List<int> { 7, 9 });
            Assert.AreEqual("", message);

            message = model.CheckSameNames(0, new List<int> { 2, 6 });
            CourseInfo courseInfo1 = model.GetCourseInfo(0, 2);
            string expectedMessage = courseInfo1.GetCompareSameNameMessage(courseInfo1);
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod()]
        public void CheckConflictTimesTest()
        {
            model.ManuallyLoadAllCourses();
            model.SelectCourses(0, new List<int> { 3, 4 });
            string message = model.CheckSameNames(0, new List<int> { 7, 9 });
            Assert.AreEqual("", message); // 23

            message = model.CheckConflictTimes(1, new List<int> { 23 });
            CourseInfo courseInfo1 = model.GetCourseInfo(1, 23);
            CourseInfo courseInfo2 = model.GetCourseInfo(0, 4);
            string expectedMessage = courseInfo1.GetCompareClassTimeMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);

            message = model.CheckConflictTimes(1, new List<int> { 11, 16 });
            courseInfo1 = model.GetCourseInfo(1, 11);
            courseInfo2 = model.GetCourseInfo(1, 16);
            expectedMessage = courseInfo1.GetBothCompareClassTimeMessage(courseInfo2);
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod()]
        public void GetCourseManagementListTest()
        {
            model.ManuallyLoadAllCourses();
            List<Tuple<int, int, string>> courseList = model.GetCourseManagementList();
            int tabCount = model.CourseTabPageInfos.Count;
            int courseCount = 0;
            for (int i = 0; i < tabCount; i++)
            {
                courseCount += model.GetCourseInfos(i).Count;
            }
            Assert.AreEqual(courseCount, courseList.Count);
        }

        [TestMethod()]
        public void MoveCourseInfoTest()
        {
            model.ManuallyLoadAllCourses();
            CourseInfo courseInfo = model.GetCourseInfo(0, 3);

            model.MoveCourseInfo(0, 3, 1);
            List<CourseInfo> courseInfos = model.GetCourseInfos(1);
            int courseIndex = courseInfos.Count - 1;
            Assert.IsTrue(courseInfos[courseIndex].CheckPropertiesIdentical(courseInfo, new int[] { }));
            Assert.IsFalse(model.CheckCourseSelected(1, courseIndex));

            model.SelectCourses(1, new List<int>{ courseIndex - 2, courseIndex - 1, courseIndex });
            model.MoveCourseInfo(1, courseIndex - 2, 0);
            List<CourseInfo> newCourseInfos = model.GetCourseInfos(0);
            int newCourseIndex = newCourseInfos.Count - 1;
            Assert.IsTrue(model.CheckCourseSelected(0, newCourseIndex));
            Assert.IsTrue(model.CheckCourseSelected(1, courseIndex - 2));
            Assert.IsTrue(model.CheckCourseSelected(1, courseIndex - 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.CheckCourseSelected(1, courseIndex));
        }
    }
}