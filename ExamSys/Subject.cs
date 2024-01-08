using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class Subject
    {
        protected string SubjectName { get; set; }
        protected double SubjectExamMark { get; set; }

        public Subject(string subjName, double subExamMark)
        {
            SubjectName = subjName;
            SubjectExamMark = subExamMark;
        }
    }
}
