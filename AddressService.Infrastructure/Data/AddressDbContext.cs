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

        public DbSet<Address> Address { get; set; } = null!;
    }
}
