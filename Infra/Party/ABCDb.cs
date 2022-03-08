﻿using ABC.Data.Party;
using ABC.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra.Party {
    public sealed class ABCDb: DbContext {
        public ABCDb(DbContextOptions<ABCDb> options) : base(options) { }
        public DbSet<PersonData> Persons { get; set; }
        public DbSet<AddressData> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }

        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            var s = nameof(ABCDb).Substring(0, 4);
            modelBuilder?.Entity<PersonData>()?.ToTable(nameof(Persons), s);
            modelBuilder?.Entity<AddressData>()?.ToTable(nameof(Addresses), s);
        }

    }
}
