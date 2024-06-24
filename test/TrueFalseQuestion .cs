using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    // Derived class for True or False question
    public class TrueFalseQuestion : QuestionBase
    {
        public bool IsTrue { get; set; }
        public int Mark { get; set; } // Added property for the mark
        public bool CorrectAnswer { get; set; } // Added property for the correct answer

        // Method to set the mark of the question
        public void SetMark(int mark)
        {
            Mark = mark;
        }

        // Method to get the mark of the question
        public int GetMark()
        {
            return Mark;
        }

        // Method to set the correct answer
        public void SetCorrectAnswer(bool correctAnswer)
        {
            CorrectAnswer = correctAnswer;
        }

        // Method to check if the provided answer is correct
        public bool IsAnswerCorrect(bool userAnswer)
        {
            return userAnswer == CorrectAnswer;
        }
    }

}
