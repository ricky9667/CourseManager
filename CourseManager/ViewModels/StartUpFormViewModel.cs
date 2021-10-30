using System.ComponentModel;

namespace CourseManager
{
    public class StartUpFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private readonly Model _model;
        private bool _courseSelectingSystemButtonEnabled;
        private bool _courseManagementSystemButtonEnabled;
        public StartUpFormViewModel(Model model)
        {
            _model = model;
            _courseSelectingSystemButtonEnabled = true;
            _courseManagementSystemButtonEnabled = true;
        }

        // data binding update data on change
        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Model Model
        {
            get => _model;
        }

        public bool CourseSelectingSystemButtonEnabled
        {
            get => _courseSelectingSystemButtonEnabled;
            set
            {
                _courseSelectingSystemButtonEnabled = value;
                NotifyPropertyChanged(nameof(CourseSelectingSystemButtonEnabled));
            }
        }

        public bool CourseManagementSystemButtonEnabled
        {
            get => _courseManagementSystemButtonEnabled;
            set
            {
                _courseManagementSystemButtonEnabled = value;
                NotifyPropertyChanged(nameof(CourseManagementSystemButtonEnabled));
            }
        }
    }
}
