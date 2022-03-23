using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests: SealedClassTests<CountryView> {
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<CountryData>();
            var e = new Country(d);
            var v = new CountryViewFactory().Create(e);
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
            var v = GetRandom.Value<CountryView>();
            var e = new CountryViewFactory().Create(v);
            isNotNull(e);
            //todo motelge
            //arePropertiesEqual(v, e)

            areEqual(e.Id, v.Id);
            areEqual(e.Code, v.Code);
            areEqual(e.Name, v.Name);
            areEqual(e.Description, v.Description);

        }
    }
}
