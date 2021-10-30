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
        List<Tuple<int, int, string>> _courseManagementList;

        public CourseManagementFormViewModel(Model model)
        {
            _model = model;
            _courseGroupBoxEnabled = false;
            _addCourseButtonEnabled = true;
            _saveButtonEnabled = false;
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
        public void AddNewCourse(CourseInfo courseInfo, int newTabIndex)
        {
            _model.AddNewCourseInfo(newTabIndex, courseInfo);
            _courseManagementList = GetCourseManagementList();
        }
    }
}
