using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class PracticalExam : Exam
    {

        public static List<Question> Create(int numQuestions)
        {
            var questions = new List<Question>();
            string input;
            bool isValid;
            int mark;
            int correctAnswer;
            for (int i = 0; i < numQuestions; i++)
            {
                string head = " Choose Correct Answer(1 or 2 or 3) for This Question";
                Console.WriteLine($"Please Enter the Body of Question {i + 1}:");
                string body = Console.ReadLine();
                Console.WriteLine("Please Enter the Marks of This Question:");
                do
                {
                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out mark);
                    if (!isValid || mark <= 0)
                    {
                        isValid = false;
                        Console.Write("Invalid Input, Please Enter a Vaild Marks of This Question: ");
                    }
                } while (!isValid);

                Console.WriteLine("Please Enter The Answers of This Question:");
                Answer[] answers = new Answer[3];
                Answer answer = new Answer();
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Please Enter the Answer Number " + (j + 1) + ": ");
                    answer.Id = j + 1;
                    answer.Text = Console.ReadLine();

                    answers[j] = answer;
                    answer = new Answer();
                }
                Console.WriteLine("Please Specify the Right Answer (1 or 2 or 3) of This Question:");
                do
                {
                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out correctAnswer);
                    if (!isValid || correctAnswer <= 0 || correctAnswer >= 4)
                    {
                        isValid = false;
                        Console.Write("Invalid Input, Please Specify a Vaild Right Answer (1 or 2 or 3) of This Question: ");
                    }
                } while (!isValid);

                questions.Add(new MCQQuestion { Head = head, Body = body, Mark = mark, AnswerList = answers, CorrectAnswerId = correctAnswer });
            }
            return questions;
        }
    }
}
