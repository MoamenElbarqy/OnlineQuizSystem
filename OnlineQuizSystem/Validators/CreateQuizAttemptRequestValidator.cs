using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class CreateQuizAttemptRequestValidator : AbstractValidator<CreateQuizAttemptRequest>
{
    public CreateQuizAttemptRequestValidator()
    {
        RuleFor(q => q.QuizId).NotEmpty();

        RuleForEach(q => q.QuestionAttempts)
            .SetValidator(new CreateQuestionAttemptRequestValidator());

        RuleFor(q => q.SubmittedAt)
        .NotEmpty().Must(submittedAt => submittedAt <= DateTime.UtcNow)
        .WithMessage("SubmittedAt cannot be in the future.");

    }
}
