using System;
using System.Collections.Generic;
using ABC.Aids;
using ABC.Data;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;
[TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {

    

        [TestMethod]
    public void CountryCurrenciesTest() => 
        ItemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(d=>d.CountryId=obj.Id, d=>new CountryCurrency(d), ()=>obj.CountryCurrencies);

    

    [TestMethod]
        public void CurrenciesTest() => isInconclusive();
    
}