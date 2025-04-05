using Core.Entities;

namespace Core.Interfases;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByUsrAsync(string usr);
}
