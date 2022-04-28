using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party {
    public sealed  class CountriesRepo: Repo<Country, CountryData>, ICountriesRepo {
        public CountriesRepo(ABCDb? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
        /*internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q)
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

        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q) {
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
