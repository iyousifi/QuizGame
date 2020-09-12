using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerTags> AnswerTags { get; set; }
        public List<QuestionTags> QuestionTags { get; set; }
    }
}
