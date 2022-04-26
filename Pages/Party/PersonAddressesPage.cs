using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Party;

public class PersonAddressesPage : PagedPage<PersonAddressView, PersonAddress, IPersonAddressesRepo> {
    private readonly IPersonRepo persons;
    private readonly IAddressRepo addresses;

    public PersonAddressesPage(IPersonAddressesRepo r, IPersonRepo p, IAddressRepo a) : base(r) {
        persons = p;
        addresses = a;
    }
    protected override PersonAddress toObject(PersonAddressView? item) => new PersonAddressViewFactory().Create(item);
    protected override PersonAddressView toView(PersonAddress? entity) => new PersonAddressViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = new[] {
        nameof(PersonAddressView.Code),
        nameof(PersonAddressView.Name),
        nameof(PersonAddressView.AddressId),
        nameof(PersonAddressView.PersonId)
    };
    public IEnumerable<SelectListItem> Persons
        => persons?.GetAll(x => x.ToString())?
               .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();

    public IEnumerable<SelectListItem> Addresses
        => addresses?.GetAll(x => x.ToString())?
               .Select(x => new SelectListItem(x.ToString(), x.Id))
           ?? new List<SelectListItem>();

    public string PersonName(string? personId = null)
        => Persons?.FirstOrDefault(x => x.Value == personId)?.Text ?? "Unspecified";

    public string AddressName(string? addressId = null)
        => Addresses?.FirstOrDefault(x => x.Value == addressId)?.Text ?? "Unspecified";

    public override object? GetValue(string name, PersonAddressView v) {
        var result = base.GetValue(name, v);
        return name == nameof(PersonAddressView.PersonId) ? PersonName(result as string):
            name == nameof(PersonAddressView.AddressId) ? AddressName(result as string) : result;
    }
}