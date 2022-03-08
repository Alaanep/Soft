using System.ComponentModel;

namespace ABC.Facade.Party;

public class AddressView : BaseView {
    [DisplayName("Street")] public string? Street { get; set; }
    [DisplayName("City")] public string? City { get; set; }
    [DisplayName("Region")] public string? Region { get; set; }
    [DisplayName("ZipCode")] public string? ZipCode { get; set; }
    [DisplayName("Country")] public string? Country { get; set; }
    [DisplayName("Full Address")] public string? FullName { get; set; }
}