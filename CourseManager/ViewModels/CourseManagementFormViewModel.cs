﻿using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseManagementFormViewModel
    {
        private Model _model;
        List<Tuple<int, int, string>> _courseManagementList;
        private bool _courseGroupBoxEnabled;
        private bool _saveButtonEnabled;
        public CourseManagementFormViewModel(Model model)
        {
            _model = model;
            _courseGroupBoxEnabled = false;
            _saveButtonEnabled = false;
            _courseManagementList = GetCourseManagementList();
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
                foreach (CourseTabPageInfo info in _model.GetCourseTabPageInfos())
                {
                    classNames.Add(info.TabText);
                }
                return classNames;
            }
        }

        // get and classify course management list
        private List<Tuple<int, int, string>> GetCourseManagementList()
        {
            List<Tuple<int, int, string>> courseManagementList = new List<Tuple<int, int, string>>(); // tabIndex, courseIndex, courseName
            int tabCount = _model.ClassCount;
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
    }
}
