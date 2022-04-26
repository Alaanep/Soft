using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABC.Aids;

namespace ABC.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<AddressView, Address, AddressData>, object> {
        private class testClass : BaseViewFactory<AddressView, Address, AddressData> {
            protected override Address toEntity(AddressData d) => new(d);
        }
        protected override BaseViewFactory<AddressView, Address, AddressData> createObj() => new testClass();

        [TestMethod]public void CreateTest() { }

        [TestMethod] public void CreateViewTest() {
            var v = GetRandom.Value<AddressView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<AddressData>();
            var v = obj.Create(new Address(d));
            areEqualProperties(d, v);
        }
    }
}
