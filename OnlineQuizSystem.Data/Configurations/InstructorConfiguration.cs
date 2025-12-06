using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Data.Models;


public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");

        
        builder.HasMany(i => i.Quizzes)
            .WithOne(q => q.Instructor)
            .HasForeignKey(q => q.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasBaseType<User>();
    }
}