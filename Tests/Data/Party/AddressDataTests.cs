using ABC.Data;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data.Party {
    [TestClass] public class AddressDataTests: SealedClassTests<AddressData, UniqueData> {
        [TestMethod] public void StreetTest() => isProperty<string>();
        [TestMethod] public void CityTest() => isProperty<string?>();
        [TestMethod] public void RegionTest() => isProperty<string?>();
        [TestMethod] public void ZipCodeTest() => isProperty<string?>();
        [TestMethod] public void CountryIdTest() => isProperty<string?>();
    }
}
