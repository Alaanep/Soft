using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Facade.Party;

public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData>
{
    protected override Address toEntity(AddressData d) => new(d);
}