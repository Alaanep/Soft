using ABC.Data.Party;
using ABC.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Domain;

[TestClass]
public class NamedEntityTests : AbstractClassTests {
    private class testClass: NamedEntity<CountryData> { }
    protected override object createObj() => new testClass();
}