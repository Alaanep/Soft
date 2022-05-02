using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ABC.Tests.Infra {
    [TestClass]public class CrudRepoTests : AbstractClassTests<CrudRepo<Address, AddressData>, BaseRepo<Address, AddressData>> {

        private int cnt;
        private ABCDb? db;
        private DbSet<AddressData>? set;
        private AddressData? d;
        private Address? a;


        private class testClass : CrudRepo<Address, AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override CrudRepo<Address, AddressData> createObj() {
            db = GetRepo.Instance<ABCDb>();
            set = db?.Addresses;
            isNotNull(set);
            return new testClass(db, set);
        }

        [TestInitialize]public override void InitializeRepo() {
            base.InitializeRepo();
            initSet();
            initAdr();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<AddressData>());
            _= db?.SaveChanges();
        }

        private void initAdr() {
            d = GetRandom.Value<AddressData>();
            isNotNull(d);
            a = new Address(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }

        [TestMethod]public async Task AddTest() {
            isNotNull(a);
            isNotNull(set);
            _= obj?.Add(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod]public async Task GetTest() {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod]public void GetListTest() {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [DataRow(nameof(Address.Id))]
        [DataRow(nameof(Address.CountryId))]
        [DataRow(nameof(Address.Street))]
        [DataRow(nameof(Address.City))]
        [DataRow(nameof(Address.ZipCode))]
        [DataRow(nameof(Address.Region))]
        [DataRow(nameof(Address.ToString))]
        [DataRow(nameof(Address.Country))]
        [TestMethod] public void GetAllTest(string s) {
            Func<Address, dynamic>? orderBy = null;
            if (s is nameof(Address.Street)) orderBy = x => x.Street;
            else if (s is nameof(Address.City)) orderBy = x => x.City;
            else if (s is nameof(Address.ZipCode)) orderBy = x => x.ZipCode;
            else if (s is nameof(Address.Region)) orderBy = x => x.Region;
            else if (s is nameof(Address.CountryId)) orderBy = x => x.CountryId;
            else if (s is nameof(Address.Id)) orderBy = x => x.Id;
            else if (s is nameof(Address.Country)) orderBy = x => x.Country;
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy == null) return;
            for (var i = 0; i < l.Count - 1; i++) {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX= GetRandom.Value<AddressData>() as AddressData;
            isNotNull(dX);
            isNotNull(d);
            dX.Id = d.Id;
            var aX = new Address(dX);
            _=obj.Update(aX);
            var x = obj.Get(d.Id);
            arePropertiesEqual(dX, x.Data);
        }

        [TestMethod]public async Task DeleteTest() {
            isNotNull(d);
            await GetTest();
            _= obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(a);
            isNotNull(set);
            _=await obj.AddAsync(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task GetAsyncTest() {
            isNotNull(d);
            await AddAsyncTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetAsyncListTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod]
        public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<AddressData>() as AddressData;
            isNotNull(dX);
            isNotNull(d);
            dX.Id = d.Id;
            var aX = new Address(dX);
            _= await obj.UpdateAsync(aX);
            var x = obj.Get(d.Id);
            arePropertiesEqual(dX, x.Data);
        }

            [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetAsyncTest();
            _= obj.DeleteAsync(d.Id);
            var x = obj.GetAsync(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
    }
}
