using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Country : NamedUniqueEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) {}

        public List<CountryCurrency> CountryCurrencies 
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
                .GetAll(x=>x.CountryId)?
                .Where(x=>x.CountryId==Id)?
                .ToList()??new List<CountryCurrency>();

        public List<Currency?> Currencies =>
            CountryCurrencies
                .Select(x => x.Currency)?.ToList() ?? new List<Currency?>();
    }
}