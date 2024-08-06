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

        public void DoSomething()
        {
            // Obtener la cadena de conexión
            string connectionString = _configuration.GetConnectionString("MysqlConnection");
            // Usar la cadena de conexión
            Console.WriteLine(connectionString);
        }
    }
    public class ApplicationDbContextMySQL : IdentityDbContext
    {
        public ApplicationDbContextMySQL(DbContextOptions<ApplicationDbContextMySQL> options)
            : base(options)
        {
        }


        public DbSet<reg_nominas> reg_nominas { get; set; }
        public DbSet<SericaReporteModel> sericaReporteModels { get; set; }
  


    }
}
