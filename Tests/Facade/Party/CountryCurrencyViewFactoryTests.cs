using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party
{
    [TestClass]
    public class CountryCurrencyViewFactoryTests : ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrency toObject(CountryCurrencyData d)=>new CountryCurrency(d);
    }
}
