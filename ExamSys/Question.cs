using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal abstract class Question
    {
        public int QNumber { get; set; }
        public string Header { get; set; }
        protected string Body { get; set; }
        protected double Marks { get; set; }
        public Answer? StudentAnswer { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Question(string header, string body
            , double marks, Answer correctAnswer, int qNumber = 0, Answer? studentAnswer = null)
        {
            QNumber = qNumber;
            Header = header;
            Body = body;
            Marks = marks;
            CorrectAnswer = correctAnswer;
            StudentAnswer = studentAnswer; 
        }

        internal abstract string QuestionFormat();
    }
}
