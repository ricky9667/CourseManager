﻿namespace CourseManager
{
    public class CourseTabPageInfo
    {
        public CourseTabPageInfo(string tabName, string tabText, string courseLink)
        {
            TabName = tabName;
            TabText = tabText;
            CourseLink = courseLink;
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
    }
}
