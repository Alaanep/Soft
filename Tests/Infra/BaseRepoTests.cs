using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Tests.Infra
{
    [TestClass]
    public class BaseRepoTests : AbstractClassTests<BaseRepo<Address, AddressData>, object>{
        private class testClass : BaseRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }

            public override bool Add(Address obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Address obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override Address Get(string id) => throw new NotImplementedException();
            public override List<Address> Get() => throw new NotImplementedException();
            public override List<Address> GetAll(Func<Address, dynamic>? orderBy = null) => throw new NotImplementedException();
            public override Task<Address> GetAsync(string id) => throw new NotImplementedException();
            public override Task<List<Address>> GetAsync() => throw new NotImplementedException();
            public override bool Update(Address obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Address obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Address, AddressData> createObj() => new testClass(null, null);

        [TestMethod] public void dbTest() => isReadOnly<DbContext>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<AddressData>>();
        [TestMethod] public void BaseRepoTest()
        {
            var db = GetRepo.Instance<ABCDb>();
            var set = db?.Addresses;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task  ClearTest()
        {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<AddressData>());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Address));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Address, dynamic>));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Address));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Address));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetAsyncListTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Address));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
    }
}
