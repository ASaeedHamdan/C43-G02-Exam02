﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class FinalExam : Exam
    {
        public static List<Question> Create(int numQuestions)
        {
            var exam = new FinalExam();
            var questions = new List<Question>();


            string input;
            bool isValid;
            int questionType;
            int mark;
            int correctAnswer;

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"Please Choose The Type of Question Number ({i + 1}) (1 for True or False || 2 for MCQ):");
                do
                {
                    input = Console.ReadLine();
                    isValid = int.TryParse(input, out questionType);
                    if (!isValid || questionType <= 0 || questionType >= 3)
                    {
                        isValid = false;
                        Console.Write($"Invalid Input, Please Choose a Vaild Type of Question Number ({i + 1}) (1 for True or False || 2 for MCQ):");
                    }
                } while (!isValid);


                Console.Clear();
                string headMCQ = " Choose Correct Answer(1 or 2 or 3) for This Question";
                string headTF = "True Or False Question (1 for True or 2 for False)";
                Console.WriteLine("Please Enter the Body of Question:");
                string body = Console.ReadLine();

                Console.WriteLine("Please Enter the Marks of Question:");
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

                //   int mark = int.Parse(Console.ReadLine());


                if (questionType == 1)
                {
                    Console.WriteLine("Please Enter the Right Answer of Question (1 for True or 2 for False):");
                    //  int correctAnswer =  int.Parse(Console.ReadLine());
                    do
                    {
                        input = Console.ReadLine();
                        isValid = int.TryParse(input, out correctAnswer);
                        if (!isValid || correctAnswer <= 0 || correctAnswer >= 3)
                        {
                            isValid = false;
                            Console.Write("Invalid Input, Please Specify a Vaild Right Answer (1 for True or 2 for False):");
                        }
                    } while (!isValid);

                    questions.Add(new TFQuestion { Head = headTF, Body = body, Mark = mark, CorrectAnswerId = correctAnswer });
                }
                else if (questionType == 2)
                {
                    Console.WriteLine("Please Enter The Answers of Question:");
                    Answer[] answers = new Answer[3];
                    Answer answer = new Answer();
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("Please Enter the Answer Number " + (j + 1) + ":");
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

                    questions.Add(new MCQQuestion { Head = headMCQ, Body = body, Mark = mark, AnswerList = answers, CorrectAnswerId = correctAnswer });
                }
                Console.Clear();
            }
            return questions;
        }
    }
}
