using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class FinalExam : Exam
    {
        QuestionList questionlist;
        AnswerList answerlist;
        double markForEachQ;

        public FinalExam(string subjectName, double subExamMark, TimeSpan time, int numOfQuestions) 
            : base(subjectName, subExamMark, time, numOfQuestions)
        {
            questionlist = new QuestionList(NumberOfQuestions);
            answerlist = new AnswerList(NumberOfQuestions);
            markForEachQ = subExamMark / (numOfQuestions <= 0 ? 1 : numOfQuestions);
        }

        public override void AddExamQuestions(string questionHeader, string questionBody
            , string correctAns, string? choices = null)
        {
            if (questionHeader == "True or False")
            {
                //Console.WriteLine("Enter Question:");

                questionlist.AddQuestion(new TrueOrFalseQ(questionHeader, questionBody
                    , markForEachQ
                    , new Answer
                    (qCorrectAnswer: correctAns == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False)
                    ));

                NumberOfQuestions--;
                if (NumberOfQuestions == 0)
                    Console.WriteLine("End of Questions");
            }
            else if (questionHeader == "Choose One")
            {
                //Console.WriteLine($"Enter Question:");

                Enum? correctAnswer = default;

                switch (correctAns)
                {
                    case "A":
                        correctAnswer = ChooseOneAns.A; break;
                    case "B":
                        correctAnswer = ChooseOneAns.B; break;
                    case "C":
                        correctAnswer = ChooseOneAns.C; break;
                    case "D":
                        correctAnswer = ChooseOneAns.D; break;
                    default: break;
                }

                questionlist.AddQuestion(new ChooseOneQ(questionHeader, questionBody, markForEachQ
                    , new Answer(qCorrectAnswer: correctAnswer ?? ChooseOneAns.A)
                    , choices ?? "NA/NA/NA/NA"
                    ));

                NumberOfQuestions--;
                if (NumberOfQuestions == 0)
                    Console.WriteLine("End of Questions");
            }
            else if (questionHeader == "Multiple Choices")
            {
                //Console.WriteLine($"Enter Question:");

                Enum? correctAnswer = default;

                switch (correctAns)
                {
                    case "A":
                        correctAnswer = MultiChoiceAns.A; break;
                    case "B":
                        correctAnswer = MultiChoiceAns.B; break;
                    case "C":
                        correctAnswer = MultiChoiceAns.C; break;
                    case "A&B":
                        correctAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B; break;
                    case "A&C":
                        correctAnswer = MultiChoiceAns.A ^ MultiChoiceAns.C; break;
                    case "B&C":
                        correctAnswer = MultiChoiceAns.B ^ MultiChoiceAns.C; break;
                    case "All":
                        correctAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B ^ MultiChoiceAns.C; break;
                    case "NonOfAll":
                        correctAnswer = MultiChoiceAns.NonOfAll; break;
                    default:
                        correctAnswer = NoAnswer.NoAnswer;
                        break;
                    
                }

                questionlist.AddQuestion(new MultiChoicesQ(questionHeader, questionBody, markForEachQ
                    , new Answer(qCorrectAnswer: correctAnswer ?? MultiChoiceAns.NonOfAll)
                    , choices ?? "NA/NA/NA/NA"
                    ));

                NumberOfQuestions--;
                if (NumberOfQuestions == 0)
                    Console.WriteLine("End of Questions");
            }
            else
            {
                Console.WriteLine("Wrong Question (Not Listed)");
            }
        }

        public override void AddStudentAnswers(int questionNumber, string studentAnswer = "None")
        {
            if (questionNumber < 0 || questionNumber > questionlist.NumberOfQuestions)
            {
                Console.WriteLine("Wrong question Number (Not Exist)");
            }
            else
            {
                int trueORfalse, multiCheck;
                string? oneCheck;
                for (int i = 0; i < questionlist.questions.Length; i++)
                {
                    if (questionlist.questions[i].QNumber == questionNumber)
                    {
                        if (questionlist.questions[i].Header == "True or False")
                        {
                            //Console.WriteLine("Enter your Answer:");

                            while (true)
                            {
                                Console.WriteLine("Enter The Answer (1 if True) or (2 if False)");
                                if (int.TryParse(Console.ReadLine(), out trueORfalse))
                                    if (trueORfalse == 1 || trueORfalse == 2)
                                    {
                                        if (trueORfalse == 1)
                                            studentAnswer = "True";
                                        else
                                            studentAnswer = "False";
                                        break;
                                    }
                            }

                            answerlist.AddStudentAns(
                                studentAnswer == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False);
                            break;
                        }
                        else if (questionlist.questions[i].Header == "Choose One")
                        {
                            //Console.WriteLine($"Enter your Answer:");

                            while (true)
                            {
                                Console.WriteLine("Enter The Correct Answer (A) or (B) or (C) or (D)");
                                oneCheck = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(oneCheck))
                                    if (oneCheck?.ToUpper() == "A" || oneCheck?.ToUpper() == "B"
                                        || oneCheck?.ToUpper() == "C" || oneCheck?.ToUpper() == "D")
                                    {
                                        studentAnswer = oneCheck;
                                        break;
                                    }
                            }

                            Enum? studAnswer = default;

                            switch (studentAnswer)
                            {
                                case "A":
                                    studAnswer = ChooseOneAns.A; break;
                                case "B":
                                    studAnswer = ChooseOneAns.B; break;
                                case "C":
                                    studAnswer = ChooseOneAns.C; break;
                                case "D":
                                    studAnswer = ChooseOneAns.D; break;
                                default: break;
                            }
                            answerlist.AddStudentAns(studAnswer ?? ChooseOneAns.A);
                            break;
                        }
                        else
                        {
                            //Console.WriteLine($"Enter your Answer:");

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
                                                studentAnswer = "A"; break;
                                            case 2:
                                                studentAnswer = "B"; break;
                                            case 3:
                                                studentAnswer = "D"; break;
                                            case 4:
                                                studentAnswer = "A&B"; break;
                                            case 5:
                                                studentAnswer = "A&C"; break;
                                            case 6:
                                                studentAnswer = "B&C"; break;
                                            case 7:
                                                studentAnswer = "All"; break;
                                            case 8:
                                                studentAnswer = "NonOfAll"; break;
                                            default:
                                                studentAnswer = "NA";
                                                break;
                                        }
                                        break;
                                    }
                            }

                            Enum? studAnswer = default;

                            switch (studentAnswer)
                            {
                                case "A":
                                    studAnswer = MultiChoiceAns.A; break;
                                case "B":
                                    studAnswer = MultiChoiceAns.B; break;
                                case "C":
                                    studAnswer = MultiChoiceAns.C; break;
                                case "A&B":
                                    studAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B; break;
                                case "A&C":
                                    studAnswer = MultiChoiceAns.A ^ MultiChoiceAns.C; break;
                                case "B&C":
                                    studAnswer = MultiChoiceAns.B ^ MultiChoiceAns.C; break;
                                case "All":
                                    studAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B ^ MultiChoiceAns.C; break;
                                case "NonOfAll":
                                    studAnswer = MultiChoiceAns.NonOfAll; break;
                                default:
                                    studAnswer = NoAnswer.NoAnswer;
                                    break;
                            }
                            answerlist.AddStudentAns(studAnswer ?? MultiChoiceAns.NonOfAll);
                            break;
                        }
                    }
                }
            }
        }

        public override void ShowQuestionToStudentToAnswer(int questionNumber)
        {
            for (int i = 0; i < questionlist.questions.Length; i++)
            {
                if (questionlist.questions[i].QNumber == questionNumber)
                {
                    Console.WriteLine(questionlist.questions[i].QuestionFormat());
                    break;
                }
            }
        }

        protected override void PrintStudentAnsList()
        {
            for (int i = 0; i < answerlist.StudentAnswers.Length; i++)
            {
                if (answerlist.StudentAnswers[i] != null)
                    Console.WriteLine(answerlist.StudentAnswers[i]);
                else if (questionlist.questions[i] == null) // handel to show the answers number equal to number of questions
                    break;
                else
                    Console.WriteLine("No Answer");
            }
        }

        protected override void PrintStudentFinalMark()
        {
            double rightAnswersCount = 0;
            for (int i = 0; i < answerlist.CorrectAnswers.Length; i++)
            {
                if (answerlist.StudentAnswers[i] != null 
                    && questionlist.questions[i].CorrectAnswer.QCorrectAnswer != null)
                {
                    if (answerlist.StudentAnswers[i].Equals(
                        questionlist.questions[i].CorrectAnswer.QCorrectAnswer))
                        rightAnswersCount += markForEachQ;
                }
            }
            Console.WriteLine("-----------Student Marks------------");
            Console.WriteLine($"{rightAnswersCount} from {SubjectExamMark}");
        }

        internal override void ShowExam() //show Questions, Student Answers only
        {
            Console.WriteLine("-----------Questions-----------");
            questionlist.PrintQuestionsList();
            Console.WriteLine("-----------Student Answers-----------");
            PrintStudentAnsList();
            PrintStudentFinalMark();
        }
    }
}
