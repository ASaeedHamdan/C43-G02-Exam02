using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class Subject
    {
        #region Attributes
        private int id;
        private string? name;

        private List<Question> subjectQuestions;
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Question> SubjectQuestions
        {
            get { return subjectQuestions; }
            set { subjectQuestions = value; }
        }
        #endregion
        #region Constructor
        public Subject(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
        #endregion
        #region Methods
        public void CreateExam()
        {
            string input;
            bool isValid;
            int ExamType;
            Console.Write("Enter Type Of Exam (1 for Practical OR 2 for Final ): ");
            do
            {
                input = Console.ReadLine();
                isValid = int.TryParse(input, out ExamType);
                if (!isValid || ExamType <= 0 || ExamType >= 3)
                {
                    isValid = false;
                    Console.Write("Invalid Input, Please Enter a Vaild Type Of Exam (1 for Practical OR 2 for Final ): ");
                }
            } while (!isValid);

            Exam exam = new Exam();

            Console.Write("Enter The Time Of Exam in Minutes: ");
            do
            {
                input = Console.ReadLine();
                isValid = int.TryParse(input, out int time);
                if (!isValid || time <= 0)
                {
                    isValid = false;
                    Console.Write("Invalid Input, Please Enter a Vaild Time Of Exam in Minutes: ");
                }
                else
                    exam.Time = time;
            } while (!isValid);


            Console.Write("Enter The Number Of Question in The Exam: ");
            do
            {
                input = Console.ReadLine();
                isValid = int.TryParse(input, out int numOfQ);
                if (!isValid || numOfQ <= 0)
                {
                    isValid = false;
                    Console.Write("Invalid Input, Please Enter a Vaild Number Of Question in The Exam: ");
                }
                else
                    exam.NumOfQuestion = numOfQ;
            } while (!isValid);


            if (ExamType == 1)//Practical
            {

                SubjectQuestions = PracticalExam.Create(exam.NumOfQuestion);
            }
            else ////Final
            {
                SubjectQuestions = FinalExam.Create(exam.NumOfQuestion);
            }
        }

        public void StartExam()
        {
            int totalMarks = 0;
            var questionAnswerUsers = new List<QuestionAnswerUser>();
            foreach (var question in SubjectQuestions)
            {
                question.ShowQuestion();
                Console.WriteLine("------------------------------------");

                string userAnswer;// = Console.ReadLine();
                bool isCorrect = false;
                bool isValid;
                int choice;

                if (question is TFQuestion)
                {
                    do
                    {
                        userAnswer = Console.ReadLine();
                        isValid = int.TryParse(userAnswer, out choice);
                        if (!isValid || choice <= 0 || choice >= 3)
                        {
                            isValid = false;
                            Console.Write("Invalid Input, Please Choose Correct Answer ( 1 for True or 2 for False ) for This Question");
                        }
                    } while (!isValid);

                    if ((userAnswer == "1" && question.CorrectAnswerId == 1) || (userAnswer == "2" && question.CorrectAnswerId == 2))
                    {
                        isCorrect = true;
                    }
                }
                else  // this question will be  MCQQuestion
                {
                    do
                    {
                        userAnswer = Console.ReadLine();
                        isValid = int.TryParse(userAnswer, out choice);
                        if (!isValid || choice <= 0 || choice >= 4)
                        {
                            isValid = false;
                            Console.WriteLine("Invalid Input, Please Choose Correct Answer (1, 2 or 3) for This Question");
                        }
                    } while (!isValid);

                    if (choice == question.CorrectAnswerId)
                        isCorrect = true;
                    else
                        isCorrect = false;
                }


                totalMarks += isCorrect ? question.Mark : 0;
                if (question is TFQuestion)
                {

                    if (isCorrect == true)
                    {
                        if (userAnswer == "1")
                            questionAnswerUsers.Add(new QuestionAnswerUser { Question = question.Body, UserAnswer = "True", IsCorrect = isCorrect });
                        else
                            questionAnswerUsers.Add(new QuestionAnswerUser { Question = question.Body, UserAnswer = "False", IsCorrect = isCorrect });
                    }
                    else  //isCorrect==false
                    {
                        if (userAnswer == "1")
                            questionAnswerUsers.Add(new QuestionAnswerUser { Question = question.Body, UserAnswer = "True", IsCorrect = isCorrect, CorrectAnswer = isCorrect ? "" : "False" });
                        else
                            questionAnswerUsers.Add(new QuestionAnswerUser { Question = question.Body, UserAnswer = "False", IsCorrect = isCorrect, CorrectAnswer = isCorrect ? "" : "True" });
                    }


                }
                else if (question is MCQQuestion)
                {
                    questionAnswerUsers.Add(new QuestionAnswerUser { Question = question.Body, UserAnswer = question.AnswerList.Where(x => x.Id.ToString() == userAnswer).FirstOrDefault().Text, IsCorrect = isCorrect, CorrectAnswer = question.AnswerList.Where(x => x.Id == question.CorrectAnswerId).FirstOrDefault().Text });

                }


                Console.WriteLine("===============================");
            }

           
            Console.Clear();

            Console.WriteLine("Your Answers:");
            for (int i = 0; i < questionAnswerUsers.Count; i++)
            {
                if (questionAnswerUsers[i].IsCorrect)
                    Console.WriteLine("Q" + (i + 1) + ") " + questionAnswerUsers[i].Question + ": " + questionAnswerUsers[i].UserAnswer + " ( " + questionAnswerUsers[i].IsCorrect + " answer )");
                else
                    Console.WriteLine("Q" + (i + 1) + ") " + questionAnswerUsers[i].Question + ": " + questionAnswerUsers[i].UserAnswer + " ( " + questionAnswerUsers[i].IsCorrect + " answer )" );
                    
                
                   Console.WriteLine(" (Correct Answer is: " + questionAnswerUsers[i].CorrectAnswer + ")");
            }
            Console.WriteLine("Your Exam Grade is " + totalMarks + " from " + SubjectQuestions.Sum(x => x.Mark) + ".");
        } 
        #endregion
    }
}
