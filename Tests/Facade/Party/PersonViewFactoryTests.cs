using System;
using System.Reflection;
using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]
    public class PersonViewFactoryTests : SealedClassTests<PersonView> {
        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<PersonData>();
            var e = new Person(d);
            var v = new PersonViewFactory().Create(e);
            isNotNull(v);
            //todo motelge
            //arePropertiesEqual(v, e, nameof(v.fullName))
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.Dob, e.Dob);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<PersonView>();
            var e = new PersonViewFactory().Create(v);
            isNotNull(e);
            //todo motelge
            //arePropertiesEqual(v, e)

            areEqual(e.Id, v?.Id);
            areEqual(e.FirstName, v?.FirstName);
            areEqual(e.LastName, v?.LastName);
            areEqual(e.Gender, v?.Gender);
            areEqual(e.Dob, v?.Dob);
            areNotEqual(e.ToString(), v?.FullName);
        }
    }
}
