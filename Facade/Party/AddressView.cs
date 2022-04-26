using System.ComponentModel;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public sealed class AddressView : UniqueView {
    [DisplayName("Street")] public string? Street { get; set; }
    [DisplayName("City")] public string? City { get; set; }
    [DisplayName("Region")] public string? Region { get; set; }
    [DisplayName("Zip Code")] public string? ZipCode { get; set; }
    [DisplayName("Country id")] public string? CountryId { get; set; }
}
public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData> {
    protected override Address toEntity(AddressData d) => new(d);
    
}