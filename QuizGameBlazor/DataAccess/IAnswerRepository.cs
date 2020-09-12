using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    interface IAnswerRepository
    {
        Task<List<Models.Answer>> GetAnswersAsync();
        Task<Answer> AddAsync(Answer answer);
        Task<Answer> UpdateAsync(Answer answer);
        Task DeleteAsync(int id);
        Task<Answer> FindAnswer(string text);
        Task<Answer> GetAnswersByIdAsync(int id);


    }
}
