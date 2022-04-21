using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain;

[TestClass]
public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity> {
    private CountryData? d;

    private class testClass : UniqueEntity<CountryData>
    {
        public testClass(): this(new CountryData()){}

        public testClass(CountryData d): base(d) { }
    }

    protected override UniqueEntity<CountryData> createObj()
    {
        d = GetRandom.Value<CountryData>();
        return new testClass(d);
    } 

    [TestMethod]
    public void IdTest() => isReadOnly(obj.Data.Id);

    [TestMethod]
    public void DataTest() => isReadOnly(d);
    [TestMethod] public void defaultStrTest() => areEqual("Undefined", UniqueEntity.defaultStr);
}