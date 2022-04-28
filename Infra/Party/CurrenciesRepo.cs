using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party {
    
    public sealed class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
        public CurrenciesRepo(ABCDb? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);
        /* internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q)
         {
             var y = CurrentFilter;
             return string.IsNullOrWhiteSpace(y)
                 ? q
                 : q.Where(
                     x => contains(x.Id, y)
                          || contains(x.Code, y)
                          || contains(x.Name, y)
                          || contains(x.Description, y)
                 );
         }*/

        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q
                : q.Where(
                    x => x.Id.Contains(y)
                         || x.Code.Contains(y)
                         || x.Name.Contains(y)
                         || x.Description.Contains(y)
                );
        }
    }
}

