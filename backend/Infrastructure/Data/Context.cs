﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }

    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<PayType> PaysType { get; set; }
    public virtual DbSet<Price> Prices { get; set; }
    public virtual DbSet<Rent> Rents { get; set; }
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rent>()
            .HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.IdCustomer);

        modelBuilder.Entity<Rent>()
            .HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.IdCar);
    }
}
