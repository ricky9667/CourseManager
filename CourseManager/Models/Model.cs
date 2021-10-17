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
            _courseTabPageInfos = new List<CourseTabPageInfo>
            {
                new CourseTabPageInfo("computerScience3TabPage", "資工三", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433"),
                new CourseTabPageInfo("electronicEngineering3ATabPage", "電子三甲", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423")
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
            List<bool> seletedCourses = new List<bool>();

            int courseCount = courseInfos.Count;
            while (courseCount-- > 0)
            {
                seletedCourses.Add(false);
            }

            _courseInfosDictionary.Add(tabIndex, courseInfos);
            _isCourseSelected.Add(tabIndex, seletedCourses);
        }

        // get is selected courses bool list
        public List<bool> GetIsSelectedList(int tabIndex)
        {
            return _isCourseSelected[tabIndex];
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

        // check same course number
        public string CheckSameNumber(int tabIndex, int courseIndex)
        {
            string message = "";

            CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
            foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
            {
                CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                if (selectedCourseInfo.Number == courseInfo.Number)
                {
                    message += "「" + courseInfo.Number + " " + courseInfo.Name + "」";
                }
            }

            return message;
        }

        // check same course name
        public string CheckSameName(int tabIndex, int courseIndex)
        {
            string message = "";

            CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
            foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
            {
                CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                if (selectedCourseInfo.Name == courseInfo.Name)
                {
                    message += "「" + courseInfo.Number + " " + courseInfo.Name + "」";
                }
            }

            return message;
        }

        // check conflict courses
        public string CheckConflictTime(int tabIndex, int courseIndex)
        {
            string message = "";

            CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
            foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
            {
                CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                if (courseInfo.HasConflictClassTime(selectedCourseInfo))
                {
                    message += "「" + courseInfo.Number + " " + courseInfo.Name + "」";
                }
            }

            return message;
        }

        // check if courses conflict each other
        public string CheckOwnConflictTime(int tabIndex, List<int> courseIndexes)
        {
            string message = "";

            int count = courseIndexes.Count;
            for (int i = 0; i < count; i++)
            {
                CourseInfo firstCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[i]];
                for (int j = i + 1; j < count; j++)
                {
                    CourseInfo secondCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[j]];
                    if (firstCourseInfo.HasConflictClassTime(secondCourseInfo))
                    {
                        message += ("「" + firstCourseInfo.Number + " " + firstCourseInfo.Name + "」");
                        message += ("「" + secondCourseInfo.Number + " " + secondCourseInfo.Name + "」");
                    }
                }
            }

            return message;
        }
    }
}
