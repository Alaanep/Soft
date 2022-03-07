using ABC.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra.Party {
    public sealed class ABCDb: DbContext {
        public ABCDb(DbContextOptions<ABCDb> options) : base(options) { }
        public DbSet<PersonData> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }

        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder?.Entity<PersonData>()?.ToTable(nameof(Persons), nameof(ABCDb).Substring(0, 4));
        }

    }
}
