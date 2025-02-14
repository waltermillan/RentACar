using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PayTypeRepository(Context context) : GenericRepository<PayType>(context), IPayTypeRepository
{

    // Método existente
    public override async Task<PayType> GetByIdAsync(int id)
    {
        return await _context.PaysType
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método existente
    public override async Task<IEnumerable<PayType>> GetAllAsync()
    {
        return await _context.PaysType.ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<PayType> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.PaysType as IQueryable<PayType>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}