using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain.Party;

[TestClass]
public class PersonTests : SealedClassTests<Person, UniqueEntity<PersonData>> {
    protected override Person createObj() => new Person(GetRandom.Value<PersonData>());
    [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
    [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
    [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
    [TestMethod] public void DobTest() => isReadOnly(obj.Data.Dob);

    [TestMethod] public void ToStringTest() {
        var expected = $"{obj.FirstName} {obj.LastName} ({obj.Gender.Description()} {obj.Dob})";
        areEqual(expected, obj.ToString());
    }
    [TestMethod]
    public void PersonAddressesTest() =>
        ItemsTest<IPersonAddressesRepo, PersonAddress, PersonAddressData>
            (d => d.PersonId = obj.Id, d => new PersonAddress(d), () => obj.PersonAddresses);

    [TestMethod]
    public void AddressesTest() => relatedItemsTest<IAddressRepo, PersonAddress, Address, AddressData>
        (PersonAddressesTest, () => obj.PersonAddresses, () => obj.Addresses, x => x.AddressId, d => new Address(d), c => c?.Data, x => x?.Address?.Data);
}