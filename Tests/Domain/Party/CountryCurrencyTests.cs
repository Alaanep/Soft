using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
    protected override CountryCurrency createObj() => new CountryCurrency(GetRandom.Value<CountryCurrencyData>());
    [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
    [TestMethod] public void CurrencyIdTest() => isReadOnly(obj.Data.CurrencyId);
    [TestMethod] public void CountryTest() => isInconclusive();
    [TestMethod] public void CurrencyTest() => isInconclusive();

}