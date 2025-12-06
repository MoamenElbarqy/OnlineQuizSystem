using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class InstructorRepository(AppDbContext context)
{
    public Instructor? Find(Guid id)
    {
        var instructor = context.Instructors
            .FirstOrDefault(i => i.Id == id);
        
        return instructor;
        
    }
    public Instructor? Find(string email, string password)
    {
        var instructor = context.Instructors
            .FirstOrDefault(i => i.Email == email && i.Password == password);  

        return instructor;
        
    }
    public bool Add(Instructor instructor)
    {
        context.Instructors.Add(instructor);
        var changes = context.SaveChanges();
        return changes > 0;
        
    }
    public bool Update(Instructor instructor)
    {
        context.Instructors.Update(instructor);
        var changes = context.SaveChanges();
        return changes > 0;
    }
    public bool Delete(Instructor instructor)
    {
        context.Instructors.Remove(instructor);
        var changes = context.SaveChanges();
        return changes > 0;
    }

}