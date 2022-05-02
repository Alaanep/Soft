﻿using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ABC.Infra;

public abstract class CrudRepo<TDomain, TData> : BaseRepo<TDomain, TData> where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    protected CrudRepo(DbContext? c, DbSet<TData>? s) : base(c, s){}
    public override bool Add(TDomain obj) => AddAsync(obj).GetAwaiter().GetResult();
    public override async Task<bool> AddAsync(TDomain obj) {
        var d = obj.Data;
        try {
            _ = (set is null) ? null : await set.AddAsync(d);
            _ = (db is null) ? 0 : await db.SaveChangesAsync();
            return true;
        } catch { return false; }
    }
    public override bool Delete(string id) => DeleteAsync(id).GetAwaiter().GetResult();
    public override async Task<bool> DeleteAsync(string id) {
        try {
            var d = (set is null) ? null : await set.FindAsync(id);
            if (d == null) return false;
            _ = set?.Remove(d);
            _ = (db is null) ? 0 : await db.SaveChangesAsync();
            return true;
        } catch { return false; }
    }
    public override TDomain Get(string id) => GetAsync(id).GetAwaiter().GetResult();

    public override List<TDomain> GetAll(Func<TDomain, dynamic>? orderBy=null) {
        var r = new List<TDomain>();
        if (set is null) return r;
        foreach (var d in set) r.Add(toDomain(d));
        return (orderBy is null) ? r : r.OrderBy(orderBy).ToList();
    }
        
    public override List<TDomain> Get() => GetAsync().GetAwaiter().GetResult();
    public override async Task<TDomain> GetAsync(string id) {
        try {
            if (id == null) return new TDomain();
            var d = (set is null) ? null : await set.FirstOrDefaultAsync(m => m.Id == id);
            return d == null ? new TDomain() : toDomain(d);
        } catch { return new TDomain(); }
    }
    public override async Task<List<TDomain>> GetAsync() {
        try {
            
            var query = createSql();
            var list = await runSql(query);
            var items = new List<TDomain>();
            foreach (var d in list) {
                var obj = toDomain(d);
                items.Add(obj);
            }
            return items;
        } catch { return new List<TDomain>(); }
    }
    internal static async Task<List<TData>> runSql(IQueryable<TData> query)=> await query.AsNoTracking().ToListAsync();//systeem ei jalgi muudatus
    protected internal virtual IQueryable<TData> createSql()=> from s in set select s;
    public override bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();
    public override async Task<bool> UpdateAsync(TDomain obj) {
        try {
            if (db is null) return false;
            db.ChangeTracker.Clear();
            var d = obj.Data;
            db.Attach(d).State = EntityState.Modified;
            _ = await db.SaveChangesAsync();
            return true;
        } catch { return false; }
    }
    protected internal abstract TDomain toDomain(TData d);
}