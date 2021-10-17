using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager
{
    public class CourseSelectingFormViewModel
    {
        Model _model;
        public CourseSelectingFormViewModel(Model model)
        {
            _model = model;
        }

        // get data model
        public Model GetModel()
        {
            return _model;
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
        public List<int> GetShowingList(int tabIndex)
        {
            List<int> showingList = new List<int>();
            List<CourseInfo> courseInfos = _model.GetCourseInfos(tabIndex);
            List<bool> isSelectedList = _model.GetIsSelectedList(tabIndex);
            for (int index = 0; index < courseInfos.Count; index++)
            {
                if (!isSelectedList[index])
                {
                    showingList.Add(index);
                }
            }
            return showingList;
        }

        // select courses if success and return select course result
        public string SelectCoursesAndGetMessage(int tabIndex, List<int> selectedIndexes)
        {
            string resultMessage = CheckSelectCoursesWithMessage(tabIndex, selectedIndexes);
            if (resultMessage == "")
            {
                _model.SelectCourses(tabIndex, selectedIndexes);
                return "加選成功";
            }

            return "加選失敗" + resultMessage;
        }

        // check if courses are able to select and return message if not
        private string CheckSelectCoursesWithMessage(int tabIndex, List<int> courseIndexes)
        {
            string sameNumberMessage = "";
            string sameNameMessage = "";
            string conflictTimeMessage = "";

            conflictTimeMessage += _model.CheckOwnConflictTime(tabIndex, courseIndexes);
            foreach (int courseIndex in courseIndexes)
            {
                sameNumberMessage += _model.CheckSameNumber(tabIndex, courseIndex);
                sameNameMessage += _model.CheckSameName(tabIndex, courseIndex);
                conflictTimeMessage += _model.CheckConflictTime(tabIndex, courseIndex);
            }

            string finalMessage = "";
            finalMessage += (sameNumberMessage == "") ? "" : ("\n課號相同：" + sameNumberMessage);
            finalMessage += (sameNameMessage == "") ? "" : ("\n課程名稱相同：" + sameNameMessage);
            finalMessage += (conflictTimeMessage == "") ? "" : ("\n衝堂：" + conflictTimeMessage);

            return finalMessage;
        }
    }
}
