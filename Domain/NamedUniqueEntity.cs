using ABC.Data;

namespace ABC.Domain;

public abstract class NamedUniqueEntity<TData> : UniqueEntity<TData> where TData : NamedData, new() {
    public NamedUniqueEntity() : this(new TData()) { }
    public NamedUniqueEntity(TData d) : base(d){}
    public string Name => getValue(Data?.Name);
    public string Description => getValue(Data?.Description);
    public string Code => getValue(Data?.Code);
}