using ABC.Aids;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Aids {
    
    [TestClass] class EnumsTests : IsTypeTested
    {
        [TestMethod] public void DescriptionTests() 
            => areEqual("Not applicable", Enums.Description(IsoGender.NotApplicable));

        [TestMethod]
        public void ToStringTest()
            => areEqual("NotApplicable", IsoGender.NotApplicable);


    }
}
