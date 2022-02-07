using System;
using ABC.Facade.Party;
using ABC.Tests.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party
{   
    [TestClass]
    public class PersonViewTests: BaseTests<PersonView>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void DobTest() => isProperty<DateTime?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
