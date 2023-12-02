using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorQuiz.Shared
{
    public class QuestionViewModel : ComponentBase
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public string PublicId { get; set; }

        public int TimeLimit {  get; set; }

        public string[] FakeAnswers { get; set; }

        public string MediaURL { get; set; }

        public bool HasMultipleAnswers { get; set; }

        public List<QuizViewModel> QuizTitle { get; set; }


    }
}
