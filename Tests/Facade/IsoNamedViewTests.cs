using ABC.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ABC.Tests.Facade
{
    [TestClass]
    public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView>{
        protected override IsoNamedView createObj() => new testClass();
        private class testClass : IsoNamedView { }
        [TestMethod] public void CodeTest() => isRequired<string?>("ISO Three-Letter Code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Native Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("English Name");
        
    }


}
