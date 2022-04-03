using ABC.Domain.Party;
using ABC.Facade.Party;

namespace ABC.Pages.Party;

public class CountriesPage: PagedPage<CountryView, Country, ICountryRepo> {
    public CountriesPage(ICountryRepo r) : base(r) { }
    protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
    protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = new[] {
        nameof(CountryView.Id),
        nameof(CountryView.Name),
        nameof(CountryView.Code),
        nameof(CountryView.Description)
    };
}