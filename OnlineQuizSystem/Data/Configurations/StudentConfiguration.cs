using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        
        builder.HasMany(s => s.SolvedQuizzes)
            .WithOne(sq => sq.Student)
            .HasForeignKey(sq => sq.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.SolvedQuestions)
            .WithOne(sq => sq.Student)
            .HasForeignKey(sq => sq.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasBaseType<User>();
    }
}