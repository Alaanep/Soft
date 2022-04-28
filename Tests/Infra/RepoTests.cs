using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Tests.Infra
{
    [TestClass]
    public class RepoTests : AbstractClassTests<Repo<Address, AddressData>, PagedRepo<Address, AddressData>>{
        private class testClass : Repo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override Repo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class BaseRepoTests : AbstractClassTests<BaseRepo<Address, AddressData>, object>{
        private class testClass : BaseRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            public override bool Add(Address obj) => throw new System.NotImplementedException();
            public override Task<bool> AddAsync(Address obj) => throw new System.NotImplementedException();
            public override bool Delete(string id) => throw new System.NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new System.NotImplementedException();
            public override Address Get(string id) => throw new System.NotImplementedException();
            public override List<Address> Get() => throw new System.NotImplementedException();
            public override List<Address> GetAll<TKey>(System.Func<Address, TKey>? orderBy = null) => throw new System.NotImplementedException();
            public override Task<Address> GetAsync(string id) => throw new System.NotImplementedException();
            public override Task<List<Address>> GetAsync() => throw new System.NotImplementedException();
            public override bool Update(Address obj) => throw new System.NotImplementedException();
            public override Task<bool> UpdateAsync(Address obj) => throw new System.NotImplementedException();
        }
        protected override BaseRepo<Address, AddressData> createObj() => new testClass(null, null);
    }
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<Address, AddressData>, BaseRepo<Address, AddressData>>{
        private class testClass : CrudRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override CrudRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Address, AddressData>, CrudRepo<Address, AddressData>>{
        private class testClass : FilteredRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override FilteredRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class OrdereredRepoTests : AbstractClassTests<OrderedRepo<Address, AddressData>, FilteredRepo<Address, AddressData>>{
        private class testClass : OrderedRepo<Address, AddressData>{
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override OrderedRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Address, AddressData>, OrderedRepo<Address, AddressData>>
    {
        private class testClass : PagedRepo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override PagedRepo<Address, AddressData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class ABCDbTests : SealedBaseTests<ABCDb, DbContext>{
        protected override ABCDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
