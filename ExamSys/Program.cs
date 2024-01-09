namespace ExamSys
{
    internal class Program
    {
            static void Main(string[] args)
        {
            #region Tries
            //QuestionList questionlist = new QuestionList(10);

            //questionlist.AddQuestion(new TrueOrFalseQ("True or False", "1 + 2 = 3", 1
            //    , new Answer(TrueOrFalseAns.True)));
            //questionlist.AddQuestion(new TrueOrFalseQ("True or False", "2 + 2 = 4", 1
            //    , new Answer(TrueOrFalseAns.True)));
            //questionlist.AddQuestion(new TrueOrFalseQ("True or False", "3 + 2 = 3", 1
            //    , new Answer(TrueOrFalseAns.False)));
            //questionlist.AddQuestion(new TrueOrFalseQ("True or False", "3 + 2 = 3", 1
            //   , new Answer(TrueOrFalseAns.False)));

            //questionlist.AddQuestion(new ChooseOneQ("Choose One"
            //    , "1 + 2 =", 1, new Answer(ChooseOneAns.B), "3/4/5/6")); //must control choices

            //questionlist.AddQuestion(new MultiChoicesQ(header: "Multiple Choices"
            //    , "1 + 2 =", 1, new Answer(MultiChoiceAns.A ^ MultiChoiceAns.B), "3/4-1/5/7"));


            //Console.WriteLine("----------------------");
            //questionlist.PrintQList();
            //Console.WriteLine("----------------------");
            //questionlist.PrintCorrAnsList(); 
            #endregion

            #region TriesVr2
            //PracticeExam practiceExam = new PracticeExam("Math", 20, TimeSpan.Parse("10"), 10);
            //FinalExam finalExam = new FinalExam("Math", 10, TimeSpan.Parse("10"), 10);

            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("Choose One", "1 + 2 =", "B", choices: "3/4/5/6");
            ////practiceExam.AddExamQuestions("Multiple Choices", "1 + 2 =", "C", choices: "3/4-1/5/7");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            ////practiceExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");

            ////practiceExam.AddStudentAnswers(1, "True");

            ////practiceExam.ShowExam();
            ////practiceExam.PrintStudentFinalMark();

            //finalExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            //finalExam.AddExamQuestions("True or False", "1 + 2 = 3", "True");
            //finalExam.AddExamQuestions("Choose One", "1 + 2 =", "B", choices: "3/4/5/6");
            //finalExam.AddExamQuestions("Multiple Choices", "1 + 2 =", "C", choices: "3/4-1/5/7");

            //finalExam.AddStudentAnswers(1, "True");

            //finalExam.ShowExam();
            ////finalExam.PrintStudentFinalMark(); 
            #endregion

            #region Exam Informations
            string? examType;
            do
            {
                Console.WriteLine("Enter The Exam Type (P for practice type)::(F for final type)");
                examType = Console.ReadLine();
            }
            while (!(examType?.ToLower() == "p" || examType?.ToLower() == "f"));

            string? examSubject;
            do
            {
                Console.WriteLine("Enter The Exam Subject");
                examSubject = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(examSubject));

            double examMarks;
            do
            {
                Console.WriteLine("Enter The Exam Marks");
            }
            while (!double.TryParse(Console.ReadLine(), out examMarks));

            TimeSpan examTime;
            string? input;
            while (true)
            {
                char[] delimiterChars = { 'h', 'm' };

                Console.WriteLine("Enter The Exam Time in this Convention --> 00h00m");
                input = Console.ReadLine();
                if (!(input.Contains('h') && input.Contains('m')))
                    continue;
                else
                {
                    string[] time = input.Split(delimiterChars);
                    int checkHours, checkMinutes;
                    if (!int.TryParse(time[0], out checkHours) || !int.TryParse(time[1], out checkMinutes))
                        continue;
                    if (checkHours == 0 && checkMinutes == 0)
                        continue;
                    //foreach(string c in time) Console.Write($"{c}, ");
                    //Console.WriteLine();
                    //Console.WriteLine(time.Length);
                    examTime = new TimeSpan(hours: checkHours, minutes: checkMinutes, seconds: 0);
                    break;
                }
            }

            int numberOfQuestions = 0;
            do
            {
                Console.WriteLine("Enter Number Of Exam Questions");
            }
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions)); 
            #endregion

            
            if (examType.ToLower() == "p")
            {
                PracticeExam practiceExam = new PracticeExam(examSubject, examMarks, examTime, numberOfQuestions);
                ControlQuestions.ControlAddingQuestoins(practiceExam, numberOfQuestions);

                practiceExam.AddStudentAnswers(1, "True");

                practiceExam.ShowExam();
            }
            else
            {
                FinalExam finalExam = new FinalExam(examSubject, examMarks, examTime, numberOfQuestions);
                ControlQuestions.ControlAddingQuestoins(finalExam, numberOfQuestions);
            }
        }
    }
 }