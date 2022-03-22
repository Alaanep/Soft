using System.Globalization;
using ABC.Data.Party;

namespace ABC.Infra.Initializers;


public sealed class CountriesInitializer : BaseInitializer<CountryData> {
    public CountriesInitializer(ABCDb? db) : base(db, db?.Countries) { }

    protected override IEnumerable<CountryData> getEntities {
        get {
            var l = new List<CountryData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var data = greateCountry(country.ThreeLetterISORegionName, country.EnglishName, country.NativeName);
                if (l.FirstOrDefault(x => x.Id == data.Id) is not null) continue;
                l.Add(data);
            }

            return l;
        }
    }

    internal static CountryData greateCountry(string code, string name, string description) => new CountryData() {
        Id = code,
        Code = code,
        Name = name,
        Description = description
    };
}