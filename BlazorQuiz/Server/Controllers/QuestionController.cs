﻿using BlazorQuiz.Server.Data;
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
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public QuestionController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //POST api/<CreateQuestionController>
        [HttpPost]
        public IActionResult Post([FromBody] QuestionViewModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var currentQuiz = _context.Quizzes.Where(u => u.PublicId.ToString() == model.PublicId).Include(q => q.Questions).Single();
            
            var question = new QuestionModel
            {
                Question = model.Question,
                Answer = model.Answer,
                Timer = model.Timer
            };
            currentQuiz.Questions.Add(question);
            _context.SaveChanges();

            return Ok();
        }

    }
}
