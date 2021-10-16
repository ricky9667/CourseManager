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
        private List<Tuple<int, int>> _selectedIndexPair; // tabindex, courseIndex

        public CourseModel()
        {
            _courseTabPageInfos = new List<CourseTabPageInfo>
            {
                new CourseTabPageInfo("computerScience3TabPage", "資工三", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433"),
                new CourseTabPageInfo("electronicEngineering3ATabPage", "電子三甲", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423")
            };

            _courseInfosDictionary = new Dictionary<int, List<CourseInfo>>();
            _isCourseSelected = new Dictionary<int, List<bool>>();
            _selectedIndexPair = new List<Tuple<int, int>>();
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
            for (int index = 0; index < isSelectedCount; index++)
            {
                if (!isSelected[index])
                {
                    filteredCourseInfos.Add(_courseInfosDictionary[tabIndex][index]);
                }
            }

            return filteredCourseInfos;
        }

        // get selected course infos
        public List<CourseInfo> GetSelectedCourseInfos()
        {
            List<CourseInfo> selectedCourseInfos = new List<CourseInfo>();
            foreach (Tuple<int, int> indexPair in _selectedIndexPair)
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
            for (int index = 0; index < tabCount; index++)
            {
                if (selectedIndexes.Count > 0 && index == selectedIndexes[0])
                {
                    _isCourseSelected[tabIndex][index] = true;
                    _selectedIndexPair.Add(new Tuple<int, int>(tabIndex, index));
                    selectedIndexes.RemoveAt(0);
                }
            }
        }

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            int tabIndex = _selectedIndexPair[index].Item1;
            int courseIndex = _selectedIndexPair[index].Item2;

            _isCourseSelected[tabIndex][courseIndex] = false;
            _selectedIndexPair.RemoveAt(index);
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
