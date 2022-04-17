using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data.Party {
    [TestClass] public class PersonAddressDataTests: SealedClassTests<PersonAddressData> {
        [TestMethod] public void PersonIdTest() => isProperty<string>();
        [TestMethod] public void AddressIdTest() => isProperty<string>();
    }
}
