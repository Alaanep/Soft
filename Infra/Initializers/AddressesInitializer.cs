using ABC.Data;
using ABC.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra.Initializers {
    public sealed class AddressesInitializer: BaseInitializer<AddressData> {
        public AddressesInitializer(ABCDb? db): base(db, db?.Addresses){}

        protected override IEnumerable<AddressData> getEntities => new AddressData[] {
            greateAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GB"),
            greateAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GB"),
            greateAddress("The Burrow", "Ottery ST Catchpole", "Devon", "DE17 5BB", "GB"),
            greateAddress("School of Witchcraft and Wizardy", "Hogwarts", "Hogsmeade", "HO29 9XX", "GB")
        };

        internal static AddressData greateAddress(string street, string city, string region, string zipCode, string country) {
            var person = new AddressData() {
                Id = street + city,
                Street = street,
                City = city,
                Region = region,
                ZipCode = zipCode,
                Country = country
            };
            return person;
        }
    }

    public sealed class PersonsInitializer: BaseInitializer<PersonData> {
        
        public PersonsInitializer(ABCDb? db): base(db, db?.Persons){}

        protected override IEnumerable<PersonData> getEntities => new PersonData[] {
            greatePerson("Harry", "Potter", false, new DateTime(1980, 07, 31)),
            greatePerson("Hermione", "Grenger", true, new DateTime(1979, 09, 19)),
            greatePerson("Ron", "Weasley", false, new DateTime(1980, 03, 01))
        };

        internal static PersonData greatePerson( string firstName, string lastName, bool gender, DateTime dob) {
            var person = new PersonData {
                Id = firstName+lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Dob = dob 
            };
            return person;
        }
    }

    public abstract class BaseInitializer<TData> where TData: EntityData {
        protected internal DbContext? database;
        protected internal DbSet<TData>? dbSet;

        protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
            database = c;
            dbSet = s;
        }

        public void Init() {
            if(dbSet?.Any()?? true) return;
            dbSet.AddRange(getEntities);
            database?.SaveChanges();
        }

        protected abstract IEnumerable<TData> getEntities{ get; }
    }
}
