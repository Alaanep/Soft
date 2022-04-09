using ABC.Data.Party;

namespace ABC.Infra.Initializers {
    public sealed class PersonsInitializer : BaseInitializer<PersonData> {

        public PersonsInitializer(ABCDb? db) : base(db, db?.Persons) { }

        internal static PersonData greatePerson(string firstName, string lastName, IsoGender gender, DateTime dob) {
            var person = new PersonData {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Dob = dob
            };
            return person;
        }

        protected override IEnumerable<PersonData> getEntities => new PersonData[] {
            greatePerson("Harry", "Potter", IsoGender.Male, new DateTime(1980, 07, 31)),
            greatePerson("Hermione", "Grenger", IsoGender.Female, new DateTime(1979, 09, 19)),
            greatePerson("Ron", "Weasley", IsoGender.Male, new DateTime(1980, 03, 01)),
            greatePerson("Karupoeg", "Puhh", IsoGender.NotApplicable, new DateTime(1980, 03, 01)),
            greatePerson("Peeter", "Paan", IsoGender.NotKnown, new DateTime(1980, 03, 01))
        };

        
    }
}
