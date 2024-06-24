using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; private set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        // Method to create the exam of the subject
        public void CreateExam()
        {
            Console.WriteLine("Choose the type of exam to create:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            Console.Write("Enter your choice (1 or 2): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Console.Write("Enter your choice (1 or 2): ");
            }

            if (choice == 1)
            {
                Console.Write("Enter the time of the exam in minutes: ");
                int timeInMinutes;
                while (!int.TryParse(Console.ReadLine(), out timeInMinutes) || timeInMinutes <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.Write("Enter the time of the exam in minutes: ");
                }

                Console.Write("Enter the number of questions for the exam: ");
                int numberOfQuestions;
                while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.Write("Enter the number of questions for the exam: ");
                }
                Console.Clear();



                Exam = new FinalExam
                {
                    Time = DateTime.Now,
                    NumberOfQuestions = numberOfQuestions,
                    AssociatedSubject = this,
                    
                };

                ((FinalExam)Exam).AddQuestions();
            }
            else if (choice == 2)
            {
                  Console.Write("Enter the time of the exam in minutes: ");
                int timeInMinutes;
                while (!int.TryParse(Console.ReadLine(), out timeInMinutes) || timeInMinutes <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.Write("Enter the time of the exam in minutes: ");
                }

                Console.Write("Enter the number of questions for the exam: ");
                int numberOfQuestions;
                while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.Write("Enter the number of questions for the exam: ");
                }
                Console.Clear();

                Exam = new PracticalExam
                {
                    Time = DateTime.Now,
                    NumberOfQuestions = numberOfQuestions,
                    AssociatedSubject = this
                };

                ((PracticalExam)Exam).AddQuestions();
            }
        }
    }


}
