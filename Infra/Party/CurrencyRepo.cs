using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party {
    
    public class CurrencyRepo : Repo<Currency, CurrencyData>, ICurrencyRepo {
        public CurrencyRepo(ABCDb? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);
    }
}

