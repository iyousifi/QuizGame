using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizGameContext _context;

        public AnswerRepository(IDbContextFactory<QuizGameContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }
        public async Task<Answer> AddAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Answer>> GetAnswersAsync()
        {
            return await _context.Answers
                .Include(x => x.Tags)
                .ThenInclude(x => x.Tag)
                .ToListAsync();   
        }

        public async Task<Answer> UpdateAsync(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return answer;
        }
    }
}
