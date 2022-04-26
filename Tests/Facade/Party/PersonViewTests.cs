using System;
using ABC.Data.Party;
using ABC.Facade;
using ABC.Facade.Party;
using ABC.Tests.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party{   
    [TestClass]public class PersonViewTests: SealedClassTests<PersonView, UniqueView>{
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string?>("First Name");
        [TestMethod] public void LastNameTest() => isDisplayNamed<string?>("Last Name");
        [TestMethod] public void GenderTest() => isDisplayNamed<IsoGender?>("Gender");
        [TestMethod] public void DobTest() => isDisplayNamed<DateTime?>("Date of birth");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string?>("Full Name");
    }
}
