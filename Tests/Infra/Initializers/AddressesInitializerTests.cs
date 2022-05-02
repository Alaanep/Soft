using ABC.Data.Party;
using ABC.Domain;
using ABC.Infra;
using ABC.Infra.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ABC.Tests.Infra.Initializers {

    [TestClass]public class AddressesInitializerTests : SealedBaseTests<AddressesInitializer, BaseInitializer<AddressData>> {
        protected override AddressesInitializer createObj() {
            var db = GetRepo.Instance<ABCDb>();
            return new AddressesInitializer(db);
        }
    }

    [TestClass] public class CountriesInitializerTests : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>> {
        protected override CountriesInitializer createObj() {
            var db = GetRepo.Instance<ABCDb>();
            return new CountriesInitializer(db);
        }
    }
    [TestClass]public class CountryCurrenciesInitializerTests : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer createObj() {
            var db = GetRepo.Instance<ABCDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
    [TestClass]public class CurrenciesInitializerTests : SealedBaseTests<CurrenciesInitializer, BaseInitializer<CurrencyData>> {
        protected override CurrenciesInitializer createObj() {
            var db = GetRepo.Instance<ABCDb>();
            return new CurrenciesInitializer(db);
        }
    }

    [TestClass]public class PersonsInitializerTests : SealedBaseTests<PersonsInitializer, BaseInitializer<PersonData>> {
        protected override PersonsInitializer createObj() {
            var db = GetRepo.Instance<ABCDb>();
            return new PersonsInitializer(db);
        }
    }

    [TestClass]public class BaseInitializerTests : AbstractClassTests<BaseInitializer<AddressData>, object> {

        private class testClass : BaseInitializer<AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) {
            }

            protected override IEnumerable<AddressData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<AddressData> createObj() => new testClass(null, null);
    }

    [TestClass] public class AbcInitializerTests: TypeTests { }
}
