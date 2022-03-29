using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra;

public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData> where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
    protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
}