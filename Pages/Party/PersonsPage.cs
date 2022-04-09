using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Party;

public class PersonsPage: PagedPage <PersonView, Person, IPersonRepo> {
    public PersonsPage(IPersonRepo r) : base(r){}
    protected override Person toObject(PersonView? item) => new PersonViewFactory().Create(item);
    protected override PersonView toView(Person? entity) => new PersonViewFactory().Create(entity);

    public override string[] IndexColumns { get; } = new[] {
        nameof(PersonView.Id),
        nameof(PersonView.FirstName),
        nameof(PersonView.LastName),
        nameof(PersonView.Gender),
        nameof(PersonView.Dob),
        nameof(PersonView.FullName)
    };

    public IEnumerable<SelectListItem> Genders
        =>Enum.GetValues<IsoGender>()?
              .Select(x => new SelectListItem(x.Description(), x.ToString()))
          ?? new List<SelectListItem>();

    public string GenderDescription(IsoGender? isoGender)
                => (isoGender ?? IsoGender.NotApplicable).Description();

    public override object? GetValue(string name, PersonView v) {
        var result = base.GetValue(name, v);
        return name == nameof(PersonView.Gender) ? GenderDescription((IsoGender)result) : result;
    }
}