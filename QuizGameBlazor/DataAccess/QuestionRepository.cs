using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizGameContext _quizGameContext;

        public QuestionRepository(IDbContextFactory<QuizGameContext> contextFactory)
        {
            _quizGameContext = contextFactory.CreateDbContext();
        }

        public async Task Add(Question question)
        {
            _quizGameContext.Questions.Add(question);
            await _quizGameContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var question = await _quizGameContext.Questions.FindAsync(id);
            _quizGameContext.Questions.Remove(question);
            await _quizGameContext.SaveChangesAsync();
        }

        public async Task<Question> Get(int id)
        {
            return await _quizGameContext.Questions.FindAsync(id);
        }

        public async Task<List<Answer>> GetAnswers()
        {
            return await _quizGameContext.Answers.Include(a => a.Tags).ToListAsync();
        }

        public async Task<List<Question>> GetQuestions()
        {
            return await _quizGameContext.Questions.Include(a => a.AnswerOptions)
                .ThenInclude(a => a.Answer)
                .ToListAsync<Question>();
        }

        public async Task<Question> Update(Question question)
        {
            _quizGameContext.Entry(question).State = EntityState.Modified;
            await _quizGameContext.SaveChangesAsync();
            return question;
        }
        
    }
}
