using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public sealed class CountryCurrencyView : NamedView {
    [Required][DisplayName("Country")] public string CountryId { get; set; } = string.Empty;
    [Required][DisplayName("Currency")] public string CurrencyId { get; set; } = string.Empty;
    [DisplayName("Currency Native Name")] public new string? Name { get; set; }
    [DisplayName("Currency Native Code")] public new string? Code { get; set; }
}

public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
    protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);

}