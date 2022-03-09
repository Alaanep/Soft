using ABC.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ABC.Tests.Facade {
    [TestClass]
    public class BaseViewTests : AbstractClassTests {
        protected override object createObj() => new testClass();
        private class testClass : BaseView{ }
    }
}
