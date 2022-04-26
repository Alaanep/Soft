using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]public class CountryViewTests: SealedClassTests<CountryView, IsoNamedView> {}
}
