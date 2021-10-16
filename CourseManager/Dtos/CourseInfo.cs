using System;
using System.Collections.Generic;

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
            this.Audit = audit;
            this.Experiment = experiment;
        }

        // return string array type
        public string[] GetCourseInfoStrings()
        {
            return new string[] { Number, Name, Stage, Credit, Hour, CourseType, Teacher, ClassTime0, ClassTime1, ClassTime2, ClassTime3, ClassTime4, ClassTime5, ClassTime6,
                                  Classroom, NumberOfStudent, NumberOfDropStudent, TeachingAssistant, Language, Outline, Note, Audit, Experiment};
        }

        // get class time of course
        public List<Tuple<int, int>> GetCourseClassTimes()
        {
            List<Tuple<int, int>> classTimes = new List<Tuple<int, int>>();

            for (int day = 0; day < 7; day++)
            {
                classTimes.AddRange(GetSingleDayClassTime(day));
            }

            return classTimes;
        }

        // get single day class time
        private List<Tuple<int, int>> GetSingleDayClassTime(int day)
        {
            List<Tuple<int, int>> classTimes = new List<Tuple<int, int>>();
            string classString;

            switch (day)
            {
                case 0: classString = ClassTime0; break;
                case 1: classString = ClassTime1; break;
                case 2: classString = ClassTime2; break;
                case 3: classString = ClassTime3; break;
                case 4: classString = ClassTime4; break;
                case 5: classString = ClassTime5; break;
                case 6: classString = ClassTime6; break;
                default: return null;
            }

            if (classString != "")
            {
                string[] classChars = classString.Split(' ');
                foreach (string classChar in classChars)
                {
                    classTimes.Add(new Tuple<int, int>(day, ConvertClassCharToInt(classChar[0])));
                }
            }

            return classTimes;
        }

        // convert class time char to index
        private int ConvertClassCharToInt(char c)
        {
            switch (c)
            {
                case '1': return 0;
                case '2': return 1;
                case '3': return 2;
                case '4': return 3;
                case 'N': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                default: return -1;
            }
        }

        // check if courses have class time overlap
        public bool HasConflictClassTime(CourseInfo courseInfo)
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

        // output course data for testing
        public void PrintCourseData()
        {
            Console.WriteLine("[ " + Number + " - " + Name + " ]");
            List<Tuple<int, int>> classTimes = GetCourseClassTimes();
            foreach (Tuple<int, int> classTime in classTimes)
            {
                Console.WriteLine(classTime.Item1 + " : " + classTime.Item2);
            }
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
