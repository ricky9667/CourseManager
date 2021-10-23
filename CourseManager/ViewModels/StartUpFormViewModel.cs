namespace CourseManager
{
    public class StartUpFormViewModel
    {
        private Model _model;
        private bool _courseSelectingSystemButtonEnabled;
        private bool _courseManagementSystemButtonEnabled;
        private bool _exitButtonEnabled;
        public StartUpFormViewModel(Model model)
        {
            _model = model;
        }

        public Model Model
        {
            get
            {
                return _model;
            }
        }

        public bool CourseSelectingSystemButtonEnabled
        {
            get
            {
                return _courseSelectingSystemButtonEnabled;
            }
            set
            {
                _courseSelectingSystemButtonEnabled = value;
            }
        }

        public bool CourseManagementSystemButtonEnabled
        {
            get
            {
                return _courseManagementSystemButtonEnabled;
            }
            set
            {
                _courseManagementSystemButtonEnabled = value;
            }
        }

        public bool ExitButtonEnabled
        {
            get
            {
                return _exitButtonEnabled;
            }
            set
            {
                _exitButtonEnabled = value;
            }
        }
    }
}
