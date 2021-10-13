using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace CourseManager
{
    public class CourseModel
    {

        public CourseModel()
        {
            
        }

        // get tab page infos
        public List<CourseTabPageInfo> GetCourseTabPageInfos()
        {
            return new List<CourseTabPageInfo>
            {
                new CourseTabPageInfo("computerScience3TabPage", "資工三", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433"),
                new CourseTabPageInfo("electronicEngineering3ATabPage", "電子三甲", "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433")
            };
        }

        // get courses infos
        public List<CourseInfo> GetCourseInfos(string courseLink)
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
