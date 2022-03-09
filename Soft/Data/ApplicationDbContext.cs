using ABC.Infra;
using ABC.Infra.Party;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Soft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            initializeTables(modelBuilder);
        }

        private static void initializeTables(ModelBuilder modelBuilder)
        {
            ABCDb.InitializeTables(modelBuilder);
        }
    }
}
