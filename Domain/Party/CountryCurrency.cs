using ABC.Data.Party;

namespace ABC.Domain.Party;

public sealed class CountryCurrency : NamedUniqueEntity<CountryCurrencyData> {
    public CountryCurrency() : this(new CountryCurrencyData()) { }
    public CountryCurrency(CountryCurrencyData d) : base(d) { }
    public string CountyId => getValue(Data?.CountryId);
    public string CurrencyId => getValue(Data?.CurrencyId);

}