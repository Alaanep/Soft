using System.Collections;
using ABC.Aids;
using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Party;

public class AddressesPage : PagedPage<AddressView, Address, IAddressRepo> {
    private readonly ICountryRepo countries;
    public AddressesPage(IAddressRepo r, ICountryRepo c) : base(r) {
        countries = c;
    }
    protected override Address toObject(AddressView? item) => new AddressViewFactory().Create(item);
    protected override AddressView toView(Address? entity) => new AddressViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = new[] {
        nameof(AddressView.Id),
        nameof(AddressView.Street),
        nameof(AddressView.City),
        nameof(AddressView.Region),
        nameof(AddressView.ZipCode),
        nameof(AddressView.CountryId)
    };
    public IEnumerable<SelectListItem> Countries
        => countries?.GetAll(x => x.Name)?
               .Select(x => new SelectListItem(x.Name, x.Id))
           ?? new List<SelectListItem>();

    public string CountryName(string? countryId = null)
        => Countries?.FirstOrDefault(x => x.Value == countryId)?.Text ?? "Unspecified";

    public override object? GetValue(string name, AddressView v) {
        var result = base.GetValue(name, v);
        return name == nameof(AddressView.CountryId) ? CountryName(result as string) : result;
    }
}