using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quizzes");

        builder.HasKey(q => q.Id);
        
        builder.HasOne(i => i.Instructor)
            .WithMany(i => i.Quizzes)
            .HasForeignKey(i => i.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.Questions)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.Property(q => q.Title).IsRequired();

        builder.Property(q => q.CreatedAt).IsRequired();

    }
}
/*public class Quiz
   {
       public Guid Id { get; set; }
       public Guid InstructorId { get; set; }
       public string Name { get; set; }
       public List<Question> Questions { get; set; }
       public Instructor Instructor { get; set; }
       public DateTime CreatedAt { get; set; }
   }
}*/