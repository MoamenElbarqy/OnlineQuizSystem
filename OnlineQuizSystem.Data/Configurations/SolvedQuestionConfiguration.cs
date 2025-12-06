using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class SolvedQuestionConfiguration : IEntityTypeConfiguration<StudentQuestion>
{
    public void Configure(EntityTypeBuilder<StudentQuestion> builder)
    {
        builder.ToTable("StudentQuestions");

        builder.HasKey( q =>  q.Id);

        builder.Property( q =>  q.StudentChoice).IsRequired();

        builder.HasOne( q =>  q.Student)
            .WithMany(s => s.SolvedQuestions)
            .HasForeignKey( q =>  q.StudentId);

        builder.HasOne( q =>  q.StudentQuiz)
            .WithMany(solvedQuiz => solvedQuiz.SolvedQuestions)
            .HasForeignKey( q =>  q.StudentQuizId);
        
        builder.HasOne( q =>  q.Question)
            .WithMany(q => q.StudentQuestions)    // if you add this navigation
            .HasForeignKey( q =>  q.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne( q =>  q.Question);
    }
}

/*
 * public class SolvedQuestion
   {
       public Guid Id { get; set; }
       public Guid StudentId { get; set; }
       public Guid QuestionId { get; set; }
       public int StudentChoice { get; set; }


       public Student Student { get; set; }
       public Question Question { get; set; }
   }
 */