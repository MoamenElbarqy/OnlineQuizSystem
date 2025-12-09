using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineQuizSystem.Data.Models;
namespace OnlineQuizSystem.Data;

public class AppDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentQuiz> SolvedQuizzes { get; set; }
    public DbSet<StudentQuestion> SolvedQuestions { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey != null && primaryKey.Properties.Count == 1)
            {
                var primaryKeyProperty = primaryKey.Properties[0];
                if (primaryKeyProperty.ClrType == typeof(Guid))
                {
                    primaryKeyProperty.ValueGenerated = ValueGenerated.Never;
                }
            }
        }

    }
}