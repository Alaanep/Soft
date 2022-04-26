using ABC.Data;
using ABC.Data.Party;

namespace ABC.Domain;
public abstract class UniqueEntity {
    public static  string defaultStr => "Undefined";
    protected const bool defaultBool = false;
    protected static DateTime defaultDate => DateTime.MinValue;
    protected static string getValue(string? v) => v ?? defaultStr;
    protected static bool getValue(bool? v) => v ?? defaultBool;
    protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
    protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
    public abstract string Id { get; }
}

public abstract class UniqueEntity<TData>: UniqueEntity where TData : UniqueData, new() {
    public TData Data => data;
    private readonly TData data;
    public UniqueEntity() : this(new TData()) { }
    public UniqueEntity(TData d) => data = d;
    public override string Id => getValue(Data?.Id);
}