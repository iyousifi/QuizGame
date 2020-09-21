using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;

namespace QuizGameBlazor.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<QuizGameContext> _factory;

        public CategoryRepository(IDbContextFactory<QuizGameContext> factory)
        {
            _factory = factory;
        }
        public async Task<List<Category>> GetAsync()
        {
            await using var context = _factory.CreateDbContext();
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> AddAsync(Category category)
        {
            await using var context = _factory.CreateDbContext();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            await using var context = _factory.CreateDbContext();
            context.Entry(category).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return category;

        }
    }
}