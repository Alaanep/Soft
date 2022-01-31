using ABC.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ABC.Domain.Party;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Soft.Pages.Persons
{
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    public class PersonsPage: PageModel
    {
        private readonly Soft.Data.ApplicationDbContext context;
        public IList<PersonView> Persons { get; set; }

        public PersonsPage(Soft.Data.ApplicationDbContext c) => context = c;

        [BindProperty]
        public PersonView Person { get; set; }

        public IActionResult OnGetCreate()
        {
            return Page();
        }

        
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Person).Data;
            context.Persons.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null ? NotFound() : Page();
        }

        private  async Task<PersonView> GetPerson(string id)
        {
            if (id == null) return null;

            var d = await context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (d == null) return null;

            return new PersonViewFactory().Create(new Person(d));
        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Persons.FindAsync(id);

            if (d != null)
            {
                context.Persons.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null ? NotFound() : Page();
        }

        
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Person).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index", "Index");
        }

        private bool PersonExists(string id) => context.Persons.Any(e => e.Id == id);

       

        public async Task OnGetIndexAsync()
        {
            var list = await context.Persons.ToListAsync();
            Persons = new List<PersonView>();
            foreach (var d in list)
            {
                var v = new PersonViewFactory().Create(new Person(d));
                Persons.Add(v);
            }
        }
    }
}
