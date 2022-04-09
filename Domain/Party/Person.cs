using ABC.Aids;
using ABC.Data.Party;

namespace ABC.Domain.Party {
    public class Person : UniqueEntity<PersonData> { 
        public Person() : this(new PersonData()) { }
        public Person(PersonData d): base(d){}
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender);
        public DateTime Dob => getValue(Data?.Dob);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()} {Dob})";
    }
}
