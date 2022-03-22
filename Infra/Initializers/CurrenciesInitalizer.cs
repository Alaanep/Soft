using ABC.Data.Party;
using System.Globalization;
namespace ABC.Infra.Initializers {
    public sealed class CurrenciesInitalizer: BaseInitializer<CurrencyData> {
        public CurrenciesInitalizer(ABCDb? db): base(db, db?.Currencies) {}
        protected override IEnumerable<CurrencyData> getEntities {
            get {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var currency = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var data = greateCurrency(currency.ThreeLetterISORegionName, currency.EnglishName, currency.NativeName);
                    if (l.FirstOrDefault(x => x.Id == data.Id) is not null) continue;
                    l.Add(data);
                }
                return l;
            }
        }
        internal static CurrencyData greateCurrency(string code, string name, string description) => new CurrencyData() {
            Id = code,
            Code = code,
            Name = name,
            Description = description
        };

    }
}

