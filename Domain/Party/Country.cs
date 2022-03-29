using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Country : NamedUniqueEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) {}
    }
}