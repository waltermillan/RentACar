using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Context _context;
    private ICarRepository _cars;
    private ICustomerRepository _customers;
    private IPayTypeRepository _paysType;
    private IRentRepository _rents;
    private IPriceRepository _prices;
    private IDocumentRepository _documents;
    private IUserRepository _users;
    private IRolRepository _roles;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public ICarRepository Cars
    {
        get
        {
            if(_cars is null)
                _cars = new CarRepository(_context);
            return _cars;
        }
    }

    public ICustomerRepository Customers
    {
        get
        {
            if(_customers is null)
                _customers = new CustomerRepository(_context);
            return _customers;
        }
    }

    public IPayTypeRepository PaysType
    {
        get
        {
            if (_paysType is null)
                _paysType = new PayTypeRepository(_context);
            return _paysType;
        }
    }
    public IRentRepository Rents
    {
        get
        {
            if (_rents is null)
                _rents = new RentRepository(_context);

            return _rents;

        }
    }

    public IPriceRepository Prices
    {
        get
        {
            if (_prices is null)
                _prices = new PriceRepository(_context);

            return _prices;
        }
    }

    public IDocumentRepository Documents
    {
        get
        {
            if (_documents is null)
                _documents = new DocumentRepository(_context);

            return _documents;
        }
    }
    public IUserRepository Users
    {
        get
        {
            if (_users is null)
                _users = new UserRepository(_context);

            return _users;
        }
    }

    public IRolRepository Roles
    {
        get
        {
            if (_roles is null)
                _roles = new RolRepository(_context);
            return _roles;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
