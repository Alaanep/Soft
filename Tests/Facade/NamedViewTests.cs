using ABC.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ABC.Tests.Facade
{
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, UniqueView>
    {
        protected override NamedView createObj() => new testClass();
        private class testClass : NamedView { }
        [TestMethod] public void CodeTest() => isRequired<string?>("Code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("Description");
    }
}
