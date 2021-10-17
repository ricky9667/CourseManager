using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseSelectionResultFormViewModel
    {
        Model _model;
        public CourseSelectionResultFormViewModel(Model model)
        {
            _model = model;
        }

        // get selected course infos
        public List<CourseInfo> GetSelectedCourseInfos()
        {
            List<CourseInfo> selectedCourseInfos = new List<CourseInfo>();
            foreach (Tuple<int, int> indexPair in _model.GetSelectedIndexPairs())
            {
                int tabIndex = indexPair.Item1;
                int courseIndex = indexPair.Item2;
                selectedCourseInfos.Add(_model.GetCourseInfo(tabIndex, courseIndex));
            }

            return selectedCourseInfos;
        }

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            _model.RemoveCourse(index);
        }
    }
}
