﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models
{
    public class Question
    {
        public Question()
        {
            AnswerOptions = new List<AnswerOption>();
            QuestionTags = new List<QuestionTags>();
        }
        public int Id { get; set; }
        [Required, StringLength(120)]
        public string Text { get; set; }

        public string FollowUp { get; set; }
        [Required]
        [MinLength(2), MaxLength(5)]
        public List<AnswerOption> AnswerOptions { get; set; }

        public List<QuestionTags> QuestionTags { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
