using create_a_quiz.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlazorQuiz.Server.Models
{
	public class FakeAnswerModel
	{
		public int Id { get; set; }

		[ForeignKey("QuestionId")]
		public int QuestionId { get; set; }

		public virtual QuestionModel? Questions { get; set; }

		[AllowNull]
		public string? FakeAnswer { get; set; }

	}
}
