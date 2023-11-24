namespace BlazorQuiz.Server.Models
{
    public class Question
    {
        public string QuestionTitle { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string Answer { get; set; }

        public Question(string questionTitle, string answer, List<string> options)
        {
            QuestionTitle = questionTitle;
            Answer = answer;
            Options = options;
        }
    }
}
