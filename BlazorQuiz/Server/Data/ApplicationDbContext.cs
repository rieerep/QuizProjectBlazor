using BlazorQuiz.Server.Models;
using create_a_quiz.Server.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorQuiz.Server.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<User>
	{
		public DbSet<QuizModel> Quizzes { get; set; }

		public DbSet<QuestionModel> Questions { get; set; }

		public DbSet<FakeAnswerModel> FakeAnswers { get; set; }

        public DbSet<GameModel> GameModels { get; set; }

        public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}
	}
}