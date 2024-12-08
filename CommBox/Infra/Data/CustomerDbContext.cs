// CommBox.Infra.Data/CustomerDbContext.cs
using System;
using Microsoft.EntityFrameworkCore;

namespace CommBox.Infra.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            Customers = Set<CustomerDto>();
        }

        public DbSet<CustomerDto> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
