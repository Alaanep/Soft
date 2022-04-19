using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass] public class PersonAddressTests : SealedClassTests<PersonAddress, NamedEntity<PersonAddressData>> {
    protected override PersonAddress createObj() => new PersonAddress(GetRandom.Value<PersonAddressData>());
    [TestMethod] public void PersonIdTest() => isReadOnly(obj.Data.PersonId);
    [TestMethod] public void AddressIdTest() => isReadOnly(obj.Data.AddressId);
}