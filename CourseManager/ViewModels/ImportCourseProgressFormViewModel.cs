using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CourseManager
{
    public class ImportCourseProgressFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Model _model;
        private string _importCourseProgressBarText;
        public ImportCourseProgressFormViewModel(Model model)
        {
            _model = model;
        }

        public string ImportCourseProgressBarText
        {
            get
            {
                return _importCourseProgressBarText;
            }
            set
            {
                _importCourseProgressBarText = value;
                NotifyPropertyChanged(nameof(ImportCourseProgressBarText));
            }
        }

        // data binding update data on change
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // load courses of particular index
        public void LoadTabPageCourses(int index)
        {
            _model.LoadTabCourses(index);
        }
    }
}
