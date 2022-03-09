using System.ComponentModel.DataAnnotations;

namespace ABC.Facade;

public class BaseView
{
    [Required] public string Id { get; set; } = Guid.NewGuid().ToString();

}