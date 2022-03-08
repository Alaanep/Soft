using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public class AddressViewFactory {
    public Address Create(AddressView v) => new Address(new AddressData() {
        Id = v.Id,
        Street = v.Street,
        City = v.City,
        Region = v.Region,
        ZipCode = v.ZipCode,
        Country = v.Country,
    });
    public AddressView Create(Address o) => new AddressView() {
        Id = o.Id,
        Street = o.Street,
        City = o.City,
        Region = o.Region,
        ZipCode = o.ZipCode,
        Country = o.Country,
        FullName = o.ToString()
    };
}