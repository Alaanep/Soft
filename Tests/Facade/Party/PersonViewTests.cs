using System;
using ABC.Data.Party;
using ABC.Facade;
using ABC.Facade.Party;
using ABC.Tests.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party
{   
    [TestClass]
    public class PersonViewTests: SealedClassTests<PersonView, UniqueView>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void DobTest() => isProperty<DateTime?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
