using System;
using System.Collections.Generic;

namespace CourseManager
{
    public class CourseInfo
    {
        private readonly int _daysPerWeek = 7;
        public static readonly string _courseChars = "1234N56789ABCD";

        public CourseInfo()
        {
            Number = "";
            Name = "";
            Stage = "";
            Credit = "";
            Hour = "";
            CourseType = "";
            Teacher = "";
            ClassTime0 = "";
            ClassTime1 = "";
            ClassTime2 = "";
            ClassTime3 = "";
            ClassTime4 = "";
            ClassTime5 = "";
            ClassTime6 = "";
            Classroom = "";
            NumberOfStudent = "";
            NumberOfDropStudent = "";
            TeachingAssistant = "";
            Language = "";
            Outline = "";
            Note = "";
            Audit = "";
            Experiment = "";
        }

        public CourseInfo(string number, string name, string stage, string credit, string hour, string courseType, string teacher,
            string classTime0, string classTime1, string classTime2, string classTime3, string classTime4, string classTime5, string classTime6,
            string classroom, string numberOfStudent, string numberOfDropStudent, string teachingAssistant,
            string language, string note, string outline, string audit, string experiment)
        {
            Number = number;
            Name = name;
            Stage = stage;
            Credit = credit;
            Hour = hour;
            CourseType = courseType;
            Teacher = teacher;
            ClassTime0 = classTime0;
            ClassTime1 = classTime1;
            ClassTime2 = classTime2;
            ClassTime3 = classTime3;
            ClassTime4 = classTime4;
            ClassTime5 = classTime5;
            ClassTime6 = classTime6;
            Classroom = classroom;
            NumberOfStudent = numberOfStudent;
            NumberOfDropStudent = numberOfDropStudent;
            TeachingAssistant = teachingAssistant;
            Language = language;
            Outline = outline;
            Note = note;
            Audit = audit;
            Experiment = experiment;
        }

        // return string array type
        public string[] GetCourseInfoStrings()
        {
            return new string[] { Number, Name, Stage, Credit, Hour, CourseType, Teacher, ClassTime0, ClassTime1, ClassTime2, ClassTime3, ClassTime4, ClassTime5, ClassTime6,
                                    Classroom, NumberOfStudent, NumberOfDropStudent, TeachingAssistant, Language, Outline, Note, Audit, Experiment};
        }

        // get class time string of course
        public string[] GetCourseClassTimeStrings()
        {
            return new string[] { ClassTime0, ClassTime1, ClassTime2, ClassTime3, ClassTime4, ClassTime5, ClassTime6 };
        }

        // get class time of course
        public List<Tuple<int, int>> GetCourseClassTimes()
        {
            List<Tuple<int, int>> classTimes = new List<Tuple<int, int>>();

            for (int day = 0; day < _daysPerWeek; day++)
            {
                classTimes.AddRange(GetSingleDayClassTime(day));
            }

            return classTimes;
        }

        // get single day class time
        private List<Tuple<int, int>> GetSingleDayClassTime(int day)
        {
            List<Tuple<int, int>> classTimes = new List<Tuple<int, int>>();
            string[] dayToClassString = new string[] { ClassTime0, ClassTime1, ClassTime2, ClassTime3, ClassTime4, ClassTime5, ClassTime6 };
            string classString = dayToClassString[day];

            if (classString != "")
            {
                const char SEPARATOR = ' ';
                string[] classChars = classString.Split(SEPARATOR);
                foreach (string classChar in classChars)
                {
                    classTimes.Add(new Tuple<int, int>(day, GetClassIndex(classChar[0])));
                }
            }

            return classTimes;
        }

        // convert class char to int
        private int GetClassIndex(char classChar)
        {
            for (int index = 0; index < _courseChars.Length; index++)
            {
                if (classChar == _courseChars[index])
                {
                    return index;
                }
            }
            return -1;
        }

        // get course basic data string
        private string GetCourseDataString()
        {
            const string FRONT_QUOTE = "「";
            const string SEPARATER = " ";
            const string BACK_QUOTE = "」";
            return FRONT_QUOTE + Number + SEPARATER + Name + BACK_QUOTE;
        }

        // check if courses have same number and return message
        public string GetCompareSameNumberMessage(CourseInfo courseInfo)
        {
            return (Number == courseInfo.Number) ? GetCourseDataString() : "";
        }

        // check if courses have same name and return message
        public string GetCompareSameNameMessage(CourseInfo courseInfo)
        {
            return (Name == courseInfo.Name) ? GetCourseDataString() : "";
        }

        // check if courses have class time overlap and return message for single course
        public string GetCompareClassTimeMessage(CourseInfo courseInfo)
        {
            return HasConflictClassTime(courseInfo) ? GetCourseDataString() : "";
        }

        // check if courses have class time overlap and return message for both courses
        public string GetBothCompareClassTimeMessage(CourseInfo courseInfo)
        {
            return HasConflictClassTime(courseInfo) ? GetCourseDataString() + courseInfo.GetCourseDataString() : "";
        }

        // check if courses have class time overlap
        private bool HasConflictClassTime(CourseInfo courseInfo)
        {
            foreach (Tuple<int, int> thisClassTime in GetCourseClassTimes())
            {
                foreach (Tuple<int, int> classTime in courseInfo.GetCourseClassTimes())
                {
                    if (classTime.Item1 == thisClassTime.Item1 && classTime.Item2 == thisClassTime.Item2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // log data for testing
        public void PrintCourseData()
        {
            Console.WriteLine("[ " + Name + " " + Number + " ]");
            Console.WriteLine("Sun: " + ClassTime0);
            Console.WriteLine("Mon: " + ClassTime1);
            Console.WriteLine("Tue: " + ClassTime2);
            Console.WriteLine("Wed: " + ClassTime3);
            Console.WriteLine("Thu: " + ClassTime4);
            Console.WriteLine("Fri: " + ClassTime5);
            Console.WriteLine("Sat: " + ClassTime6);
            Console.WriteLine("---------------------");
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

        // return index of hour combobox
        public int HourIndex
        {
            get
            {
                switch (Hour)
                {
                    case "1":
                        return 0;
                    case "2":
                        return 1;
                    case "3":
                        return 2;
                    default:
                        return -1;
                }
            }
        }

        public string CourseType
        {
            get; set;
        }

        // return index of course type combobox
        public int CourseTypeIndex
        {
            get
            {
                const string courseSymbols = "○△☆●▲★";
                return courseSymbols.IndexOf(CourseType);
            }
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
