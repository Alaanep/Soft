using ABC.Data.Party;
using ABC.Domain.Party;
using ABC.Facade;
using ABC.Facade.Party;

namespace ABC.Facade.Party {
    public sealed class CurrencyView : IsoNamedView { }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}

