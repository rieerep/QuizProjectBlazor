using BlazorQuiz.Server.Data;
using BlazorQuiz.Server.Migrations;
using BlazorQuiz.Server.Models;
using BlazorQuiz.Shared;
using create_a_quiz.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace create_a_quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public QuizController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        //GET api/playquiz
        [HttpGet("allquizzes")]
        public async Task<IEnumerable<QuizViewModel>> GetAllQuizzes()
        {
            var quizInfo = _context.Quizzes
                .Select(q => new QuizViewModel { Title = q.Title, PublicId = q.PublicId })
                .ToList();

            return quizInfo;
        }

        //GET api/get
        [HttpGet("get")]
        public async Task<IEnumerable<QuizViewModel>> Get()
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            var quizInfo = _context.Quizzes
                .Select(q => new QuizViewModel { Title = q.Title, PublicId = q.PublicId })
                .ToList();

            var userQuizzes = _context.Quizzes
                .Where(u => u.UserId == userId)
                .Select(q => new QuizViewModel { Title = q.Title, PublicId = q.PublicId })
                .ToList();

            return userQuizzes;
        }

            [HttpGet("chosenquiz/{publicId}")]
            public async Task<List<QuestionViewModel>> ChosenQuiz(Guid publicId)
            {
                var quizInfo = _context.Quizzes.Where(q => q.PublicId == publicId)
                    .Include(q => q.Questions).ThenInclude(f => f.FakeAnswers)
                    .FirstOrDefault()
                .Questions.Select(q => new QuestionViewModel
                {
                    IncludingImage = q.ImageUrl,
                    IncludingVideo = q.VideoUrl,
                    MediaURL = q.MediaURL,
                    HasMultipleAnswers = q.HasMultipleAnswers, 
                    Question = q.Question,
                    FakeAnswers = q.FakeAnswers.Select(f => f.FakeAnswer).ToArray(),
                    Answer = q.Answer,
                    TimeLimit = q.TimeLimit
                }).ToList();

                // Check if the quiz exists
                if (quizInfo == null)
                {
                    throw new Exception("Quiz not found");
                }
                return quizInfo;
            }

            // POST api/<CreateQuizController>
            [HttpPost("post")]
            public IActionResult Post([FromBody] QuizViewModel model)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var quiz = new QuizModel
                {
                    UserId = userId,
                    Title = model.Title,
                    PublicId = Guid.NewGuid()
                };
                _context.Quizzes.Add(quiz);
                _context.SaveChanges();

                QuizTitleViewModel newQuizId = new QuizTitleViewModel() { PublicId = quiz.PublicId };
                return Ok(newQuizId);
            }


            //POST /api/quiz/checkanswer
            [HttpPost]

            public IActionResult Post()
            {
                return null;
            }
        }
    }
