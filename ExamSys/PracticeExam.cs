using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSys
{
    internal class PracticeExam : Exam
    {
        QuestionList questionlist;
        AnswerList answerlist;
        double markForEachQ;

        public PracticeExam(string subjectName, double subExamMark, TimeSpan time, int numOfQuestions) 
            : base(subjectName, subExamMark, time, numOfQuestions)
        {
            questionlist = new QuestionList(NumberOfQuestions);
            answerlist = new AnswerList(NumberOfQuestions);
            markForEachQ = subExamMark / (numOfQuestions <= 0 ? 1 : numOfQuestions);
        }

        public override void AddExamQuestions(string questionHeader, string questionBody
            ,string correctAns, /*string studentAns,*/ string? choices = null) 
        {
            #region ImplementationVr1
            //int counter = 1;
            //while(NumberOfQuestions > 0)
            //{
            //    if (questionHeader == "True or False")
            //    {
            //        Console.WriteLine($"Enter Question {counter}");

            //        //Enum correctAnswer = correctAns == "True"? TrueOrFalseAns.True : TrueOrFalseAns.False;
            //        questionlist.AddQuestion(new TrueOrFalseQ(questionHeader, questionBody
            //            , markForEachQ
            //            , new Answer
            //            (correctAns == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False)));

            //        NumberOfQuestions--;
            //        counter++;
            //        if (NumberOfQuestions == 0)
            //            Console.WriteLine("End of Questions");
            //    }
            //    else if (questionHeader == "Choose One")
            //    {
            //        Console.WriteLine($"Enter Question {counter}");

            //        Enum? correctAnswer = default;

            //        switch (correctAns)
            //        {
            //            case "A":
            //                correctAnswer = ChooseOneAns.A; break;
            //            case "B":
            //                correctAnswer = ChooseOneAns.B; break;
            //            case "C":
            //                correctAnswer = ChooseOneAns.C; break;
            //            case "D":
            //                correctAnswer = ChooseOneAns.D; break;
            //            default: break;
            //        }

            //        questionlist.AddQuestion(new ChooseOneQ(questionHeader, questionBody, markForEachQ
            //            , new Answer(correctAnswer ?? ChooseOneAns.A), choices ?? "NA/NA/NA/NA"));

            //        NumberOfQuestions--;
            //        counter++;
            //        if (NumberOfQuestions == 0)
            //            Console.WriteLine("End of Questions");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Enter Question {counter}");

            //        Enum? correctAnswer = default;

            //        switch (correctAns)
            //        {
            //            case "A":
            //                correctAnswer = MultiChoiceAns.A; break;
            //            case "B":
            //                correctAnswer = MultiChoiceAns.B; break;
            //            case "C": // A & B
            //                correctAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B; break;
            //            case "D":
            //                correctAnswer = MultiChoiceAns.D; break;
            //            case "All": // C & D
            //                correctAnswer = MultiChoiceAns.C ^ MultiChoiceAns.D; break;
            //            case "NonOfAll":
            //                correctAnswer = MultiChoiceAns.NonOfAll; break;
            //            default: break;
            //        }

            //        questionlist.AddQuestion(new MultiChoicesQ(questionHeader, questionBody, markForEachQ
            //            , new Answer(correctAnswer ?? MultiChoiceAns.NonOfAll)
            //            , choices ?? "NA/NA/NA/NA"));

            //        NumberOfQuestions--;
            //        counter++;
            //        if (NumberOfQuestions == 0)
            //            Console.WriteLine("End of Questions");
            //    }
            //} 
            #endregion

            if (questionHeader == "True or False")
            {
                //Console.WriteLine("Enter Question:");

                questionlist.AddQuestion(new TrueOrFalseQ(questionHeader, questionBody
                    , markForEachQ
                    , new Answer
                    (qCorrectAnswer: correctAns == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False)
                    //, new Answer
                    //(qStudentAnswer: AddStudentAnswers(-1))
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
                    //, new Answer
                    //(qStudentAnswer: AddStudentAnswers(-1))
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
                    case "D":
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
                    //, new Answer
                    //(qStudentAnswer: AddStudentAnswers(-1))
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

        public override void AddStudentAnswers(/*string questionHeader = "None", */int questionNumber, string studentAnswer = "None")
        {
            if(questionNumber < 0 || questionNumber > questionlist.NumberOfQuestions)
            {
                Console.WriteLine("Wrong question Number (Not Exist)");
                //return NoAnswer.None;
            }
            else
            {
                for (int i = 0; i < questionlist.questions.Length; i++)
                {
                    if (questionlist.questions[i].QNumber == questionNumber)
                    {
                        if (questionlist.questions[i].Header == "True or False")
                        {
                            //Console.WriteLine("Enter your Answer:");
                            answerlist.AddStudentAns(
                                studentAnswer == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False);
                            //questionlist.questions[i].StudentAnswer =
                            //    new Answer
                            //    (studentAnswer == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False);
                            break;
                        }
                        else if (questionlist.questions[i].Header == "Choose One")
                        {
                            //Console.WriteLine($"Enter your Answer:");

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
                            //questionlist.questions[i].StudentAnswer =
                            //    new Answer( studAnswer ?? ChooseOneAns.A);
                            break;
                        }
                        else /*if (questionlist.questions[i].Header == "Multiple Choices")*/
                        {
                            //Console.WriteLine($"Enter your Answer:");

                            Enum? studAnswer = default;

                            switch (studentAnswer)
                            {
                                case "A":
                                    studAnswer = MultiChoiceAns.A; break;
                                case "B":
                                    studAnswer = MultiChoiceAns.B; break;
                                case "D":
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
                            //questionlist.questions[i].StudentAnswer =
                            //    new Answer(studAnswer ?? MultiChoiceAns.NonOfAll);
                            break;
                        }
                        //else
                        //{
                        //    answerlist.AddStudentAns(NoAnswer.None);
                        //    //questionlist.questions[i].StudentAnswer =
                        //    //    new Answer(NoAnswer.None);
                        //    break;
                        //}
                    }
                }
            }
            

            #region Not right
            //if (questionHeader == "True or False")
            //{
            //    Console.WriteLine("Enter your Answer:");

            //    return studentAnswer == "True" ? TrueOrFalseAns.True : TrueOrFalseAns.False;
            //}
            //else if (questionHeader == "Choose One")
            //{
            //    Console.WriteLine($"Enter your Answer:");

            //    Enum? studAnswer = default;

            //    switch (studentAnswer)
            //    {
            //        case "A":
            //            studAnswer = ChooseOneAns.A; break;
            //        case "B":
            //            studAnswer = ChooseOneAns.B; break;
            //        case "C":
            //            studAnswer = ChooseOneAns.C; break;
            //        case "D":
            //            studAnswer = ChooseOneAns.D; break;
            //        default: break;
            //    }

            //    return studAnswer ?? ChooseOneAns.A;
            //}
            //else if ( questionHeader == "Multiple Choices")
            //{
            //    Console.WriteLine($"Enter your Answer:");

            //    Enum? studAnswer = default;

            //    switch (studentAnswer)
            //    {
            //        case "A":
            //            studAnswer = MultiChoiceAns.A; break;
            //        case "B":
            //            studAnswer = MultiChoiceAns.B; break;
            //        case "C": // A & B
            //            studAnswer = MultiChoiceAns.A ^ MultiChoiceAns.B; break;
            //        case "D":
            //            studAnswer = MultiChoiceAns.D; break;
            //        case "All": // C & D
            //            studAnswer = MultiChoiceAns.C ^ MultiChoiceAns.D; break;
            //        case "NonOfAll":
            //            studAnswer = MultiChoiceAns.NonOfAll; break;
            //        default: break;
            //    }

            //    return studAnswer ?? MultiChoiceAns.NonOfAll;
            //}
            //else { return NoAnswer.None;} 
            #endregion
        }

        protected override void PrintStudentAnsList()
        {
            for (int i = 0; i < answerlist.StudentAnswers.Length; i++)
            {
                if (answerlist.StudentAnswers[i] != null)
                    Console.WriteLine(answerlist.StudentAnswers[i]);
                else if (questionlist.questions[i] == null)
                    break;
                else
                    Console.WriteLine("No Answer");

            }
        }

        protected override void PrintStudentFinalMark()
        {
            double rightAnswersCount = 0;
            for(int i = 0; i <answerlist.CorrectAnswers.Length; i++)
            {
                if (answerlist.StudentAnswers[i] != null 
                    && questionlist.questions[i].CorrectAnswer.QCorrectAnswer != null)
                {
                    if(answerlist.StudentAnswers[i].Equals(
                        questionlist.questions[i].CorrectAnswer.QCorrectAnswer))
                       rightAnswersCount += markForEachQ;
                }
            }
            Console.WriteLine("-----------Student Marks------------");
            Console.WriteLine($"{rightAnswersCount} from {SubjectExamMark}");
        }

        internal override void ShowExam() //show Questions, Student Answers, Correct Answers
        {
            Console.WriteLine("-----------Questions-----------");
            questionlist.PrintQuestionsList();
            Console.WriteLine("-----------Correct Answers-----------");
            questionlist.PrintCorrectAnsList();
            Console.WriteLine("-----------Student Answers-----------");
            PrintStudentAnsList();
            PrintStudentFinalMark();
        }
    }
}
