using ABC.Data.Party;

namespace ABC.Infra.Initializers {
    public sealed class PersonsInitializer : BaseInitializer<PersonData> {

        public PersonsInitializer(ABCDb? db) : base(db, db?.Persons) { }

        protected override IEnumerable<PersonData> getEntities => new PersonData[] {
            greatePerson("Harry", "Potter", false, new DateTime(1980, 07, 31)),
            greatePerson("Hermione", "Grenger", true, new DateTime(1979, 09, 19)),
            greatePerson("Ron", "Weasley", false, new DateTime(1980, 03, 01))
        };

        internal static PersonData greatePerson(string firstName, string lastName, bool gender, DateTime dob) {
            var person = new PersonData {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Dob = dob
            };
            return person;
        }
    }
}
