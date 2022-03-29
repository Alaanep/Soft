using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Currency: NamedUniqueEntity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
    }
}
