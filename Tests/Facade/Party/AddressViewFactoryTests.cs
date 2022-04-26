using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass] public class AddressViewFactoryTests : ViewFactoryTests<AddressViewFactory, AddressView, Address, AddressData>{
        protected override Address toObject(AddressData d) => new Address(d);
    }
}
