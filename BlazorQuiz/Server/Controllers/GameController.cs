using BlazorQuiz.Server.Data;
using BlazorQuiz.Server.Models;
using BlazorQuiz.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorQuiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public GameController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST api/<CreateQuizController>
        [HttpPost("endgame")]
        public async Task<IActionResult> Post([FromBody] EndgameViewModel endgame)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var _quiz = _context.Quizzes.Where(x => x.PublicId == endgame.PublicId).FirstOrDefault();
            var quiz = new GameModel
            {
                UserId = userId,
                Score = endgame.Score,
                QuizId = _quiz.Id
            };
            _context.GameModels.Add(quiz);
            _context.SaveChanges();

            // QuizViewModel newQuizId = new QuizViewModel() { PublicId = quiz.PublicId };

            // QuizTitleViewModel newQuizId = new QuizTitleViewModel() { PublicId = quiz.PublicId };
            return Ok();
        }
    }
}
