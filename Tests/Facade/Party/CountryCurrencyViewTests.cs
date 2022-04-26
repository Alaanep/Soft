using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Tests.Facade.Party{
    [TestClass] public class CountryCurrencyViewTests: SealedClassTests<CountryCurrencyView, NamedView>{
        [TestMethod]public void CountryIdTest() => isRequired<string>("Country");
        [TestMethod] public void CurrencyIdTest() => isRequired<string>("Currency");
        [TestMethod] public void NameTest() => isDisplayNamed<string>("Currency Native Name");
        [TestMethod] public void CodeTest() => isDisplayNamed<string>("Currency Native Code");
    }
}
