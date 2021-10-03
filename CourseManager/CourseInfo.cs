namespace CourseManager
{
    public class CourseInfo
    {
        public CourseInfo(string number, string name, string stage, string credit, string hour, string courseType, string teacher,
            string classTime0, string classTime1, string classTime2, string classTime3, string classTime4, string classTime5, string classTime6, 
            string classroom, string numberOfStudent, string numberOfDropStudent, string teachingAssistant, 
            string language, string note, string outline, string audit, string experiment)
        {
            this.Number = number;
            this.Name = name;
            this.Stage = stage;
            this.Credit = credit;
            this.Hour = hour;
            this.CourseType = courseType;
            this.Teacher = teacher;
            this.ClassTime0 = classTime0;
            this.ClassTime1 = classTime1;
            this.ClassTime2 = classTime2;
            this.ClassTime3 = classTime3;
            this.ClassTime4 = classTime4;
            this.ClassTime5 = classTime5;
            this.ClassTime6 = classTime6;
            this.Classroom = classroom;
            this.NumberOfStudent = numberOfStudent;
            this.NumberOfDropStudent = numberOfDropStudent;
            this.TeachingAssistant = teachingAssistant;
            this.Language = language;
            this.Outline = outline;
            this.Note = note;
            this.Audit = audit; //
            this.Experiment = experiment;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string CourseType
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public string ClassTime0
        {
            get; set;
        }

        public string ClassTime1
        {
            get; set;
        }

        public string ClassTime2
        {
            get; set;
        }

        public string ClassTime3
        {
            get; set;
        }

        public string ClassTime4
        {
            get; set;
        }

        public string ClassTime5
        {
            get; set;
        }

        public string ClassTime6
        {
            get; set;
        }
        public string Classroom
        {
            get; set;
        }

        public string NumberOfStudent
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string NumberOfDropStudent
        {
            get; set;
        }

        public string TeachingAssistant
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Outline
        {
            get; set;
        }

        public string Audit
        {
            get; set;
        }

        public string Experiment
        {
            get; set;
        }
    }
}

