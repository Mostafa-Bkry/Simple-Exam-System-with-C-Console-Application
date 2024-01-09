using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    enum NoAnswer : byte { NoAnswer = 0 }

    internal class QuestionList
    {
        public Question[] questions { get; }
        public int NumberOfQuestions { get; set; }
        AnswerList answerList;

        public QuestionList(int numberOfQuesions)
        {
            NumberOfQuestions = numberOfQuesions;
            questions = new Question[numberOfQuesions];
            answerList = new AnswerList(numberOfQuesions);
        }

        public void AddQuestion(/*int questionNumber, */Question question)
        {
            if (question != null)
            {
                #region try1
                //if (NumLabelForQuestion.Contains(questionNumber))
                //{
                //    for(int i = 0; i < questions.Length; i++)
                //    {
                //        Console.WriteLine($"QNumber: {question.QNumber}");
                //        if (questions[i] == null && questionNumber > question.QNumber)
                //        {
                //            questions[i] = question;
                //            question.QNumber = questionNumber;
                //            Console.WriteLine($"Question number {question.QNumber} Added");
                //            break;
                //        }
                //        else
                //        {
                //            questions[questionNumber] = question;
                //            question.QNumber = questionNumber;
                //            Console.WriteLine($"Question number {question.QNumber} Added");
                //            break;
                //        }
                //    }
                //}
                //else
                //    Console.WriteLine("Questions if full"); 
                #endregion

                #region try2
                //if (question.QNumber > questions.Length)
                //    Console.WriteLine("Questions if full");
                //else
                //{
                //    if (question.QNumber < 1)
                //        Console.WriteLine("Number Question must be > 0");
                //    else
                //    {

                //        for (int i = 0; i < questions.Length; i++)
                //        {
                //            if (questions[i] == null)
                //            {
                //                //Console.WriteLine($"Enter {i + 1} first");
                //                question.QNumber = i + 1;
                //                questions[i] = question;
                //                Console.WriteLine($"Question number {question.QNumber} Added");
                //                break;
                //            }
                //            //else
                //            //{
                //            //    questions[question.QNumber - 1] = question;
                //            //    Console.WriteLine($"Question number {question.QNumber} Added");
                //            //    break;
                //            //}
                //        }
                //    }
                //} 
                #endregion

                if (questions[questions.Length - 1] == null)
                {
                    for (int i = 0; i < questions.Length; i++)
                    {
                        if (questions[i] == null)
                        {
                            //Console.WriteLine($"Enter {i + 1} first");
                            question.QNumber = i + 1;
                            questions[i] = question;
                            //Console.WriteLine($"Question number {question.QNumber} Added");
                            //Console.WriteLine(question.CorrectAnswer.QAnswer);
                            answerList.AddCorrectAns(
                                question.CorrectAnswer.QCorrectAnswer ?? NoAnswer.NoAnswer);
                            //answerList.AddStudentAns(question?.StudentAnswer?.QStudentAnswer ?? NoAnswer.None);
                            break;
                        }
                        else
                            continue;
                    }
                }
                else
                    Console.WriteLine("Questions is full");
            }
            else
                Console.WriteLine("Wrong Question!!");
        }

        public void PrintQuestionsList()
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] != null)
                    Console.WriteLine(questions[i].QuestionFormat());
            }
        }

        public void PrintCorrectAnsList()
        {
            for (int i = 0; i < answerList.CorrectAnswers.Length; i++)
            {
                if (answerList.CorrectAnswers[i] != null)
                    Console.WriteLine(answerList.CorrectAnswers[i]);
            }
        }
    }
}
