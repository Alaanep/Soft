using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass] public class AddressViewFactoryTests
        : SealedClassTests<AddressViewFactory, BaseViewFactory<AddressView, Address, AddressData>> {
        [TestMethod]
        public void CreateViewTest() {
            var d = GetRandom.Value<AddressData>();
            var e = new Address(d);
            var v = new AddressViewFactory().Create(e);
            isNotNull(v);
            //todo motelge
            //arePropertiesEqual(v, e, nameof(v.fullName))
            areEqual(v.Id, e.Id);
            areEqual(v.Street, e.Street);
            areEqual(v.City, e.City);
            areEqual(v.Region, e.Region);
            areEqual(v.ZipCode, e.ZipCode);
            areEqual(v.CountryId, e.CountryId);
            //areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<AddressView>();
            var e = new AddressViewFactory().Create(v);
            isNotNull(e);
            //todo motelge
            //arePropertiesEqual(v, e)
            areEqual(e.Id, v?.Id);
            areEqual(e.Street, v?.Street);
            areEqual(e.City, v?.City);
            areEqual(e.Region, v?.Region);
            areEqual(e.ZipCode, v?.ZipCode);
            areEqual(e.CountryId, v?.CountryId);
            //areNotEqual(e.ToString(), v?.FullName);
        }
    }
}
