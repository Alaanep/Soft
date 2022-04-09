using System.Globalization;
using ABC.Data;
using ABC.Data.Party;
using ABC.Domain;

namespace ABC.Infra.Initializers;

public sealed class CountryCurrencyInitializer : BaseInitializer<CountryCurrencyData> {
    public CountryCurrencyInitializer(ABCDb? db) : base(db, db?.CountryCurrencies) { }
    protected override IEnumerable<CountryCurrencyData> getEntities {
        get {
            var l = new List<CountryCurrencyData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var countryId = country.ThreeLetterISORegionName;
                var currencyId = country.ISOCurrencySymbol;
                var nativeName = country.CurrencyNativeName;
                var currencyCode = country.CurrencySymbol;
                
                var data = greateEntity(countryId, currencyId, currencyCode, nativeName);
                l.Add(data);
            }
            return l;
        }
    }

    internal static CountryCurrencyData greateEntity(string countryId, string currencyId, string code, string name=null, string description=null) => new CountryCurrencyData() {
        Id = UniqueData.NewId,
        Code = code ?? UniqueEntity.defaultStr,
        Name = name,
        Description = description,
        CountryId = countryId,
        CurrencyId = currencyId
    };
}