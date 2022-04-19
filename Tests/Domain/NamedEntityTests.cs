using ABC.Data.Party;
using ABC.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain;

[TestClass]
public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, UniqueEntity<CountryData>> {
    private class testClass: NamedEntity<CountryData> { }
    protected override NamedEntity<CountryData> createObj() => new testClass();
    [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
    [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data.Description);
    [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
}