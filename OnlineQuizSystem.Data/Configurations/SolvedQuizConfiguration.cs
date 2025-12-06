using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class SolvedQuizConfiguration : IEntityTypeConfiguration<StudentQuiz>
{
    public void Configure(EntityTypeBuilder<StudentQuiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Student)
            .WithMany(student => student.SolvedQuizzes)
            .HasForeignKey(q => q.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(q => q.Quiz)
            .WithMany(q => q.StudentQuizzes)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.SolvedQuestions)
            .WithOne(solvedQuestion => solvedQuestion.StudentQuiz);
        
        builder.Property(q => q.StartedAt).IsRequired();
        
        
    }
}