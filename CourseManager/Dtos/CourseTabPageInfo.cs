using System.Collections.Generic;

namespace CourseManager
{
    public class CourseTabPageInfo
    {
        CourseCrawler _courseCrawler;
        public CourseTabPageInfo(string tabName, string tabText, string courseLink)
        {
            _courseCrawler = new CourseCrawler();
            TabName = tabName;
            TabText = tabText;
            CourseLink = courseLink;
            Loaded = false;
        }

        // return course infos via own course link
        public List<CourseInfo> GetOwnCourseInfos()
        {
            return _courseCrawler.FetchCourseInfos(CourseLink);
        }

        public string TabName
        {
            get; set;
        }

        public string TabText
        {
            get; set;
        }

        public string CourseLink
        {
            get; set;
        }

        public bool Loaded
        {
            get; set;
        }
    }
}
