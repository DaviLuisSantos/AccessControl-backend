using AccessControl_backend.Models;
using AccessControl_backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccessControl_backend.Services
{
    public class UserFieldValueService
    {
        private readonly AppDbContext _context;
        private readonly UserFieldService _userFieldService;
        private readonly UserService _userService;

        public UserFieldValueService(AppDbContext context)
        {
            _context = context;
            _userFieldService = new UserFieldService(context);
            _userService = new UserService(context);
        }
        public async Task<UserFieldValue> GetUserFieldValueById(int id)
        {
            return await _context.UserFieldValue.FindAsync(id);
        }
        public async Task<List<UserFieldValue>> GetAll()
        {
            return await _context.UserFieldValue.ToListAsync();
        }
        public async Task<UserFieldValue> Create(int userId, int userFieldId, string value )
        {
            UserFieldValue userFieldValue = new UserFieldValue
            {
                User = await _userService.GetUserById(userId),
                UserField = await _context.UserField.FindAsync(userFieldId),
                Value = value
            };

            _context.UserFieldValue.Add(userFieldValue);
            await _context.SaveChangesAsync();
            return userFieldValue;
        }
        public async Task<UserFieldValue> UpdateUserFieldValue(UserFieldValue userFieldValue)
        {
            _context.Entry(userFieldValue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userFieldValue;
        }
        public async Task<UserFieldValue> DeleteUserFieldValue(int id)
        {
            var userFieldValue = await _context.UserFieldValue.FindAsync(id);
            if (userFieldValue == null)
            {
                return null;
            }
            _context.UserFieldValue.Remove(userFieldValue);
            await _context.SaveChangesAsync();
            return userFieldValue;
        }

    }
}
