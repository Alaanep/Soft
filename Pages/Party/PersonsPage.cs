using ABC.Domain.Party;
using ABC.Facade.Party;

namespace ABC.Pages.Party;

public class PersonsPage: PagedPage <PersonView, Person, IPersonsRepo> {
    public PersonsPage(IPersonsRepo r) : base(r){}
    protected override Person toObject(PersonView? item) => new PersonViewFactory().Create(item);
    protected override PersonView toView(Person? entity) => new PersonViewFactory().Create(entity);
}