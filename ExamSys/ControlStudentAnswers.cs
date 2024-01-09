using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class ControlStudentAnswers
    {
        int numberOfQuestions;
        int[] answered;

        public ControlStudentAnswers(int _numberOfQuestions)
        {
            numberOfQuestions = _numberOfQuestions;
            answered = new int[numberOfQuestions];
        }

        public void ControlAnswer(Exam exam)
        {
            int questionNumber, index = 0;

            while (true)
            {
                Console.WriteLine($"Enter Question Number to Answer from 1 to {numberOfQuestions}");
                if (int.TryParse(Console.ReadLine(), out questionNumber))
                    if (questionNumber > 0 && questionNumber <= numberOfQuestions)
                    {
                        if(answered.Contains(questionNumber))
                        {
                            Console.WriteLine("This question is answered");
                            continue;
                        }
                        else
                        {
                            answered[index] = questionNumber;
                            index++;
                            exam.AddStudentAnswers(questionNumber);
                            break;
                        }
                    }    
            }
        }
    }
}
