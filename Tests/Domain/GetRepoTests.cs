using System;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ABC.Tests.Domain;
[TestClass] public class GetRepoTests : TypeTests {
    
    private class testClass : IServiceProvider
    {
        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
    [TestMethod] public void InstanceTest() 
        => Assert.IsInstanceOfType(GetRepo.Instance<ICountriesRepo>(), typeof(CountriesRepo));

    [TestMethod] public void SetServiceTest() {
        var x = new testClass();
        GetRepo.SetService(x);
        areEqual(x, GetRepo.service);
    }

}