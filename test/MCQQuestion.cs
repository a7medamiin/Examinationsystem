using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class MCQQuestion : QuestionBase
    {
        public List<string> Choices { get; set; }
        public int CorrectChoiceIndex { get; set; }
    }

}
