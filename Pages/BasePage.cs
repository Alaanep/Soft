using ABC.Domain;
using ABC.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC.Pages;

public abstract class BasePage<TView, TEntity, TRepo> : PageModel
    where TView: UniqueView
    where TEntity: UniqueEntity
    where TRepo: IBaseRepo<TEntity> {
        
    protected readonly TRepo repo;
    protected abstract TView toView(TEntity? entity);
    protected abstract TEntity toObject(TView? item);
    [BindProperty] public TView? Item { get; set; }
    public IList<TView>? Items { get; set; }
    public string ItemId => Item?.Id ?? string.Empty;
    public BasePage(TRepo r) => repo = r;

    public virtual IActionResult  OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) => Page();
    public virtual async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        if (!ModelState.IsValid) return Page();
        await repo.AddAsync(toObject(Item));
        return RedirectToPage("./Index", "Index", new {
            pageIndex = pageIndex,
            currentFilter = currentFilter,
            sortOrder = sortOrder
        });
    }
    public virtual async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        Item = await getItem(id);
        return Item == null ? NotFound() : Page();
    }
    public virtual async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        Item = await getItem(id);
        return Item == null ? NotFound() : Page();
    }
    public virtual async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        if (id == null) return NotFound();
        await repo.DeleteAsync(id);
        return RedirectToPage("./Index", "Index", new {
            pageIndex = pageIndex,
            currentFilter = currentFilter,
            sortOrder = sortOrder
        });
    }
    public virtual async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        Item = await getItem(id);
        return Item == null ? NotFound() : Page();
    }
    public virtual async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        if (!ModelState.IsValid) return Page();
        var obj = toObject(Item);
        var updated = await repo.UpdateAsync(obj);
        if (!updated) return NotFound();
        return RedirectToPage("./Index", "Index", new
        {
            pageIndex=pageIndex,
            currentFilter=currentFilter,
            sortOrder=sortOrder
        });
    }

    public virtual async Task<IActionResult> OnGetIndexAsync(int pageIndex=0, string? currentFilter=null, string? sortOrder =null) {
        var list = await repo.GetAsync();
        Items = new List<TView>();
        foreach (var obj in list) {
            var v = toView(obj);
            Items.Add(v);
        }
        return Page();
    }
    private async Task<TView> getItem(string id) => toView(await repo.GetAsync(id));
}