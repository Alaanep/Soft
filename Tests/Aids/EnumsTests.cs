using ABC.Aids;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Aids {
    
    [TestClass]public class EnumsTests : IsTypeTested
    {
        [TestMethod] public void DescriptionTest() 
            => areEqual("Not Applicable", Enums.Description(IsoGender.NotApplicable));

        [TestMethod]
        public void ToStringTest()
            => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());


    }
}
