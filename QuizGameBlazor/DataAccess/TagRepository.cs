﻿using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public class TagRepository : ITagsRepository
    {
        private readonly IDbContextFactory<QuizGameContext> _factory;

        public TagRepository(IDbContextFactory<QuizGameContext> factory)
        {
            _factory = factory;
        }
        public async Task<List<Tag>> GetTagsAsync()
        {
            await using var context = _factory.CreateDbContext();
            var result = await context.Tags
                .ToListAsync();

            return result;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await using var context = _factory.CreateDbContext();
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
            return tag;
        }
    }
}
