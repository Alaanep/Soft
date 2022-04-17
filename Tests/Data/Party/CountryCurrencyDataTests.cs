using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests: SealedClassTests<CountryCurrencyData> {
        [TestMethod] public void CountryIdTest() => isProperty<string>();
        [TestMethod] public void CurrencyIdTest() => isProperty<string>();
    }
}
