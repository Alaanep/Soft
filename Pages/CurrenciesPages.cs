﻿using ABC.Domain.Party;
using ABC.Facade.Party;

namespace ABC.Pages {
    public class CurrenciesPages : BasePage<CurrencyView, Currency, ICurrencyRepo> {
        public CurrenciesPages(ICurrencyRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency? entity) => new CurrencyViewFactory().Create(entity);
    }
}
