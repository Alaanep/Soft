using System;
using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party {
    [TestClass]
    public class AddressTests : SealedClassTests<Address, UniqueEntity<AddressData>> {
        
        protected override Address createObj() => new(GetRandom.Value<AddressData>());

        [TestMethod]
        public void StreetTest() => isReadOnly(obj.Data.Street);

        [TestMethod]
        public void CityTest() => isReadOnly(obj.Data.City);

        [TestMethod]
        public void RegionTest() => isReadOnly(obj.Data.Region);

        [TestMethod]
        public void ZipCodeTest() => isReadOnly(obj.Data.ZipCode);

        [TestMethod]
        public void CountryIdTest() => isReadOnly(obj.Data.CountryId);

        [TestMethod]
        public void ToStringTest() {   
            var expected = $"{obj.Street} {obj.City} {obj.ZipCode} {obj.CountryId} {obj.Country?.Name}";
            areEqual(expected, obj.ToString());
        }

        [TestMethod]
        public void CountryTest() =>
            itemTest<ICountriesRepo, Country, CountryData>(obj.CountryId, d => new Country(d), () => obj.Country);

    }
}

