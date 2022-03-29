namespace ABC.Data;

public class NamedData: UniqueData {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; } = string.Empty;
}