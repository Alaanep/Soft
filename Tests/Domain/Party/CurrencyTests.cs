using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass]
public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>>
{
    [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
    [TestMethod] public void CountriesTest() => isInconclusive();
}