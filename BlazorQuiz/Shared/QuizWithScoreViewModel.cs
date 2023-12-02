using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorQuiz.Shared
{
    public class QuizWithScoreViewModel
    {
        public string Title { get; set; }
        public Guid PublicId { get; set; }
        public int Score { get; set; }
    }
}
