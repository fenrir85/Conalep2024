
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalRh.Models;


namespace PortalRh.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<SatIdData> SatId { get; set; } 
        //public DbSet<reg_nominas> reg_nominas { get; set; }
    }
}
