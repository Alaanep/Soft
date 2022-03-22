using System.ComponentModel;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party {
    public sealed class CountryView: BaseView {
        [DisplayName("Name")]public string? Name { get; set; }
        [DisplayName("Description")]public string? Description { get; set; }
        [DisplayName("Code")]public string? Code { get; set; }
    }

    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country toEntity(CountryData d) => new(d);
    }
}
