using ABC.Domain.Party;
using ABC.Facade.Party;

namespace ABC.Pages.Party;

public class AddressesPage : PagedPage<AddressView, Address, IAddressRepo> {
    public AddressesPage(IAddressRepo r) : base(r) { }
    protected override Address toObject(AddressView? item) => new AddressViewFactory().Create(item);
    protected override AddressView toView(Address? entity) => new AddressViewFactory().Create(entity);
}