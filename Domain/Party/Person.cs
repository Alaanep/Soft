using ABC.Aids;
using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Person : UniqueEntity<PersonData> { 
        public Person() : this(new PersonData()) { }
        public Person(PersonData d): base(d){}
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender);
        public DateTime Dob => getValue(Data?.Dob);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()} {Dob})";
        

        public List<PersonAddress> PersonAddresses
            => GetRepo.Instance<IPersonAddressesRepo>()?
                .GetAll(x => x.PersonId)?
                .Where(x => x.PersonId == Id)?
                .ToList() ?? new List<PersonAddress>();

        public List<Address?> Addresses =>
            PersonAddresses
                .Select(x => x.Address)?.ToList() ?? new List<Address?>();
    }
}
