﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace create_a_quiz.Server.Models
{
    public class QuestionModel
{
        [Key]
        public int Id { get; set; }

        [ForeignKey("Quiz")]
        public int Fk_QuizId { get; set; }
        public virtual QuizModel? Quiz { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Media { get; set; }

    }
}