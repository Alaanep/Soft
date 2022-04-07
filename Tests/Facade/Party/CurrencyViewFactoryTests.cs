using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass] public class CurrencyViewFactoryTests: SealedClassTests<CurrencyView> {
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<CurrencyData>();
            var e = new Currency(d);
            var v = new CurrencyViewFactory().Create(e);
            isNotNull(v);
            //todo motelge
            //arePropertiesEqual(v, e, nameof(v.fullName))
            areEqual(v.Id, e.Id);
            areEqual(v.Code, e.Code);
            areEqual(v.Name, e.Name);
            areEqual(v.Description, e.Description);

        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<CurrencyView>();
            var e = new CurrencyViewFactory().Create(v);
            isNotNull(e);
            //todo motelge
            //arePropertiesEqual(v, e)

            areEqual(e.Id, v?.Id);
            areEqual(e.Code, v?.Code);
            areEqual(e.Name, v?.Name);
            areEqual(e.Description, v?.Description);

        }
    }
}
