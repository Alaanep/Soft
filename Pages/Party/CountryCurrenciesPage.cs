using ABC.Domain.Party;
using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Party;

public class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo> {
    private readonly ICountriesRepo _countrieses;
    private readonly ICurrenciesRepo _currencieses;

    public CountryCurrenciesPage(ICountryCurrenciesRepo r, ICountriesRepo co, ICurrenciesRepo cu) : base(r) {
        _countrieses = co;
        _currencieses = cu;
    }
    protected override CountryCurrency toObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);
    protected override CountryCurrencyView toView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = new[] {
        nameof(CountryCurrencyView.Code),
        nameof(CountryCurrencyView.Name),
        nameof(CountryCurrencyView.CountryId),
        nameof(CountryCurrencyView.CurrencyId)
    };
    public IEnumerable<SelectListItem> Countries
        => _countrieses?.GetAll(x => x.Name)?
               .Select(x => new SelectListItem(x.Name, x.Id))
           ?? new List<SelectListItem>();

    public IEnumerable<SelectListItem> Currencies
        => _currencieses?.GetAll(x => x.Name)?
               .Select(x => new SelectListItem(x.Name, x.Id))
           ?? new List<SelectListItem>();

    public string CountryName(string? countryId = null)
        => Countries?.FirstOrDefault(x => x.Value == countryId)?.Text ?? "Unspecified";

    public string CurrencyName(string? currencyId = null)
        => Currencies?.FirstOrDefault(x => x.Value == currencyId)?.Text ?? "Unspecified";

    public override object? GetValue(string name, CountryCurrencyView v) {
        var result = base.GetValue(name, v);
        return name == nameof(CountryCurrencyView.CountryId) ? CountryName(result as string) :
            name == nameof(CountryCurrencyView.CurrencyId) ? CurrencyName(result as string) : result;
    }
}