using FluentValidation;
using OnlineQuizSystem.Business.Request;

namespace OnlineQuizSystem.Business.Validators;

public class UpdateQuestionRequestValidator : AbstractValidator<UpdateQuestionRequest>
{
    public UpdateQuestionRequestValidator()
    {
        
    }
}