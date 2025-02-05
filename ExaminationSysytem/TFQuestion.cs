using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class TFQuestion : Question
    {
        public override void ShowQuestion()
        {
            Console.WriteLine($"{Head}  Mark({Mark})");
            Console.WriteLine(Body);
        }
    }

}
