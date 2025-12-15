using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineQuizSystem.Models;
namespace OnlineQuizSystem.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Role).IsRequired();
        
        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}