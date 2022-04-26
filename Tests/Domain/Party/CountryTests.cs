using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;
[TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
    [TestMethod] public void CountryCurrenciesTest() => 
        ItemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>
            (d=>d.CountryId=obj.Id, d=>new CountryCurrency(d), ()=>obj.CountryCurrencies);

    [TestMethod]
    public void CurrenciesTest() => relatedItemsTest<ICurrenciesRepo, CountryCurrency, Currency, CurrencyData>
        (CountryCurrenciesTest, ()=>obj.CountryCurrencies, ()=>obj.Currencies,  x=>x.CurrencyId, d=>new Currency(d), c=>c?.Data, x=>x?.Currency?.Data);
    
    
}