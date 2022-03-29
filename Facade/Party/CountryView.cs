using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party {
    public sealed class CountryView : IsoNamedView { }

    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country toEntity(CountryData d) => new(d);
    }
}
