using System.Globalization;
using ABC.Data.Party;

namespace ABC.Infra.Initializers
{
    public sealed class AddressesInitializer : BaseInitializer<AddressData>
    {
        public AddressesInitializer(ABCDb? db) : base(db, db?.Addresses)
        {
        }

        protected override IEnumerable<AddressData> getEntities => new AddressData[]
        {
            greateAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GB"),
            greateAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GB"),
            greateAddress("The Burrow", "Ottery ST Catchpole", "Devon", "DE17 5BB", "GB"),
            greateAddress("School of Witchcraft and Wizardy", "Hogwarts", "Hogsmeade", "HO29 9XX", "GB")
        };

        internal static AddressData greateAddress(string street, string city, string region, string zipCode,
            string country)
        {
            var person = new AddressData()
            {
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

    public sealed class CountriesInitializer : BaseInitializer<CountryData>
    {
        public CountriesInitializer(ABCDb? db) : base(db, db?.Countries)
        {
        }

        protected override IEnumerable<CountryData> getEntities
        {
            get
            {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var data = greateCountry(country.ThreeLetterISORegionName, country.EnglishName, country.NativeName);
                    if (l.FirstOrDefault(x => x.Id == data.Id) is not null) continue;
                    l.Add(data);
                }

                return l;
            }
        }

        internal static CountryData greateCountry(string code, string name, string description) => new CountryData()
        {
            Id = code, Code = code, Name = name, Description = description};
    }
}

