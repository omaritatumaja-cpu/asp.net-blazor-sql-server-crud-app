using API.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AppicationDbContext : DbContext
    {
        public AppicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Clients {  get; set; }
        
    }
}
