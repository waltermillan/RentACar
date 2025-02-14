using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CarRepository(Context context) : GenericRepository<Car>(context), ICarRepository
{

    // Método existente
    public override async Task<Car> GetByIdAsync(int id)
    {
        return await _context.Cars.AsNoTracking()
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método existente
    public override async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<Car> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Cars as IQueryable<Car>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Model.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}