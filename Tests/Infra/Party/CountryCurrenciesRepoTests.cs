using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra.Party
{
    [TestClass]
    public class CountryCurrenciesRepoTests : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<ABCDb>());
        protected override object? getSet(ABCDb db) => db.CountryCurrencies;
    }
}
