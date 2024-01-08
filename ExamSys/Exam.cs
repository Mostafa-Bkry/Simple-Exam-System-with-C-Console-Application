using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal abstract class Exam : Subject
    {
        public TimeSpan Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Exam(string subjectName, double subExamMark, TimeSpan time
            , int numOfQuestions) : base(subjectName, subExamMark)
        {
            Time = time;
            NumberOfQuestions = numOfQuestions;
        }

        internal abstract void ShowExam();
        protected abstract void PrintStudentAnsList();
        protected abstract void PrintStudentFinalMark();
    }
}
