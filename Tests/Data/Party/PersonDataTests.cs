using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateTime = System.DateTime;

namespace ABC.Tests.Data.Party
{   
    [TestClass]
    public class PersonDataTests: BaseTests<PersonData>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
    }
}
