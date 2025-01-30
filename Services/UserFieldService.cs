using AccessControl_backend.Data;
using AccessControl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl_backend.Services;

public class UserFieldService: IUserFieldService
{
    private readonly AppDbContext _context;
    public UserFieldService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<UserField> GetById(int id)
    {
        return await _context.UserField.FindAsync(id);
    }
    public async Task<List<UserField>> GetAll()
    {
        return await _context.UserField.ToListAsync();
    }


    public async Task<bool> Create(string name, string type, bool required, string? description)
    {
        var userField = new UserField
        {
            Name = name,
            Type = type,
            Required = required,
            Description = description
        };

        _context.UserField.Add(userField);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<UserField> Update(UserField userField)
    {
        _context.Entry(userField).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return userField;
    }
    public async Task<bool> Delete(int id)
    {
        var userField = await _context.UserField.FindAsync(id);
        if (userField == null)
        {
            return false;
        }
        _context.UserField.Remove(userField);
        await _context.SaveChangesAsync();
        return true;
    }
}
