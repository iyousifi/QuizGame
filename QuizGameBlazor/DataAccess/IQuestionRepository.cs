﻿using QuizGameBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.DataAccess
{
    interface IQuestionRepository
    {
        Task<Question> Get(int Id);
        Task<List<Answer>> GetAnswers();
        Task<List<Question>> GetQuestions();
        Task Add(Question question);
        Task<Question> Update(Question question);
        Task Delete(int Id);
    }
}