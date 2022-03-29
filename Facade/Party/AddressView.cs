using System.ComponentModel;
using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public sealed class AddressView : UniqueView {
    [DisplayName("Street")] public string? Street { get; set; }
    [DisplayName("City")] public string? City { get; set; }
    [DisplayName("Region")] public string? Region { get; set; }
    [DisplayName("ZipCode")] public string? ZipCode { get; set; }
    [DisplayName("Country")] public string? Country { get; set; }
    [DisplayName("Full Address")] public string? FullName { get; set; }
}
public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData> {
    protected override Address toEntity(AddressData d) => new(d);
    public override AddressView Create(Address? e) {
        var v = base.Create(e);
        v.FullName = e?.ToString();
        return v;
    }
}