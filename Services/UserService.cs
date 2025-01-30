using AccessControl_backend.Data;
using AccessControl_backend.Models;
using Microsoft.EntityFrameworkCore;


namespace AccessControl_backend.Services;
public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<bool> Create(string name, string base64Image)
    {

        byte[] image = Convert.FromBase64String(base64Image);

        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", name + ".png");

        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));

        await File.WriteAllBytesAsync(path, image);

        User user = new User
        {
            Name = name,
            Image = path
        };

        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
