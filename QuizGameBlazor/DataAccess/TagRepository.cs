using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class TagRepository : ITagsRepository
    {
        private readonly QuizGameContext _context;

        public TagRepository(IDbContextFactory<QuizGameContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }
        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}
