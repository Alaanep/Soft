using ABC.Data.Party;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Infra.Party
{   
    public abstract class SealedRepoTests<TClass, TBaseClass>: SealedBaseTests<TClass, TBaseClass> where TClass: class where TBaseClass: class { }

    [TestClass]
    public class AddressesRepoTests : SealedRepoTests<AddressesRepo, Repo<Address, AddressData>>{
        protected override AddressesRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }

    [TestClass]
    public class CountriesRepoTests : SealedRepoTests<CountriesRepo, Repo<Country, CountryData>>
    {
        protected override CountriesRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }

    [TestClass]
    public class CountryCurrenciesRepoTests : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>>{
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }

    [TestClass]
    public class CurrenciesRepoTests : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>>
    {
        protected override CurrenciesRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }

    [TestClass]
    public class PersonAddressesRepoTests : SealedRepoTests<PersonAddressesRepo, Repo<PersonAddress, PersonAddressData>>
    {
        protected override PersonAddressesRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }

    [TestClass]
    public class PersonsRepoTests : SealedRepoTests<PersonsRepo, Repo<Person, PersonData>>
    {
        protected override PersonsRepo createObj() => new(GetRepo.Instance<ABCDb>());
    }
}
