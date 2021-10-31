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
            _courseManagementList = _model.GetCourseManagementList();
        }

        public bool CourseGroupBoxEnabled
        {
            get
            {
                return _courseGroupBoxEnabled;
            }
            set
            {
                _courseGroupBoxEnabled = value;
                NotifyPropertyChanged(nameof(CourseGroupBoxEnabled));
            }
        }

        public bool AddCourseButtonEnabled
        {
            get
            {
                return _addCourseButtonEnabled;
            }
            set
            {
                _addCourseButtonEnabled = value;
                NotifyPropertyChanged(nameof(AddCourseButtonEnabled));
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                return _saveButtonEnabled;
            }
            set
            {
                _saveButtonEnabled = value;
                NotifyPropertyChanged(nameof(SaveButtonEnabled));
            }
        }

        public int CurrentSelectedCourse
        {
            get
            {
                return _currentSelectedCourse;
            }
            set
            {
                _currentSelectedCourse = value;
                NotifyPropertyChanged(nameof(CurrentSelectedCourse));
            }
        }

        public List<Tuple<int, int, string>> CourseManagementList
        {
            get
            {
                return _courseManagementList;
            }
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // get single course info by tab index and course index
        public CourseInfo GetCourseInfoByIndexPair(int tabIndex, int courseIndex)
        {
            return _model.GetCourseInfo(tabIndex, courseIndex);
        }

        // get single course info by list box index
        public CourseInfo GetCourseInfoByListBoxIndex(int index)
        {
            Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
            return _model.GetCourseInfo(course.Item1, course.Item2);
        }

        // update course info
        public void UpdateCourseInfo(int tabIndex, int courseIndex, CourseInfo courseInfo, int newTabIndex)
        {
            _model.SetCourseInfo(tabIndex, courseIndex, courseInfo);
            if (tabIndex != newTabIndex)
            {
                _model.MoveCourseInfo(tabIndex, courseIndex, newTabIndex);
            }
            _courseManagementList = _model.GetCourseManagementList();
        }

        // add course info to model
        public void AddNewCourse(CourseInfo newCourseInfo, int newTabIndex)
        {
            _model.AddNewCourseInfo(newTabIndex, newCourseInfo);
            _courseManagementList = _model.GetCourseManagementList();
        }

        // handle save button state
        public bool CheckSaveButtonStateByCourseData(CourseInfo changedCourseInfo, int classIndex)
        {
            Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
            CourseInfo courseInfo = _model.GetCourseInfo(course.Item1, course.Item2);

            bool isClassChanged = course.Item1 != classIndex;
            bool isDataChanged = CheckCourseDataChanged(courseInfo, changedCourseInfo);
            bool isTextFormatCorrect = changedCourseInfo.CheckCourseFormat();
            bool isCourseHourMatch = changedCourseInfo.CheckCourseHourMatch();

            return (isClassChanged || isDataChanged) && isTextFormatCorrect && isCourseHourMatch;
        }

        // check if course data is changed
        private bool CheckCourseDataChanged(CourseInfo courseInfo, CourseInfo changedCourseInfo)
        {
            if (_currentSelectedCourse == -1)
            {
                return true; 
            }

            return !courseInfo.CheckPropertiesIdentical(changedCourseInfo, new int[] { 14, 15, 16, 19, 21, 22 });
        }
    }
}
