using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]
    public class AddressViewTests: SealedClassTests<AddressView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void StreetTest() => isProperty<string?>();
        [TestMethod] public void CityTest() => isProperty<string?>();
        [TestMethod] public void RegionTest() => isProperty<string?>();
        [TestMethod] public void ZipCodeTest() => isProperty<string?>();
        [TestMethod] public void CountryTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
