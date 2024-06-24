using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test
{
    public abstract class Exam
    {
        public DateTime Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject AssociatedSubject { get; set; }
        public QuestionList Questions { get; } = new QuestionList(); // Added

        // Abstract method to show exam functionality
        public abstract void ShowExam();
    }


}
