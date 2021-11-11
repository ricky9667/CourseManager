using System.Collections.Generic;

namespace CourseManager
{
    public class ImportCourseProgressFormViewModel
    {

        private readonly Model _model;
        private string _importCourseProgressBarText;
        public ImportCourseProgressFormViewModel(Model model)
        {
            _model = model;
        }

        public List<int> ComputerScienceTabIndexes
        {
            get
            {
                const int COMPUTER_SCIENCE_1_INDEX = 2;
                const int COMPUTER_SCIENCE_2_INDEX = 3;
                const int COMPUTER_SCIENCE_3_INDEX = 0;
                const int COMPUTER_SCIENCE_4_INDEX = 4;
                const int COMPUTER_SCIENCE_MASTER_INDEX = 5;
                return new List<int> { COMPUTER_SCIENCE_1_INDEX, COMPUTER_SCIENCE_2_INDEX, COMPUTER_SCIENCE_3_INDEX, COMPUTER_SCIENCE_4_INDEX, COMPUTER_SCIENCE_MASTER_INDEX };
            }
        }

        // load courses of particular index
        public void LoadTabPageCourses(int index)
        {
            _model.LoadTabCourses(index);
        }

        // generate progress label string
        public string GenerateProgressLabelText(double percentage)
        {
            const string LOADING_TEXT = "正在匯入課程... ";
            const string PERCENT = "%";
            return LOADING_TEXT + percentage + PERCENT;
        }
    }
}
