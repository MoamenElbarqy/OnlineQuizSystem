using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class AdminRepository(AppDbContext context)
{
    public Admin? Find(Guid id)
    {
        var admin = context.Admins
            .FirstOrDefault(a => a.Id == id);
        
        return admin;
        
    }
    public Admin? Find(string email, string password)
    {
        var admin = context.Admins
            .FirstOrDefault(a => a.Email == email && a.Password == password);  

        return admin;
    }

    public bool Add(Admin admin)
    {
        context.Admins.Add(admin);
        var changes = context.SaveChanges();
        return changes > 0;
        
    }
    public bool Update(Admin admin)
    {
        context.Admins.Update(admin);
        var changes = context.SaveChanges();
        return changes > 0;
    }
    public bool Delete(Admin admin)
    {
        context.Admins.Remove(admin);
        var changes = context.SaveChanges();
        return changes > 0;
    }   
    
}