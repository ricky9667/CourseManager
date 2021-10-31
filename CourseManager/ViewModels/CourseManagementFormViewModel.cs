using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseManager
{
    public class CourseManagementFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private readonly Model _model;
        private bool _courseGroupBoxEnabled;
        private bool _addCourseButtonEnabled;
        private bool _saveButtonEnabled;
        int _currentSelectedCourse;
        List<Tuple<int, int, string>> _courseManagementList;

        public CourseManagementFormViewModel(Model model)
        {
            _model = model;
            _courseGroupBoxEnabled = false;
            _addCourseButtonEnabled = true;
            _saveButtonEnabled = false;
            _currentSelectedCourse = -1;
            _courseManagementList = GetCourseManagementList();
        }

        public bool CourseGroupBoxEnabled
        {
            get => _courseGroupBoxEnabled;
            set
            {
                _courseGroupBoxEnabled = value;
                NotifyPropertyChanged(nameof(CourseGroupBoxEnabled));
            }
        }

        public bool AddCourseButtonEnabled
        {
            get => _addCourseButtonEnabled;
            set
            {
                _addCourseButtonEnabled = value;
                NotifyPropertyChanged(nameof(AddCourseButtonEnabled));
            }
        }

        public bool SaveButtonEnabled
        {
            get => _saveButtonEnabled;
            set
            {
                _saveButtonEnabled = value;
                NotifyPropertyChanged(nameof(SaveButtonEnabled));
            }
        }

        public int CurrentSelectedCourse
        {
            get => _currentSelectedCourse;
            set
            {
                _currentSelectedCourse = value;
                NotifyPropertyChanged(nameof(CurrentSelectedCourse));
            }
        }

        public List<Tuple<int, int, string>> CourseManagementList
        {
            get => _courseManagementList;
        }

        public List<string> ClassNames
        {
            get
            {
                List<string> classNames = new List<string>();
                foreach (CourseTabPageInfo info in _model.CourseTabPageInfos)
                {
                    classNames.Add(info.TabText);
                }
                return classNames;
            }
        }

        // data binding update data on change
        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // get and classify course management list
        private List<Tuple<int, int, string>> GetCourseManagementList()
        {
            List<Tuple<int, int, string>> courseManagementList = new List<Tuple<int, int, string>>(); // tabIndex, courseIndex, courseName
            int tabCount = _model.CourseTabPageInfos.Count;
            for (int tabIndex = 0; tabIndex < tabCount; tabIndex++)
            {
                List<CourseInfo> courseInfos = _model.GetCourseInfos(tabIndex);
                int courseCount = courseInfos.Count;
                for (int courseIndex = 0; courseIndex < courseCount; courseIndex++)
                {
                    courseManagementList.Add(new Tuple<int, int, string>(tabIndex, courseIndex, courseInfos[courseIndex].Name));
                }
            }

            return courseManagementList;
        }

        // get course info
        public CourseInfo GetCourseInfo(int tabIndex, int courseIndex)
        {
            return _model.GetCourseInfo(tabIndex, courseIndex);
        }

        // update course info
        public void UpdateCourseInfo(int tabIndex, int courseIndex, CourseInfo courseInfo, int newTabIndex)
        {
            _model.SetCourseInfo(tabIndex, courseIndex, courseInfo);
            if (tabIndex != newTabIndex)
            {
                _model.MoveCourseInfo(tabIndex, courseIndex, newTabIndex);
            }
            _courseManagementList = GetCourseManagementList();
        }

        // add course info to model
        public void AddNewCourse(CourseInfo newCourseInfo, int newTabIndex)
        {
            _model.AddNewCourseInfo(newTabIndex, newCourseInfo);
            _courseManagementList = GetCourseManagementList();
        }

        // handle save button state
        public bool CheckSaveButtonStateByCourseData(CourseInfo changedCourseInfo)
        {
            Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
            CourseInfo courseInfo = _model.GetCourseInfo(course.Item1, course.Item2);
            bool isDataChanged = CheckCourseDataChanged(courseInfo, changedCourseInfo);
            bool isTextFormatCorrect = CheckCourseTextFormat(changedCourseInfo);
            bool isCourseHourMatch = CheckCourseHourMatch(changedCourseInfo);

            Console.WriteLine(isDataChanged.ToString() + " " + isTextFormatCorrect.ToString() + " " + isCourseHourMatch.ToString());
            return isDataChanged && isTextFormatCorrect && isCourseHourMatch;
        }

        // check if course data is changed
        private bool CheckCourseDataChanged(CourseInfo courseInfo, CourseInfo changedCourseInfo)
        {
            if (_currentSelectedCourse == -1)
            {
                return true; 
            }

            int[] ignoredIndexes = new int[] { 14, 15, 16, 19, 21, 22 };
            string[] courseInfoStrings = courseInfo.GetCourseInfoStrings();
            string[] changedCourseInfoStrings = changedCourseInfo.GetCourseInfoStrings();
            for (int index = 0; index < courseInfoStrings.Length; index++)
            {
                if (Array.Exists(ignoredIndexes, item => item == index))
                {
                    continue;
                }
                if (courseInfoStrings[index] != changedCourseInfoStrings[index])
                {
                    return true;
                }
            }

            return false;
        }

        // check particular textbox has correct format
        private bool CheckCourseTextFormat(CourseInfo changedCourseInfo)
        {
            if (changedCourseInfo.Number == "" || changedCourseInfo.Name == "" || changedCourseInfo.Stage == "" || changedCourseInfo.Credit == "" || changedCourseInfo.Teacher == "")
            {
                return false;
            }

            bool numberIsNumeric = int.TryParse(changedCourseInfo.Number, out _);
            bool stageIsNumeric = int.TryParse(changedCourseInfo.Stage, out _);
            bool creditIsNumeric = double.TryParse(changedCourseInfo.Credit, out _);

            if (!numberIsNumeric || !stageIsNumeric || !creditIsNumeric)
            {
                return false;
            }

            return true;
        }

        // check class time matchs course hours
        private bool CheckCourseHourMatch(CourseInfo changedCourseInfo)
        {
            const char SEPARATOR = ' ';
            int hourCount = 0;
            
            foreach (string classTime in changedCourseInfo.GetCourseClassTimeStrings())
            {
                if (classTime.Trim() != "")
                {
                    hourCount += classTime.Split(SEPARATOR).Length;
                }
            }

            return hourCount.ToString() == changedCourseInfo.Hour;
        }
    }
}
