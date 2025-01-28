using AccessControl_backend.Data;
using AccessControl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl_backend.Services
{
    public class OperatorService
    {
        private readonly AppDbContext _context;

        public OperatorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Operator> GetOperatorById(int id)
        {
            return await _context.Operator.FindAsync(id);
        }
        public async Task<Operator> CreateOperator(string login,string password, int userId)
        {
            var @operator = new Operator
            {
                Login = login,
                Password = password,
                UserId = userId
            };

            _context.Operator.Add(@operator);
            await _context.SaveChangesAsync();
            return @operator;
        }
        public async Task<Operator> UpdateOperator(int id,string login,string password)
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
        public async Task<Operator> DeleteOperator(int id)
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
        public async Task<List<Operator>> GetAllOperators()
        {
            return await _context.Operator.ToListAsync();
        }
    }
}
