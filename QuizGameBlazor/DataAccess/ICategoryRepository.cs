using System.Collections.Generic;
using System.Threading.Tasks;
using QuizGameBlazor.Models;

namespace QuizGameBlazor.DataAccess
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAsync();
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);

    }
}
