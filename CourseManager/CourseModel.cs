using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace CourseManager
{
    public class CourseModel
    {
        private List<CourseTabPageInfo> _courseTabPageInfos;
        private Dictionary<int, List<CourseInfo>> _courseInfosDictionary;
        private Dictionary<int, List<bool>> _isCourseSelected;
        private List<Tuple<int, int>> _selectedIndexPairs; // tabindex, courseIndex

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
                List<CourseInfo> courseInfos = FetchCourseInfos(_courseTabPageInfos[tabIndex].CourseLink);
                List<bool> seletedCourses = new List<bool>();

                _courseInfosDictionary.Add(tabIndex, courseInfos);

                int courseCount = courseInfos.Count;
                while (courseCount-- > 0)
                {
                    seletedCourses.Add(false);
                }
                _isCourseSelected.Add(tabIndex, seletedCourses);
            }

            List<CourseInfo> filteredCourseInfos = new List<CourseInfo>();
            List<bool> isSelected = _isCourseSelected[tabIndex];
            int isSelectedCount = isSelected.Count;
            for (int courseIndex = 0; courseIndex < isSelectedCount; courseIndex++)
            {
                if (!isSelected[courseIndex])
                {
                    filteredCourseInfos.Add(_courseInfosDictionary[tabIndex][courseIndex]);
                }
            }

            return filteredCourseInfos;
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

            foreach (int courseIndex in courseIndexes)
            {
                sameNumberMessage = CheckSameNumber(tabIndex, courseIndex);
                sameNameMessage = CheckSameName(tabIndex, courseIndex);
                conflictTimeMessage = CheckConflictTime(tabIndex, courseIndex);
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

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            int tabIndex = _selectedIndexPairs[index].Item1;
            int courseIndex = _selectedIndexPairs[index].Item2;

            _isCourseSelected[tabIndex][courseIndex] = false;
            _selectedIndexPairs.RemoveAt(index);
        }

        // get courses infos
        public List<CourseInfo> FetchCourseInfos(string courseLink)
        {
            HtmlNodeCollection nodeTableRows = FetchCourseData(courseLink);
            List<CourseInfo> courseInfos = new List<CourseInfo>();
            foreach (var row in nodeTableRows)
            {
                HtmlNodeCollection nodeTableDatas = row.ChildNodes;
                nodeTableDatas.RemoveAt(0);
                List<string> courseDataList = new List<string>();
                foreach (var node in nodeTableDatas)
                {
                    courseDataList.Add(node.InnerText.Trim());
                }
                courseInfos.Add(CreateCourseInfo(courseDataList));
            }
            return courseInfos;
        }

        // fetch and arrange course data from website
        private HtmlNodeCollection FetchCourseData(string courseLink)
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlAgilityPack.HtmlDocument document = webClient.Load(courseLink);

            const string NODE_PATH = "//body/table";
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(NODE_PATH);
            HtmlNodeCollection nodeTableRows = nodeTable.ChildNodes;

            nodeTableRows.RemoveAt(0); // 移除 tbody
            nodeTableRows.RemoveAt(0); // 移除 <tr>資工三
            nodeTableRows.RemoveAt(0); // 移除 table header
            nodeTableRows.RemoveAt(GetCollectionSize(nodeTableRows) - 1); // 移除 <tr>小計

            return nodeTableRows;
        }

        // avoid feature envy
        private int GetCollectionSize(HtmlNodeCollection collection)
        {
            return collection.Count;
        }

        // create course info instance from list
        private CourseInfo CreateCourseInfo(List<string> courseDataList)
        {
            return new CourseInfo(
                courseDataList[(int)DataColumns.Number], courseDataList[(int)DataColumns.Name], 
                courseDataList[(int)DataColumns.Stage], courseDataList[(int)DataColumns.Credit],
                courseDataList[(int)DataColumns.Hour], courseDataList[(int)DataColumns.CourseType], 
                courseDataList[(int)DataColumns.Teacher], courseDataList[(int)DataColumns.ClassTime0],
                courseDataList[(int)DataColumns.ClassTime1], courseDataList[(int)DataColumns.ClassTime2],
                courseDataList[(int)DataColumns.ClassTime3], courseDataList[(int)DataColumns.ClassTime4],
                courseDataList[(int)DataColumns.ClassTime5], courseDataList[(int)DataColumns.ClassTime6],
                courseDataList[(int)DataColumns.Classroom], courseDataList[(int)DataColumns.NumberOfStudents],
                courseDataList[(int)DataColumns.NumberOfDropStudents], courseDataList[(int)DataColumns.TeachingAssistant],
                courseDataList[(int)DataColumns.Language], courseDataList[(int)DataColumns.Outline],
                courseDataList[(int)DataColumns.Note], courseDataList[(int)DataColumns.Audit], 
                courseDataList[(int)DataColumns.Experiment]);
        }
    }
}
