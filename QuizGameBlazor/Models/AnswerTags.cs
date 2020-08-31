using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models
{
    public class AnswerTags
    {
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
