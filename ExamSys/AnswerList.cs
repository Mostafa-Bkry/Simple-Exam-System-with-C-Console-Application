using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class AnswerList
    {
        public Enum[] CorrectAnswers { get; set; }
        public Enum[] StudentAnswers { get; set; }
        //QuestionList? questionList;
        public int NumberOfQuestions { get; set; }

        public AnswerList(int numberOfQuesions)
        {
            NumberOfQuestions = numberOfQuesions;
            CorrectAnswers = new Enum[numberOfQuesions];
            StudentAnswers = new Enum[numberOfQuesions];
        }

        public void AddCorrectAns(Enum answer)
        {
            if (answer != null)
            {
                if (CorrectAnswers[CorrectAnswers.Length - 1] == null)
                {
                    for (int i = 0; i < CorrectAnswers.Length; i++)
                    {
                        if (CorrectAnswers[i] == null /*&& questionList?.questions[i] != null*/)
                        {
                            //Console.WriteLine(answer);
                            CorrectAnswers[i] = answer;
                            //Console.WriteLine($"Correct Answer number " +
                            //    $"{i + 1} Added");
                            break;
                        }
                        else
                            continue;
                    }
                }
                else
                    Console.WriteLine("Correct Answers is full");
            }
            else
                Console.WriteLine("Wrong Optional Answer!!");
        }

        public void AddStudentAns(Enum answer)
        {
            if (answer != null)
            {
                if (StudentAnswers[StudentAnswers.Length - 1] == null)
                {
                    for (int i = 0; i < StudentAnswers.Length; i++)
                    {
                        if (StudentAnswers[i] == null)
                        {
                            StudentAnswers[i] = answer;
                            break;
                        }
                        else
                            continue;
                    }
                }
                else
                    Console.WriteLine("Correct Answers is full");
            }
            else
                Console.WriteLine("Wrong Optional Answer!!");
        }
    }
}
