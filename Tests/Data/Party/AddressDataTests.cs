using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Data.Party {
    [TestClass] public class AddressDataTests: SealedClassTests<AddressData> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void Street() => isProperty<string>();
        [TestMethod] public void City() => isProperty<string>();
        [TestMethod] public void Region() => isProperty<string>();
        [TestMethod] public void ZipCode() => isProperty<string>();
        [TestMethod] public void Country() => isProperty<string>();
    }
}
