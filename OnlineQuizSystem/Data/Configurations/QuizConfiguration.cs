using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quizzes");

        
        builder.HasOne(i => i.Instructor)
            .WithMany(i => i.Quizzes)
            .HasForeignKey(i => i.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Questions)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        

    }
}
