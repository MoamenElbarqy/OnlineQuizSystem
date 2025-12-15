using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");


        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(q => q.QuizId);

        builder.HasOne(q => q.CorrectChoice)
        .WithMany()
        .HasForeignKey(q => q.CorrectChoiceId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
