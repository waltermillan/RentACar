using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RentRepository(Context context) : GenericRepository<Rent>(context), IRentRepository
{

    // Método existente
    public override async Task<Rent> GetByIdAsync(int id)
    {
        return await _context.Rents
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método existente
    public override async Task<IEnumerable<Rent>> GetAllAsync()
    {
        return await _context.Rents.ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<Rent> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Rents as IQueryable<Rent>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Day.ToString().Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}