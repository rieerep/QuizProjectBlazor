using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorQuiz.Server.Models
{
	public class FakeAnswerModel
	{
		public int Id { get; set; }

		[ForeignKey("Question")]
		public int Question { get; set; }

		public string FakeAnswers { get; set; }

	}
}
