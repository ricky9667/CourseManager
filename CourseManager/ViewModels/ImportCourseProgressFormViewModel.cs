using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CourseManager
{
    public class ImportCourseProgressFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Model _model;
        private readonly List<CourseTabPageInfo> _computerScienceCourseTabPageInfos;
        private List<int> _courseTabPageIndexes;
        private string _importCourseProgressBarText;
        public ImportCourseProgressFormViewModel(Model model)
        {
            _model = model;
            _computerScienceCourseTabPageInfos = new List<CourseTabPageInfo>();
            _courseTabPageIndexes = new List<int>();
            SetUpComputerScienceCourseTabPageInfos();
        }

        public List<CourseTabPageInfo> ComputerScienceCourseTabPageInfos
        { 
            get
            {
                return _computerScienceCourseTabPageInfos;
            }
        }

        public string ImportCourseProgressBarText
        {
            get
            {
                return _importCourseProgressBarText;
            }
            set
            {
                _importCourseProgressBarText = value;
                NotifyPropertyChanged(nameof(ImportCourseProgressBarText));
            }
        }

        // data binding update data on change
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // setup computer science course tab page infos
        private void SetUpComputerScienceCourseTabPageInfos()
        {
            const string COMPUTER_SCIENCE_1_TAB_NAME = "computerScience1TabPage";
            const string COMPUTER_SCIENCE_1_TAB_TEXT = "資工一";
            const string COMPUTER_SCIENCE_1_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676";
            const string COMPUTER_SCIENCE_2_TAB_NAME = "computerScience2TabPage";
            const string COMPUTER_SCIENCE_2_TAB_TEXT = "資工二";
            const string COMPUTER_SCIENCE_2_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2550";
            const string COMPUTER_SCIENCE_4_TAB_NAME = "computerScience4TabPage";
            const string COMPUTER_SCIENCE_4_TAB_TEXT = "資工四";
            const string COMPUTER_SCIENCE_4_COURSE_LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2314";

            _computerScienceCourseTabPageInfos.Add(new CourseTabPageInfo(COMPUTER_SCIENCE_1_TAB_NAME, COMPUTER_SCIENCE_1_TAB_TEXT, COMPUTER_SCIENCE_1_COURSE_LINK));
            _computerScienceCourseTabPageInfos.Add(new CourseTabPageInfo(COMPUTER_SCIENCE_2_TAB_NAME, COMPUTER_SCIENCE_2_TAB_TEXT, COMPUTER_SCIENCE_2_COURSE_LINK));
            _computerScienceCourseTabPageInfos.Add(new CourseTabPageInfo(COMPUTER_SCIENCE_4_TAB_NAME, COMPUTER_SCIENCE_4_TAB_TEXT, COMPUTER_SCIENCE_4_COURSE_LINK));
        }

        // load courses of particular index
        public void LoadTabPageCourses(int index)
        {
            _model.CourseTabPageInfos.Add(_computerScienceCourseTabPageInfos[index]);
            _model.ManuallyLoadAllCourses();
            _courseTabPageIndexes.Insert(index, _model.CourseTabPageInfos.Count - 1);
        }
    }
}
