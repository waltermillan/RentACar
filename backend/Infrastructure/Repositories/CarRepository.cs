using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CarRepository(Context context) : GenericRepository<Car>(context), ICarRepository
{
    public override async Task<Car> GetByIdAsync(int id)
    {
        return await _context.Cars.AsNoTracking()
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }
}