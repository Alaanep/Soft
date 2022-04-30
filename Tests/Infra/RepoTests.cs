using ABC.Data.Party;
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
    public class RepoTests : AbstractClassTests<Repo<Address, AddressData>, PagedRepo<Address, AddressData>>{
        private class testClass : Repo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override Repo<Address, AddressData> createObj() => new testClass(null, null);
    }

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

        [TestMethod] public void DbTest() => isInconclusive();
        [TestMethod] public void SetTest() => isInconclusive();
        [TestMethod] public void BaseRepoTest() => isInconclusive();
        [TestMethod] public void ClearTest()=>isInconclusive();
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
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<Address, AddressData>, BaseRepo<Address, AddressData>>{
        private class testClass : CrudRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override CrudRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Address, AddressData>, CrudRepo<Address, AddressData>>{
        private class testClass : FilteredRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected  internal override Address toDomain(AddressData d) => new(d);
        }
        protected override FilteredRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class OrdereredRepoTests : AbstractClassTests<OrderedRepo<Address, AddressData>, FilteredRepo<Address, AddressData>>{
        private class testClass : OrderedRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override OrderedRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Address, AddressData>, OrderedRepo<Address, AddressData>>
    {
        private class testClass : PagedRepo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override PagedRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class ABCDbTests : SealedBaseTests<ABCDb, DbContext>{
        protected override ABCDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
