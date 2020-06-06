using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveLearningFramework.ViewModels
{
    public class QuizVm
    {
    }
    public class QuestionVM
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string Description { get; set; }
        public string Anwser { get; set; }

        public ICollection<ChoiceVM> Choices { get; set; }
    }
    public class ChoiceVM
    {
        public int ChoiceID { get; set; }
        public string ChoiceText { get; set; }
    }
}
