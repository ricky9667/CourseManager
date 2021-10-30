﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseManager
{
    public class CourseSelectingFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event ViewModelChangedEventHandler ViewModelChanged;
        public delegate void ViewModelChangedEventHandler();

        private Model _model;
        private bool _courseTabControlEnabled;
        private bool _courseSelectionResultButtonEnabled;
        private bool _submitButtonEnabled;
        private int _currentTabIndex;
        private List<CourseInfo> _currentTabCourseInfos;
        private List<int> _currentTabShowingIndexes;
        public CourseSelectingFormViewModel(Model model)
        {
            _model = model;
            _model.ModelChanged += UpdateCurrentTabData;

            _courseTabControlEnabled = true;
            _courseSelectionResultButtonEnabled = true;
            _submitButtonEnabled = false;
            _currentTabIndex = 0;
            _currentTabCourseInfos = _model.GetCourseInfos(_currentTabIndex);
            _currentTabShowingIndexes = _model.GetShowingIndexes(_currentTabIndex);
        }

        public Model Model
        {
            get
            {
                return _model;
            }
        }

        // notify observer on data changed
        public void NotifyObserver()
        {
            ViewModelChanged?.Invoke();
            Console.WriteLine("CourseSelectingFormViewModel Changed");
        }

        // data binding update data on change
        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CourseTabControlEnabled
        {
            get
            {
                return _courseTabControlEnabled;
            }
            set
            {
                _courseTabControlEnabled = value;
                NotifyPropertyChanged(nameof(CourseTabControlEnabled));
            }
        }

        public bool CourseSelectionResultButtonEnabled
        {
            get
            {
                return _courseSelectionResultButtonEnabled;
            }
            set
            {
                _courseSelectionResultButtonEnabled = value;
                NotifyPropertyChanged(nameof(CourseSelectionResultButtonEnabled));
            }
        }
        public bool SubmitButtonEnabled
        {
            get
            {
                return _submitButtonEnabled;
            }
            set
            {
                _submitButtonEnabled = value;
                NotifyPropertyChanged(nameof(SubmitButtonEnabled));
            }
        }

        public int CurrentTabIndex
        {
            get
            {
                return _currentTabIndex;
            }
            set
            {
                _currentTabIndex = value;
                UpdateCurrentTabData();
                NotifyPropertyChanged(nameof(CurrentTabIndex));
            }
        }

        public List<CourseInfo> CurrentCourseInfos
        {
            get
            {
                return _currentTabCourseInfos;
            }
        }

        public List<int> CurrentShowingIndexes
        {
            get
            {
                return _currentTabShowingIndexes;
            }
        }

        // get tab page infos
        public List<CourseTabPageInfo> GetCourseTabPageInfos()
        {
            return _model.GetCourseTabPageInfos();
        }

        // update current tab course infos and current showing indexes
        public void UpdateCurrentTabData()
        {
            _currentTabCourseInfos = _model.GetCourseInfos(_currentTabIndex);
            _currentTabShowingIndexes = _model.GetShowingIndexes(_currentTabIndex);
            NotifyObserver();
        }

        // select courses if success and return select course result
        public string SelectCoursesAndGetMessage(int tabIndex, List<int> selectedIndexes)
        {
            string resultMessage = CheckSelectCoursesWithMessage(tabIndex, selectedIndexes);
            if (resultMessage == "")
            {
                _model.SelectCourses(tabIndex, selectedIndexes);
            }
            return resultMessage;
        }

        // check if courses are able to select and return message if not
        private string CheckSelectCoursesWithMessage(int tabIndex, List<int> courseIndexes)
        {
            string sameNumberMessage = _model.CheckSameNumbers(tabIndex, courseIndexes);
            string sameNameMessage = _model.CheckSameNames(tabIndex, courseIndexes);
            string conflictTimeMessage = _model.CheckConflictTimes(tabIndex, courseIndexes);

            return GetCheckSelectCoursesMessage(sameNumberMessage, sameNameMessage, conflictTimeMessage);
        }

        // get check select course message final result
        private string GetCheckSelectCoursesMessage(string sameNumberMessage, string sameNameMessage, string conflictTimeMessage)
        {
            const string SAME_NUMBER_MESSAGE_FRONT = "\n\n課號相同：";
            const string SAME_NAME_MESSAGE_FRONT = "\n\n課程名稱相同：";
            const string CONFLICT_TIME_FRONT = "\n\n衝堂：";

            sameNumberMessage = (sameNumberMessage == "") ? "" : (SAME_NUMBER_MESSAGE_FRONT + sameNumberMessage);
            sameNameMessage = (sameNameMessage == "") ? "" : (SAME_NAME_MESSAGE_FRONT + sameNameMessage);
            conflictTimeMessage = (conflictTimeMessage == "") ? "" : (CONFLICT_TIME_FRONT + conflictTimeMessage);

            return sameNumberMessage + sameNameMessage + conflictTimeMessage;
        }
    }
}
