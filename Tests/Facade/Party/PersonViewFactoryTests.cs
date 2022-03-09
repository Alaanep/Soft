using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party {
    [TestClass]public class PersonViewFactoryTests: SealedClassTests<PersonView> {
        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateViewTest() {
            var d = new PersonData() {
                Id = "id",
                FirstName = "first",
                LastName = "last",
                Gender = false,
                Dob = System.DateTime.Now
            };
            var e = new Person(d);
            var v = new PersonViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.Dob, e.Dob);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = new PersonView() {
                Id = "id",
                FirstName = "first",
                LastName = "last",
                Gender = false,
                Dob = System.DateTime.Now,
                FullName = "name"
            };
            var e = new PersonViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v.Id);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.Gender, v.Gender);
            areEqual(e.Dob, v.Dob);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
