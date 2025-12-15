using System.Data;
using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class CreateStudentRequestValidator : AbstractValidator<CreateStudentRequest>
{
    public CreateStudentRequestValidator()
    {
        RuleFor(s => s.UserInfo).NotEmpty()
        .SetValidator(new CreateUserRequestValidator());

        RuleFor(s => s.Level).NotEmpty().InclusiveBetween(1, 4);

        RuleFor(s => s.Department).NotEmpty().MaximumLength(20);
    }
}
