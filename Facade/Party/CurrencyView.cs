using System.ComponentModel;
using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;

namespace ABC.Facade.Party {
    public sealed class CurrencyView: BaseView {
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
        [DisplayName("Code")] public string? Code { get; set; }
    }
}

public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
    protected override Currency toEntity(CurrencyData d) => new(d);
}