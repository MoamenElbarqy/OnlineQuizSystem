using FluentValidation;
using OnlineQuizSystem.Business.Request;

namespace OnlineQuizSystem.Business.Validators;

public class CreateQuestionRequestValidator :AbstractValidator<CreateQuestionRequest>
{
    public CreateQuestionRequestValidator()
    {
        
    }
}