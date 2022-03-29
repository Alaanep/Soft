using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using ABC.Data;
using ABC.Data.Party;
using ABC.Domain;

namespace ABC.Infra.Initializers;


public sealed class CountriesInitializer : BaseInitializer<CountryData> {
    public CountriesInitializer(ABCDb? db) : base(db, db?.Countries) { }

    protected override IEnumerable<CountryData> getEntities {
        get {
            var l = new List<CountryData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var id = country.ThreeLetterISORegionName;
                if (!isCorrectIsoCode(id)) continue;
                if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                var data = greateCountry(id, country.EnglishName, country.NativeName);
                l.Add(data);
            }
            return l;
        }
    }

    internal static CountryData greateCountry(string code, string name, string description) => new CountryData() {
        Id = code??UniqueData.NewId,
        Code = code??UniqueEntity.defaultStr,
        Name = name,
        Description = description
    };
}