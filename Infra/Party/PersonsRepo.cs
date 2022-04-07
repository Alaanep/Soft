using ABC.Domain.Party;
using ABC.Data.Party;

namespace ABC.Infra.Party
{
    public class PersonsRepo: Repo<Person, PersonData>, IPersonsRepo {
        public PersonsRepo(ABCDb? db) : base(db, db?.Persons) { }
        protected override Person toDomain(PersonData d) => new(d);

        internal override IQueryable<PersonData> addFilter(IQueryable<PersonData> q)
        {
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
        }
    }
}
