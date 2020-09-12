using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models
{
    public class QuestionTags
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
