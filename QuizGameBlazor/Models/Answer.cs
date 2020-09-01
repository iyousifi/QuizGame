using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models
{
    public class Answer
    {
        public Answer()
        {
            Tags = new List<AnswerTags>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerTags> Tags { get; set; }
    }
}
