using Microsoft.EntityFrameworkCore;
using NewCrudApp.Models.Domain;

namespace NewCrudApp.Controllers.Data
{
    public class NewDbContext : DbContext
    {
        public NewDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Employee> Employee_Tab { get; set; }
    }
}
