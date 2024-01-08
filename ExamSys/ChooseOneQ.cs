using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    enum ChooseOneAns : byte { A, B, C, D }
    internal class ChooseOneQ : Question
    {
        public string[] Choices { get; set; }
        public ChooseOneQ(/*int qNumber,*/ string header, string body
           , double marks, Answer correctAnswer, string choices, Answer? studentAnswer = null)
           : base(header, body, marks, correctAnswer/*, qNumber: qNumber*/, studentAnswer: studentAnswer)
        {
            Choices = choices.Split('/');
        }

        internal override string QuestionFormat()
        {
            return
                $"Q{QNumber}- {Header}\t\t\t\t\tMarks({Marks})" +
                $"\n     {Body} ? (A.{Choices[0]} , B.{Choices[1]} , C.{Choices[2]} , D.{Choices[3]})";
        }
    }
}
