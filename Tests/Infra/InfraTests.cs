using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra {
    [TestClass]
    class InfraTests : AbstractClassTests<Repo<Address, AddressData>, PagedRepo<Address, AddressData>>
    {
        protected override Repo<Address, AddressData> createObj() => new testClass(null, null);

        private class testClass : Repo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
    }
}
