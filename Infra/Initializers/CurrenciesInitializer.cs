using ABC.Data.Party;
using System.Globalization;
using ABC.Data;
using ABC.Domain;

namespace ABC.Infra.Initializers {
    public sealed class CurrenciesInitializer: BaseInitializer<CurrencyData> {
        public CurrenciesInitializer(ABCDb? db): base(db, db?.Currencies) {}
        protected override IEnumerable<CurrencyData> getEntities {
            get {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var currency = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = currency.ISOCurrencySymbol;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                    var data = greateCurrency(id, currency.CurrencyEnglishName, currency.CurrencyNativeName);
                    
                    l.Add(data);
                }
                return l;
            }
        }

        
        internal static CurrencyData greateCurrency(string code, string name, string description) => new CurrencyData() {
            Id = code ?? UniqueData.NewId,
            Code = code?? UniqueEntity.defaultStr,
            Name = name,
            Description = description
        };

    }
}

