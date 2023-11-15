using BlazorQuiz.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace create_a_quiz.Server.Models 
{
    public class QuizModel
    {
        [Key]
        public int Id { get; set; }

        public Guid PublicId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public virtual User? User { get; set; }
        public ICollection<QuestionModel> Questions { get; set; }
    }
}