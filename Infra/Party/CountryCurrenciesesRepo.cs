using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public class CountryCurrenciesesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo {
    public CountryCurrenciesesRepo(ABCDb? db) : base(db, db?.CountryCurrencies) { }
    protected override CountryCurrency toDomain(CountryCurrencyData d) => new(d);
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
                     || x.CountryId.Contains(y)
                     || x.CurrencyId.Contains(y)
            );
    }
}