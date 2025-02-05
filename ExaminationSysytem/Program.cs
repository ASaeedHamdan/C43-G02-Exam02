using System.Diagnostics;

namespace ExaminationSysytem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new Subject(10, "Programming");
            sub.CreateExam();

            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n):");
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sub.StartExam();
                Console.WriteLine($"The Elapsed Time = {stopwatch.Elapsed}");
            }
            else
                Console.WriteLine("Thank you");
        }
    }
    
}
