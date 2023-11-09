﻿using BlazorQuiz.Server.Data;
using BlazorQuiz.Server.Models;
using BlazorQuiz.Shared;
using create_a_quiz.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


		// GET: api/<CreateQuizController>
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreateQuizController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreateQuizController>
        [HttpPost]
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
    }
}
