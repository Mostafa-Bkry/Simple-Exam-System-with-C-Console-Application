using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class ControlQuestions
    {
        public static void ControlAddingQuestoins(Exam exam, int numberOfQuestions)
        {
            int questionType, trueORfalse, multiCheck;
            string? questionBody, correctAnswer, choices;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                do
                {
                    Console.WriteLine("Choose number from these question types:");
                    Console.WriteLine("(1) True or False  (2) Choose One  (3) Multi Choices");
                }
                while (!int.TryParse(Console.ReadLine(), out questionType));

                if (questionType > 0 && questionType < 4)
                {
                    switch (questionType)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Enter The Question Body");
                                questionBody = Console.ReadLine();
                            }
                            while (string.IsNullOrWhiteSpace(questionBody));

                            while (true)
                            {
                                Console.WriteLine("Enter The Correct Answer (1 if True) or (2 if False)");
                                if (int.TryParse(Console.ReadLine(), out trueORfalse))
                                    if (trueORfalse == 1 || trueORfalse == 2)
                                        break;
                            }

                            exam.AddExamQuestions("True or False", questionBody, trueORfalse == 1 ? "True" : "False"); //"1 + 2 = 3"

                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("Enter The Question Body");
                                questionBody = Console.ReadLine();
                            }
                            while (string.IsNullOrWhiteSpace(questionBody));

                            while (true)
                            {
                                Console.WriteLine("Enter The Choices (A) (B) (C) (D) in this convention --> .../.../.../...");
                                choices = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(choices))
                                {
                                    string[] check = choices.Split('/');
                                    if (check.Length == 4)
                                        break;
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Enter The Correct Answer (A) or (B) or (C) or (D)");
                                correctAnswer = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(correctAnswer))
                                    if (correctAnswer?.ToUpper() == "A" || correctAnswer?.ToUpper() == "B"
                                        || correctAnswer?.ToUpper() == "C" || correctAnswer?.ToUpper() == "D")
                                        break;
                            }
                            exam.AddExamQuestions("Choose One", questionBody, correctAnswer.ToUpper(), choices: choices);//"1 + 2 ="
                            break;
                        case 3:
                            do
                            {
                                Console.WriteLine("Enter The Question Body");
                                questionBody = Console.ReadLine();
                            }
                            while (string.IsNullOrWhiteSpace(questionBody));

                            while (true)
                            {
                                Console.WriteLine("Enter The Choices (A) (B) (C) (D) in this convention --> .../.../.../...");
                                choices = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(choices))
                                {
                                    string[] check = choices.Split('/');
                                    if (check.Length == 4)
                                        break;
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Enter The Correct Answer number " +
                                    "1(A) or 2(B) or 3(C) or 4(A&B) or 5(A&C) or 6(B&C) or 7(All) or 8(NonOfAll)");
                                if (int.TryParse(Console.ReadLine(), out multiCheck))
                                    if (multiCheck > 0 && multiCheck < 9)
                                    {
                                        switch (multiCheck)
                                        {
                                            case 1:
                                                correctAnswer = "A"; break;
                                            case 2:
                                                correctAnswer = "B"; break;
                                            case 3:
                                                correctAnswer = "D"; break;
                                            case 4:
                                                correctAnswer = "A&B"; break;
                                            case 5:
                                                correctAnswer = "A&C"; break;
                                            case 6:
                                                correctAnswer = "B&C"; break;
                                            case 7:
                                                correctAnswer = "All"; break;
                                            case 8:
                                                correctAnswer = "NonOfAll"; break;
                                            default:
                                                correctAnswer = "NA";
                                                break;
                                        }
                                        break;
                                    }
                            }
                            exam.AddExamQuestions("Multiple Choices", questionBody, correctAnswer, choices: "3/4-1/5/7");//"1 + 2 ="
                            break;
                    }
                }
                else
                    Console.WriteLine("Wrong Questoin Type (Must be 1 or 2 or 3)");
            }
        }

    }
}
