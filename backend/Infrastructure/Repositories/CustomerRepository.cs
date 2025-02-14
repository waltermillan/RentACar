using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository(Context context) : GenericRepository<Customer>(context), ICustomerRepository
{

    // Método existente
    public override async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método existente
    public override async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<Customer> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Customers as IQueryable<Customer>;

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