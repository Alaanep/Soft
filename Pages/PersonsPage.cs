using ABC.Domain.Party;
using ABC.Facade.Party;
using ABC.Infra.Party;
using ABC.Infra;

namespace ABC.Pages
{
    public class PersonsPage: BasePage <PersonView, Person, IPersonsRepo> {
        public PersonsPage(IPersonsRepo r) : base(r){}
        protected override Person toObject(PersonView? item) => new PersonViewFactory().Create(item);
        protected override PersonView toView(Person? entity) => new PersonViewFactory().Create(entity);
    }
}
