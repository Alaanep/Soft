using ABC.Data;
using Microsoft.EntityFrameworkCore;

namespace ABC.Infra.Initializers;

public abstract class BaseInitializer<TData> where TData: UniqueData {
    protected internal DbContext? database;
    protected internal DbSet<TData>? dbSet;

    protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
        database = c;
        dbSet = s;
    }

    public void Init() {
        if(dbSet?.Any()?? true) return;
        dbSet.AddRange(getEntities);
        database?.SaveChanges();
    }

    protected abstract IEnumerable<TData> getEntities{ get; }
    internal static bool isCorrectIsoCode(string id) => string.IsNullOrWhiteSpace(id) ? false : char.IsLetter(id[0]);
}

public static class AbcInitializer {
    public static void Init(ABCDb abcDb) {
        new AddressesInitializer(abcDb).Init();
        new PersonsInitializer(abcDb).Init();
        new CountriesInitializer(abcDb).Init();
        new CurrenciesInitalizer(abcDb).Init();
    }
}