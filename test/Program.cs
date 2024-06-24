using System.Diagnostics;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C#");
            sub1.CreateExam();
            Console.Clear();
            Console.Write("Do you want to start the exam (y/n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub1.Exam.ShowExam();
                Console.WriteLine($"Elapsed Time: {sw.Elapsed}");
            }
        }
    }
}
