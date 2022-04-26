using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass]
public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>>
{
    [TestMethod] public void CountryCurrenciesTest() => 
        ItemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(d => d.CurrencyId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies);
    [TestMethod] public void CountriesTest() => relatedItemsTest<ICountriesRepo, CountryCurrency, Country, CountryData>
        (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Countries, x => x.CountryId, d => new Country(d), c => c?.Data, x => x?.Country?.Data);
}