using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    interface ITagsRepository
    {
        Task<List<Tag>> GetTagsAsync(TagType type);
        Task<Tag> AddTagAsync(Tag tag);
    }
}
