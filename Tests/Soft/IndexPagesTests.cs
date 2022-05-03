using ABC.Aids;
using ABC.Data.Party;
using ABC.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace ABC.Tests.Soft {

    [TestClass] public class IndexPagesTests : HostTests {
        [TestMethod] public async Task GetCountriesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
            var page = await client.GetAsync("/Countries?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Countries</h4>"));

        }

        [TestMethod]
        public async Task GetCurrenciesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
            var page = await client.GetAsync("/Currencies?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Currencies</h4>"));
        }

        [TestMethod]
        public async Task GetPersonsIndexPageTest() {
            var page = await client.GetAsync("/Persons?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Log in</h1>"));
        }

        [TestMethod] public async Task GetCountriesDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            var page = await client.GetAsync($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));

        }
    }
}
