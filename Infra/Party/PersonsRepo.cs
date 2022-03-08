using ABC.Domain.Party;
using ABC.Data.Party;

namespace ABC.Infra.Party
{
    public class PersonsRepo: Repo<Person, PersonData>, IPersonsRepo
    {
        public PersonsRepo(ABCDb db) : base(db, db.Persons) { }
        protected override Person toDomain(PersonData d) => new Person(d);
    }
}
