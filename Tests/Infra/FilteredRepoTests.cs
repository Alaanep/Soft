using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra {
    [TestClass] public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Address, AddressData>, CrudRepo<Address, AddressData>> {
        private class testClass : FilteredRepo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override FilteredRepo<Address, AddressData> createObj() {
            var db = GetRepo.Instance<ABCDb>();
            var set = db?.Addresses;
            return new testClass(db, set);
        }

        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter=hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));

        }
    }
}
