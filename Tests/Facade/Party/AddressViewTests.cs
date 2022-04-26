using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]
    public class AddressViewTests: SealedClassTests<AddressView, UniqueView> {
        
        [TestMethod] public void StreetTest() => isDisplayNamed<string?>("Street");
        [TestMethod] public void CityTest() => isDisplayNamed<string?>("City");
        [TestMethod] public void RegionTest() => isDisplayNamed<string?>("Region");
        [TestMethod] public void ZipCodeTest() => isDisplayNamed<string?>("Zip Code");
        [TestMethod] public void CountryIdTest() => isDisplayNamed<string?>("Country id");
    }
}
