using BlazorQuiz.Server.Data;
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


        [HttpGet("getquizwithscore")]

        public async Task<IEnumerable<QuizWithScoreViewModel>> GetQuizWithScore()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            {
                if (userId == null)
                {
                    throw new ArgumentNullException("userID");
                }

                var userQuizzes = _context.Quizzes
                    .Where(u => u.UserId == userId)
                    .Select(q => new QuizWithScoreViewModel
                    {
                        Title = q.Title,
                        PublicId = q.PublicId,
                        Score = _context.Scores.Where(s => s.QuizId == q.Id && s.UserId == userId)
                    .Select(s => s.Score).FirstOrDefault()
                    })
                    .ToList();

                return userQuizzes;

            }
        }

        [HttpGet("chosenquiz/{publicId}")]
        public async Task<List<QuestionViewModel>> ChosenQuiz(Guid publicId)
        {
            // konverta från question model till question view model
            var quizInfo = _context.Quizzes.Where(q => q.PublicId == publicId)
                .Include(q => q.Questions).ThenInclude(f => f.FakeAnswers)
                .FirstOrDefault()
            .Questions.Select(q => new QuestionViewModel
            {
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

            // var question = quizInfo.Questions.First();

            //var questionViewModel = new QuestionViewModel
            //{
            //	Question = question.Question,
            //	FakeAnswers = question.FakeAnswers.Select(f => f.FakeAnswer).ToArray(),
            //	Answer = question.Answer,
            //	TimeLimit = question.TimeLimit

            //};

            return quizInfo;

            // Skapa en lista med Answer och fakeanswer tillsammans.
            // Skicka in en lista som består av alla frågor som quizzet hr


            // Select all questions where quizID = question.quizID

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

            // QuizViewModel newQuizId = new QuizViewModel() { PublicId = quiz.PublicId };

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
