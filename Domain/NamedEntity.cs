using ABC.Data;

namespace ABC.Domain;

public abstract class NamedEntity<TData> : UniqueEntity<TData> where TData : NamedData, new() {
    public NamedEntity() : this(new TData()) { }
    public NamedEntity(TData d) : base(d){}
    public string Name => getValue(Data?.Name);
    public string Description => getValue(Data?.Description);
    public string Code => getValue(Data?.Code);
}