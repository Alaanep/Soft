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
    [TestMethod] public void ToStringTest() => isInconclusive();
    [TestMethod] public void AddressesTest() => isInconclusive();
}