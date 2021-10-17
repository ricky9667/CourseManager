using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class Model
    {
        private List<CourseTabPageInfo> _courseTabPageInfos;
        private Dictionary<int, List<CourseInfo>> _courseInfosDictionary;
        private Dictionary<int, List<bool>> _isCourseSelected;
        private List<Tuple<int, int>> _selectedIndexPairs; // tabIndex, courseIndex
        private CourseCrawler _courseCrawler;
        public Model()
        {
            string[] tabNames = new string[] { "computerScience3TabPage", "electronicEngineering3ATabPage" };
            string[] tabTexts = new string[] { "資工三", "電子三甲" };
            string[] tabLinks = new string[] { "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423" };

            _courseTabPageInfos = new List<CourseTabPageInfo>
            {
                new CourseTabPageInfo(tabNames[0], tabTexts[0], tabLinks[0]),
                new CourseTabPageInfo(tabNames[1], tabTexts[1], tabLinks[1]),
            };

            _courseInfosDictionary = new Dictionary<int, List<CourseInfo>>();
            _isCourseSelected = new Dictionary<int, List<bool>>();
            _selectedIndexPairs = new List<Tuple<int, int>>();
            _courseCrawler = new CourseCrawler();
        }

        // get tab page infos
        public List<CourseTabPageInfo> GetCourseTabPageInfos()
        {
            return _courseTabPageInfos;
        }

        // get single course info
        public CourseInfo GetCourseInfo(int tabIndex, int courseIndex)
        {
            return _courseInfosDictionary[tabIndex][courseIndex];
        }

        // get course infos from selected tab
        public List<CourseInfo> GetCourseInfos(int tabIndex)
        {
            if (!_courseInfosDictionary.ContainsKey(tabIndex))
            {
                LoadCourses(tabIndex);
            }
            return _courseInfosDictionary[tabIndex];
        }

        // get count of specific course list
        public int GetCourseCount(int tabIndex)
        {
            if (!_courseInfosDictionary.ContainsKey(tabIndex))
            {
                LoadCourses(tabIndex);
            }
            return _courseInfosDictionary[tabIndex].Count;
        }

        // fetch course data from crawler
        private void LoadCourses(int tabIndex)
        {
            List<CourseInfo> courseInfos = _courseCrawler.FetchCourseInfos(_courseTabPageInfos[tabIndex].CourseLink);
            List<bool> selectedCourses = new List<bool>();

            int courseCount = courseInfos.Count;
            while (courseCount-- > 0)
            {
                selectedCourses.Add(false);
            }

            _courseInfosDictionary.Add(tabIndex, courseInfos);
            _isCourseSelected.Add(tabIndex, selectedCourses);
        }

        // get showing indexes of current datagridview
        public List<int> GetShowingIndexes(int tabIndex)
        {
            List<int> showingList = new List<int>();
            int count = _courseInfosDictionary[tabIndex].Count;
            for (int courseIndex = 0; courseIndex < count; courseIndex++)
            {
                if (!_isCourseSelected[tabIndex][courseIndex])
                {
                    showingList.Add(courseIndex);
                }
            }
            return showingList;
        }

        // get selected courses index pairs
        public List<Tuple<int, int>> GetSelectedIndexPairs()
        {
            return _selectedIndexPairs;
        }

        // add checked courses to selected courses
        public void SelectCourses(int tabIndex, List<int> selectedIndexes)
        {
            int tabCount = _courseInfosDictionary[tabIndex].Count;
            for (int courseIndex = 0; courseIndex < tabCount; courseIndex++)
            {
                if (selectedIndexes.Count > 0 && courseIndex == selectedIndexes[0])
                {
                    _selectedIndexPairs.Add(new Tuple<int, int>(tabIndex, courseIndex));
                    _isCourseSelected[tabIndex][courseIndex] = true;
                    selectedIndexes.RemoveAt(0);
                }
            }
        }

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            int tabIndex = _selectedIndexPairs[index].Item1;
            int courseIndex = _selectedIndexPairs[index].Item2;

            _isCourseSelected[tabIndex][courseIndex] = false;
            _selectedIndexPairs.RemoveAt(index);
        }

        // check same course numbers
        public string CheckSameNumbers(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            foreach (int courseIndex in courseIndexes)
            {
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareSameNumberMessage(selectedCourseInfo);
                }
            }
            
            return message;
        }

        // check same course names
        public string CheckSameNames(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            foreach (int courseIndex in courseIndexes)
            {
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareSameNameMessage(selectedCourseInfo);
                }
            }
            return message;
        }

        // check conflict course times
        public string CheckConflictTimes(int tabIndex, List<int> courseIndexes)
        {
            string message = CheckOwnConflictTime(tabIndex, courseIndexes);
            foreach (int courseIndex in courseIndexes)
            { 
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareClassTimeMessage(selectedCourseInfo);
                }
            }
            return message;
        }

        // check if courses conflict each other
        private string CheckOwnConflictTime(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            int count = courseIndexes.Count;
            for (int i = 0; i < count; i++)
            {
                CourseInfo firstCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[i]];
                for (int j = i + 1; j < count; j++)
                {
                    CourseInfo secondCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[j]];
                    message += firstCourseInfo.GetBothCompareClassTimeMessage(secondCourseInfo);
                }
            }
            return message;
        }
    }
}
