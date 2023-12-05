using BlazorQuiz.Server.Data;
using BlazorQuiz.Server.Models;
using BlazorQuiz.Shared;
using create_a_quiz.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorQuiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ScoreController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET api/get
        [HttpGet("get")]
        public async Task<IEnumerable<QuizWithScoreViewModel>> Get()
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            IEnumerable<QuizWithScoreViewModel> result = _context.Scores
                .Include(s => s.Quiz)
                .Include(s => s.ExternalPlayer)
                .Select(s => new QuizWithScoreViewModel
                {
                    Title = s.Quiz.Title,
                    UserName = s.ExternalPlayer.UserName,
                    Score = s.Score,
                });

            return result;
        }
    }
}
