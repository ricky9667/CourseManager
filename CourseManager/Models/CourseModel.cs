using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseModel
    {
        private List<CourseTabPageInfo> _courseTabPageInfos;
        private Dictionary<int, List<CourseInfo>> _courseInfosDictionary;
        private Dictionary<int, List<bool>> _isCourseSelected;
        private List<Tuple<int, int>> _selectedIndexPairs; // tabIndex, courseIndex
        private CourseCrawler _courseCrawler;
        public CourseModel()
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

        // get course infos from selected tab
        public List<CourseInfo> GetCourseInfos(int tabIndex)
        {
            if (!_courseInfosDictionary.ContainsKey(tabIndex))
            {
                List<CourseInfo> courseInfos = _courseCrawler.FetchCourseInfos(_courseTabPageInfos[tabIndex].CourseLink);
                List<bool> seletedCourses = new List<bool>();

                _courseInfosDictionary.Add(tabIndex, courseInfos);

                int courseCount = courseInfos.Count;
                while (courseCount-- > 0)
                {
                    seletedCourses.Add(false);
                }
                _isCourseSelected.Add(tabIndex, seletedCourses);
            }

            return _courseInfosDictionary[tabIndex];
        }

        // get showing indexes of current datagridview
        public List<int> GetShowingList(int tabIndex)
        {
            int count = _courseInfosDictionary[tabIndex].Count;
            List<int> showingList = new List<int>();
            for (int courseIndex = 0; courseIndex < count; courseIndex++)
            {
                if (!_isCourseSelected[tabIndex][courseIndex])
                {
                    showingList.Add(courseIndex);
                }
            }
            return showingList;
        }

        // get selected course infos
        public List<CourseInfo> GetSelectedCourseInfos()
        {
            List<CourseInfo> selectedCourseInfos = new List<CourseInfo>();
            foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
            {
                int tabIndex = indexPair.Item1;
                int courseIndex = indexPair.Item2;
                selectedCourseInfos.Add(_courseInfosDictionary[tabIndex][courseIndex]);
            }

            return selectedCourseInfos;
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

        // check if courses are able to select and return message if not
        public string CheckSelectCoursesWithMessage(int tabIndex, List<int> courseIndexes)
        {
            string sameNumberMessage = "";
            string sameNameMessage = "";
            string conflictTimeMessage = "";

            conflictTimeMessage += CheckOwnConflictTime(tabIndex, courseIndexes);
            foreach (int courseIndex in courseIndexes)
            {
                sameNumberMessage += CheckSameNumber(tabIndex, courseIndex);
                sameNameMessage += CheckSameName(tabIndex, courseIndex);
                conflictTimeMessage += CheckConflictTime(tabIndex, courseIndex);
            }

            string finalMessage = "";
            finalMessage += (sameNumberMessage == "") ? "" : ("\n課號相同：" + sameNumberMessage);
            finalMessage += (sameNameMessage == "") ? "" : ("\n課程名稱相同：" + sameNameMessage);
            finalMessage += (conflictTimeMessage == "") ? "" : ("\n衝堂：" + conflictTimeMessage);

            return finalMessage;
        }

        // check same course number
        private string CheckSameNumber(int tabIndex, int courseIndex)
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
        private string CheckSameName(int tabIndex, int courseIndex)
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
        private string CheckConflictTime(int tabIndex, int courseIndex)
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
                    if (firstCourseInfo.HasConflictClassTime(secondCourseInfo))
                    {
                        message += ("「" + firstCourseInfo.Number + " " + firstCourseInfo.Name + "」");
                        message += ("「" + secondCourseInfo.Number + " " + secondCourseInfo.Name + "」");
                    }
                }
            }

            return message;
        }

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            int tabIndex = _selectedIndexPairs[index].Item1;
            int courseIndex = _selectedIndexPairs[index].Item2;

            _isCourseSelected[tabIndex][courseIndex] = false;
            _selectedIndexPairs.RemoveAt(index);
        }
    }
}
