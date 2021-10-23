using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseManagementFormViewModel
    {
        private Model _model;
        List<Tuple<int, int, string>> _courseManagementList;
        private bool _courseGroupBoxEnabled;

        public CourseManagementFormViewModel(Model model)
        {
            _model = model;
            _courseGroupBoxEnabled = false;
            _courseManagementList = GetCourseManagementList();
        }

        public bool CourseGroupBoxEnabled
        {
            get
            {
                return _courseGroupBoxEnabled;
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
        
        // set course group box enabled to true
        public void EnableCourseGroupBox()
        {
            _courseGroupBoxEnabled = true;
        }

        // get course info
        public CourseInfo GetCourseInfo(int tabIndex, int courseIndex)
        {
            return _model.GetCourseInfo(tabIndex, courseIndex);
        }
    }
}
