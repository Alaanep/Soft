using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra {
    [TestClass]public class RepoTests : AbstractClassTests<Repo<Address, AddressData>, PagedRepo<Address, AddressData>> {
        private class testClass : Repo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override Repo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Address, AddressData>, OrderedRepo<Address, AddressData>> {
        private class testClass : PagedRepo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override PagedRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class ABCDbTests : SealedBaseTests<ABCDb, DbContext> {
        protected override ABCDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
