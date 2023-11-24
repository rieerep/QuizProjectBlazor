using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorQuiz.Shared
{
	public class QuizViewModel
	{
		public Guid PublicId { get; set; }
		public string? Title { get; set; }

		//public List<QuestionViewModel> Question { get; set; }
	}
}
