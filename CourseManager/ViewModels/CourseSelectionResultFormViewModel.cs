﻿using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseSelectionResultFormViewModel
    {
        public event ViewModelChangedEventHandler ViewModelChanged;
        public delegate void ViewModelChangedEventHandler();

        private readonly Model _model;
        private List<CourseInfo> _selectedCourseInfos;
        public CourseSelectionResultFormViewModel(Model model)
        {
            _model = model;
            _model.ModelChanged += UpdateSelectedCourseInfos;
            _selectedCourseInfos = new List<CourseInfo>();
            UpdateSelectedCourseInfos();
        }

        public List<CourseInfo> SelectedCourseInfos
        {
            get => _selectedCourseInfos;
        }

        // notify observer on data changed
        public void NotifyObserver()
        {
            ViewModelChanged?.Invoke();
        }

        // update selected course infos
        public void UpdateSelectedCourseInfos()
        {
            _selectedCourseInfos.Clear();
            foreach (Tuple<int, int> indexPair in _model.GetSelectedIndexPairs())
            {
                int tabIndex = indexPair.Item1;
                int courseIndex = indexPair.Item2;
                _selectedCourseInfos.Add(_model.GetCourseInfo(tabIndex, courseIndex));
            }
            NotifyObserver();
        }

        // remove course from selected courses
        public void RemoveCourse(int index)
        {
            _model.DiscardCourse(index);
        }
    }
}
