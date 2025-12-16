using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
{
    public void Configure(EntityTypeBuilder<Choice> builder)
    {
        builder.ToTable("Choices");

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Question)
            .WithMany(q => q.Choices)
            .HasForeignKey(c => c.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
