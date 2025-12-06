using FluentValidation;
using OnlineQuizSystem.Business.Request;

namespace OnlineQuizSystem.Business.Validators;

public class CreateQuizRequestValidator :AbstractValidator<CreateQuizRequest>
{
    public CreateQuizRequestValidator()
    {
        
    }
    
}