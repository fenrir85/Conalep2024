using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalRh.Models;
using MySql.Data.MySqlClient;
using System.Data;

 

namespace PortalRh.Data

{

    public class MyService
    {
        private readonly IConfiguration _configuration;

        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
    public class ApplicationDbContextMySQL : IdentityDbContext
    {
        public ApplicationDbContextMySQL(DbContextOptions<ApplicationDbContextMySQL> options)
            : base(options)
        {
        }

        public DbSet<reg_nominas> reg_nominas { get; set; }
        public DbSet<SericaHeaderModel> sericaReporteModels { get; set; }
        public DbSet<SericaDetalleReporteModel> sericaDetalleReporteModels { get; set; }


    }
}
