using ABC.Domain.Party;
using ABC.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra.Party
{
    public class PersonsRepo: Repo<Person, PersonData>, IPersonsRepo
    {
        public PersonsRepo(DbContext c, DbSet<PersonData> s) : base(c, s) { }
        protected override Person toDomain(PersonData d) => new Person(d);
    }
}
