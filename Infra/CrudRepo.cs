﻿using ABC.Data;
using ABC.Domain;
using Microsoft.EntityFrameworkCore;

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
            var list = (set is null) ? new List<TData>() : await set.ToListAsync();
            var items = new List<TDomain>();
            foreach (var d in list) {
                var obj = toDomain(d);
                items.Add(obj);
            }
            return items;
        } catch { return new List<TDomain>(); }
    }
    public override bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();
    public override async Task<bool> UpdateAsync(TDomain obj) {
        try {
            var d = obj.Data;
            if (db is not null) db.Attach(d).State = EntityState.Modified;
            _ = (db is null) ? 0 : await db.SaveChangesAsync();
            return true;
        } catch { return false; }
    }
    protected abstract TDomain toDomain(TData d);

}