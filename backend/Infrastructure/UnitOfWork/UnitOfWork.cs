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

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public ICarRepository Cars
    {
        get
        {
            _cars ??= new CarRepository(_context);
            return _cars;
        }
    }

    public ICustomerRepository Customers
    {
        get
        {
            _customers ??= new CustomerRepository(_context);
            return _customers;
        }
    }

    public IPayTypeRepository PaysType
    {
        get
        {
            _paysType ??= new PayTypeRepository(_context);
            return _paysType;
        }
    }
    public IRentRepository Rents
    {
        get
        {
            //if (_rents == null)
            //{
            //    _rents = new RentRepository(_context);
            //}
            //return _rents;
            _rents ??= new RentRepository(_context);
            return _rents;
        }
    }

    public IPriceRepository Prices
    {
        get
        {
            //if (_prices == null)
            //{
            //    _prices = new PriceRepository(_context);
            //}
            _prices ??= new PriceRepository(_context);
            return _prices;
        }
    }

    public IDocumentRepository Documents
    {
        get
        {
            //if (_documents == null)
            //{
            //    _documents = new DocumentRepository(_context);
            //}
            _documents ??= new DocumentRepository(_context);
            return _documents;
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
