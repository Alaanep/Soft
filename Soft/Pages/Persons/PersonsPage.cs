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
        [BindProperty] public PersonView Item { get; set; }
        public IList<PersonView> Items { get; set; }
        public string ItemId => Item?.Id ?? string.Empty;
        public PersonsPage(ABCDb c) => repo = new PersonsRepo(c, c.Persons);
        
        public IActionResult OnGetCreate()=>Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new PersonViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await GetPerson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await GetPerson(id);
            return Item == null? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await GetPerson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new PersonViewFactory().Create(Item);
            var updated= await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<PersonView>();
            foreach (var obj in list)
            {
                var v = new PersonViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<PersonView> GetPerson(string id)=>new PersonViewFactory().Create(await repo.GetAsync(id));
    }
}
