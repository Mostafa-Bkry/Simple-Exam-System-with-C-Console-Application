using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class Answer
    {
        public Enum? QStudentAnswer { get; set; }
        public Enum? QCorrectAnswer { get; set; }
        public Answer(Enum? qCorrectAnswer = null, Enum? qStudentAnswer = null)
        {
            QCorrectAnswer = qCorrectAnswer;
            QStudentAnswer = qStudentAnswer;
        }
    }
}
