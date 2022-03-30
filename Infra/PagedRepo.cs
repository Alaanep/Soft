using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ABC.Infra;

public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData> where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
{
    internal int skippedItemCount => PageSize * PageIndex;
    internal static int itemsCountInPage=10;

    public int PageIndex { get; set; }
    public int TotalPages => totalPages;
    public bool HasNextPage => PageIndex < TotalPages-1;
    public bool HasPreviousPage => PageIndex > 0;
    public int PageSize { get; set; } = itemsCountInPage;

    protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    protected internal override IQueryable<TData> createSql() => addSkipAndTake(base.createSql());
    internal IQueryable<TData> addSkipAndTake(IQueryable<TData> q)=>  q.Skip(skippedItemCount).Take(PageSize);
    internal int totalPages => (int) Math.Ceiling(countPages);

    internal double countPages => itemsCount / (double) PageSize;
    internal int itemsCount => base.createSql().Count();
}