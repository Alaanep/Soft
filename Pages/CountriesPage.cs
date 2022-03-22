using ABC.Domain.Party;
using ABC.Facade.Party;

namespace ABC.Pages {
    public class CountriesPage: BasePage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
    }
}
