using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateTime = System.DateTime;

namespace ABC.Tests.Data.Party
{   
    [TestClass]
    public class PersonDataTests: SealedClassTests<PersonData>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender>();
        [TestMethod] public void DobTest() => isProperty<DateTime?>();
    }
}
