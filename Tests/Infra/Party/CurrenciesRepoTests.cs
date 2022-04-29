using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra.Party
{
    [TestClass]
    public class CurrenciesRepoTests : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>, Currency, CurrencyData>
    {
        protected override CurrenciesRepo createObj() => new(GetRepo.Instance<ABCDb>());
        protected override object? getSet(ABCDb db) => db.Currencies;
    }
}
