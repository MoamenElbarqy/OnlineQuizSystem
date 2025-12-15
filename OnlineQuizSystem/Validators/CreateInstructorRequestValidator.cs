using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class CreateInstructorRequestValidator : AbstractValidator<CreateInstructorRequest>
{
    public CreateInstructorRequestValidator()
    {
        RuleFor(i => i.UserInfo).NotEmpty()
        .SetValidator(new CreateUserRequestValidator());

        RuleFor(i => i.Salary).NotEmpty()
            .InclusiveBetween(5000, 20000);
    }
}
