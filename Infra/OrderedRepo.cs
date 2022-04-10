using System.Linq.Expressions;
using System.Reflection;
using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra;

public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData> where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
    protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    public string? CurrentOrder { get; set; }
    public static string DescendingString => "_desc";
    protected internal override IQueryable<TData> createSql() => AddSort(base.createSql());
    internal IQueryable<TData> AddSort(IQueryable<TData> q) {
        if (string.IsNullOrWhiteSpace(CurrentOrder)) return q;
        var e = LambdaExpression;
        if (e == null) return q;
        if (IsDescending) return q.OrderByDescending(e);
        return q.OrderBy(e);
    }
    internal bool IsDescending => CurrentOrder?.EndsWith(DescendingString) ?? false;
    internal bool IsSameProperty(string s) => (!string.IsNullOrEmpty(s) && (CurrentOrder?.StartsWith(s) ?? false));
    internal string DisplayName => CurrentOrder?.Replace(DescendingString, "")?? "";
    internal PropertyInfo? PropertyInfo => typeof(TData).GetProperty(DisplayName);

    internal Expression<Func<TData, object>>? LambdaExpression {
        get
        {
            if (PropertyInfo is null) return null;
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, PropertyInfo);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }
    }
    public string SortOrder(string propertyName) {
        var n = propertyName;
        if (!IsSameProperty(n)) return n + DescendingString;
        if (IsDescending) return n;
        return n + DescendingString;
    }
}