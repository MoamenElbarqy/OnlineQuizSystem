using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class UpdateQuizRequestValidator : AbstractValidator<UpdateQuizRequest>
{
    public UpdateQuizRequestValidator()
    {
        RuleFor(q => q.Title).NotEmpty().MaximumLength(200);

        RuleFor(q => q.StartTime).NotEmpty()
        .WithMessage("StartTime is required.")
        .Must(startTime => startTime >= DateTime.UtcNow)
        .WithMessage("StartTime cannot be in the past.");

        RuleFor(q => q.EndTime).NotEmpty()
        .WithMessage("EndTime is required.")
        .Must((request, endTime) => endTime > request.StartTime)
        .WithMessage("EndTime must be after StartTime.")
        .Must(endTime => endTime >= DateTime.UtcNow)
        .WithMessage("EndTime cannot be in the past.");

        RuleForEach(q => q.Questions)
            .SetValidator(new UpdateQuestionRequestValidator());

        RuleFor(q => q.MinDegreesToPass).NotEmpty()
        .GreaterThan(0).WithMessage("MinDegreesToPass must be greater than 0.")
        .Must((request, MinDegreesToPass) => MinDegreesToPass <= request.Questions.Sum(q => q.Points))
        .WithMessage("MinDegreesToPass cannot exceed total points of all questions.");
    }
}
