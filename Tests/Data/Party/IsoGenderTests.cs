using ABC.Data.Party;
using ABC.Aids;
using ABC.Tests.Domain;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABC.Tests.Data.Party {
    
    [TestClass] public class IsoGenderTests: TypeTests {
        [TestMethod] public void MaleTest() => doTest(IsoGender.Male, 1, "Male");
        [TestMethod] public void FemaleTest() => doTest(IsoGender.Female, 2, "Female");
        [TestMethod] public void NotKnownTest() => doTest(IsoGender.NotKnown, 0, "Not known");
        [TestMethod] public void NotApplicableTest() => doTest(IsoGender.NotApplicable, 9, "Not Applicable");

        private void doTest(IsoGender isoGender, int value, string description) {
            areEqual(value, (int)isoGender);
            areEqual(description, isoGender.Description());
        }
    }
}
