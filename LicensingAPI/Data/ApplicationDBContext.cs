using LicensingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<TechEODService> TechEODServices { get; set; }

        public DbSet<SOA> SOAs { get; set; }
        public DbSet<SOA_Details> SOA_Details { get; set; }
    }
}
