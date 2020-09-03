using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizGameBlazor.DataAccess;
using QuizGameBlazor.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizGameBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public GameController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        // GET: api/<GameController>
        [HttpGet]
        public async Task<object> Get()
        {
            var questions =  await _questionRepository.GetQuestions();
            return questions.Select(q => new Models.Api.Question{ Text = q.Text, Answers = q.AnswerOptions.Select(ao => new Models.Api.Answer {  Text = ao.Answer.Text, IsCorrect = ao.IsCorrect  }).ToList(),  Difficulty = q.DifficultyLevel });
        }


    }
}
