using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public class PersonAddressView : NamedView {
    [Required][DisplayName("Person")] public string PersonId { get; set; } = string.Empty;
    [Required][DisplayName("Geographic Address")] public string AddressId { get; set; } = string.Empty;
    [DisplayName("Use for")] public new string? Code { get; set; }
}

public sealed class PersonAddressViewFactory : BaseViewFactory<PersonAddressView, PersonAddress, PersonAddressData> {
    protected override PersonAddress toEntity(PersonAddressData d) => new(d);

}