using ABC.Domain.Party;
using ABC.Data.Party;

namespace ABC.Infra.Party
{
    public class PersonsRepo: Repo<Person, PersonData>, IPersonsRepo {
        public PersonsRepo(ABCDb? db) : base(db, db?.Persons) { }
        protected override Person toDomain(PersonData d) => new(d);

        internal override IQueryable<PersonData> addFilter(IQueryable<PersonData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                     || x.FirstName.Contains(y)
                     || x.LastName.Contains(y)
                     || x.Gender.ToString().Contains(y)
                     || x.Dob.ToString().Contains(y)
            );
        }
    }
}
