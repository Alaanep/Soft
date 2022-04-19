using ABC.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data {
    [TestClass] public class NamedDataTests: AbstractClassTests<NamedData, UniqueData> {

        private class testClass: NamedData{}
        protected override NamedData createObj() => new testClass();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void CodeTest() => isProperty<string>();
    }
}
