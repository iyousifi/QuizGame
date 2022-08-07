using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    public interface ITagsRepository
    {
        Task<List<Tag>> GetTagsAsync(TagType type);
        Task<Tag> AddTagAsync(Tag tag);
        Task RemoveTag(Tag tag);
    }
}
