using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain;

[TestClass]
public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, UniqueEntity<CountryData>> {
    private class testClass : NamedEntity<CountryData>
    {
        public testClass() : this(new CountryData()) { }
        public testClass(CountryData d) : base(d) { }
    }
    protected override NamedEntity<CountryData> createObj() => new testClass(GetRandom.Value<CountryData>());
    [TestMethod] public void NameTest() => isReadOnly(obj.Data?.Name);
    [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data?.Description);
    [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
}