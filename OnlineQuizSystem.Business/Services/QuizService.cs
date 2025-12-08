using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Business.Response;
<<<<<<< HEAD
using OnlineQuizSystem.Data;

namespace OnlineQuizSystem.Business.Services;

public class QuizService(AppDbContext dbContext):IQuizService
{

    public Task<bool> Create(CreateQuizRequest request)
    {
         throw new NotImplementedException();
=======
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class QuizService(InstructorRepository instructorRepository,
                         QuizRepository quizRepository) :IQuizService
{
    public async Task<bool> Create(CreateQuizRequest request, Guid instructorId)
    {
        var instructor = instructorRepository.GetById(instructorId); 

        if(instructor is null)
            throw new Exception("Instructor not found");

        var quiz = new Quiz
        {
            Id = Guid.NewGuid(),
            InstructorId = instructorId,
            Title = request.Title,
            CreatedAt = DateTime.UtcNow
        };

        foreach(var questionRequest in request.Questions)
        {
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuizId = quiz.Id,
                Title = questionRequest.Text,
                Points = questionRequest.Points,
                
            };

            for(int i = 0; i < questionRequest.Choices.Count; i++)
            {
                var choice = new Choice
                {
                    Id = Guid.NewGuid(),
                    Text = questionRequest.Choices[i],
                    QuestionId = question.Id};

                question.Choices.Add(choice);

                if(i == questionRequest.CorrectChoiceIndex)
                {
                    question.CorrectChoice = choice;
                    question.CorrectChoiceId = choice.Id;
                }
            }

           
        }
        var result = await quizRepository.AddAsync(quiz);

        return result;

>>>>>>> login-authentication-branch
    }
    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Guid id, UpdateQuizRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<QuizResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task StartQuiz(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SubmitQuiz(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(CreateQuizRequest request)
    {
        throw new NotImplementedException();
    }
}