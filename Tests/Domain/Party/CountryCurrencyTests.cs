using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
    protected override CountryCurrency createObj() => new CountryCurrency(GetRandom.Value<CountryCurrencyData>());
    

    [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
    [TestMethod] public void CurrencyIdTest() => isReadOnly(obj.Data.CurrencyId);
    [TestMethod] public void CountryTest() =>
        itemTest<ICountriesRepo, Country, CountryData>(obj.CountryId, d => new Country(d), () => obj.Country);
    [TestMethod] public void CurrencyTest() =>
        itemTest<ICurrenciesRepo, Currency, CurrencyData>(obj.CurrencyId, d => new Currency(d), () => obj.Currency);

}