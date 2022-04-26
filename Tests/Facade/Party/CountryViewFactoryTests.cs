using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]
    public class CountryViewFactoryTests
        : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData>{
        protected override Country toObject(CountryData d) => new Country(d);
    }
}
