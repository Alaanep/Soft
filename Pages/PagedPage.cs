using ABC.Domain;
using ABC.Facade;
using Microsoft.AspNetCore.Mvc;

namespace ABC.Pages;

public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IPagedRepo<TEntity> {
    protected PagedPage(TRepo r) : base(r) { }
    public string? CurrentSort { get; set; } = "currentSort";
    public string? CurrentFilter { get; set; } = "currentFilter";

    public int PageIndex
    {
        get=>repo.PageIndex;
        set=>repo.PageIndex=value;
    }

    public int TotalPages  =>repo.TotalPages;
    public bool HasNextPage =>repo.HasNextPage;
    public bool HasPreviousPage =>repo.HasPreviousPage;


    public override IActionResult OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return base.OnGetCreate(pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnPostCreateAsync(pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnGetDetailsAsync(id, pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnGetDeleteAsync(id, pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnPostDeleteAsync(id, pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnGetEditAsync(id, pageIndex, currentFilter, sortOrder);
    }
    public override async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
        PageIndex = pageIndex;
        return await base.OnPostEditAsync(pageIndex, currentFilter, sortOrder);
    }

    public override async Task<IActionResult> OnGetIndexAsync(int pageIndex, string? currentFilter, string? sortOrder)
    {
        PageIndex = pageIndex;
        return await base.OnGetIndexAsync(pageIndex, currentFilter, sortOrder);
    }

}