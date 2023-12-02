using create_a_quiz.Server.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorQuiz.Server.Models
{
    public class ScoreModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        public virtual QuizModel? Quiz { get; set; }

        [ForeignKey("Player")]
        public string UserId { get; set; }

        public virtual User? Player { get; set; }

        [Required]
        public int Score { get; set; }

    }
}
