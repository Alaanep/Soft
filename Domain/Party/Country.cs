using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Country : Entity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) {}
        public string Name => getValue(Data?.Name);
        public string Description => getValue(Data?.Description);
        public string Code => getValue(Data?.Code);
    }
}