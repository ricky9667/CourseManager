using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManager
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private readonly List<CourseTabPageInfo> _courseTabPageInfos;
        private readonly Dictionary<int, List<CourseInfo>> _courseInfosDictionary;
        private readonly Dictionary<int, List<bool>> _isCourseSelected;
        private readonly Dictionary<int, List<bool>> _isCourseOpen;
        private readonly List<Tuple<int, int>> _selectedIndexPairs; // tabIndex, courseIndex
        public Model()
        {
            _courseTabPageInfos = new List<CourseTabPageInfo>();
            _courseInfosDictionary = new Dictionary<int, List<CourseInfo>>();
            _isCourseSelected = new Dictionary<int, List<bool>>();
            _isCourseOpen = new Dictionary<int, List<bool>>(); // should test
            _selectedIndexPairs = new List<Tuple<int, int>>();

            SetUpTabPageInfo();
            LoadTabCourses(0);
            LoadTabCourses(1);
        }

        public List<CourseTabPageInfo> CourseTabPageInfos
        {
            get
            {
                return _courseTabPageInfos;
            }
        }

        public List<Tuple<int, int>> SelectedIndexPairs
        {
            get
            {
                return _selectedIndexPairs.Where(indexPair => _isCourseOpen[indexPair.Item1][indexPair.Item2]).ToList();
            }
        }

        // notify observers when data changed
        public void NotifyObserver()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        // setup hard data, should be moved
        private void SetUpTabPageInfo()
        {
            ClassInfo classInfo = new ClassInfo();
            _courseTabPageInfos.Add(classInfo.ComputerScience3TabPageInfo);
            _courseTabPageInfos.Add(classInfo.ElectronicEngineering3ATabPageInfo);
            _courseTabPageInfos.Add(classInfo.ComputerScience1TabPageInfo);
            _courseTabPageInfos.Add(classInfo.ComputerScience2TabPageInfo);
            _courseTabPageInfos.Add(classInfo.ComputerScience4TabPageInfo);
            _courseTabPageInfos.Add(classInfo.ComputerScienceMasterTabPageInfo);
        }

        // fetch course tab data from crawler
        public void LoadTabCourses(int tabIndex)
        {
            if (!_courseTabPageInfos[tabIndex].Loaded)
            {
                List<CourseInfo> courseInfos = _courseTabPageInfos[tabIndex].GetOwnCourseInfos();
                List<bool> selectedCourses = new List<bool>();
                List<bool> openedCourses = new List<bool>();
                foreach (CourseInfo _ in courseInfos)
                {
                    selectedCourses.Add(false);
                    openedCourses.Add(true);
                }
                _courseInfosDictionary.Add(tabIndex, courseInfos);
                _isCourseSelected.Add(tabIndex, selectedCourses);
                _isCourseOpen.Add(tabIndex, openedCourses); // should test
                _courseTabPageInfos[tabIndex].Loaded = true;
                NotifyObserver();
            }
        }

        // load all courses
        public void LoadAllTabCourses()
        {
            for (int index = 0; index < _courseTabPageInfos.Count; index++)
            {
                LoadTabCourses(index);
            }
        }

        // get single course info
        public CourseInfo GetCourseInfo(int tabIndex, int courseIndex)
        {
            return _courseInfosDictionary[tabIndex][courseIndex];
        }

        // get course infos from selected tab
        public List<CourseInfo> GetCourseInfos(int tabIndex)
        {
            return _courseInfosDictionary[tabIndex];
        }

        // get showing indexes of current datagridview
        public List<int> GetShowingIndexes(int tabIndex)
        {
            List<int> showingList = new List<int>();
            int count = _courseInfosDictionary[tabIndex].Count;
            for (int courseIndex = 0; courseIndex < count; courseIndex++)
            {
                if (!_isCourseSelected[tabIndex][courseIndex] && _isCourseOpen[tabIndex][courseIndex])
                {
                    showingList.Add(courseIndex);
                }
            }
            return showingList;
        }

        // get course management list
        public List<Tuple<int, int, string>> GetCourseManagementList()
        {
            List<Tuple<int, int, string>> courseManagementList = new List<Tuple<int, int, string>>(); // tabIndex, courseIndex, courseName
            for (int tabIndex = 0; tabIndex < _courseTabPageInfos.Count; tabIndex++)
            {
                if (_courseTabPageInfos[tabIndex].Loaded)
                {
                    List<CourseInfo> courseInfos = _courseInfosDictionary[tabIndex];
                    for (int courseIndex = 0; courseIndex < courseInfos.Count; courseIndex++)
                    {
                        courseManagementList.Add(new Tuple<int, int, string>(tabIndex, courseIndex, courseInfos[courseIndex].Name));
                    }
                }
            }

            return courseManagementList;
        }

        // get course isopen property
        public bool GetIsCourseOpen(int tabIndex, int courseIndex)
        {
            return _isCourseOpen[tabIndex][courseIndex];
        }

        // set single course info
        public void SetCourseInfo(int tabIndex, int courseIndex, CourseInfo courseInfo)
        {
            _courseInfosDictionary[tabIndex][courseIndex] = courseInfo;
            NotifyObserver();
        }

        // add new course info
        public void AddNewCourseInfo(int tabIndex, CourseInfo courseInfo)
        {
            _courseInfosDictionary[tabIndex].Add(courseInfo);
            _isCourseSelected[tabIndex].Add(false);
            NotifyObserver();
        }

        // add new tab page info
        public void AddNewTabPage(CourseTabPageInfo tabPageInfo)
        {
            int index = _courseTabPageInfos.Count;
            _courseTabPageInfos.Add(tabPageInfo);
            _courseInfosDictionary.Add(index, new List<CourseInfo>());
            _isCourseSelected.Add(index, new List<bool>());
            _isCourseOpen.Add(index, new List<bool>());
            NotifyObserver();
        }

        // change open course status
        public void UpdateCourseOpen(int tabIndex, int courseIndex, bool isCourseOpen)
        {
            _isCourseOpen[tabIndex][courseIndex] = isCourseOpen;
            NotifyObserver();
        }

        // add new open course status
        public void AddNewCourseOpen(int tabIndex, bool isCourseOpen)
        {
            _isCourseOpen[tabIndex].Add(isCourseOpen);
            NotifyObserver();
        }

        // add checked courses to selected courses
        public void SelectCourses(int tabIndex, List<int> selectedIndexes)
        {
            int tabCount = _courseInfosDictionary[tabIndex].Count;
            for (int courseIndex = 0; courseIndex < tabCount; courseIndex++)
            {
                if (selectedIndexes.Count > 0 && courseIndex == selectedIndexes[0])
                {
                    _selectedIndexPairs.Add(new Tuple<int, int>(tabIndex, courseIndex));
                    _isCourseSelected[tabIndex][courseIndex] = true;
                    selectedIndexes.RemoveAt(0);
                }
            }

            NotifyObserver();
        }

        // remove course from selected courses
        public void DiscardCourse(int index)
        {
            int tabIndex = _selectedIndexPairs[index].Item1;
            int courseIndex = _selectedIndexPairs[index].Item2;
            _isCourseSelected[tabIndex][courseIndex] = false;
            _selectedIndexPairs.RemoveAt(index);

            NotifyObserver();
        }

        // move course info to new list in dictionary
        public void MoveCourseInfo(int tabIndex, int courseIndex, int newTabIndex)
        {
            CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
            _courseInfosDictionary[tabIndex].RemoveAt(courseIndex);
            _courseInfosDictionary[newTabIndex].Add(courseInfo);
            int newCourseIndex = _courseInfosDictionary[newTabIndex].IndexOf(courseInfo);

            bool isOpen = _isCourseOpen[tabIndex][courseIndex];
            _isCourseOpen[tabIndex].RemoveAt(courseIndex);
            _isCourseOpen[newTabIndex].Add(isOpen);

            bool isSelected = _isCourseSelected[tabIndex][courseIndex];
            _isCourseSelected[tabIndex].RemoveAt(courseIndex);
            _isCourseSelected[newTabIndex].Add(isSelected);
            if (isSelected)
            {
                AdjustSelectedIndexPairs(tabIndex, courseIndex, newTabIndex, newCourseIndex);
            }
            NotifyObserver();
        }

        // adjust course indexes when course moved to another tab
        private void AdjustSelectedIndexPairs(int tabIndex, int courseIndex, int newTabIndex, int newCourseIndex)
        {
            for (int i = 0; i < _selectedIndexPairs.Count; i++)
            {
                if (_selectedIndexPairs[i].Item1 == tabIndex && _selectedIndexPairs[i].Item2 == courseIndex)
                {
                    _selectedIndexPairs[i] = new Tuple<int, int>(newTabIndex, newCourseIndex);
                }
                else if (_selectedIndexPairs[i].Item1 == tabIndex && _selectedIndexPairs[i].Item2 > courseIndex)
                {
                    _selectedIndexPairs[i] = new Tuple<int, int>(tabIndex, _selectedIndexPairs[i].Item2 - 1);
                }
            }
        }

        // check if a particular course is selected
        public bool CheckCourseSelected(int tabIndex, int courseIndex)
        {
            return _isCourseSelected[tabIndex][courseIndex];
        }

        // check same course numbers
        public string CheckSameNumbers(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            foreach (int courseIndex in courseIndexes)
            {
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareSameNumberMessage(selectedCourseInfo);
                }
            }
            return message;
        }

        // check same course names
        public string CheckSameNames(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            foreach (int courseIndex in courseIndexes)
            {
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareSameNameMessage(selectedCourseInfo);
                }
            }
            return message;
        }

        // check conflict course times
        public string CheckConflictTimes(int tabIndex, List<int> courseIndexes)
        {
            string message = CheckOwnConflictTime(tabIndex, courseIndexes);
            foreach (int courseIndex in courseIndexes)
            {
                CourseInfo courseInfo = _courseInfosDictionary[tabIndex][courseIndex];
                foreach (Tuple<int, int> indexPair in _selectedIndexPairs)
                {
                    CourseInfo selectedCourseInfo = _courseInfosDictionary[indexPair.Item1][indexPair.Item2];
                    message += courseInfo.GetCompareClassTimeMessage(selectedCourseInfo);
                }
            }
            return message;
        }

        // check if courses conflict each other
        private string CheckOwnConflictTime(int tabIndex, List<int> courseIndexes)
        {
            string message = "";
            int count = courseIndexes.Count;
            for (int i = 0; i < count; i++)
            {
                CourseInfo firstCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[i]];
                for (int j = i + 1; j < count; j++)
                {
                    CourseInfo secondCourseInfo = _courseInfosDictionary[tabIndex][courseIndexes[j]];
                    message += firstCourseInfo.GetBothCompareClassTimeMessage(secondCourseInfo);
                }
            }
            return message;
        }
    }
}
