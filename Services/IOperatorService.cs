using AccessControl_backend.Models;

namespace AccessControl_backend.Services;

public interface IOperatorService
{
    Task <List<Operator>> GetAll();
    Task <Operator> GetById(int id);
    Task<Operator> Create(string login, string password, int userId);
    Task<Operator> Update(int id, string login, string password);
    Task<Operator> Delete(int id);
    Task<Operator> Login(string login, string password);
}
