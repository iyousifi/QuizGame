using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDbContextFactory<QuizGameContext> _factory;

        public QuestionRepository(IDbContextFactory<QuizGameContext> factory)
        {
            _factory = factory;
        }

        public async Task Add(Question question)
        {
            await using var context = _factory.CreateDbContext();

            context.Answers.AttachRange(question.AnswerOptions.Select(x => x.Answer));
            context.AnswerOptions.AttachRange(question.AnswerOptions);
            context.QuestionTags.AttachRange(question.QuestionTags);
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await using var context = _factory.CreateDbContext();
            var question = await context.Questions.FindAsync(id);
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
        }

        public async Task UpdateQuestionTags(List<QuestionTags> toAdd, List<QuestionTags> toRemove)
        {
            await using var addcontext = _factory.CreateDbContext();
            await addcontext.AddRangeAsync(toAdd);
            await addcontext.SaveChangesAsync();

            await using var removecontext = _factory.CreateDbContext();
            removecontext.QuestionTags.RemoveRange(toRemove);
            await removecontext.SaveChangesAsync();

        }

        public async Task<Question> Get(int id)
        {
            await using var context = _factory.CreateDbContext();
            return await context.Questions.FindAsync(id);
        }

        public async Task<List<Answer>> GetAnswers()
        {
            await using var context = _factory.CreateDbContext();
            return await context.Answers.Include(a => a.Tags).ToListAsync();
        }

        public async Task<List<Question>> GetQuestions()
        {
            await using var context = _factory.CreateDbContext();
            return await context.Questions
                .Include(t => t.QuestionTags)
                .ThenInclude(t => t.Tag)
                .Include(a => a.AnswerOptions)
                .ThenInclude(a => a.Answer)
                .ToListAsync<Question>();
        }

        public async Task<Question> Update(Question question)
        {
            await using var context = _factory.CreateDbContext();
            context.Entry(question).State = EntityState.Modified;
            context.Answers.AttachRange(question.AnswerOptions.Select(x => x.Answer));
            context.AnswerOptions.AttachRange(question.AnswerOptions);
            //context.QuestionTags.AttachRange(question.QuestionTags);

            await context.SaveChangesAsync();
            return question;
        }
        
    }
}
