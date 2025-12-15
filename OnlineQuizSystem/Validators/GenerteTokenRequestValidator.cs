using FluentValidation;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class GenerteTokenRequestValidator : AbstractValidator<GenerateTokenRequest>
{
    public GenerteTokenRequestValidator()
    {
        RuleFor(t => t.Id)
        .NotEmpty().WithMessage("Id cannot be empty.");
        RuleFor(t => t.Role).IsInEnum()
        .WithMessage("Role must be a valid enum value.");
    }
}
