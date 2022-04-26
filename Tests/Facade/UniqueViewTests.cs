using ABC.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ABC.Tests.Facade
{
    [TestClass]
    public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        protected override UniqueView createObj() => new testClass();
        private class testClass : UniqueView{ }
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
