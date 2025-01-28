using AccessControl_backend.Models;
using AccessControl_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace AccessControl_backend.Services
{
    public class UserFieldService
    {
        private readonly AppDbContext _context;
        public UserFieldService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserField> GetUserFieldById(int id)
        {
            return await _context.UserField.FindAsync(id);
        }
        public async Task<UserField> CreateUserField(string name, string type, bool required, string? description)
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
            return userField;
        }
        public async Task<UserField> UpdateUserField(UserField userField)
        {
            _context.Entry(userField).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userField;
        }
        public async Task<UserField> DeleteUserField(int id)
        {
            var userField = await _context.UserField.FindAsync(id);
            if (userField == null)
            {
                return null;
            }
            _context.UserField.Remove(userField);
            await _context.SaveChangesAsync();
            return userField;
        }
    }
}
