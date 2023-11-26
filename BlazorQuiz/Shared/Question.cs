using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorQuiz.Server.Models
{
    public class Question : ComponentBase
    {
        public string QuestionTitle { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string Answer { get; set; } = string.Empty;

        //public Question(string questionTitle, string answer, List<string> options)
        //{
        //    QuestionTitle = questionTitle;
        //    Answer = answer;
        //    Options = options;
        //}
    }
}
