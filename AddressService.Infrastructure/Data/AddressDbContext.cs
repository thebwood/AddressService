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

        public DbSet<Address> Addresses { get; set; } = null!;
    }
}
