using FluentValidation;
using QuizGameBlazor.Models;
using System.Linq;

namespace QuizGameBlazor.Validators
{
    public class QuestionValidator:AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.AnswerOptions)
                .Must(x => x.Any(a => a.IsCorrect)).WithMessage("Answer options must have a correct answer")
                .Must(x => x.Count() > 1 && x.Count < 6).WithMessage("Answer options must have between 2 and 5 answers");
            
            RuleFor(x => x.DifficultyLevel).InclusiveBetween(1, 10).WithMessage("Must be between 1-10");
            RuleFor(x => x.Text).Length(10, 120).WithMessage("Must be between 10 and 120 characters long");
        }
    }
    public class AnswerOptionValidator : AbstractValidator<AnswerOption>
    {

    }
}
