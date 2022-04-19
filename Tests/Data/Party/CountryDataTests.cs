using ABC.Data;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data.Party {
    [TestClass]
    public class CountryDataTests: SealedClassTests<CountryData, NamedData> {
        [TestMethod] public void NameTest() => isProperty<string>();
        [TestMethod] public void CodeTest() => isProperty<string>();
        [TestMethod] public void DescriptionTest() => isProperty<string>();
    }
}
