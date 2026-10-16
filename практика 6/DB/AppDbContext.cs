using Microsoft.EntityFrameworkCore;

namespace практика_6.DB
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VERONIKA\\SQLEXPRESS;Database=WebApiDatabase;Trusted_Connection=True;TrustServerCertificate = True;");
        }
    }
}