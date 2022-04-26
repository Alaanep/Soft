using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ABC.Tests.Facade.Party
{
    [TestClass]
    public class PersonAddressViewFactoryTests : ViewFactoryTests<PersonAddressViewFactory, PersonAddressView, PersonAddress, PersonAddressData>
    {
        protected override PersonAddress toObject(PersonAddressData d) => new PersonAddress(d);
    }
}
