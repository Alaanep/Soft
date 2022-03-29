using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra;

public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData> where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
    protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
}