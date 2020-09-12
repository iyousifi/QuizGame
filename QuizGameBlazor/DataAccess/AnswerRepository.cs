using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IDbContextFactory<QuizGameContext> _factory;

        public AnswerRepository(IDbContextFactory<QuizGameContext> factory)
        {
            _factory = factory;
        }
        public async Task<Answer> AddAsync(Answer answer)
        {
            await using var context = _factory.CreateDbContext();
            context.Tags.AttachRange(answer.Tags.Select(t => t.Tag));
            await context.Answers.AddAsync(answer);

            Debug.WriteLine($"Instance Id: {context.ContextId.InstanceId}");
            await context.SaveChangesAsync();

            return answer;
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = _factory.CreateDbContext();
            var answer = await context.Answers.FindAsync(id);
            context.Answers.Remove(answer);
            await context.SaveChangesAsync();
        }

        public async Task<Answer> FindAnswer(string text)
        {
            await using var context = _factory.CreateDbContext();
            var result = context.Answers
                .AsEnumerable()
                .FirstOrDefault(a => a.Text.Trim().ToLowerInvariant().Equals(text.Trim().ToLowerInvariant()));
            if (result != null)
                context.Entry(result).State = EntityState.Detached;
            return result;

        }

        public async Task<List<Answer>> GetAnswersAsync()
        {
            await using var context = _factory.CreateDbContext();
            return await context.Answers
                .Include(x => x.Tags)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
        }

        public async Task<Answer> GetAnswersByIdAsync(int id)
        {
            await using var context = _factory.CreateDbContext();
            return await context.Answers
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }


        public async Task<Answer> UpdateAsync(Answer answer)
        {
            await using var context = _factory.CreateDbContext();
            context.Entry(answer).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return answer;
        }
    }
}
