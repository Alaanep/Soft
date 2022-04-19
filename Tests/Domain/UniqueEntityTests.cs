using ABC.Data.Party;
using ABC.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain;

[TestClass]
public class UniqueEntityTests : AbstractClassTests {
    private class testClass : UniqueEntity<CountryData> { }
    protected override object createObj() => new testClass();

}