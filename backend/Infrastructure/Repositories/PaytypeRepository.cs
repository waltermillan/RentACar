using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PayTypeRepository(Context context) : GenericRepository<PayType>(context), IPayTypeRepository
{
    public override async Task<PayType> GetByIdAsync(int id)
    {
        return await _context.PaysType
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<PayType>> GetAllAsync()
    {
        return await _context.PaysType.ToListAsync();
    }
}