using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class CreateQuestionAttemptRequestValidator : AbstractValidator<CreateQuestionAttemptRequest>
{
    public CreateQuestionAttemptRequestValidator()
    {
        RuleFor(q => q.QuestionId).NotEmpty();
        RuleFor(q => q.SelectedChoiceId).NotEmpty();
    }
}
