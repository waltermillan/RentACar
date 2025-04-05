using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(Context context) : GenericRepository<User>(context), IUserRepository
{
    public override async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
