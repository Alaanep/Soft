using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Currency: Entity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string Name => getValue(Data?.Name);
        public string Description => getValue(Data?.Description);
        public string Code => getValue(Data?.Code);
    }
}
