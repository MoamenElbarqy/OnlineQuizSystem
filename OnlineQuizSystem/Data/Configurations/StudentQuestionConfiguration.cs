using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class StudentQuestionConfiguration : IEntityTypeConfiguration<StudentQuestion>
{
    public void Configure(EntityTypeBuilder<StudentQuestion> builder)
    {
        builder.ToTable("StudentQuestions");


        builder.HasOne(q => q.StudentChoice)
            .WithMany()
            .HasForeignKey(q => q.StudentChoiceId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(q => q.Student)
            .WithMany(s => s.SolvedQuestions)
            .HasForeignKey(q => q.StudentId);

        builder.HasOne(q => q.StudentQuiz)
            .WithMany(solvedQuiz => solvedQuiz.SolvedQuestions)
            .HasForeignKey(q => q.StudentQuizId);

        builder.HasOne(q => q.Question)
            .WithMany(q => q.StudentQuestions)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
