using AccessControl_backend.Data;
using AccessControl_backend.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace AccessControl_backend.Services;

public class OperatorService: IOperatorService
{
    private readonly AppDbContext _context;

    public OperatorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Operator> GetById(int id)
    {
        return await _context.Operator.FindAsync(id);
    }
    public async Task<List<Operator>> GetAll()
    {
        return await _context.Operator.ToListAsync();
    }

    public async Task<Operator> Create(string login, string password, int userId)
    {
        var @operator = new Operator
        {
            Login = login,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            UserId = userId
        };

        _context.Operator.Add(@operator);
        await _context.SaveChangesAsync();
        return @operator;
    }
    public async Task<Operator> Update(int id, string login, string password)
    {
        var @operator = await _context.Operator.FindAsync(id);
        if (@operator == null)
        {
            return null;
        }
        @operator.Login = login;
        @operator.Password = password;
        _context.Entry(@operator).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return @operator;

    }
    public async Task<Operator> Delete(int id)
    {
        var @operator = await _context.Operator.FindAsync(id);
        if (@operator == null)
        {
            return null;
        }
        _context.Operator.Remove(@operator);
        await _context.SaveChangesAsync();
        return @operator;
    }

    public async Task<Operator> Login(string login, string password)
    {
        Operator? @operator = await _context.Operator.FirstOrDefaultAsync(x => x.Login == login);
        if (@operator == null)
        {
            return null;
        }
        if (!BCrypt.Net.BCrypt.Verify(password, @operator.Password))
        {
            return null;
        }
        return @operator;
    }
}
