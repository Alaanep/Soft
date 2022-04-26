using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABC.Facade;

public abstract class NamedView : UniqueView {
    [Required][DisplayName("Code")] public string? Code { get; set; }
    [DisplayName("Name")] public string? Name { get; set; }
    [DisplayName("Description")] public string? Description { get; set; }
}