using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class UpdateQuestionRequestValidator : AbstractValidator<UpdateQuestionRequest>
{
    public UpdateQuestionRequestValidator()
    {
        RuleFor(q => q.Title).NotEmpty()
        .MaximumLength(200);

        RuleFor(q => q.Choices).NotEmpty()
        .Must(c => c.Count >= 2).WithMessage("At least two choices are required.");

        RuleFor(q => q.CorrectChoiceIndex).NotEmpty()
            .Must(CorrectIndex => CorrectIndex >= 0)
            .WithMessage("Correct choice index must be non-negative.")
            .Must((request, CorrectIndex) => CorrectIndex < request.Choices.Count)
            .WithMessage("Correct choice index must be within the range of choices.");
        RuleFor(q => q.Points).NotEmpty().GreaterThan(0);

        RuleFor(q => q.DisplayOrder).NotEmpty().GreaterThanOrEqualTo(0);
    }
}
