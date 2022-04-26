using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABC.Facade;

public abstract class IsoNamedView : NamedView {
    [Required][DisplayName("ISO Three-Letter Code")] public new string? Code { get; set; }
    [DisplayName("Native Name")] public new string? Name { get; set; }
    [DisplayName("English Name")] public new string? Description { get; set; }
    
}