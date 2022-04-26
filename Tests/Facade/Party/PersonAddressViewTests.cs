using ABC.Aids;
using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ABC.Tests.Facade.Party
{
    [TestClass] public class PersonAddressViewTests: SealedClassTests<PersonAddressView, NamedView>{
        [TestMethod]public void PersonIdTest() => isRequired<string>("Person");
        [TestMethod] public void AddressIdTest() => isRequired<string>("Geographic Address");
        [TestMethod] public void CodeTest() => isDisplayNamed<string>("Use for");
    }
}
