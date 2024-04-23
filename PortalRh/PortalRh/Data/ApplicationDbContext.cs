
using Microsoft.EntityFrameworkCore;
using PortalRh.Models;


namespace PortalRh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Expediente> Expedientes { get; set; }
    }
}
