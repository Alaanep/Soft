using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party {
    public  class CountryRepo: Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(ABCDb? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
    }
}
