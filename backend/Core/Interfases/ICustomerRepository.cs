using Core.Entities;
using System.Net;

namespace Core.Interfases;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer> GetByCustomerIdAsync(int customerId);
}
