using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
    [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
    [TestMethod] public void CurrenciesTest() => isInconclusive();
}