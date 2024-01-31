using AddressService.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressService.Infrastructure.Data
{
    public class AddressDbContext : DbContext
    {
        public AddressDbContext(DbContextOptions<AddressDbContext> options)
        : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Addresses");

        }



    }
}
