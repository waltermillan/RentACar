﻿using Core.Interfases;

namespace Core.Interfases;

public interface IUnitOfWork
{
    ICarRepository Cars { get; }
    ICustomerRepository Customers { get; }
    IPayTypeRepository PaysType { get; }
    IPriceRepository Prices { get; }
    IRentRepository Rents { get; }
    IDocumentRepository Documents { get; }
    IUserRepository Users { get; }
    IRolRepository Roles { get; }

    void Dispose();
    Task<int> SaveAsync();
}
