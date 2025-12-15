using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(u => u.Name).NotEmpty().MaximumLength(15);
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
    }
}
