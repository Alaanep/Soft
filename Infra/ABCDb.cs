using ABC.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra {
    public sealed class ABCDb: DbContext {
        public ABCDb(DbContextOptions<ABCDb> options) : base(options) { }
        public DbSet<PersonData>? Persons { get; set; }
        public DbSet<AddressData>? Addresses { get; set; }
        public DbSet<CountryData>? Countries { get; set; }
        //public DbSet<CurrencyData>? Currencies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }

        public static void InitializeTables(ModelBuilder modelBuilder) {
            var s = nameof(ABCDb).Substring(0,4);
            _= (modelBuilder?.Entity<PersonData>()?.ToTable(nameof(Persons), s));
            _ = (modelBuilder?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
            _ = (modelBuilder?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            //_ = (modelBuilder?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s));
        }
    }
}
