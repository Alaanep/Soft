using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party {
    [TestClass] public class AddressTests: SealedClassTests<Address, UniqueEntity<AddressData>> {
        [TestInitialize] public void Init() =>
            (GetRepo.Instance<ICountriesRepo>() as CountriesRepo)?.clear();
        

        protected override Address createObj() => new (GetRandom.Value<AddressData>());
        [TestMethod] public void StreetTest() => isReadOnly(obj.Data.Street);
        [TestMethod]public void CityTest() => isReadOnly(obj.Data.City);
        [TestMethod]public void RegionTest() => isReadOnly(obj.Data.Region);
        [TestMethod]public void ZipCodeTest() => isReadOnly(obj.Data.ZipCode);
        [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
        [TestMethod]public void ToStringTest() => isInconclusive();
        [TestMethod] public void CountryTest() {
            var c = isReadOnly<Country>();
            isNotNull(c);
            isInstanceOfType(c, typeof(Country));
            var r = GetRepo.Instance<ICountriesRepo>();
            var d = GetRandom.Value<CountryData>() as CountryData;
            d.Id = obj.CountryId;
            var count = GetRandom.Int32(0, 30);
            var index = GetRandom.Int32(0, count);
            for (var i = 0; i < count; i++) {
                var x = (i==index) ? d: GetRandom.Value<CountryData>() as CountryData;
                isNotNull(x);
                r?.Add(new Country(x));
            }

            var country = obj.Country;
            r.PageSize = 30;
            areEqual(count, r.Get().Count);
            isNotNull(country);
            areEqual(d.Id, country.Id);
            areEqual(d.Name, country.Name);
            areEqual(d.Code, country.Code);
            areEqual(d.Description, country.Description);



        }

    }
}

