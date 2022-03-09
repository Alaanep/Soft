using ABC.Data.Party;
using ABC.Domain.Party;
namespace ABC.Facade.Party
{
    public sealed class PersonViewFactory : BaseViewFactory<PersonView, Person, PersonData> {
        protected override Person toEntity(PersonData d) => new(d);
    }
}
