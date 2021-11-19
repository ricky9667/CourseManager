using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseManager
{
    public class CourseManagementFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event ViewModelChangedEventHandler _viewModelChanged;
        public delegate void ViewModelChangedEventHandler();

        private readonly Model _model;
        private bool _courseGroupBoxEnabled;
        private bool _addCourseButtonEnabled;
        private bool _saveButtonEnabled;
        private bool _importCourseButtonEnabled;
        int _currentSelectedCourse;
        List<Tuple<int, int, string>> _courseManagementList;

        public CourseManagementFormViewModel(Model model)
        {
            _model = model;
            _model._modelChanged += UpdateCourseManagementList;

            _courseGroupBoxEnabled = false;
            _addCourseButtonEnabled = true;
            _saveButtonEnabled = false;
            _importCourseButtonEnabled = true;
            _currentSelectedCourse = -1;
            UpdateCourseManagementList();
        }

        public Model Model
        {
            get
            {
                return _model;
            }
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

        public bool ImportCourseButtonEnabled
        {
            get
            {
                return _importCourseButtonEnabled;
            }
            set
            {
                _importCourseButtonEnabled = value;
                NotifyPropertyChanged(nameof(ImportCourseButtonEnabled));
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

        public int CurrentClassIndex
        {
            get
            {
                return _courseManagementList[_currentSelectedCourse].Item1;
            }
        }

        public int IsOpenCourseIndex
        {
            get
            {
                int tabIndex = _courseManagementList[_currentSelectedCourse].Item1;
                int courseIndex = _courseManagementList[_currentSelectedCourse].Item2;
                return _model.GetIsCourseOpen(tabIndex, courseIndex) ? 0 : 1;
            }
        }

        public CourseInfo CurrentCourseInfo
        {
            get
            {
                Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
                return _model.GetCourseInfo(course.Item1, course.Item2);
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
                    if (info.Loaded)
                    {
                        classNames.Add(info.TabText);
                    }
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

        // notify observer on data changed
        public void NotifyObserver()
        {
            if (_viewModelChanged != null)
            {
                _viewModelChanged();
            }
        }

        // get single course info by tab index and course index
        public CourseInfo GetCourseInfo(int tabIndex, int courseIndex)
        {
            return _model.GetCourseInfo(tabIndex, courseIndex);
        }

        // update course info
        public void UpdateCourseInfo(CourseInfo courseInfo, int newTabIndex, int isCourseOpenIndex)
        {
            Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
            _model.SetCourseInfo(course.Item1, course.Item2, courseInfo);
            _model.UpdateCourseOpen(course.Item1, course.Item2, (isCourseOpenIndex == 0));
            if (course.Item1 != newTabIndex)
            {
                _model.MoveCourseInfo(course.Item1, course.Item2, newTabIndex);
            }
        }

        // update course management list
        public void UpdateCourseManagementList()
        {
            _courseManagementList = _model.GetCourseManagementList();
            NotifyObserver();
        }

        // add course info to model
        public void AddNewCourse(CourseInfo newCourseInfo, int newTabIndex, int isCourseOpenIndex)
        {
            _model.AddNewCourseInfo(newTabIndex, newCourseInfo);
            _model.AddNewCourseOpen(newTabIndex, (isCourseOpenIndex == 0));
        }

        // handle save button state
        public bool CheckSaveButtonStateByCourseData(CourseInfo changedCourseInfo, int classIndex, int isOpenCourseIndex)
        {
            bool isClassChanged = true;
            bool isOpenCourseChanged = true;
            bool isDataChanged = true;
            bool isTextFormatCorrect = changedCourseInfo.CheckCourseFormat();
            bool isCourseHourMatch = changedCourseInfo.CheckCourseHourMatch();

            if (_currentSelectedCourse != -1)
            {
                Tuple<int, int, string> course = _courseManagementList[_currentSelectedCourse];
                CourseInfo courseInfo = _model.GetCourseInfo(course.Item1, course.Item2);
                isClassChanged = course.Item1 != classIndex;
                isOpenCourseChanged = _model.GetIsCourseOpen(course.Item1, course.Item2) != (isOpenCourseIndex == 0);
                isDataChanged = CheckCourseDataChanged(courseInfo, changedCourseInfo);
            }

            return (isClassChanged || isOpenCourseChanged || isDataChanged) && isTextFormatCorrect && isCourseHourMatch;
        }

        // check if course data is changed
        private bool CheckCourseDataChanged(CourseInfo courseInfo, CourseInfo changedCourseInfo)
        {
            const int CLASSROOM_INDEX = 14;
            const int NUMBER_OF_STUDENT = 15;
            const int NUMBER_OF_DROP_STUDENT = 16;
            const int OUTLINE_INDEX = 19;
            const int AUDIT_INDEX = 21;
            const int EXPERIMENT_INDEX = 22;
            return !courseInfo.CheckPropertiesIdentical(changedCourseInfo, new int[] { CLASSROOM_INDEX, NUMBER_OF_STUDENT, NUMBER_OF_DROP_STUDENT, OUTLINE_INDEX, AUDIT_INDEX, EXPERIMENT_INDEX });
        }

        // add new tab page from class management
        public void AddNewClass(string className)
        {
            CourseTabPageInfo tabPageInfo = new CourseTabPageInfo(className, className, "")
            {
                Loaded = true
            };
            _model.AddNewTabPage(tabPageInfo);
        }
    }
}
