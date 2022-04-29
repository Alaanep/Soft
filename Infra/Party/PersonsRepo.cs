using ABC.Domain.Party;
using ABC.Data.Party;

namespace ABC.Infra.Party
{
    public sealed class PersonsRepo: Repo<Person, PersonData>, IPersonRepo {
        public PersonsRepo(ABCDb? db) : base(db, db?.Persons) { }
        protected internal override Person toDomain(PersonData d) => new(d);

        /*internal override IQueryable<PersonData> addFilter(IQueryable<PersonData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q
                : q.Where(
                    x => contains(x.Id, y)
                         || contains(x.FirstName, y)
                         || contains(x.LastName, y)
                         || contains(x.Gender.ToString(), y)
                         || contains(x.Dob.ToString(), y)
                );
        }*/

        internal override IQueryable<PersonData> addFilter(IQueryable<PersonData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q
                : q.Where(
                    x => x.Id.Contains(y)
                         || x.FirstName.Contains(y)
                         || x.LastName.Contains(y)
                         || x.Gender.ToString().Contains(y)
                         || x.Dob.ToString().Contains(y)
                );
        }
    }
}
