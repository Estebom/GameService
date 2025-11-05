using GameService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
