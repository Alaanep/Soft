using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public sealed class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo {
    public CountryCurrenciesRepo(ABCDb? db) : base(db, db?.CountryCurrencies) { }
    protected internal override CountryCurrency toDomain(CountryCurrencyData d) => new(d);
    /*internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => contains(x.Id, y)
                     || contains(x.Code, y)
                     || contains(x.Name, y)
                     || contains(x.CountryId, y)
                     || contains(x.CurrencyId, y)
            );
    }*/
    internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => x.Id.Contains(y)
                     || x.Code.Contains(y)
                     || x.Name.Contains( y)
                     || x.Description.Contains(y)
                     || x.CountryId.Contains(y)
                     || x.CurrencyId.Contains(y)
            );
    }
}