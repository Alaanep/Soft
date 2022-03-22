using ABC.Data.Party;

namespace ABC.Infra.Initializers {
    public sealed class AddressesInitializer : BaseInitializer<AddressData> {
        public AddressesInitializer(ABCDb? db) : base(db, db?.Addresses) { }

        protected override IEnumerable<AddressData> getEntities => new AddressData[] {
            greateAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GB"),
            greateAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GB"),
            greateAddress("The Burrow", "Ottery ST Catchpole", "Devon", "DE17 5BB", "GB"),
            greateAddress("School of Witchcraft and Wizardy", "Hogwarts", "Hogsmeade", "HO29 9XX", "GB")
        };

        internal static AddressData greateAddress(string street, string city, string region, string zipCode,
            string country) {
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
}

