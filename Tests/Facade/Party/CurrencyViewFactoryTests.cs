using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]
    public class CurrencyViewFactoryTests : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData>{
        protected override Currency toObject(CurrencyData d)=>new Currency(d);
    }
}
