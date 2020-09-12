using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizGameBlazor.DataAccess;
using QuizGameBlazor.Models.Api;

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
        public async Task<QuestionData> Get()
        {
            var questions = (await _questionRepository.GetQuestions()).Where(q => q.AnswerOptions.Any(a => a.IsCorrect));
            return new QuestionData
            {
                Data = questions.Select(q => new Question
                {
                    question = q.Text,
                    bonus = 100 * (q.DifficultyLevel == 0 ? 1 : q.DifficultyLevel),
                    answers = q.AnswerOptions.Select(ao => new Models.Api.Answer { answer = ao.Answer.Text, isCorrect = ao.IsCorrect }).ToArray()
                }).ToList()
            };
        }
    }
}
