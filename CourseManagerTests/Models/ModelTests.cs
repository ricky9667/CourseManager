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
        CourseInfo windowsProgrammingCourseInfo = new CourseInfo("291710", "視窗程式設計", "1", "3.0", "3", "★", "陳偉凱", "", "", "", "", "3 4 6", "", "", "二教206(e) 二教205(e)", "43", "15", "", "", "", "查詢", "", "");
        CourseInfo databaseSystemsCourseInfo = new CourseInfo("291705", "資料庫系統", "1", "3.0", "3", "▲", "劉建宏", "", "", "7", "8 9", "", "", "", "六教327(e)", "100", "0", "", "", "", "查詢", "", "");
        CourseInfo artificialIntelligenceCourseInfo = new CourseInfo("294738", "人工智慧", "1", "3.0", "3", "▲", "黃育賢 賴冠廷 賴建宏", "", "", "", "2 3 4", "", "", "", "六教325(e)", "58", "1", "", "", "電子三、四甲乙合開", "查詢 查詢 查詢", "", "");
        
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
        }

        [TestCleanup]
        public void Teardown()
        {

        }

        [TestMethod()]
        public void ModelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            //Assert.Fail();
            //Not sure how to test
        }

        [TestMethod()]
        public void GetCourseInfoTest()
        {
            CourseInfo testCourseInfo = model.GetCourseInfo(0, 9);
            Assert.AreEqual(windowsProgrammingCourseInfo.Number, testCourseInfo.Number);
            Assert.AreEqual(windowsProgrammingCourseInfo.Name, testCourseInfo.Name);
            //Assert.IsTrue(testCourseInfo.CheckPropertiesIdentical(windowsProgrammingCourseInfo, new int[]{ 16, 17, 18, 19, 20, 21, 22 }));
        }

        [TestMethod()]
        public void SetCourseInfoTest()
        {
            List<CourseInfo> courseInfo = model.GetCourseInfos(0);
            model.SetCourseInfo(0, 0, windowsProgrammingCourseInfo);
            Assert.AreEqual(windowsProgrammingCourseInfo.Number, model.GetCourseInfo(0, 0).Number);
            Assert.AreEqual(windowsProgrammingCourseInfo.Name, model.GetCourseInfo(0, 0).Name);

            //Assert.ThrowsException()
        }

        [TestMethod()]
        public void AddNewCourseInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCourseInfosTest()
        {
            List<CourseInfo> courseInfos = model.GetCourseInfos(0);
            Assert.AreEqual(12, courseInfos.Count);
            Assert.AreEqual("班週會及導師時間", courseInfos[0].Name);
        }

        [TestMethod()]
        public void GetShowingIndexesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSelectedIndexPairsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectCoursesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DiscardCourseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckSameNumbersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckSameNamesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckConflictTimesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCourseManagementListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveCourseInfoTest()
        {
            Assert.Fail();
        }
    }
}