using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{

    public class PracticalExam : Exam
    {

        // Method to create True/False question for Practical Exam
        private TrueFalseQuestion CreateTrueFalseQuestion()
        {
            Console.WriteLine("Enter the body of the True/False question:");
            string body = Console.ReadLine();

            Console.Write("Enter the mark for the question: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative integer for the mark.");
                Console.Write("Enter the mark for the question: ");
            }

            Console.WriteLine("Enter the correct answer (1 for True, 2 for False): ");
            int correctAnswer;
            while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2))
            {
                Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                Console.Write("Enter the correct answer (1 for True, 2 for False): ");
            }

            bool isTrue = correctAnswer == 1;

            TrueFalseQuestion tfQuestion = new TrueFalseQuestion
            {
                Header = "True/False Question",
                Body = body,
                Mark = mark,
                CorrectAnswer = isTrue
            };

            return tfQuestion;
        }

        // Method to create Multiple Choice question for Practical Exam
        private MCQQuestion CreateMultipleChoiceQuestion()
        {
            Console.WriteLine("Enter the body of the Multiple Choice question:");
            string body = Console.ReadLine();

            Console.Write("Enter the mark for the question: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative integer for the mark.");
                Console.Write("Enter the mark for the question: ");
            }

            Console.WriteLine("Enter the number of choices for the question:");
            int numChoices;
            while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of choices.");
                Console.Write("Enter the number of choices for the question:");
            }

            List<string> choices = new List<string>();
            for (int i = 0; i < numChoices; i++)
            {
                Console.Write($"Enter choice {i + 1}: ");
                choices.Add(Console.ReadLine());
            }

            Console.Write("Enter the index of the correct choice (1-based indexing): ");
            int correctIndex;
            while (!int.TryParse(Console.ReadLine(), out correctIndex) || correctIndex < 1 || correctIndex > numChoices)
            {
                Console.WriteLine($"Invalid input. Please enter an integer between 1 and {numChoices}.");
                Console.Write("Enter the index of the correct choice (1-based indexing): ");
            }

            MCQQuestion mcqQuestion = new MCQQuestion
            {
                Header = "Multiple Choice Question",
                Body = body,
                Mark = mark,
                Choices = choices,
                CorrectChoiceIndex = correctIndex - 1 // Adjust to 0-based index
            };

            return mcqQuestion;
        }

        // Method to add questions to the Practical Exam
        public void AddQuestions()
        {
            Console.WriteLine($"Adding {NumberOfQuestions} Multiple Choice questions to the Practical Exam:");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");

                // Defaulting to Multiple Choice question
                MCQQuestion mcqQuestion = CreateMultipleChoiceQuestion();
                Questions.AddQuestion(mcqQuestion);
                Console.WriteLine($"Added Multiple Choice question:");
                Console.WriteLine($"Body: {mcqQuestion.Body}");
                Console.WriteLine($"Mark: {mcqQuestion.Mark}");
                Console.WriteLine("Choices:");
                foreach (var choice in mcqQuestion.Choices)
                {
                    Console.WriteLine(choice);
                }
                Console.WriteLine($"Correct Choice Index: {mcqQuestion.CorrectChoiceIndex + 1}");
                Console.Clear();
            }
        }


        // Modify the ShowExam method in the PracticalExam class
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("PracticalExam:");
            Console.WriteLine("");

            int totalGrade = 0;
            int totalQuestions = 0;
            List<string> userAnswers = new List<string>();

            foreach (var question in Questions.Questions)
            {
                if (question is TrueFalseQuestion tfQuestion)
                {
                    Console.WriteLine("=======================================");
                    totalQuestions++;
                    Console.WriteLine($"Question {totalQuestions}: True/False        Mark({tfQuestion.Mark})");
                    Console.WriteLine($"{tfQuestion.Body}");
                    Console.WriteLine("(1-True / 2-False)");
                    Console.WriteLine("--------------------------------------");

                    // Take input from the user to answer the question
                    Console.Write("Your answer (1 or 2): ");
                    int userChoice;
                    while (!int.TryParse(Console.ReadLine(), out userChoice) || (userChoice != 1 && userChoice != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                        Console.Write("Your answer (1 or 2): ");
                    }

                    bool userAnswer = userChoice == 1;
                    bool correctAnswer = tfQuestion.CorrectAnswer;
                    Console.WriteLine($"Your answer: {(userAnswer ? "True" : "False")}");

                    // Check if the user's answer is correct
                    if (userAnswer == correctAnswer)
                    {

                        totalGrade += tfQuestion.Mark;
                    }
                    else
                    {
                        Console.WriteLine($"");
                    }
                    userAnswers.Add($"{tfQuestion.Body}-{(userAnswer ? "True" : "False")}");
                }

                else if (question is MCQQuestion mcqQuestion)
                {
                    Console.WriteLine("=======================================");
                    totalQuestions++;
                    Console.WriteLine($"Question{totalQuestions}: Multiple Choice        Mark({mcqQuestion.Mark})");
                    Console.WriteLine($"{mcqQuestion.Body}");
                    Console.WriteLine("Choices:");
                    for (int i = 0; i < mcqQuestion.Choices.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {mcqQuestion.Choices[i]}");
                    }
                    Console.WriteLine("---------------------------------------");

                    // Take input from the user to answer the question
                    Console.Write("Your choice (1, 2, 3, ...): ");
                    int userChoiceIndex;
                    while (!int.TryParse(Console.ReadLine(), out userChoiceIndex) || userChoiceIndex < 1 || userChoiceIndex > mcqQuestion.Choices.Count)
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between 1 and {mcqQuestion.Choices.Count}.");
                        Console.Write("Your choice (1, 2, 3, ...): ");
                    }

                    // Check if the user's answer is correct
                    if (userChoiceIndex - 1 == mcqQuestion.CorrectChoiceIndex)
                    {

                        totalGrade += mcqQuestion.Mark;
                    }
                    else
                    {
                        Console.WriteLine($"");
                    }
                    userAnswers.Add($"{mcqQuestion.Body}-{mcqQuestion.Choices[userChoiceIndex - 1]}  ");
                }
            }
            Console.Clear();
            Console.WriteLine("Exam Answers");
            Console.WriteLine("");
            Console.WriteLine($"Your exam Total grade is {totalGrade}");

            Console.WriteLine("==================================================");

            // Displaying correct answers
            Console.WriteLine("Correct Answers:");
            for (int i = 0; i < Questions.Questions.Count; i++)
            {
                var question = Questions.Questions[i];
                if (question is TrueFalseQuestion tfQuestion)
                {
                    Console.WriteLine($"Q{i + 1}:  {tfQuestion.Body}-{(tfQuestion.CorrectAnswer ? "True" : "False")}");
                }
                else if (question is MCQQuestion mcqQuestion)
                {
                    Console.WriteLine($"Q{i + 1}:  {mcqQuestion.Body}-{mcqQuestion.Choices[mcqQuestion.CorrectChoiceIndex]} ");
                }
            }
            Console.WriteLine("==================================================");

            // Displaying user's answers
            Console.WriteLine("Your Answers:");
            for (int i = 0; i < userAnswers.Count; i++)
            {
                Console.WriteLine($"Q{i + 1}: {userAnswers[i]}");
            }
        }
    }



}
