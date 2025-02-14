using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public partial class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PayType> PaysType { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Core.Entities.Customer>()
                .HasKey(c => c.Id);  // Define Id as the primary key
        }
    }
}
