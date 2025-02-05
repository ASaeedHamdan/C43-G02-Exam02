using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class MCQQuestion : Question
    {
        public override void ShowQuestion()
        {
            Console.WriteLine($"{Head} ---------> Question Marks ({Mark})");
            Console.WriteLine(Body);
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.Write($"{AnswerList[i].Id}. {AnswerList[i].Text}            ");
            }
            Console.WriteLine();
        }
    }

}
