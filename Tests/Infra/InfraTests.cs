using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra {
    [TestClass]
    class InfraTests : AbstractClassTests
    {
        protected override object createObj() => new testClass(null, null);

        private class testClass : Repo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
    }
}
