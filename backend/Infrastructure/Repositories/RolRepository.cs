using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RolRepository(Context context) : GenericRepository<Rol>(context), IRolRepository
{
    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Roles
                          .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }
}
