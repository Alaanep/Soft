using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ABC.Domain.Party;
using System.Collections.Generic;
using ABC.Infra.Party;
using Soft.Data;

namespace Soft.Pages.Persons
{
    public class PersonsPage: PageModel
    {
        private readonly IPersonsRepo repo;
        public IList<PersonView> Persons { get; set; }
        public PersonsPage(ApplicationDbContext c) => repo = new PersonsRepo(c, c.Persons);
        [BindProperty] public PersonView Person { get; set; }
        public IActionResult OnGetCreate()=>Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new PersonViewFactory().Create(Person));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new PersonViewFactory().Create(Person);
            var updated= await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Persons = new List<PersonView>();
            foreach (var obj in list)
            {
                var v = new PersonViewFactory().Create(obj);
                Persons.Add(v);
            }
            return Page();
        }
        private async Task<PersonView> GetPerson(string id)=>new PersonViewFactory().Create(await repo.GetAsync(id));
    }
}
