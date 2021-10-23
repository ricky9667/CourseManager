using System.Collections.Generic;

namespace CourseManager
{
    public class CourseSelectingFormViewModel
    {
        private Model _model;
        private bool _courseTabControlEnabled;
        private bool _courseSelectionResultButtonEnabled;
        private bool _submitButtonEnabled;
        public CourseSelectingFormViewModel(Model model)
        {
            _model = model;
            _courseTabControlEnabled = true;
            _courseSelectionResultButtonEnabled = true;
            _submitButtonEnabled = false;
        }

        public Model Model
        {
            get
            {
                return _model;
            }
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
            }
        }

        // get tab page infos
        public List<CourseTabPageInfo> GetCourseTabPageInfos()
        {
            return _model.GetCourseTabPageInfos();
        }

        // get course infos from selected tab
        public List<CourseInfo> GetCourseInfos(int tabIndex)
        {
            return _model.GetCourseInfos(tabIndex);
        }

        // get showing indexes of current datagridview
        public List<int> GetShowingIndexes(int tabIndex)
        {
            return _model.GetShowingIndexes(tabIndex);
        }

        // select courses if success and return select course result
        public string SelectCoursesAndGetMessage(int tabIndex, List<int> selectedIndexes)
        {
            const string SELECT_SUCCESS_MESSAGE = "加選成功";
            const string SELECT_FAIL_MESSAGE = "加選失敗";

            string resultMessage = CheckSelectCoursesWithMessage(tabIndex, selectedIndexes);
            if (resultMessage == "")
            {
                _model.SelectCourses(tabIndex, selectedIndexes);
                return SELECT_SUCCESS_MESSAGE;
            }

            return SELECT_FAIL_MESSAGE + resultMessage;
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
