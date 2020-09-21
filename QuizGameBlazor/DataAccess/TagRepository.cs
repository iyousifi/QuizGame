using Microsoft.EntityFrameworkCore;
using QuizGameBlazor.Models;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Tag>> GetTagsAsync(TagType type)
        {
            await using var context = _factory.CreateDbContext();
            var result = await context.Tags
                .Where(x => x.Type.Equals(type))
                .ToListAsync();

            return result;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await using var context = _factory.CreateDbContext();
            var dbTag = await context.Tags.FirstOrDefaultAsync(x => x.Text.Equals(tag.Text));
            if (dbTag != null)
                return dbTag;
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
            return tag;
        }

        public async Task RemoveTag(Tag tag)
        {
            await using var context = _factory.CreateDbContext();
            context.Tags.Remove(tag);
            await context.SaveChangesAsync();
        }
    }
}
