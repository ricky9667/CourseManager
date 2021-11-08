using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager
{
    public class ClassInfo
    {
        public ClassInfo()
        {

        }

        public CourseTabPageInfo ComputerScience3TabPageInfo
        {
            get
            {
                const string COMPUTER_SCIENCE_3_TAB_NAME = "computerScience3TabPage";
                const string COMPUTER_SCIENCE_3_TAB_TEXT = "資工三";
                const string COMPUTER_SCIENCE_3_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
                return new CourseTabPageInfo(COMPUTER_SCIENCE_3_TAB_NAME, COMPUTER_SCIENCE_3_TAB_TEXT, COMPUTER_SCIENCE_3_COURSE_LINK);
            }
        }

        public CourseTabPageInfo ElectronicEngineering3ATabPageInfo
        {
            get
            {
                const string ELECTRONIC_ENGINEERING_3A_TAB_NAME = "electronicEngineering3ATabPage";
                const string ELECTRONIC_ENGINEERING_3A_TAB_TEXT = "電子三甲";
                const string ELECTRONIC_ENGINEERING_3A_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2423";
                return new CourseTabPageInfo(ELECTRONIC_ENGINEERING_3A_TAB_NAME, ELECTRONIC_ENGINEERING_3A_TAB_TEXT, ELECTRONIC_ENGINEERING_3A_COURSE_LINK);

            }
        }

        public CourseTabPageInfo ComputerScience1TabPageInfo
        {
            get
            {
                const string COMPUTER_SCIENCE_1_TAB_NAME = "computerScience1TabPage";
                const string COMPUTER_SCIENCE_1_TAB_TEXT = "資工一";
                const string COMPUTER_SCIENCE_1_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676";
                return new CourseTabPageInfo(COMPUTER_SCIENCE_1_TAB_NAME, COMPUTER_SCIENCE_1_TAB_TEXT, COMPUTER_SCIENCE_1_COURSE_LINK);
            }
        }

        public CourseTabPageInfo ComputerScience2TabPageInfo
        {
            get
            {
                const string COMPUTER_SCIENCE_2_TAB_NAME = "computerScience2TabPage";
                const string COMPUTER_SCIENCE_2_TAB_TEXT = "資工二";
                const string COMPUTER_SCIENCE_2_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2550";
                return new CourseTabPageInfo(COMPUTER_SCIENCE_2_TAB_NAME, COMPUTER_SCIENCE_2_TAB_TEXT, COMPUTER_SCIENCE_2_COURSE_LINK);
            }
        }

        public CourseTabPageInfo ComputerScience4TabPageInfo
        {
            get
            {
                const string COMPUTER_SCIENCE_4_TAB_NAME = "computerScience4TabPage";
                const string COMPUTER_SCIENCE_4_TAB_TEXT = "資工四";
                const string COMPUTER_SCIENCE_4_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2314";
                return new CourseTabPageInfo(COMPUTER_SCIENCE_4_TAB_NAME, COMPUTER_SCIENCE_4_TAB_TEXT, COMPUTER_SCIENCE_4_COURSE_LINK);
            }
        }
    }
}
