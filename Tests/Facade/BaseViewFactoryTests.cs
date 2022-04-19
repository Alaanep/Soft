using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<AddressView, Address, AddressData>, object> {
        private class testClass : BaseViewFactory<AddressView, Address, AddressData> {
            protected override Address toEntity(AddressData d) => new(d);
        }
        protected override BaseViewFactory<AddressView, Address, AddressData> createObj() => new testClass();
    }
}
