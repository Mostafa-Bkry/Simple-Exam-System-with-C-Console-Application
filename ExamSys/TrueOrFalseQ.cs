using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    enum TrueOrFalseAns : byte { True = 1, False = 0 }
    internal class TrueOrFalseQ : Question
    {
        public TrueOrFalseQ(/*int qNumber, */string header, string body
            , double marks, Answer correctAnswer, Answer? studentAnswer = null)
            : base(header, body, marks, correctAnswer/*, qNumber: qNumber*/, studentAnswer: studentAnswer)
        {
        }

        internal override string QuestionFormat()
        {
            return
                $"Q{QNumber}- {Header}\t\t\t\tMarks({Marks})" +
                $"\n   {Body} ? (.....)";
        }
    }
}
